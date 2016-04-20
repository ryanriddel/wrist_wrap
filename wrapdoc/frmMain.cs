﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

namespace wrapdoc
{
    public partial class frmMain : Form
    {
        static bool DEBUG_MODE = true;

        frmSerialConnection serialConnection=null;
        static string DEFAULT_PORT_NAME = "COM3";
        static UInt32 DEFAULT_BAUD_RATE = 500000;
        
        
        frmInputConfiguration inputConfiguration = null;

        public Dictionary<String, DataRecord> dataRecordDictionary;
        
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mainDockPanel.Parent = this;
            mainDockPanel.BringToFront();
            
            inputConfiguration = new frmInputConfiguration();

            serialConnection = new frmSerialConnection(this);

            dataRecordDictionary = new Dictionary<string, DataRecord>();
            serialConnection.Show();

            //try to connect to default serial port
            if(serialConnection.connect(DEFAULT_PORT_NAME, DEFAULT_BAUD_RATE))
            {
                connectionToolStripLabel.Text = "Connected";
                connectionToolStripLabel.ForeColor = Color.Green;
                //inputConfiguration.Show(mainDockPanel, DockState.Document);
                //dataRecordDictionary.Add(serialConnection._dataRecord._name, serialConnection._dataRecord);
            }
            else
            {
                connectionToolStripLabel.Text = "Not Connected";
                connectionToolStripLabel.ForeColor = Color.Red;
                serialConnection.ShowDialog();
            }

            if(DEBUG_MODE)
            {
                //inputConfiguration.Show(mainDockPanel, DockState.Document);
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            serialConnection.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            frmScope newScope = new frmScope(this);
            newScope.Show(mainDockPanel, DockState.Document);
        }


        //Serial Read Code

       
    }
}
