using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using QLBanSach_DTO;

namespace QLBanSach_GUI.Dialogs
{
    public partial class FrmProfile : Form
    {
        private readonly NhanVienDTO _user;
        private readonly string _connStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=QLBanSach;Integrated Security=True";
        private int _maNV;                // số; 0 nếu không parse được
        private string _avatarPath;

        public FrmProfile(NhanVienDTO user)
        {
            _user = user;
            InitializeComponent();
        }

        private void FrmProfile_Load(object sender, EventArgs e)
        {
            BindStatic();
            LoadProfileFromDb();
        }

        private void BindStatic()
        {
            if (_user == null) return;

            lblName.Text = "Họ tên: " + (_user.HoTen ?? "");
            lblRole.Text = "Vai trò: " + (_user.VaiTro ?? "");
            lblUser.Text = "Tài khoản: " + (_user.TaiKhoan ?? "");
            lblEmail.Text = "Email: " + (_user.Email ?? "");
            lblPhone.Text = "Điện thoại: " + (_user.DienThoai ?? "");
            lblCreated.Text = "Ngày tạo: " + (_user.NgayTao != DateTime.MinValue ? _user.NgayTao.ToString("dd/MM/yyyy") : "");
            lblStatus.Text = "Trạng thái: " + (_user.TrangThai == 1 ? "Hoạt động" : "Khóa");
        }

        private void LoadProfileFromDb()
        {
            using (var conn = new SqlConnection(_connStr))
            using (var cmd = new SqlCommand(
                "SELECT TOP 1 MaNV, CCCD, NgaySinh, AvatarPath FROM NhanVien WHERE TaiKhoan=@tk", conn))
            {
                cmd.Parameters.Add("@tk", SqlDbType.NVarChar, 50).Value = _user?.TaiKhoan ?? (object)DBNull.Value;
                conn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        _maNV = SafeToInt(rd["MaNV"]); // không ném FormatException
                        string cccd = rd["CCCD"] as string;
                        lblCCCD.Text = "CCCD: " + (cccd ?? "");

                        if (rd["NgaySinh"] != DBNull.Value)
                        {
                            var ns = Convert.ToDateTime(rd["NgaySinh"]);
                            lblDOB.Text = "Ngày sinh: " + ns.ToString("dd/MM/yyyy");
                        }

                        _avatarPath = rd["AvatarPath"] as string;
                        LoadAvatar(_avatarPath);
                    }
                    else
                    {
                        LoadAvatar(null);
                    }
                }
            }
        }

        private static int SafeToInt(object value)
        {
            try
            {
                if (value == null || value == DBNull.Value) return 0;
                if (value is int i) return i;
                if (value is long l) return checked((int)l);
                if (value is short s) return s;
                var sVal = value.ToString()?.Trim();
                if (int.TryParse(sVal, out var parsed)) return parsed;
                return 0; // không parse được (ví dụ NV001) -> 0
            }
            catch
            {
                return 0;
            }
        }

        private void LoadAvatar(string path)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
                {
                    // .NET Framework 4.7.2 không có SystemIcons.User
                    picAvatar.Image = SystemIcons.Application.ToBitmap();
                    return;
                }

                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var ms = new MemoryStream())
                {
                    fs.CopyTo(ms);
                    using (var img = Image.FromStream(ms))
                    {
                        picAvatar.Image = (Image)img.Clone();
                    }
                }
            }
            catch
            {
                picAvatar.Image = SystemIcons.Application.ToBitmap();
            }
        }

        private void btnChangeAvatar_Click(object sender, EventArgs e)
        {
            if ((_maNV <= 0) && string.IsNullOrWhiteSpace(_user?.TaiKhoan))
            {
                MessageBox.Show("Không xác định được người dùng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn ảnh đại diện";
                ofd.Filter = "Ảnh|*.png;*.jpg;*.jpeg;*.bmp;*.gif";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string folder = Path.Combine(Application.StartupPath, "Avatars");
                        if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

                        string ext = Path.GetExtension(ofd.FileName);
                        string fileName = $"{Guid.NewGuid()}{ext}";
                        string destPath = Path.Combine(folder, fileName);
                        File.Copy(ofd.FileName, destPath, overwrite: false);

                        using (var conn = new SqlConnection(_connStr))
                        using (var cmd = new SqlCommand(!string.IsNullOrWhiteSpace(_user?.MaNV)
                                   ? "UPDATE NhanVien SET AvatarPath=@p WHERE MaNV=@id"
                                   : "UPDATE NhanVien SET AvatarPath=@p WHERE TaiKhoan=@tk", conn))
                        {
                            cmd.Parameters.Add("@p", SqlDbType.NVarChar, 260).Value = destPath;
                            if (!string.IsNullOrWhiteSpace(_user?.MaNV))
                                cmd.Parameters.Add("@id", SqlDbType.NVarChar, 20).Value = _user.MaNV;
                            else
                                cmd.Parameters.Add("@tk", SqlDbType.NVarChar, 50).Value = _user?.TaiKhoan ?? (object)DBNull.Value;
                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }

                        _avatarPath = destPath;
                        LoadAvatar(_avatarPath);
                        MessageBox.Show("Cập nhật ảnh đại diện thành công!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi cập nhật ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblCreated_Click(object sender, EventArgs e)
        {
            // no-op; added to satisfy Designer event
        }
    }
}
