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
    public partial class frmBase : Form
    {
        public frmBase()
        {
            InitializeComponent();
        }

        
        List<frmSub> SubForms = new List<frmSub>();

        private void button1_Click(object sender, EventArgs e)
        {
            var newConn = new frmDialog();
            frmSub f = new frmSub();
            f = newConn.fn_openDialog(SubForms);
            if (f != null)
            {
                fn_addSubToStack(f);
                fn_setActiveForm(f.Text);
            }
        }


        private void fn_addSubToStack(frmSub f)
        {
            f.TopLevel = false;
            f.TopMost = false;

            pnlSub.Controls.Add(f);

            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;

            SubForms.Add(f);
            cboActiveConns.Items.Add(f.Text);
            cboActiveConns.SelectedItem = f.Text;
        }

        private void fn_setActiveForm(string frmName)
        {
            foreach (var item in SubForms)
            {
                if (item.Text == frmName)
                    item.Show();
                else
                    item.Hide();
            }
        }

        private void cboActiveConns_SelectedIndexChanged(object sender, EventArgs e)
        {
            fn_setActiveForm(cboActiveConns.SelectedItem.ToString());
        }

        private void connectionManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmConnectionManager();
            f.ShowDialog();
        }
    }
}
