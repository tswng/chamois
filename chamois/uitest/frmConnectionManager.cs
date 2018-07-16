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
    public partial class frmConnectionManager : Form
    {
        List<connItem> connItems = new List<connItem>();
        string path = Path.GetDirectoryName(Application.ExecutablePath) + @"\config.cfg";


        public frmConnectionManager()
        {
            InitializeComponent();
        }

        private void frmConnectionManager_Load(object sender, EventArgs e)
        {
            fn_loadConfiguration();
        }


        private void fn_loadConfiguration()
        {
            if (File.Exists(path))
            {
                string indata = File.ReadAllText(path);
                if (indata.Contains("%%%"))
                {
                    string[] lines = indata.Split(new string[] { "###" }, StringSplitOptions.None);
                    //MessageBox.Show(lines[0]);
                    if (lines.Count() > 0)
                    {
                        lstConnections.Items.Clear();
                        foreach (var line in lines)
                        {
                            string[] singleConn = line.Split(new string[] { "%%%" }, StringSplitOptions.None);
                            var item = new connItem();
                            item.connName = singleConn[0];
                            item.dbDriver = singleConn[1];
                            item.Hostname = singleConn[2];
                            item.Port = singleConn[3];
                            item.Database = singleConn[4];
                            item.Username = singleConn[5];
                            item.Password = singleConn[6];
                            item.savePassword = singleConn[7];

                            connItems.Add(item);
                            lstConnections.Items.Add(item.connName);
                        }
                    }
                }
            }
        }


        private void fn_saveConfiguration()
        {
            string line = "";
            foreach (var item in connItems)
            {
                line += item.connName + "%%%" + item.dbDriver + "%%%" + item.Hostname + "%%%" + item.Port + "%%%" + item.Database
                     + "%%%" + item.Username + "%%%" + item.Password + "%%%" + item.savePassword + "###";
            }

            line = line.Substring(0, line.Length - 3);
            File.Delete(path);
            File.WriteAllText(path, line);

        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

        private void lstConnections_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstConnections.SelectedIndex > -1)
            {
                string connectionName = lstConnections.SelectedItem.ToString();
                var item = connItems.Where(c => c.connName == connectionName).First();
                if (item != null)
                {
                    txtConnName.Text = item.connName;
                    cboDatabaseDriver.SelectedItem = item.dbDriver;
                    txtDatabase.Text = item.Database;
                    txtHostname.Text = item.Hostname;
                    txtPort.Text = item.Port;
                    txtUsername.Text = item.Username;
                    txtPassword.Text = item.Password;
                    if (item.savePassword == "true")
                        chkSavePassword.Checked = true;
                    else
                        chkSavePassword.Checked = false;
                }
            }
        }

        private void btnSaveConnction_Click(object sender, EventArgs e)
        {
            if (txtConnName.Text == "" || txtDatabase.Text == ""|| txtHostname.Text == "" || txtPort.Text == "")
            {
                MessageBox.Show("Enter Server information.");
                return;
            }

            var itemz = connItems.Where(i => i.connName == txtConnName.Text).ToList();
            if (itemz.Count > 0)
            {
                foreach (var item in itemz)
                {
                    connItems.Remove(item);
                }
            }

            var newItem = new connItem();
            newItem.connName = txtConnName.Text;
            newItem.dbDriver = cboDatabaseDriver.SelectedItem.ToString();
            newItem.Hostname = txtHostname.Text;
            newItem.Port = txtPort.Text;
            newItem.Database = txtDatabase.Text;
            newItem.Username = txtUsername.Text;
            newItem.Password = txtPassword.Text;
            if (chkSavePassword.Checked == true)
                newItem.savePassword = "true";
            else
                newItem.savePassword = "false";

            connItems.Add(newItem);

            fn_saveConfiguration();
            fn_loadConfiguration();

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            cboDatabaseDriver.SelectedIndex = 0;
            txtHostname.Text = "";
            txtPort.Text = "";
            txtDatabase.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            chkSavePassword.Checked = false;
            txtConnName.Text = "";
        }
    }

    public class connItem
    {
        public string connName { get; set; }
        public string dbDriver { get; set; }
        public string Hostname { get; set; }
        public string Port { get; set; }
        public string Database { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string savePassword { get; set; }
    }
}
