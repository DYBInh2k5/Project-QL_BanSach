using QLBanSach_DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanSach_DAL
{
    public class NhanVienDAL
    {
        private readonly string connStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=QLBanSach;Integrated Security=True";

        // Generate MaNV similar to frmQuanLyTaiKhoan (10 chars)
        private static string GenerateMaNV10()
        {
            var date = DateTime.Now.ToString("yyMMdd");
            var rnd = Guid.NewGuid().ToString("N").Substring(0, 2);
            return "NV" + date + rnd; // 10 chars
        }

        public bool DangKyTaiKhoan(string hoTen, string taiKhoan, string matKhau, string dienThoai, string email)
        {
            var maNV = GenerateMaNV10();
            var vaiTro = "User";   // default role
            var trangThai = 1;     // active

            using (SqlConnection conn = DatabaseHelper.GetConnection()) // use same source everywhere
            using (SqlCommand cmd = new SqlCommand(
                @"INSERT INTO NhanVien
                  (MaNV, HoTen, TaiKhoan, MatKhau, VaiTro, DienThoai, Email, NgaySinh, NgayTao, CCCD, AvatarPath, TrangThai)
                  VALUES
                  (@MaNV, @HoTen, @TaiKhoan, @MatKhau, @VaiTro, @DienThoai, @Email, @NgaySinh, GETDATE(), @CCCD, @AvatarPath, @TrangThai)", conn))
            {
                // Strings as NVARCHAR; no numeric parsing
                cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar, 10).Value = maNV;
                cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar, 50).Value = (object)hoTen ?? DBNull.Value;
                cmd.Parameters.Add("@TaiKhoan", SqlDbType.NVarChar, 30).Value = (object)taiKhoan ?? DBNull.Value;
                cmd.Parameters.Add("@MatKhau", SqlDbType.NVarChar, 30).Value = (object)matKhau ?? DBNull.Value;
                cmd.Parameters.Add("@VaiTro", SqlDbType.NVarChar, 20).Value = vaiTro;
                cmd.Parameters.Add("@DienThoai", SqlDbType.NVarChar, 20).Value = string.IsNullOrWhiteSpace(dienThoai) ? (object)DBNull.Value : dienThoai;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = string.IsNullOrWhiteSpace(email) ? (object)DBNull.Value : email;

                // If NgaySinh column allows NULL, send DBNull.Value; otherwise set a valid date
                cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = DBNull.Value;

                cmd.Parameters.Add("@CCCD", SqlDbType.NVarChar, 20).Value = DBNull.Value;
                cmd.Parameters.Add("@AvatarPath", SqlDbType.NVarChar, 260).Value = DBNull.Value;

                cmd.Parameters.Add("@TrangThai", SqlDbType.Int).Value = trangThai;

                conn.Open();
                int affected = cmd.ExecuteNonQuery();
                return affected > 0;
            }
        }

        public bool KiemTraTonTai(string taiKhoan)
        {
            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand("SELECT COUNT(*) FROM NhanVien WHERE TaiKhoan=@tk", conn))
            {
                cmd.Parameters.Add("@tk", SqlDbType.NVarChar, 30).Value = taiKhoan;
                conn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        public bool KiemTraTonTaiNgoaiMa(string taiKhoan, string maNV)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM NhanVien WHERE TaiKhoan = @tk AND MaNV <> @maNV";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tk", taiKhoan);
                cmd.Parameters.AddWithValue("@maNV", maNV);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public bool KiemTraDangNhap(string user, string pass)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM NhanVien WHERE TaiKhoan = @user AND MatKhau = @pass";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@user", user);
                cmd.Parameters.AddWithValue("@pass", pass);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public NhanVienDTO DangNhap(string user, string pass)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string sql = "SELECT * FROM NhanVien WHERE TaiKhoan = @user AND MatKhau = @pass";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@user", user);
                cmd.Parameters.AddWithValue("@pass", pass);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new NhanVienDTO
                    {
                        MaNV = reader["MaNV"].ToString(),
                        HoTen = reader["HoTen"].ToString(),
                        TaiKhoan = reader["TaiKhoan"].ToString(),
                        VaiTro = reader["VaiTro"].ToString(),
                        DienThoai = reader["DienThoai"].ToString(),
                        Email = reader["Email"].ToString(),
                        NgayTao = Convert.ToDateTime(reader["NgayTao"]),
                        TrangThai = reader["TrangThai"] == DBNull.Value ? 1 : Convert.ToInt32(reader["TrangThai"])
                    };
                }

                return null;
            }
        }

        // --- MỚI: Lấy thông tin NV theo MaNV ---
        public NhanVienDTO GetNhanVienById(string maNV)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM NhanVien WHERE MaNV = @maNV";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@maNV", maNV);
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        // Nếu NgayTao NULL trong DB, gán DateTime.MinValue (hoặc DateTime.Now nếu bạn muốn)
                        DateTime ngayTao = rd["NgayTao"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(rd["NgayTao"]);

                        return new NhanVienDTO
                        {
                            MaNV = rd["MaNV"].ToString(),
                            HoTen = rd["HoTen"]?.ToString(),
                            TaiKhoan = rd["TaiKhoan"]?.ToString(),
                            MatKhau = rd["MatKhau"]?.ToString(), // read password column if present (may be null)
                            VaiTro = rd["VaiTro"]?.ToString(),
                            DienThoai = rd["DienThoai"]?.ToString(),
                            Email = rd["Email"]?.ToString(),
                            NgayTao = ngayTao,
                            TrangThai = rd["TrangThai"] == DBNull.Value ? 1 : Convert.ToInt32(rd["TrangThai"])
                        };
                    }
                }
            }
            return null;
        }

        // --- MỚI: Cập nhật nhân viên ---
        public bool UpdateNhanVien(NhanVienDTO nv, bool updatePassword = false)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                var sql = new StringBuilder();
                sql.Append("UPDATE NhanVien SET HoTen = @HoTen, TaiKhoan = @TaiKhoan, VaiTro = @VaiTro, DienThoai = @DienThoai, Email = @Email");

                if (updatePassword)
                    sql.Append(", MatKhau = @MatKhau");

                sql.Append(" WHERE MaNV = @MaNV");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), conn))
                {
                    cmd.Parameters.AddWithValue("@HoTen", nv.HoTen ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@TaiKhoan", nv.TaiKhoan ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@VaiTro", nv.VaiTro ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DienThoai", nv.DienThoai ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", nv.Email ?? (object)DBNull.Value);
                    if (updatePassword)
                        cmd.Parameters.AddWithValue("@MatKhau", nv.MatKhau ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@MaNV", nv.MaNV);

                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }
    }
}
