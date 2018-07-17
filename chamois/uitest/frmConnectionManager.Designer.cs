namespace chamois.uitest
{
    partial class frmConnectionManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstConnections = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRemoveConnection = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboDatabaseDriver = new System.Windows.Forms.ComboBox();
            this.txtHostname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkSavePassword = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.txtConnName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveConnction = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstConnections
            // 
            this.lstConnections.FormattingEnabled = true;
            this.lstConnections.Location = new System.Drawing.Point(15, 31);
            this.lstConnections.Name = "lstConnections";
            this.lstConnections.Size = new System.Drawing.Size(240, 342);
            this.lstConnections.TabIndex = 0;
            this.lstConnections.SelectedIndexChanged += new System.EventHandler(this.lstConnections_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRemoveConnection);
            this.groupBox1.Controls.Add(this.lstConnections);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 405);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Saved Connections";
            // 
            // btnRemoveConnection
            // 
            this.btnRemoveConnection.Location = new System.Drawing.Point(15, 376);
            this.btnRemoveConnection.Name = "btnRemoveConnection";
            this.btnRemoveConnection.Size = new System.Drawing.Size(72, 23);
            this.btnRemoveConnection.TabIndex = 14;
            this.btnRemoveConnection.Text = "Remove";
            this.btnRemoveConnection.UseVisualStyleBackColor = true;
            this.btnRemoveConnection.Click += new System.EventHandler(this.btnRemoveConnection_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtDatabase);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtPort);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cboDatabaseDriver);
            this.groupBox2.Controls.Add(this.txtHostname);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(289, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(376, 160);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Server information";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Database:";
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(113, 107);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(222, 20);
            this.txtDatabase.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(78, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Port:";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(113, 81);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(222, 20);
            this.txtPort.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Hostname:";
            // 
            // cboDatabaseDriver
            // 
            this.cboDatabaseDriver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDatabaseDriver.FormattingEnabled = true;
            this.cboDatabaseDriver.Items.AddRange(new object[] {
            "MSSQL",
            "mySQL",
            "postgrSQL"});
            this.cboDatabaseDriver.Location = new System.Drawing.Point(113, 28);
            this.cboDatabaseDriver.Name = "cboDatabaseDriver";
            this.cboDatabaseDriver.Size = new System.Drawing.Size(222, 21);
            this.cboDatabaseDriver.Sorted = true;
            this.cboDatabaseDriver.TabIndex = 2;
            // 
            // txtHostname
            // 
            this.txtHostname.Location = new System.Drawing.Point(113, 55);
            this.txtHostname.Name = "txtHostname";
            this.txtHostname.Size = new System.Drawing.Size(222, 20);
            this.txtHostname.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Database driver:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkSavePassword);
            this.groupBox3.Controls.Add(this.txtPassword);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtUsername);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(289, 178);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(376, 135);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "User information";
            // 
            // chkSavePassword
            // 
            this.chkSavePassword.AutoSize = true;
            this.chkSavePassword.Location = new System.Drawing.Point(113, 82);
            this.chkSavePassword.Name = "chkSavePassword";
            this.chkSavePassword.Size = new System.Drawing.Size(99, 17);
            this.chkSavePassword.TabIndex = 8;
            this.chkSavePassword.Text = "Save password";
            this.chkSavePassword.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(113, 55);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(222, 20);
            this.txtPassword.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(51, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Password:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(113, 28);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(222, 20);
            this.txtUsername.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(49, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Username:";
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(472, 373);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(115, 23);
            this.btnTestConnection.TabIndex = 10;
            this.btnTestConnection.Text = "Test Connection";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // txtConnName
            // 
            this.txtConnName.Location = new System.Drawing.Point(402, 328);
            this.txtConnName.Name = "txtConnName";
            this.txtConnName.Size = new System.Drawing.Size(222, 20);
            this.txtConnName.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(306, 331);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Connection name";
            // 
            // btnSaveConnction
            // 
            this.btnSaveConnction.Location = new System.Drawing.Point(394, 373);
            this.btnSaveConnction.Name = "btnSaveConnction";
            this.btnSaveConnction.Size = new System.Drawing.Size(72, 23);
            this.btnSaveConnction.TabIndex = 11;
            this.btnSaveConnction.Text = "Save";
            this.btnSaveConnction.UseVisualStyleBackColor = true;
            this.btnSaveConnction.Click += new System.EventHandler(this.btnSaveConnction_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(593, 373);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(72, 23);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(316, 373);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(72, 23);
            this.btnNew.TabIndex = 13;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // frmConnectionManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 429);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSaveConnction);
            this.Controls.Add(this.txtConnName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTestConnection);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmConnectionManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.frmConnectionManager_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstConnections;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHostname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkSavePassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.TextBox txtConnName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveConnction;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.ComboBox cboDatabaseDriver;
        private System.Windows.Forms.Button btnRemoveConnection;
    }
}