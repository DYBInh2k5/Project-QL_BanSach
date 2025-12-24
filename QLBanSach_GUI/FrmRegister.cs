using QLBanSach_BLL;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QLBanSach_GUI
{
    public partial class FrmRegister : Form
    {
        NhanVienBLL bll = new NhanVienBLL();

        public FrmRegister()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void FrmRegister_Load(object sender, EventArgs e)
        {
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text.Trim();
            string tk = txtTaiKhoan.Text.Trim();
            string mk = txtMatKhau.Text.Trim();
            string xacNhan = txtXacNhanMK.Text.Trim();
            string dt = txtDienThoai.Text.Trim();
            string email = txtEmail.Text.Trim();

            // Basic validation
            if (string.IsNullOrWhiteSpace(hoTen))
            {
                MessageBox.Show("Họ tên không được để trống!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus(); return;
            }
            if (string.IsNullOrWhiteSpace(tk))
            {
                MessageBox.Show("Tài khoản không được để trống!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTaiKhoan.Focus(); return;
            }
            if (string.IsNullOrWhiteSpace(mk))
            {
                MessageBox.Show("Mật khẩu không được để trống!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus(); return;
            }
            if (mk != xacNhan)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtXacNhanMK.Focus(); return;
            }
            if (!string.IsNullOrWhiteSpace(email) && !Regex.IsMatch(email, @"^[A-Za-z0-9._%+\-]+@[A-Za-z0-9.\-]+\.[A-Za-z]{2,}$", RegexOptions.IgnoreCase))
            {
                MessageBox.Show("Email không hợp lệ!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus(); return;
            }
            if (!string.IsNullOrWhiteSpace(dt) && !Regex.IsMatch(dt, @"^\+?\d{8,15}$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDienThoai.Focus(); return;
            }

            try
            {
                // Optional: pre-check duplicate account if BLL/DAL exposes it
                // if (bll.KiemTraTonTai(tk)) { MessageBox.Show("Tài khoản đã tồn tại!"); return; }

                bool ok = bll.DangKyTaiKhoan(hoTen, tk, mk, dt, email);
                if (ok)
                {
                    MessageBox.Show("Đăng ký thành công! Bạn có thể đăng nhập ngay.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    // Make the failure visible to the user
                    MessageBox.Show("Đăng ký không thành công. Vui lòng kiểm tra lại thông tin hoặc thử lại sau.", "Đăng ký thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (System.Data.SqlClient.SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                MessageBox.Show("Tài khoản hoặc email/số điện thoại đã tồn tại.", "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
