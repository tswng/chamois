using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chamois.uitest
{
    public partial class frmDialog : Form
    {
        public frmDialog()
        {
            InitializeComponent();
        }

        private void frmDialog_Load(object sender, EventArgs e)
        {

        }

        public frmSub fn_openDialog(List<frmSub> frms)
        {
            if (this.ShowDialog() == DialogResult.OK)
            {
                foreach (var item in frms)
                {
                    if (item.Text == txtConnName.Text)
                    {
                        MessageBox.Show("There is active connection with the same name.");
                        return null;
                    }
                }

                var f = new frmSub();
                f.Text = txtConnName.Text;
                return f;
            }
            else
                return null;
        }
    }
}
