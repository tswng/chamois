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
using Npgsql;

namespace chamois.uitest
{
    public partial class frmConnectionManager : Form
    {
        List<connItem> connItems = new List<connItem>(); // List of connItem objects
        string path = Path.GetDirectoryName(Application.ExecutablePath) + @"\config.xml"; // path for storing and reading XML
        
        public frmConnectionManager()
        {
            InitializeComponent();
        }

        // LOAD event of form
        private void frmConnectionManager_Load(object sender, EventArgs e)
        {
            fn_loadConfiguration(); // get all saved connections and populate listbox
            lstConnections.SelectedIndex = -1; // "Unselect" first selected item in listbox
            fn_ResetControls(); // reset controls
        }

        // Load connections from stored XML file using static method of connItem.cs object to list of connItem objects - connItems
        private void fn_loadConfiguration()
        {
            if (File.Exists(path))
            {
                connItems.Clear(); // clear list of connections
                connItems = connItem.fn_getSavedConnections(path); // read connections from XML file and store in list

                var connItemsList = connItems.OrderBy(c => c.connName).ToList(); // create new object just to apply ordering

                // Clear list box
                lstConnections.DataSource = null;
                lstConnections.Items.Clear();

                // Set listbox parametars and bind it to ordered connItemsList list of connItem objects
                lstConnections.DisplayMember = "connName";
                lstConnections.ValueMember = "connName";
                lstConnections.DataSource = connItemsList;
            }
        }

        // Calls public static function in connItem.cs class which saves list of connItem objects to XML file at desired path
        private void fn_saveConfiguration()
        {
            connItem.fn_saveAllConnections(connItems, path);
        }

        // Populate controls on form from list of connItem objects when user selects connection name in listbox
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

        // Reset all controls on form
        private void fn_ResetControls()
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

        #region BUTTONS

        // Saves new or existing connection to XML
        private void btnSaveConnction_Click(object sender, EventArgs e)
        {
            // Just simple validation
            if (txtConnName.Text == "" || txtDatabase.Text == "" || txtHostname.Text == "" || txtPort.Text == "")
            {
                MessageBox.Show("Enter Server information and Connection name.");
                return;
            }

            // search items with same connection name, if any found, delete all
            var itemz = connItems.Where(i => i.connName == txtConnName.Text).ToList();
            if (itemz.Count > 0)
            {
                foreach (var item in itemz)
                {
                    connItems.Remove(item);
                }
            }

            // create new connItem object and populate it with data from controls
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

            connItems.Add(newItem); // add item to main list

            fn_saveConfiguration();  // save to XML
            fn_loadConfiguration(); // read from XML

            lstConnections.SelectedValue = newItem.connName.ToString(); // select manipulated object in list box
        }

        // Remove selected connection from XML
        private void btnRemoveConnection_Click(object sender, EventArgs e)
        {
            if (lstConnections.SelectedIndex > -1)
            {
                string connectionName = lstConnections.SelectedValue.ToString(); // get connection name from list box
                var itemz = connItems.Where(c => c.connName == connectionName).ToList(); // get all saved connections whit the same name

                foreach (var item in itemz)
                {
                    connItems.Remove(item); // delete all connections with the same name
                }

                fn_saveConfiguration(); // save to XML
                fn_loadConfiguration(); // read XML
            }
        }

        // Experimental postgrSQL implementation
        private void btnTestConnection_Click(object sender, EventArgs e)
        {

            if (cboDatabaseDriver.SelectedItem.ToString() == "pgsql")
            {
                string connString = String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};",
                    txtHostname.Text, txtPort.Text, txtUsername.Text, txtPassword.Text, txtDatabase.Text);
                NpgsqlConnection connectionPostgr = new NpgsqlConnection(connString);
                try
                {
                    connectionPostgr.Open();
                    connectionPostgr.Close();
                    MessageBox.Show("Database connection established.");
                }
                catch (Exception)
                {

                    MessageBox.Show("Connection could not be established. Check entered informaton.");
                }
            }


        }

        // Reset controls on form
        private void btnNew_Click(object sender, EventArgs e)
        {
            fn_ResetControls();
        }

        // Exit button closes form
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion


        
    }

}
