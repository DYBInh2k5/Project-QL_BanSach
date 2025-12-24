using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanSach_DTO
{
    public class NhanVienDTO
    {
        public string MaNV { get; set; }
        public string HoTen { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; } // lưu mật khẩu (tạm thời plain text; khuyến nghị hash trước khi lưu)
        public string VaiTro { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public DateTime NgayTao { get; set; } // giữ nguyên kiểu DateTime (không cho phép null)
        public int TrangThai { get; set; }  // 1 = hoạt động, 0 = khóa

        public NhanVienDTO() { }

        public NhanVienDTO(string maNV, string hoTen, string taiKhoan, string vaiTro,
                           string dienThoai, string email, DateTime ngayTao, int trangThai)
        {
            MaNV = maNV;
            HoTen = hoTen;
            TaiKhoan = taiKhoan;
            VaiTro = vaiTro;
            DienThoai = dienThoai;
            Email = email;
            NgayTao = ngayTao;
            TrangThai = trangThai;
        }
    }
}
