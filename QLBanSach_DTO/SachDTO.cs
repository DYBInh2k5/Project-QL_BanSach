using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanSach_DTO
{
    
    public class SachDTO
    {
        public int MaSach { get; set; }
        public string TenSach { get; set; }
        public string TacGia { get; set; }
        public string TheLoai { get; set; }
        public decimal DonGia { get; set; }
        public int SoLuong { get; set; }
        public string AnhBia { get; set; }



        public SachDTO() { }

        public SachDTO(int maSach, string tenSach, string tacGia, string theLoai, decimal donGia, int soLuong, string anhBia)
        {
            MaSach = maSach;
            TenSach = tenSach;
            TacGia = tacGia;
            TheLoai = theLoai;
            DonGia = donGia;
            SoLuong = soLuong;
            AnhBia = anhBia;
        }
    }
}
