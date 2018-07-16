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
        string path = Path.GetDirectoryName(Application.ExecutablePath) + @"\config.xml";


        public frmConnectionManager()
        {
            InitializeComponent();
        }

        private void frmConnectionManager_Load(object sender, EventArgs e)
        {
            fn_loadConfiguration();
            cboDatabaseDriver.SelectedIndex = 0;
        }


        private void fn_loadConfiguration()
        {
            if (File.Exists(path))
            {
                connItems.Clear();
                System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(List<connItem>));
                System.IO.StreamReader file = new System.IO.StreamReader(path);
                connItems = (List<connItem>)reader.Deserialize(file);
                file.Close();

                var connItemsList = connItems.OrderBy(c => c.connName).ToList();

                lstConnections.DataSource = null;
                lstConnections.Items.Clear();

                lstConnections.DisplayMember = "connName";
                lstConnections.ValueMember = "connName";
                lstConnections.DataSource = connItemsList;
            }
        }


        private void fn_saveConfiguration()
        {
            var writer = new System.Xml.Serialization.XmlSerializer(typeof(List<connItem>));
            var wfile = new System.IO.StreamWriter(path);
            writer.Serialize(wfile, connItems);
            wfile.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lstConnections_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstConnections.SelectedIndex > -1)
            {
                string connectionName = lstConnections.SelectedValue.ToString();
                var item = connItems.Where(c => c.connName == connectionName).FirstOrDefault();
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
            if (txtConnName.Text == "" || txtDatabase.Text == "" || txtHostname.Text == "" || txtPort.Text == "")
            {
                MessageBox.Show("Enter Server information and Connection name.");
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

        private void btnRemoveConnection_Click(object sender, EventArgs e)
        {
            if (lstConnections.SelectedIndex > -1)
            {
                string connectionName = lstConnections.SelectedValue.ToString();
                var itemz = connItems.Where(c => c.connName == connectionName).ToList();

                foreach (var item in itemz)
                {
                    connItems.Remove(item);
                }

                fn_saveConfiguration();
                fn_loadConfiguration();
            }
        }
    }

}
