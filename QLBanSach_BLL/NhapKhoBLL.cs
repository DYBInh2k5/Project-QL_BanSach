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
    public class NhapKhoBLL
    {
        // Lưu phiếu nhập và cập nhật tồn kho
        // ChiTiet: DataTable có các cột MaSach, SoLuongNhap, DonGia (tùy bạn)
        // Trả về MaPhieuNhap (int)
        public int LuuPhieuNhap(string maNV, DataTable chiTiet)
        {
            if (chiTiet == null || chiTiet.Rows.Count == 0) throw new ArgumentException("Chi tiết nhập rỗng.");

            int maPN = 0;
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        string sqlPN = @"INSERT INTO PhieuNhap(MaNV, NgayNhap) VALUES(@MaNV, GETDATE()); SELECT SCOPE_IDENTITY();";
                        using (SqlCommand cmd = new SqlCommand(sqlPN, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@MaNV", maNV);
                            object scalar = cmd.ExecuteScalar();
                            // SCOPE_IDENTITY() returns decimal in SQL Server; convert safely
                            maPN = Convert.ToInt32(Convert.ToDecimal(scalar));
                        }

                        foreach (DataRow r in chiTiet.Rows)
                        {
                            int maSach = Convert.ToInt32(r["MaSach"]);
                            int soLuong = Convert.ToInt32(r["SoLuongNhap"]);
                            decimal donGia = r.Table.Columns.Contains("DonGia") ? Convert.ToDecimal(r["DonGia"]) : 0m;

                            string sqlCT = @"INSERT INTO ChiTietPhieuNhap(MaPN, MaSach, SoLuong, DonGia) VALUES(@MaPN, @MaSach, @SoLuong, @DonGia)";
                            using (SqlCommand cmd = new SqlCommand(sqlCT, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@MaPN", maPN);
                                cmd.Parameters.AddWithValue("@MaSach", maSach);
                                cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                                cmd.Parameters.AddWithValue("@DonGia", donGia);
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
                        return maPN;
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
