using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace chamois.uitest
{
    public partial class frmBase : Form
    {
        public frmBase()
        {
            InitializeComponent();
        }

        ExTabControl tabMaster = new ExTabControl();

        string path = Path.GetDirectoryName(Application.ExecutablePath) + @"\config.xml";

        List<frmSub> SubForms = new List<frmSub>();

        private void button1_Click(object sender, EventArgs e)
        {
            var f = new frmSub();
            f.TopLevel = false;
            f.TopMost = false;

            var tab = new TabPage();
            tab.Text = "Screen";
            tab.Controls.Add(f);

            tabMaster.TabPages.Add(tab);

            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;

            f.Show();

            //var newConn = new frmDialog();
            //frmSub f = new frmSub();
            //f = newConn.fn_openDialog(SubForms);
            //if (f != null)
            //{
            //    fn_addSubToStack(f);
            //    fn_setActiveForm(f.Text);
            //}
        }


        // Opens frmConnectionManager in dialog
        private void connectionManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmConnectionManager();
            f.ShowDialog();
        }

        private void frmBase_Load(object sender, EventArgs e)
        {
            
            pnlSub.Controls.Add(tabMaster);
            tabMaster.Dock = DockStyle.Fill;
            tabMaster.ItemSize = new Size(250, 30);
            

        }


    }
}
