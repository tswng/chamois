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


        // XML file location for reading and saving connections
        string path = Path.GetDirectoryName(Application.ExecutablePath) + @"\config.xml";

        private void frmBase_Load(object sender, EventArgs e)
        {
            initTabControl();
        }

        // Opens frmConnectionManager in dialog, menu item
        private void connectionManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmConnectionManager();
            f.ShowDialog();
        }


        // TESTING

        private void initTabControl()
        {
            tabControl1.Padding = new Point(12, 4);

            this.tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;

            tabControl1.Dock = DockStyle.Fill;

            tabControl1.TabPages.Add(new TabPage());
        }

        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            var lastIndex = this.tabControl1.TabCount - 1;
            if (this.tabControl1.GetTabRect(lastIndex).Contains(e.Location))
            {
                // prepare form
                var f = new frmSub();
                f.TopLevel = false;
                f.TopMost = false;
                f.FormBorderStyle = FormBorderStyle.None;
                f.Dock = DockStyle.Fill;

                // prepare tab
                var tab = new TabPage();
                tab.Text = "New query        ";

                // add form to tab
                tab.Controls.Add(f);

                // finally show form
                f.Show();


                this.tabControl1.TabPages.Insert(lastIndex, tab);
                this.tabControl1.SelectedIndex = lastIndex;
            }
            else
            {
                for (var i = 0; i < this.tabControl1.TabPages.Count; i++)
                {
                    var tabRect = this.tabControl1.GetTabRect(i);
                    tabRect.Inflate(-2, -2);
                    var closeImage = Properties.Resources.closetab;
                    var imageRect = new Rectangle(
                        (tabRect.Right - closeImage.Width),
                        tabRect.Top + (tabRect.Height - closeImage.Height) / 2,
                        closeImage.Width,
                        closeImage.Height);
                    if (imageRect.Contains(e.Location))
                    {
                        this.tabControl1.TabPages.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            var tabPage = this.tabControl1.TabPages[e.Index];
            var tabRect = this.tabControl1.GetTabRect(e.Index);
            tabRect.Inflate(-2, -2);
            if (e.Index == this.tabControl1.TabCount - 1)
            {
                var addImage = Properties.Resources.addtab;
                e.Graphics.DrawImage(addImage,
                    tabRect.Left + (tabRect.Width - addImage.Width) / 2,
                    tabRect.Top + (tabRect.Height - addImage.Height) / 2);
            }
            else
            {
                var closeImage = Properties.Resources.closetab;
                e.Graphics.DrawImage(closeImage,
                    (tabRect.Right - closeImage.Width),
                    tabRect.Top + (tabRect.Height - closeImage.Height) / 2);
                TextRenderer.DrawText(e.Graphics, tabPage.Text, tabPage.Font,
                    tabRect, tabPage.ForeColor, TextFormatFlags.Left);
            }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == this.tabControl1.TabCount - 1)
                e.Cancel = true;
        }
    }
}
