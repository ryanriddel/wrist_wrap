using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

using System.IO.Ports;
using System.Diagnostics;

namespace wrapdoc
{


    public partial class frmSerialConnection : DockContent
    {

        public DataRecord _dataRecord;
        frmMain _parentForm;
        byte _numberOfInputChannels = 1;

        bool _serialInitialized = false;


        double startTime;

        public frmSerialConnection(frmMain parentForm)
        {
            InitializeComponent();
            _parentForm = parentForm;

            _dataRecord = new DataRecord("Serial");
            _parentForm.dataRecordDictionary.Add(_dataRecord._name, _dataRecord);
           
        }

        private void frmSerialConnection_Load(object sender, EventArgs e)
        {
            Invalidate();
            Update();
            this.Show();

            string[] portNames=SerialPort.GetPortNames();
            for (int i = 0; i < portNames.Length; i++) serialPortComboBox.Items.Add(portNames[i]);
            
        }

        public bool connect(String portName, UInt32 baudRate)
        {
            serialPort.BaudRate = (int) baudRate;
            serialPort.PortName = portName;
            serialPort.StopBits = StopBits.One;
            try
            {
                serialPort.Open();
                serialPort.DtrEnable = true;
                serialPort.RtsEnable = true;

                serialPortComboBox.Text = serialPort.PortName;
                if (_dataRecord == null)
                {
                    _dataRecord = new DataRecord(serialPort.PortName);
                    _parentForm.dataRecordDictionary.Add(_dataRecord._name, _dataRecord);

                    establishConnection();
                    serialHandler.RunWorkerAsync();
                    
                }
                
            }
            catch(Exception e)
            {
                serialConnectTextBox.Text = e.Message;
                return false;
            }
           // Hide();
            return true;
        }

        public event EventHandler serialReadEvent;
        

        public delegate void serialReadEventHandler(byte[] data);

        public event serialReadEventHandler serialDataReceived;

        void establishConnection()
        {
            serialPort.Write("INIT");
        }

        double parseTimestamp(byte[] data)
        {
            return data[3] << 24 + data[4] << 16 + data[5] << 8 + data[6];
        }

        DataPoint parseDataPacket(byte[] data)
        {
            double timestamp = parseTimestamp(data); ;
            
            DataPoint newDataPoint = new DataPoint(timestamp);

            for (int i = 7; i<_numberOfInputChannels; i++)
            {
                UInt16 value = (UInt16) (((UInt16)data[i]) << 12 + data[i + 1]);
                byte channel = (byte) (data[i] >> 4);

                newDataPoint.setData(value, channel);
                Debug.WriteLine("Data point : " + value + ", " + channel);
            }

            return newDataPoint;
        }

        
        //start this off at the initialization value.
        //we'll define data packet sizes once the uC tells
        //us how many channels we're using.
        byte configPacketSizeBytes = 10; //in bytes
        byte dataPacketSizeBytes = 9;
        
        private void serialHandler_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (!_serialInitialized)
                {
                    if (serialPort.BytesToRead >= configPacketSizeBytes)
                    {
                        //read the config message
                        byte[] data = new byte[configPacketSizeBytes];
                        serialPort.Read(data, 0, configPacketSizeBytes);

                        //this serves to align packets, which is a problem
                        if (data[0] != 33 || data[1] != 33 || data[2] != 33)
                        {
                            //check for the packet header
                            serialPort.DiscardInBuffer();
                        }
                        else
                        {
                            //parse config message
                            _numberOfInputChannels = data[3];
                            dataPacketSizeBytes = (byte) (3 + 4 + _numberOfInputChannels * 2); //header + timestamp + data
                            //respond
                            
                            serialPort.Write("READY");
                            Debug.WriteLine("READY FOR DATA");
                            _serialInitialized = true;
                            System.Threading.Thread.Sleep(1000);
                        }

                    }
                    else
                    {
                        serialPort.Write("INIT");
                        System.Threading.Thread.Sleep(1000);
                    }
                }
                else
                {
                    if (serialPort.BytesToRead >= dataPacketSizeBytes)
                    {
                         //read the data message

                        byte[] data = new byte[dataPacketSizeBytes];
                        serialPort.Read(data, 0, dataPacketSizeBytes);

                        //this serves to align packets, which is a problem
                        if (data[0] != 33 || data[1] != 33 || data[2] != 33)
                        {
                            //check for the packet header
                            serialPort.DiscardInBuffer();
                        }
                        else
                        {
                            //This section parses incoming data
                            Debug.Write("DATA: ");
                            StringBuilder thing = new StringBuilder();
                            for (int i = 0; i < dataPacketSizeBytes; i++)
                            {
                                Debug.Write(" " + data[i]);
                                thing.Append(data[i] + " ");
                            }

                            Debug.WriteLine(" ");

                            _dataRecord.addDataPoint(parseDataPacket(data));
                            this.Invoke(new MethodInvoker(delegate { this.serialConnectTextBox.Text = thing.ToString(); }));
                        }
                    }


                }
            }
        }

        private void btnSendSerialMessage_Click(object sender, EventArgs e)
        {
            if (txtSerialOutput.Text != "")
            {
                try
                {
                    serialPort.Write(txtSerialOutput.Text);

                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
                finally
                {
                    txtSerialOutput.Text = "";
                }
            }
        }

    }
}
