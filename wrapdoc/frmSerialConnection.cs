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

            try
            {
                serialPort.Open();
                serialPort.DtrEnable = true;
                serialPort.RtsEnable = true;

                if (_dataRecord == null)
                {
                    _dataRecord = new DataRecord(serialPort.PortName);
                    _parentForm.dataRecordDictionary.Add(_dataRecord._name, _dataRecord);

                    Debug.WriteLine("PORT INIT SUCCESS");

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

        bool establishConnection()
        {
            //send a packet that instructs the microcontroller to start
            //and requests a special packet that contains the start time
            //the number of channels, and other config data

           
            serialPort.Write("INIT");
            
            return false;
        }

        double parseTimestamp(byte[] data)
        {
            return data[0] << 24 + data[1] << 16 + data[2] << 8 + data[3];
        }

        DataPoint parseSerialPacket(byte[] data)
        {
            double timestamp = parseTimestamp(data); ;
            
            DataPoint newDataPoint = new DataPoint(timestamp);

            for (int i = 0; i<_numberOfInputChannels; i++)
            {
                newDataPoint.setData((UInt16) ((data[4 + 2 * i] << 4) * 0x0F + data[5 + 2 * i]), (byte) ((data[4 + 2 * i] >> 4) & 0x0F));
            }

            return newDataPoint;
        }

        
        //start this off at the initialization value.
        //we'll define data packet sizes once the uC tells
        //us how many channels we're using.
        byte configPacketSizeBytes = 10; //in bytes
        byte dataPacketSizeBytes = 2;
        
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
                            //uC sent back ready message
                            //parse it

                            //respond
                            serialPort.Write("READY");
                            Debug.WriteLine("READY FOR DATA");
                            _serialInitialized = true;
                        }

                    }
                    else
                    {

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
                        //    serialPort.DiscardInBuffer();
                        }
                        Debug.Write("DATA: ");
                        for (int i = 0; i < dataPacketSizeBytes; i++)
                        {
                            Debug.Write(" " + data[i]);
                            //thing.Append(data[i] + " ");
                        }

                        Debug.WriteLine(" ");
                    }


                }
            }
        }

    }
}
