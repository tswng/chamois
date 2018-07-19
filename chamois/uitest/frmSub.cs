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


        string[] purpleWords = new string[] { "select", "from", "where" };
        string[] redWords = new string[] { "delete", "remove" };
        string[] greenWords = new string[] { "insert", "into", "update" };

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
                

                string sql = txtQuery.Text;

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
                    txtMessage.Text = "";
                    txtMessage.Text = ex.ToString();
                }
            }

        }

        private void btnClearText_Click(object sender, EventArgs e)
        {
            txtQuery.Text = "";
        }


        private void CheckKeyword(string[] words, Color color, int startIndex)
        {
            foreach (var word in words)
            {
                if (this.txtQuery.Text.ToLower().Contains(word))
                {
                    int index = -1;
                    int selectStart = this.txtQuery.SelectionStart;



                    while ((index = this.txtQuery.Text.IndexOf(word, (index + 1))) != -1)
                    {
                        this.txtQuery.Select((index + startIndex), word.Length);
                        this.txtQuery.SelectionColor = color;
                        this.txtQuery.SelectedText = this.txtQuery.SelectedText.ToUpper();
                        this.txtQuery.Select(selectStart, 0);
                        this.txtQuery.SelectionColor = Color.Black;
                        this.txtQuery.ForeColor = Color.Black;
                    }
                }
            }




        }

        private void txtQuery_TextChanged(object sender, EventArgs e)
        {
            this.CheckKeyword(purpleWords, Color.Purple, 0);
            this.CheckKeyword(greenWords, Color.Green, 0);
            this.CheckKeyword(redWords, Color.Red, 0);
        }
    }
}
