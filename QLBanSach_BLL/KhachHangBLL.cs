using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QLBanSach_DAL;
using QLBanSach_DTO;

namespace QLBanSach_BLL
{
    public class KhachHangBLL
    {
        // Lấy tất cả khách hàng
        public DataTable GetAllKhachHang()
        {
            string sql = "SELECT * FROM KhachHang";
            return DatabaseHelper.GetData(sql);
        }

        // Lấy theo MaKH
        public DataRow GetKhachHangById(string maKH)
        {
            string sql = "SELECT * FROM KhachHang WHERE MaKH = @MaKH";
            var dt = DatabaseHelper.ExecuteQuery(sql, new SqlParameter[] { new SqlParameter("@MaKH", maKH) });
            return (dt != null && dt.Rows.Count > 0) ? dt.Rows[0] : null;
        }

        // Thêm khách hàng (trả về true nếu thành công)
        public bool InsertKhachHang(KhachHangDTO kh)
        {
            string sql = @"INSERT INTO KhachHang(MaKH, TenKH, DienThoai, Email, DiaChi)
                           VALUES(@MaKH, @TenKH, @DienThoai, @Email, @DiaChi)";
            var p = new SqlParameter[]
            {
                new SqlParameter("@MaKH", kh.MaKH),
                new SqlParameter("@TenKH", kh.TenKH),
                new SqlParameter("@DienThoai", kh.DienThoai),
                new SqlParameter("@Email", kh.Email),
                new SqlParameter("@DiaChi", kh.DiaChi)
            };
            return DatabaseHelper.ExecuteNonQuery(sql, p) > 0;
        }

        // Cập nhật
        public bool UpdateKhachHang(KhachHangDTO kh)
        {
            string sql = @"UPDATE KhachHang SET TenKH=@TenKH, DienThoai=@DienThoai, Email=@Email, DiaChi=@DiaChi
                           WHERE MaKH=@MaKH";
            var p = new SqlParameter[]
            {
                new SqlParameter("@TenKH", kh.TenKH),
                new SqlParameter("@DienThoai", kh.DienThoai),
                new SqlParameter("@Email", kh.Email),
                new SqlParameter("@DiaChi", kh.DiaChi),
                new SqlParameter("@MaKH", kh.MaKH)
            };
            return DatabaseHelper.ExecuteNonQuery(sql, p) > 0;
        }

        // Xóa
        public bool DeleteKhachHang(string maKH)
        {
            string sql = "DELETE FROM KhachHang WHERE MaKH=@MaKH";
            var p = new SqlParameter[] { new SqlParameter("@MaKH", maKH) };
            return DatabaseHelper.ExecuteNonQuery(sql, p) > 0;
        }
    }
}