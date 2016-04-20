using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wrapdoc
{
    public partial class frmSignalGenerator : Form
    {
        static int _iSignalNumber=0;

        UInt32 iteratorVariable=0;

        bool _blIsEnabled;
        DataRecord _dataRecord;
        frmMain _parentForm;

        double _dFrequency;
        string _sSignalType;
        double _dAmplitude;

        public frmSignalGenerator(frmMain parentForm)
        {
            InitializeComponent();
            _blIsEnabled = false;
            _parentForm = parentForm;
            timer1.Interval = 10;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!_blIsEnabled)
            {
                if (double.TryParse(txtFrequency.Text, out _dFrequency) && double.TryParse(txtAmplitude.Text, out _dAmplitude))
                {
                    _dFrequency = Convert.ToDouble(txtFrequency.Text);
                    _sSignalType = cboSignalType.Text;
                    
                    _dataRecord.clearRecord();
                    if (_dataRecord == null)
                    {
                        _iSignalNumber++;
                        _dataRecord = new DataRecord(_sSignalType + " " + _dFrequency.ToString() + "Hz " + _iSignalNumber);
                        _parentForm.dataRecordDictionary.Add(_dataRecord._name, _dataRecord);
                    }
                }
                else
                {
                    return;
                }

                timer1.Enabled = true;
                _blIsEnabled = true;
            }
            else
            {
                timer1.Enabled = false;
                _blIsEnabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_sSignalType == "Sinusoidal")
            {
               //_dataRecord.addPointPair(new ZedGraph.PointPair(DataRecord.getXDateNow(), _dAmplitude*Math.Sin(2*Math.PI*iteratorVariable*timer1.Interval/(_dFrequency*1000))));
               iteratorVariable++;
            }
            
            if (iteratorVariable == UInt32.MaxValue) iteratorVariable = 0;
        }

        private void frmSignalGenerator_Load(object sender, EventArgs e)
        {

        }
    };
}
