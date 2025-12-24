using System;

namespace QLBanSach_DTO
{
    public class KhachHangDTO
    {
        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }

        // Constructor rỗng (bắt buộc nếu bạn dùng DataTable → DTO)
        public KhachHangDTO() { }

        // Constructor đầy đủ
        public KhachHangDTO(string maKH, string tenKH, string dienThoai, string email, string diaChi)
        {
            MaKH = maKH;
            TenKH = tenKH;
            DienThoai = dienThoai;
            Email = email;
            DiaChi = diaChi;
        }

        // Giúp hiển thị tên khách trong ComboBox, ListBox
        public override string ToString()
        {
            return $"{TenKH} - {DienThoai}";
        }
    }
}
