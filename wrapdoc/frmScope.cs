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
using System.Diagnostics;

namespace wrapdoc
{
    public partial class frmScope : DockContent
    {

        Random _numberGenerator = new Random();
        frmMain _parent;
        double iterator = 0;
        UInt16 samples = 0;
        DateTime lastInterval;

        UInt16 _sampleFrequency = 200;
        
        public frmScope(frmMain parent)
        {
            _parent = parent;
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void zedGraphControl1_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void frmScope_Load(object sender, EventArgs e)
        {
            zedGraphControl1.GraphPane.AddCurve("Data", new ZedGraph.PointPairList(), Color.Red);
            //zedGraphControl1.GraphPane.XAxis.ScaleFormat = "f4";
            //zedGraphControl1.GraphPane.XAxis.ScaleFormat = "HH:mm:ss.fff";
            //zedGraphControl1.GraphPane.XAxis.Type = ZedGraph.AxisType.Date;

            lastInterval = DateTime.Now;
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!backgroundWorker1.CancellationPending)
            {

                DateTime now = DateTime.Now;
                TimeSpan span = now - lastInterval;

                if (span.TotalMilliseconds >= 1000.0/_sampleFrequency)
                {

                    iterator++;
                    zedGraphControl1.GraphPane.CurveList[0].AddPoint(iterator, Math.Sin(iterator *2 * Math.PI / _sampleFrequency));
                    samples++;

                    zedGraphControl1.GraphPane.XAxis.MinAuto = false;
                    //Debug.WriteLine(iterator-500);
                    zedGraphControl1.GraphPane.XAxis.Min = iterator > 1000 ? iterator - 1000 : 0;
                    zedGraphControl1.GraphPane.XAxis.Max = iterator + 5;

                    if (zedGraphControl1.GraphPane.CurveList[0].Points.Count > 1000) zedGraphControl1.GraphPane.CurveList[0].Points.RemoveAt(0);

                    zedGraphControl1.AxisChange();
                    zedGraphControl1.Invalidate();

                    lastInterval = DateTime.Now;
                }
            }
            
        }

        private void updSamplingFrequency_ValueChanged(object sender, EventArgs e)
        {
            _sampleFrequency = Convert.ToUInt16(updSamplingFrequency.Value);
        }

        private void frmScope_DockChanged(object sender, EventArgs e)
        {
            if (this.Visible && !backgroundWorker1.IsBusy) backgroundWorker1.RunWorkerAsync();
        }

        private void frmScope_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.Visible) backgroundWorker1.CancelAsync();
            if (this.Visible && !backgroundWorker1.IsBusy) backgroundWorker1.RunWorkerAsync();
            
        }

        private void chkAutoScaleX_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoScaleY.Checked == false)
            {
                updYScale.Value = Convert.ToDecimal(zedGraphControl1.GraphPane.YAxis.Max - zedGraphControl1.GraphPane.YAxis.Min) / 8;
                zedGraphControl1.GraphPane.YAxis.MaxAuto = false;
                zedGraphControl1.GraphPane.YAxis.MinAuto = false;

                updYScale.Enabled = true;
            }
            else
            {
                zedGraphControl1.GraphPane.YAxis.MaxAuto = true;
                zedGraphControl1.GraphPane.YAxis.MinAuto = true;
                updYScale.Enabled = false;
            }
        }
    }
}