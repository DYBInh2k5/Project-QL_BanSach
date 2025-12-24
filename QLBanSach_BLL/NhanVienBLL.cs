//using QLBanSach_DAL;
//using System;
//using System.Data;

//namespace QLBanSach_BLL
//{
//    public class NhanVienBLL
//    {
//        NhanVienDAL dal = new NhanVienDAL();
//        public bool KiemTraDangNhap(string user, string pass)
//        {
//            string sql = $"SELECT * FROM NhanVien WHERE TaiKhoan='{user}' AND MatKhau='{pass}'";
//            DataTable dt = DatabaseHelper.GetData(sql);
//            return dt.Rows.Count > 0;
//        }
//        public bool DangKyTaiKhoan(string hoTen, string taiKhoan, string matKhau, string dienThoai, string email)
//        {
//            if (string.IsNullOrWhiteSpace(taiKhoan) || string.IsNullOrWhiteSpace(matKhau))
//                throw new Exception("Tài khoản và mật khẩu không được để trống.");

//            if (dal.KiemTraTonTai(taiKhoan))
//                throw new Exception("Tài khoản đã tồn tại!");

//            return dal.DangKyTaiKhoan(hoTen, taiKhoan, matKhau, dienThoai, email);
//        }
//    }
//}

using QLBanSach_DAL;
using QLBanSach_DTO;
using System;

namespace QLBanSach_BLL
{
    public class NhanVienBLL
    {
        NhanVienDAL dal = new NhanVienDAL();

        // LOGIN NEW
        public NhanVienDTO DangNhap(string user, string pass)
        {
            return dal.DangNhap(user, pass);
        }

        // REGISTER
        public bool DangKyTaiKhoan(string hoTen, string taiKhoan, string matKhau, string dienThoai, string email)
        {
            // Optional: pre-validate in BLL
            if (string.IsNullOrWhiteSpace(hoTen) || string.IsNullOrWhiteSpace(taiKhoan) || string.IsNullOrWhiteSpace(matKhau))
                return false;

            return dal.DangKyTaiKhoan(hoTen, taiKhoan, matKhau, dienThoai, email);
        }
    }
}
