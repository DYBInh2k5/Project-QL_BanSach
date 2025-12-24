using System;
using System.Data;
using QLBanSach_DAL;

namespace QLBanSach_BLL
{
    public class HoaDonBLL
    {
        private readonly HoaDonDAL dal = new HoaDonDAL();

        // Overload hiện có của DAL: 3 tham số (giữ chạy ổn ngay)
        public int LuuHoaDon(string maNV, int maKH, DataTable chiTiet)
        {
            if (string.IsNullOrWhiteSpace(maNV))
                throw new ArgumentException("MaNV không được rỗng.", nameof(maNV));
            if (maKH <= 0)
                throw new ArgumentException("MaKH không hợp lệ.", nameof(maKH));
            if (chiTiet == null || chiTiet.Rows.Count == 0)
                throw new ArgumentException("Chi tiết hóa đơn rỗng.", nameof(chiTiet));

            return dal.LuuHoaDon(maNV, maKH, chiTiet);
        }

        // Phiên bản có giảm giá + VAT (tạm gọi về overload 3 tham số cho đến khi DAL được bổ sung)
        public int LuuHoaDon(string maNV, int maKH, DataTable chiTiet, decimal giamGia, decimal thueVatPercent)
        {
            if (string.IsNullOrWhiteSpace(maNV))
                throw new ArgumentException("MaNV không được rỗng.", nameof(maNV));
            if (maKH <= 0)
                throw new ArgumentException("MaKH không hợp lệ.", nameof(maKH));
            if (chiTiet == null || chiTiet.Rows.Count == 0)
                throw new ArgumentException("Chi tiết hóa đơn rỗng.", nameof(chiTiet));
            if (giamGia < 0) giamGia = 0;
            if (thueVatPercent < 0) thueVatPercent = 0;

            // TODO: Khi DAL có method mới nhận giamGia/VAT, đổi lời gọi bên dưới:
            // return dal.LuuHoaDon(maNV, maKH, chiTiet, giamGia, thueVatPercent);

            // Tạm thời gọi về phiên bản 3 tham số để không lỗi biên dịch
            return dal.LuuHoaDon(maNV, maKH, chiTiet);
        }
    }
}

