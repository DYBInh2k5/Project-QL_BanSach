namespace QLBanSach_GUI.Dialogs
{
    partial class FrmSettingsDialog
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tcSettings = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.tabDatabase = new System.Windows.Forms.TabPage();
            this.cbTheme = new System.Windows.Forms.ComboBox();
            this.cbLanguage = new System.Windows.Forms.ComboBox();
            this.chkAutoSave = new System.Windows.Forms.CheckBox();
            this.chkRememberLogin = new System.Windows.Forms.CheckBox();
            this.chkNotifications = new System.Windows.Forms.CheckBox();
            this.numAutoSaveInterval = new System.Windows.Forms.NumericUpDown();
            this.txtDBServer = new System.Windows.Forms.TextBox();
            this.txtDBName = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblTheme = new System.Windows.Forms.Label();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.lblAutoSave = new System.Windows.Forms.Label();
            this.lblDBServer = new System.Windows.Forms.Label();
            this.lblDBName = new System.Windows.Forms.Label();
            this.tcSettings.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tabDatabase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAutoSaveInterval)).BeginInit();
            this.SuspendLayout();

            // tcSettings
            this.tcSettings.Controls.Add(this.tabGeneral);
            this.tcSettings.Controls.Add(this.tabDatabase);
            this.tcSettings.Location = new System.Drawing.Point(12, 12);
            this.tcSettings.Name = "tcSettings";
            this.tcSettings.SelectedIndex = 0;
            this.tcSettings.Size = new System.Drawing.Size(460, 280);
            this.tcSettings.TabIndex = 0;

            // tabGeneral
            this.tabGeneral.Controls.Add(this.lblTheme);
            this.tabGeneral.Controls.Add(this.cbTheme);
            this.tabGeneral.Controls.Add(this.lblLanguage);
            this.tabGeneral.Controls.Add(this.cbLanguage);
            this.tabGeneral.Controls.Add(this.chkAutoSave);
            this.tabGeneral.Controls.Add(this.lblAutoSave);
            this.tabGeneral.Controls.Add(this.numAutoSaveInterval);
            this.tabGeneral.Controls.Add(this.chkRememberLogin);
            this.tabGeneral.Controls.Add(this.chkNotifications);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(452, 254);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "Chung";
            this.tabGeneral.UseVisualStyleBackColor = true;

            // tabDatabase
            this.tabDatabase.Controls.Add(this.lblDBServer);
            this.tabDatabase.Controls.Add(this.txtDBServer);
            this.tabDatabase.Controls.Add(this.lblDBName);
            this.tabDatabase.Controls.Add(this.txtDBName);
            this.tabDatabase.Location = new System.Drawing.Point(4, 22);
            this.tabDatabase.Name = "tabDatabase";
            this.tabDatabase.Padding = new System.Windows.Forms.Padding(3);
            this.tabDatabase.Size = new System.Drawing.Size(452, 254);
            this.tabDatabase.TabIndex = 1;
            this.tabDatabase.Text = "Cơ sở dữ liệu";
            this.tabDatabase.UseVisualStyleBackColor = true;

            // lblTheme
            this.lblTheme.AutoSize = true;
            this.lblTheme.Location = new System.Drawing.Point(10, 15);
            this.lblTheme.Name = "lblTheme";
            this.lblTheme.Size = new System.Drawing.Size(35, 13);
            this.lblTheme.TabIndex = 0;
            this.lblTheme.Text = "Giao diện:";

            // cbTheme
            this.cbTheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTheme.FormattingEnabled = true;
            this.cbTheme.Items.AddRange(new object[] { "Light", "Dark" });
            this.cbTheme.Location = new System.Drawing.Point(100, 12);
            this.cbTheme.Name = "cbTheme";
            this.cbTheme.Size = new System.Drawing.Size(150, 21);
            this.cbTheme.TabIndex = 1;

            // lblLanguage
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Location = new System.Drawing.Point(10, 45);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(33, 13);
            this.lblLanguage.TabIndex = 2;
            this.lblLanguage.Text = "Ngôn ngữ:";

            // cbLanguage
            this.cbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLanguage.FormattingEnabled = true;
            this.cbLanguage.Items.AddRange(new object[] { "Vietnamese", "English" });
            this.cbLanguage.Location = new System.Drawing.Point(100, 42);
            this.cbLanguage.Name = "cbLanguage";
            this.cbLanguage.Size = new System.Drawing.Size(150, 21);
            this.cbLanguage.TabIndex = 3;

            // chkAutoSave
            this.chkAutoSave.AutoSize = true;
            this.chkAutoSave.Location = new System.Drawing.Point(13, 75);
            this.chkAutoSave.Name = "chkAutoSave";
            this.chkAutoSave.Size = new System.Drawing.Size(92, 17);
            this.chkAutoSave.TabIndex = 4;
            this.chkAutoSave.Text = "Tự động lưu";
            this.chkAutoSave.UseVisualStyleBackColor = true;
            this.chkAutoSave.CheckedChanged += new System.EventHandler(this.chkAutoSave_CheckedChanged);

            // lblAutoSave
            this.lblAutoSave.AutoSize = true;
            this.lblAutoSave.Location = new System.Drawing.Point(25, 105);
            this.lblAutoSave.Name = "lblAutoSave";
            this.lblAutoSave.Size = new System.Drawing.Size(72, 13);
            this.lblAutoSave.TabIndex = 5;
            this.lblAutoSave.Text = "Khoảng cách (phút):";

            // numAutoSaveInterval
            this.numAutoSaveInterval.Enabled = false;
            this.numAutoSaveInterval.Location = new System.Drawing.Point(100, 102);
            this.numAutoSaveInterval.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numAutoSaveInterval.Name = "numAutoSaveInterval";
            this.numAutoSaveInterval.Size = new System.Drawing.Size(80, 20);
            this.numAutoSaveInterval.TabIndex = 6;
            this.numAutoSaveInterval.Value = new decimal(new int[] { 5, 0, 0, 0 });

            // chkRememberLogin
            this.chkRememberLogin.AutoSize = true;
            this.chkRememberLogin.Location = new System.Drawing.Point(13, 135);
            this.chkRememberLogin.Name = "chkRememberLogin";
            this.chkRememberLogin.Size = new System.Drawing.Size(105, 17);
            this.chkRememberLogin.TabIndex = 7;
            this.chkRememberLogin.Text = "Ghi nhớ đăng nhập";
            this.chkRememberLogin.UseVisualStyleBackColor = true;

            // chkNotifications
            this.chkNotifications.AutoSize = true;
            this.chkNotifications.Location = new System.Drawing.Point(13, 160);
            this.chkNotifications.Name = "chkNotifications";
            this.chkNotifications.Size = new System.Drawing.Size(107, 17);
            this.chkNotifications.TabIndex = 8;
            this.chkNotifications.Text = "Hiển thị thông báo";
            this.chkNotifications.UseVisualStyleBackColor = true;

            // lblDBServer
            this.lblDBServer.AutoSize = true;
            this.lblDBServer.Location = new System.Drawing.Point(10, 15);
            this.lblDBServer.Name = "lblDBServer";
            this.lblDBServer.Size = new System.Drawing.Size(50, 13);
            this.lblDBServer.TabIndex = 0;
            this.lblDBServer.Text = "Server:";

            // txtDBServer
            this.txtDBServer.Location = new System.Drawing.Point(100, 12);
            this.txtDBServer.Name = "txtDBServer";
            this.txtDBServer.Size = new System.Drawing.Size(200, 20);
            this.txtDBServer.TabIndex = 1;

            // lblDBName
            this.lblDBName.AutoSize = true;
            this.lblDBName.Location = new System.Drawing.Point(10, 45);
            this.lblDBName.Name = "lblDBName";
            this.lblDBName.Size = new System.Drawing.Size(80, 13);
            this.lblDBName.TabIndex = 2;
            this.lblDBName.Text = "Tên cơ sở dữ liệu:";

            // txtDBName
            this.txtDBName.Location = new System.Drawing.Point(100, 42);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(200, 20);
            this.txtDBName.TabIndex = 3;

            // btnReset
            this.btnReset.Location = new System.Drawing.Point(12, 298);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 32);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "Đặt Lại";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);

            // btnOK
            this.btnOK.BackColor = System.Drawing.Color.Green;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(318, 298);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 32);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);

            // btnCancel
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(398, 298);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 32);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // FrmSettingsDialog
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(484, 342);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tcSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSettingsDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cài đặt";
            this.tcSettings.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            this.tabDatabase.ResumeLayout(false);
            this.tabDatabase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAutoSaveInterval)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl tcSettings;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabDatabase;
        private System.Windows.Forms.ComboBox cbTheme;
        private System.Windows.Forms.ComboBox cbLanguage;
        private System.Windows.Forms.CheckBox chkAutoSave;
        private System.Windows.Forms.CheckBox chkRememberLogin;
        private System.Windows.Forms.CheckBox chkNotifications;
        private System.Windows.Forms.NumericUpDown numAutoSaveInterval;
        private System.Windows.Forms.TextBox txtDBServer;
        private System.Windows.Forms.TextBox txtDBName;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblTheme;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.Label lblAutoSave;
        private System.Windows.Forms.Label lblDBServer;
        private System.Windows.Forms.Label lblDBName;
    }
}