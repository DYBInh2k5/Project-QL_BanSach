using System.Collections.Generic;
using System.Linq;  // ✅ cần import để dùng FirstOrDefault
using QLBanSach_DAL;
using QLBanSach_DTO;

namespace QLBanSach_BLL
{
    public class SachBLL
    {
        private readonly SachDAL dal = new SachDAL();

        public List<SachDTO> LayDanhSachSach()
        {
            return dal.GetAllSach();
        }

        public bool ThemSach(SachDTO s)
        {
            if (string.IsNullOrEmpty(s.TenSach)) return false;
            if (s.DonGia <= 0 || s.SoLuong < 0) return false;
            return dal.Insert(s);
        }

        public bool SuaSach(SachDTO s)
        {
            return dal.Update(s);
        }

        public bool XoaSach(int ma)
        {
            return dal.Delete(ma);
        }

        public List<SachDTO> TimKiemSach(string keyword)
        {
            return dal.Search(keyword);
        }

        // ✅ Thêm hàm này để fix lỗi trong UC_HoaDon
        public SachDTO LaySachTheoMa(int maSach)
        {
            //var list = dal.GetAllSach();
            //return list.FirstOrDefault(s => s.MaSach == maSach);
            return dal.GetAllSach().FirstOrDefault(s => s.MaSach == maSach);
        }
        public void CapNhatSoLuong(int ma, int soLuongNhap)
        {

            dal.UpdateSoLuong(ma, soLuongNhap);
        }

    }
}
