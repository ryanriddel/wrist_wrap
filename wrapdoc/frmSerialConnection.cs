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
namespace wrapdoc
{
    public partial class frmSerialConnection : DockContent
    {

        public DataRecord _dataRecord;
        frmMain _parentForm;

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

                if (_dataRecord == null)
                {
                    _dataRecord = new DataRecord(serialPort.PortName);
                    _parentForm.dataRecordDictionary.Add(_dataRecord.Name, _dataRecord);
                }
                
            }
            catch(Exception e)
            {
                serialConnectTextBox.Text = e.Message;
                return false;
            }
            Hide();
            return true;
        }
    }
}
