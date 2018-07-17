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


        // Custom TabControl class whit integrated close button on main TabPage button
        ExTabControl tabMaster = new ExTabControl();

        // XML file location for reading and saving connections
        string path = Path.GetDirectoryName(Application.ExecutablePath) + @"\config.xml";

        private void frmBase_Load(object sender, EventArgs e)
        {
            // add custom TabControl to panel and set it's dock propety to Fill
            pnlSub.Controls.Add(tabMaster);
            tabMaster.Dock = DockStyle.Fill;
        }

        // Experimental feature, button to put frmSub as tabPage to TabMaster control
        private void button1_Click(object sender, EventArgs e)
        {
            // prepare form
            var f = new frmSub();
            f.TopLevel = false;
            f.TopMost = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;

            // prepare tab
            var tab = new TabPage();
            tab.Text = "Screen        ";            
            tab.BorderStyle = BorderStyle.FixedSingle;

            // add form to tab
            tab.Controls.Add(f);

            // add tab to tabMaster control
            tabMaster.TabPages.Add(tab);

            // finally show form
            f.Show();
        }


        // Opens frmConnectionManager in dialog, menu item
        private void connectionManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmConnectionManager();
            f.ShowDialog();
        }

    }
}
