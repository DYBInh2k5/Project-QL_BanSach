using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Data;
using QLBanSach_DAL;

namespace QLBanSach_BLL
{
    public class KhuyenMaiBLL
    {
        private readonly KhuyenMaiDAL dal = new KhuyenMaiDAL();

        // Trả về DataTable các khuyến mãi đang có hiệu lực
        public DataTable GetActivePromotions()
        {
            return dal.GetAllKhuyenMai();
        }

        // Lấy 1 khuyến mãi theo mã coupon (DataTable trả về có 0 hoặc 1 row)
        public DataRow GetPromotionByCoupon(string coupon)
        {
            var dt = dal.GetKhuyenMaiByCoupon(coupon);
            return (dt != null && dt.Rows.Count > 0) ? dt.Rows[0] : null;
        }

        // Kiểm tra coupon hợp lệ (nếu cần check ngày, số lần, v.v) — trả về true/false
        public bool ValidateCoupon(string coupon)
        {
            var row = GetPromotionByCoupon(coupon);
            if (row == null) return false;

            // Nếu bảng có cột NgayBD, NgayKT thì kiểm tra
            if (row.Table.Columns.Contains("NgayBD") && row.Table.Columns.Contains("NgayKT"))
            {
                DateTime bd, kt;
                if (DateTime.TryParse(row["NgayBD"]?.ToString(), out bd) &&
                    DateTime.TryParse(row["NgayKT"]?.ToString(), out kt))
                {
                    return DateTime.Now.Date >= bd.Date && DateTime.Now.Date <= kt.Date;
                }
            }

            return true;
        }

        // Tính số tiền giảm dựa trên DataRow khuyến mãi và tổng tiền
        // Hỗ trợ % (cột GiaTri biểu thị số phần trăm) hoặc giảm cố định (GiaTri tiền)
        public decimal CalculateDiscount(DataRow promotionRow, decimal total)
        {
            if (promotionRow == null) return 0m;
            decimal giaTri = 0m;
            if (promotionRow.Table.Columns.Contains("GiaTri"))
            {
                decimal.TryParse(promotionRow["GiaTri"]?.ToString(), out giaTri);
            }

            string hinhThuc = null;
            if (promotionRow.Table.Columns.Contains("HinhThuc"))
                hinhThuc = promotionRow["HinhThuc"]?.ToString();

            if (!string.IsNullOrEmpty(hinhThuc) && hinhThuc.Contains("%"))
            {
                return Math.Round(total * (giaTri / 100m), 0);
            }

            // mặc định coi GiaTri là tiền giảm
            return giaTri;
        }
    }
}
