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

namespace wrapdoc
{
    public partial class frmInputConfiguration :DockContent
    {
        public frmInputConfiguration()
        {
            InitializeComponent();
        }

        private void frmInputConfiguration_Load(object sender, EventArgs e)
        {
            
        }

        private void frmInputConfiguration_Shown(object sender, EventArgs e)
        {
            
        }

        private void frmInputConfiguration_DockStateChanged(object sender, EventArgs e)
        {
            if(this.FloatPane!=null) this.FloatPane.FloatWindow.Size = new Size(870, 548); 
        }


    }
}
