﻿using System;
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

        string path = Path.GetDirectoryName(Application.ExecutablePath) + @"\config.xml";

        private void frmSub_Load(object sender, EventArgs e)
        {
            fn_cboConnectionsFill();
        }

        private void fn_cboConnectionsFill()
        {
            cboConnectionList.DataSource = null;
            cboConnectionList.Items.Clear();
            cboConnectionList.DataSource = connItem.fn_getSavedConnections(path);
            cboConnectionList.DisplayMember = "connName";
            cboConnectionList.ValueMember = "connName";
        }

        private void cboConnectionList_MouseEnter(object sender, EventArgs e)
        {
            fn_cboConnectionsFill();
        }
    }
}
