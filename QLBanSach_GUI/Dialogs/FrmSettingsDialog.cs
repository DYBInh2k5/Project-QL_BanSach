using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBanSach_GUI.Dialogs
{
    /// <summary>
    /// Application Settings Dialog
    /// </summary>
    public partial class FrmSettingsDialog : Form
    {
        public FrmSettingsDialog()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings()
        {
            // Load from application settings
            try
            {
                // Theme
                string theme = Properties.Settings.Default["Theme"]?.ToString() ?? "Light";
                cbTheme.SelectedItem = theme;

                // Language
                string language = Properties.Settings.Default["Language"]?.ToString() ?? "Vietnamese";
                cbLanguage.SelectedItem = language;

                // Auto-save
                chkAutoSave.Checked = Convert.ToBoolean(Properties.Settings.Default["AutoSave"] ?? false);

                // Auto-save interval
                int interval = Convert.ToInt32(Properties.Settings.Default["AutoSaveInterval"] ?? 5);
                numAutoSaveInterval.Value = interval;

                // Remember login
                chkRememberLogin.Checked = Convert.ToBoolean(Properties.Settings.Default["RememberLogin"] ?? false);

                // Show notifications
                chkNotifications.Checked = Convert.ToBoolean(Properties.Settings.Default["ShowNotifications"] ?? true);

                // Database connection
                string dbServer = Properties.Settings.Default["DBServer"]?.ToString() ?? "";
                txtDBServer.Text = dbServer;

                string dbName = Properties.Settings.Default["DBName"]?.ToString() ?? "";
                txtDBName.Text = dbName;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải cài đặt: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkAutoSave_CheckedChanged(object sender, EventArgs e)
        {
            numAutoSaveInterval.Enabled = chkAutoSave.Checked;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                var r = MessageBox.Show("Bạn có chắc muốn đặt lại tất cả cài đặt?", "Xác nhận", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {
                    Properties.Settings.Default.Reset();
                    LoadSettings();
                    MessageBox.Show("Đặt lại cài đặt thành công!", "Hoàn tất", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                SaveSettings();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu cài đặt: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveSettings()
        {
            Properties.Settings.Default["Theme"] = cbTheme.SelectedItem?.ToString() ?? "Light";
            Properties.Settings.Default["Language"] = cbLanguage.SelectedItem?.ToString() ?? "Vietnamese";
            Properties.Settings.Default["AutoSave"] = chkAutoSave.Checked;
            Properties.Settings.Default["AutoSaveInterval"] = (int)numAutoSaveInterval.Value;
            Properties.Settings.Default["RememberLogin"] = chkRememberLogin.Checked;
            Properties.Settings.Default["ShowNotifications"] = chkNotifications.Checked;
            Properties.Settings.Default["DBServer"] = txtDBServer.Text;
            Properties.Settings.Default["DBName"] = txtDBName.Text;
            Properties.Settings.Default.Save();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}