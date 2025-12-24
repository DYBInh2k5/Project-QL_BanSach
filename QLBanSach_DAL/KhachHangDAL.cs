using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QLBanSach_DTO;

namespace QLBanSach_DAL
{
    public class KhachHangDAL
    {
        // Lấy toàn bộ khách hàng
        public DataTable GetAllKhachHang()
        {
            string sql = "SELECT MaKH, TenKH, DienThoai, Email, DiaChi FROM KhachHang";
            return DatabaseHelper.GetData(sql);
        }

        // Lấy khách hàng theo MaKH (trả về DataTable chứa 0 hoặc 1 row)
        public DataTable GetKhachHangById(string maKH)
        {
            string sql = "SELECT MaKH, TenKH, DienThoai, Email, DiaChi FROM KhachHang WHERE MaKH = @MaKH";
            var p = new SqlParameter[] { new SqlParameter("@MaKH", maKH ?? (object)DBNull.Value) };
            return DatabaseHelper.ExecuteQuery(sql, p);
        }

        // Thêm khách hàng. Nếu MaKH là identity ở DB thì bỏ MaKH.
        public bool InsertKhachHang(KhachHangDTO kh)
        {
            // Giữ tương thích: không chèn MaKH nếu DB tự sinh
            string sql = @"INSERT INTO KhachHang (TenKH, DienThoai, Email, DiaChi)
                           VALUES (@TenKH, @DienThoai, @Email, @DiaChi)";
            var p = new SqlParameter[]
            {
                new SqlParameter("@TenKH", (object)kh.TenKH ?? DBNull.Value),
                new SqlParameter("@DienThoai", (object)kh.DienThoai ?? DBNull.Value),
                new SqlParameter("@Email", (object)kh.Email ?? DBNull.Value),
                new SqlParameter("@DiaChi", (object)kh.DiaChi ?? DBNull.Value),
            };
            return DatabaseHelper.ExecuteNonQuery(sql, p) > 0;
        }

        // Cập nhật khách hàng theo MaKH
        public bool UpdateKhachHang(KhachHangDTO kh)
        {
            string sql = @"UPDATE KhachHang 
                           SET TenKH = @TenKH, DienThoai = @DienThoai, Email = @Email, DiaChi = @DiaChi
                           WHERE MaKH = @MaKH";
            var p = new SqlParameter[]
            {
                new SqlParameter("@TenKH", (object)kh.TenKH ?? DBNull.Value),
                new SqlParameter("@DienThoai", (object)kh.DienThoai ?? DBNull.Value),
                new SqlParameter("@Email", (object)kh.Email ?? DBNull.Value),
                new SqlParameter("@DiaChi", (object)kh.DiaChi ?? DBNull.Value),
                new SqlParameter("@MaKH", (object)kh.MaKH ?? DBNull.Value)
            };
            return DatabaseHelper.ExecuteNonQuery(sql, p) > 0;
        }

        // Xóa khách hàng theo MaKH
        public bool DeleteKhachHang(string maKH)
        {
            string sql = "DELETE FROM KhachHang WHERE MaKH = @MaKH";
            var p = new SqlParameter[] { new SqlParameter("@MaKH", maKH ?? (object)DBNull.Value) };
            return DatabaseHelper.ExecuteNonQuery(sql, p) > 0;
        }

        // Tìm kiếm theo tên hoặc điện thoại
        public DataTable Search(string keyword)
        {
            string sql = @"SELECT MaKH, TenKH, DienThoai, Email, DiaChi
                           FROM KhachHang
                           WHERE TenKH LIKE N'%' + @kw + '%' OR DienThoai LIKE '%' + @kw + '%'";
            var p = new SqlParameter[] { new SqlParameter("@kw", keyword ?? string.Empty) };
            return DatabaseHelper.ExecuteQuery(sql, p);
        }
    }
}