using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanSach_DAL
{
    // Chỉ 1 định nghĩa class ở đây
    public class KhuyenMaiDAL
    {
        // Lấy khuyến mãi đang còn hiệu lực
        public DataTable GetAllKhuyenMai()
        {
            string sql = "SELECT * FROM KhuyenMai WHERE GETDATE() BETWEEN NgayBD AND NgayKT";
            return DatabaseHelper.GetData(sql); // sử dụng DatabaseHelper (static)
        }

        // Lấy khuyến mãi theo mã coupon (parameterized)
        public DataTable GetKhuyenMaiByCoupon(string coupon)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string sql = "SELECT * FROM KhuyenMai WHERE MaCoupon = @coupon";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@coupon", coupon ?? string.Empty);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }

            return dt;
        }
    }
}
