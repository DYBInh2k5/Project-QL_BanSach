using QLBanSach_DAL;
using QLBanSach_DTO;
using System;
using System.Windows.Forms;

namespace QLBanSach_GUI.Forms
{
    public partial class FrmNhanVienEdit : Form
    {
        private readonly NhanVienDAL dal = new NhanVienDAL();
        private readonly bool isEdit;
        private NhanVienDTO current;

        public FrmNhanVienEdit()
        {
            InitializeComponent();
            isEdit = false;
            this.Text = "Thêm nhân viên";
            txtMaNV.ReadOnly = true; // will be generated
        }

        public FrmNhanVienEdit(NhanVienDTO nv) : this()
        {
            isEdit = true;
            current = nv;
            this.Text = "Sửa nhân viên";
            LoadDataToForm(nv);
            txtMaNV.ReadOnly = true;
            txtTaiKhoan.ReadOnly = false;
            // PlaceholderText not supported on .NET Framework WinForms TextBox:
            // Instead leave password empty and you can show a tooltip or label indicating "(Để trống nếu không đổi)".
            // Example: show a small label next to the textbox or use ToolTip.
            // If you have a Label named lblMatKhauHint, you could set it here:
            // lblMatKhauHint.Text = "(Để trống nếu không đổi)";
        }

        private void LoadDataToForm(NhanVienDTO nv)
        {
            txtMaNV.Text = nv.MaNV;
            txtHoTen.Text = nv.HoTen;
            txtTaiKhoan.Text = nv.TaiKhoan;
            // Do not pre-fill password
            cmbVaiTro.Text = nv.VaiTro ?? "Nhân viên";
            txtDienThoai.Text = nv.DienThoai;
            txtEmail.Text = nv.Email;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validation
            string hoTen = txtHoTen.Text.Trim();
            string taiKhoan = txtTaiKhoan.Text.Trim();
            string matKhau = txtMatKhau.Text; // may be empty on edit
            string dienThoai = txtDienThoai.Text.Trim();
            string email = txtEmail.Text.Trim();
            string vaiTro = string.IsNullOrEmpty(cmbVaiTro.Text) ? "Nhân viên" : cmbVaiTro.Text;

            if (string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Họ tên không được để trống.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(taiKhoan))
            {
                MessageBox.Show("Tài khoản không được để trống.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Add
            if (!isEdit)
            {
                // check username exists
                if (dal.KiemTraTonTai(taiKhoan))
                {
                    MessageBox.Show("Tài khoản đã tồn tại. Chọn tên khác.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(matKhau))
                {
                    MessageBox.Show("Mật khẩu không được để trống khi thêm mới.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool ok = dal.DangKyTaiKhoan(hoTen, taiKhoan, matKhau, dienThoai, email);
                if (ok)
                {
                    MessageBox.Show("Thêm nhân viên thành công.", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;
                }
                else
                {
                    MessageBox.Show("Thêm không thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                // Edit
                if (current == null) return;
                // nếu đổi tài khoản, kiểm tra tồn tại ngoại trừ chính nó
                if (dal.KiemTraTonTaiNgoaiMa(taiKhoan, current.MaNV))
                {
                    MessageBox.Show("Tài khoản đã tồn tại cho nhân viên khác.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                current.HoTen = hoTen;
                current.TaiKhoan = taiKhoan;
                current.DienThoai = dienThoai;
                current.Email = email;
                current.VaiTro = vaiTro;

                bool updatePassword = !string.IsNullOrEmpty(matKhau);
                if (updatePassword) current.MatKhau = matKhau;

                bool ok = dal.UpdateNhanVien(current, updatePassword);
                if (ok)
                {
                    MessageBox.Show("Cập nhật nhân viên thành công.", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;
                }
                else
                {
                    MessageBox.Show("Cập nhật không thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
    }
}
