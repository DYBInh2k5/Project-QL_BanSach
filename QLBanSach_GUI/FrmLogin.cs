using QLBanSach_BLL;
using QLBanSach_DAL;
using QLBanSach_DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBanSach_GUI
{
    public partial class FrmLogin : Form
    {
        NhanVienBLL bll = new NhanVienBLL();
        public FrmLogin()
        {
            InitializeComponent();
            animateLogin.TargetForm = this;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text.Trim();
            string pass = txtPass.Text.Trim();

            if (user == "" || pass == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!",
                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NhanVienDTO nv = bll.DangNhap(user, pass);

            if (nv != null)
            {
                if (nv.TrangThai == 0)
                {
                    MessageBox.Show("Tài khoản đã bị khóa!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Đăng nhập thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();

                FrmMain frmMain = new FrmMain(nv);
                new QLBanSach_GUI.Dialogs.FrmProfile(nv).ShowDialog();
                frmMain.ShowDialog();

                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!",
                    "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e) { }

        private void pnlBackground_Paint(object sender, PaintEventArgs e) { }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Open the About dialog
        private void button1_Click(object sender, EventArgs e)
        {
            using (var frm = new QLBanSach_GUI.Dialogs.FrmAboutDialog())
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog(this);
            }
        }
    }
}
