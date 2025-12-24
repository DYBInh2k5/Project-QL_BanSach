using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBanSach_GUI.Dialogs
{
    /// <summary>
    /// About Application Dialog
    /// </summary>
    public partial class FrmAboutDialog : Form
    {
        public FrmAboutDialog()
        {
            InitializeComponent();
        }

        private void FrmAboutDialog_Load(object sender, EventArgs e)
        {
            LoadAboutInfo();
        }

        private void LoadAboutInfo()
        {
            try
            {
                // Get assembly information
                Assembly assembly = Assembly.GetExecutingAssembly();
                Version version = assembly.GetName().Version;

                // Set application name
                if (this.lblAppName != null)
                    this.lblAppName.Text = "Hệ Thống Quản Lý Bán Sách";
                
                // Set version
                if (this.lblVersion != null)
                    this.lblVersion.Text = string.Format("Phiên bản: {0}.{1}.{2}", 
                        version.Major, version.Minor, version.Build);
                
                // Set company
                if (this.lblCompany != null)
                    this.lblCompany.Text = "Công ty: Thư viên Võ Duy Bình";
                
                // Set copyright
                if (this.lblCopyright != null)
                    this.lblCopyright.Text = string.Format("Bản quyền: © {0} - Tất cả các quyền được bảo lưu", 
                        DateTime.Now.Year);

                // Set about text
                if (this.rtbAboutText != null)
                {
                    StringBuilder aboutText = new StringBuilder();
                    aboutText.AppendLine("Hệ Thống Quản Lý Bán Sách");
                    aboutText.AppendLine();
                    aboutText.AppendLine("Tính năng chính:");
                    aboutText.AppendLine("• Quản lý tài khoản nhân viên");
                    aboutText.AppendLine("• Quản lý sách và hàng hóa");
                    aboutText.AppendLine("• Bán hàng (POS)");
                    aboutText.AppendLine("• Quản lý hóa đơn");
                    aboutText.AppendLine("• Thống kê doanh thu");
                    aboutText.AppendLine("• Quản lý khách hàng");
                    aboutText.AppendLine("• Quản lý nhập kho");
                    aboutText.AppendLine("• Quản lý khuyến mãi");
                    aboutText.AppendLine();
                    aboutText.AppendLine("Công nghệ:");
                    aboutText.AppendLine("• C# .NET Framework 4.7.2");
                    aboutText.AppendLine("• SQL Server");
                    aboutText.AppendLine("• Guna2 UI Framework");
                    aboutText.AppendLine();
                    aboutText.AppendLine("Liên hệ hỗ trợ:");
                    aboutText.AppendLine("Email: support@example.com");
                    aboutText.AppendLine("Điện thoại: (84) 123-456-789");
                    
                    this.rtbAboutText.Text = aboutText.ToString();
                    this.rtbAboutText.SelectionStart = 0;
                    this.rtbAboutText.SelectionLength = 0;
                }

                // Set icon if available
                if (this.pictureBox1 != null)
                {
                    try
                    {
                        // Try to load application icon
                        this.pictureBox1.Image = SystemIcons.Application.ToBitmap();
                    }
                    catch
                    {
                        // If icon loading fails, just use the default background color
                        this.pictureBox1.BackColor = Color.FromArgb(59, 130, 246);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}