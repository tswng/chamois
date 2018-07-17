using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chamois.uitest
{
    public partial class frmSub : Form
    {
        public frmSub()
        {
            InitializeComponent();
        }

        string path = Path.GetDirectoryName(Application.ExecutablePath) + @"\config.xml"; // Path for storing and reading XML

        private void frmSub_Load(object sender, EventArgs e)
        {
            fn_cboConnectionsFill();
        }

        // Prepare and fill combobox cboConnections with saved connections from XML file
        private void fn_cboConnectionsFill()
        {
            cboConnectionList.DataSource = null;
            cboConnectionList.Items.Clear();
            cboConnectionList.DataSource = connItem.fn_getSavedConnections(path);
            cboConnectionList.DisplayMember = "connName";
            cboConnectionList.ValueMember = "connName";
        }

        private void btnExecuteSQL_Click(object sender, EventArgs e)
        {
            // Build connection string
            string connName = cboConnectionList.SelectedValue.ToString();
            var connObject = connItem.fn_getConnectionByName(connName, path);

            if (connObject.dbDriver == "pgsql")
            {
                string connString = String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};",
                        connObject.Hostname, connObject.Port, connObject.Username, connObject.Password, connObject.Database);
                NpgsqlConnection pgsqlConnection = new NpgsqlConnection(connString);
                

                string sql = txtQueryCmd.Text;

                try
                {
                    pgsqlConnection.Open();

                    NpgsqlCommand pgsqlCmd = new NpgsqlCommand(sql, pgsqlConnection);
                    pgsqlCmd.CommandType = CommandType.Text;

                    NpgsqlDataReader dr = pgsqlCmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);

                    dgvResult.DataSource = dt;

                    pgsqlConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

        }
    }
}
