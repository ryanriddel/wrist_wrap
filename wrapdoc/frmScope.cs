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
        double _trailingTimeMilliseconds = 1;

        Size initialSize;

        bool _blPlottingEnabled = true;
        
        public frmScope(frmMain parent)
        {
            _parent = parent;
            InitializeComponent();
        }


        private void zedGraphControl1_Load(object sender, EventArgs e)
        {

        }

        

        private void frmScope_Load(object sender, EventArgs e)
        {
            zedGraphControl1.GraphPane.AddCurve("Data", new ZedGraph.PointPairList(), Color.Red);
            //zedGraphControl1.GraphPane.XAxis.ScaleFormat = "f4";
            //zedGraphControl1.GraphPane.XAxis.ScaleFormat = "HH:mm:ss.fff";
            //zedGraphControl1.GraphPane.XAxis.Type = ZedGraph.AxisType.Date;

            initialSize=this.Size;
            lastInterval = DateTime.Now;

            _trailingTimeMilliseconds = Convert.ToUInt32(updXScale.Value);
            _sampleFrequency = Convert.ToUInt16(updSamplingFrequency.Value);
            zedGraphControl1.GraphPane.XAxis.MinAuto = false;

            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Debug.WriteLine("Plotting Enabled.");
            while (_blPlottingEnabled && !backgroundWorker1.CancellationPending)
            {

                DateTime now = DateTime.Now;
                TimeSpan span = now - lastInterval;

                if (span.TotalMilliseconds >= 1000.0/_sampleFrequency)
                {
                    //NOTE: The microcontroller is going to enforce timestamps

                    iterator++;

                    zedGraphControl1.GraphPane.CurveList[0].AddPoint(iterator*1000/_sampleFrequency, Math.Sin(iterator *2 * Math.PI / _sampleFrequency));
                    
                    zedGraphControl1.GraphPane.XAxis.Min = iterator * 1000 / _sampleFrequency > _trailingTimeMilliseconds ? (iterator) * 1000 / _sampleFrequency - _trailingTimeMilliseconds : 0;
                    zedGraphControl1.GraphPane.XAxis.Max = iterator * 1000 / _sampleFrequency;

                    if (zedGraphControl1.GraphPane.CurveList[0].Points[0].X<zedGraphControl1.GraphPane.XAxis.Min) zedGraphControl1.GraphPane.CurveList[0].Points.RemoveAt(0);

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

        private void frmScope_DockStateChanged(object sender, EventArgs e)
        {

            if (this.FloatPane != null)
            {
                this.FloatPane.FloatWindow.Size = initialSize;
                btnPlotEnabled.Text = "Enable Plotting";
                if (!backgroundWorker1.IsBusy) backgroundWorker1.RunWorkerAsync();
                
            }
        }

        private void frmScope_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.Visible && backgroundWorker1.IsBusy) _blPlottingEnabled = false;

            if (this.Visible ) _blPlottingEnabled=true;
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

        private void btnPlotEnabled_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();

                btnPlotEnabled.Text = "Disable Plotting";
            }
            else
            {
                backgroundWorker1.CancelAsync();

                btnPlotEnabled.Text = "Enable Plotting";
            }
        }

        private void updXScale_ValueChanged(object sender, EventArgs e)
        {
            //trailing time
            _trailingTimeMilliseconds = Convert.ToDouble(updXScale.Value);
        }

        private void updYScale_ValueChanged(object sender, EventArgs e)
        {

        }

        
    }
}
