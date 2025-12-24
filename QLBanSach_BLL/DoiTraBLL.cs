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
    public class DoiTraBLL
    {
        // Lưu đổi trả: trả về MaDT (int)
        // items: danh sách tuple (maSach, soLuongDoi)
        public int LuuDoiTra(int maHD, List<Tuple<int, int>> items, string lyDo)
        {
            if (items == null || items.Count == 0) throw new ArgumentException("Không có mặt hàng để đổi trả.");

            int maDT = 0;
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        // Insert DoiTra, lấy MaDT
                        string sqlDT = @"INSERT INTO DoiTra(MaHD, NgayDoi, LyDo) VALUES(@MaHD, @NgayDoi, @LyDo);
                                         SELECT SCOPE_IDENTITY();";
                        using (SqlCommand cmd = new SqlCommand(sqlDT, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@MaHD", maHD);
                            cmd.Parameters.AddWithValue("@NgayDoi", DateTime.Now);
                            cmd.Parameters.AddWithValue("@LyDo", lyDo ?? string.Empty);
                            object o = cmd.ExecuteScalar();
                            maDT = Convert.ToInt32(o);
                        }

                        // Insert từng ChiTietDoiTra và cập nhật tồn kho
                        foreach (var it in items)
                        {
                            int maSach = it.Item1;
                            int soLuong = it.Item2;
                            if (soLuong <= 0) continue;

                            string sqlCT = @"INSERT INTO ChiTietDoiTra(MaDT, MaSach, SoLuong) VALUES(@MaDT, @MaSach, @SoLuong)";
                            using (SqlCommand cmd = new SqlCommand(sqlCT, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@MaDT", maDT);
                                cmd.Parameters.AddWithValue("@MaSach", maSach);
                                cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                                cmd.ExecuteNonQuery();
                            }

                            string sqlUpd = "UPDATE Sach SET SoLuong = SoLuong + @SoLuong WHERE MaSach = @MaSach";
                            using (SqlCommand cmd = new SqlCommand(sqlUpd, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                                cmd.Parameters.AddWithValue("@MaSach", maSach);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        tran.Commit();
                        return maDT;
                    }
                    catch
                    {
                        try { tran.Rollback(); } catch { }
                        throw;
                    }
                }
            }
        }
    }
}
