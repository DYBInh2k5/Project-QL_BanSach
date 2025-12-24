using System;

namespace QLBanSach_DTO
{
    public class HoaDonDTO
    {
        public int MaHD { get; set; }
        public string MaNV { get; set; }
        public int MaKH { get; set; }
        public DateTime NgayLap { get; set; }
        public decimal TongTien { get; set; }
        public decimal GiamGia { get; set; }
        public decimal ThueVAT { get; set; }

        // Constructor rỗng
        public HoaDonDTO()
        {
        }

        // Constructor đầy đủ
        public HoaDonDTO(int maHD, string maNV, int maKH, DateTime ngayLap,
                         decimal tongTien, decimal giamGia, decimal thueVAT)
        {
            MaHD = maHD;
            MaNV = maNV;
            MaKH = maKH;
            NgayLap = ngayLap;
            TongTien = tongTien;
            GiamGia = giamGia;
            ThueVAT = thueVAT;
        }

        // Constructor thường dùng khi thêm hóa đơn (MaHD tự sinh)
        public HoaDonDTO(string maNV, int maKH, DateTime ngayLap,
                         decimal tongTien, decimal giamGia, decimal thueVAT)
        {
            MaNV = maNV;
            MaKH = maKH;
            NgayLap = ngayLap;
            TongTien = tongTien;
            GiamGia = giamGia;
            ThueVAT = thueVAT;
        }
    }
}
