using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QLBanSach_DAL;

namespace QLBanSach_BLL
{
    public class BanHangBLL
    {
        private readonly HoaDonBLL hoaDonBLL = new HoaDonBLL();
        private readonly KhuyenMaiBLL khuyenMaiBLL = new KhuyenMaiBLL();

        // Checkout: lưu hoá đơn (sử dụng HoaDonBLL) và nếu có mã KM, cập nhật thông tin giảm giá
        // Trả về MaHD
        public int Checkout(string maNV, int maKH, DataTable chiTiet, DataRow promotionRow = null)
        {
            int maHD = hoaDonBLL.LuuHoaDon(maNV, maKH, chiTiet);

            if (promotionRow != null)
            {
                // tính tiền trước => HoaDonBLL đã tính tổng dựa trên ChiTietHoaDon
                decimal tong = 0m;
                // lấy tổng từ DB
                var dt = DatabaseHelper.ExecuteQuery("SELECT TongTien FROM HoaDon WHERE MaHD=@MaHD",
                    new SqlParameter[] { new SqlParameter("@MaHD", maHD) });
                if (dt.Rows.Count > 0) decimal.TryParse(dt.Rows[0][0].ToString(), out tong);

                decimal discount = khuyenMaiBLL.CalculateDiscount(promotionRow, tong);

                // Cập nhật lại HoaDon: lưu MaKM nếu có cột và TongTienSauGiam (tùy schema)
                string updateSql = "UPDATE HoaDon SET TongTien = TongTien - @Discount WHERE MaHD = @MaHD";
                DatabaseHelper.ExecuteNonQuery(updateSql, new SqlParameter[] {
                    new SqlParameter("@Discount", discount),
                    new SqlParameter("@MaHD", maHD)
                });

                // Nếu bảng có cột MaKM, lưu lại (tùy bạn sửa schema)
                if (promotionRow.Table.Columns.Contains("MaKM") || promotionRow.Table.Columns.Contains("MaCoupon"))
                {
                    string maKM = promotionRow.Table.Columns.Contains("MaKM") ? promotionRow["MaKM"]?.ToString() : promotionRow["MaCoupon"]?.ToString();
                    if (!string.IsNullOrEmpty(maKM))
                    {
                        // bảo vệ: chỉ chạy nếu cột MaKM tồn tại
                        try
                        {
                            DatabaseHelper.ExecuteNonQuery("UPDATE HoaDon SET MaKM=@MaKM WHERE MaHD=@MaHD",
                                new SqlParameter[] {
                                    new SqlParameter("@MaKM", maKM),
                                    new SqlParameter("@MaHD", maHD)
                                });
                        }
                        catch { /* nếu schema không có cột thì bỏ qua */ }
                    }
                }
            }

            return maHD;
        }
    }
}