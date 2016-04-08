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
    public partial class frmOperator : Form
    {

        List<ComboBox> dataInputs = new List<ComboBox>();

        public frmOperator()
        {
            InitializeComponent();
        }

        private void frmOperator_Load(object sender, EventArgs e)
        {
            dataInputs.Add(argComboBox1); dataInputs.Add(argComboBox2); dataInputs.Add(argComboBox3);
            dataInputs.Add(argComboBox4); dataInputs.Add(argComboBox5); dataInputs.Add(argComboBox6);

            operatorComboBox.Items.Add("FFT");
            operatorComboBox.Items.Add("Low Pass Filter");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

       
    }
}
