using System;
using System.Data;
using System.Data.SqlClient;

//namespace QLBanSach_DAL
//{
//    public class HoaDonDAL
//    {
//        private string connectionString =
//            @"Data Source=.\SQLEXPRESS;Initial Catalog=QLBanSach;Integrated Security=True";

//        public string LuuHoaDon(int maNV, int maKH, DataTable chiTiet)
//        {
//            string maHD = "";

//            using (SqlConnection conn = new SqlConnection(connectionString))
//            {
//                conn.Open();
//                SqlTransaction tran = conn.BeginTransaction();

//                try
//                {
//                    // 1. Tạo hóa đơn
//                    string sqlHD = @"INSERT INTO HoaDon(MaNV, MaKH, NgayLap, TongTien) 
//                                     OUTPUT INSERTED.MaHD
//                                     VALUES (@MaNV, @MaKH, GETDATE(), 0)";

//                    SqlCommand cmdHD = new SqlCommand(sqlHD, conn, tran);
//                    cmdHD.Parameters.AddWithValue("@MaNV", maNV);
//                    cmdHD.Parameters.AddWithValue("@MaKH", maKH);

//                    maHD = cmdHD.ExecuteScalar().ToString();

//                    // 2. Thêm chi tiết
//                    foreach (DataRow row in chiTiet.Rows)
//                    {
//                        string sqlCT = @"INSERT INTO ChiTietHoaDon(MaHD, MaSach, SoLuong, DonGia, ThanhTien)
//                                         VALUES (@MaHD, @MaSach, @SoLuong, @DonGia, @ThanhTien)";

//                        SqlCommand cmdCT = new SqlCommand(sqlCT, conn, tran);
//                        cmdCT.Parameters.AddWithValue("@MaHD", maHD);
//                        cmdCT.Parameters.AddWithValue("@MaSach", row["MaSach"]);
//                        cmdCT.Parameters.AddWithValue("@SoLuong", row["SoLuong"]);
//                        cmdCT.Parameters.AddWithValue("@DonGia", row["DonGia"]);
//                        cmdCT.Parameters.AddWithValue("@ThanhTien", row["ThanhTien"]);

//                        cmdCT.ExecuteNonQuery();
//                    }

//                    // 3. Cập nhật tổng tiền
//                    string sqlTong = @"UPDATE HoaDon 
//                                       SET TongTien = (SELECT SUM(ThanhTien) FROM ChiTietHoaDon WHERE MaHD=@MaHD)
//                                       WHERE MaHD=@MaHD";

//                    SqlCommand cmdTong = new SqlCommand(sqlTong, conn, tran);
//                    cmdTong.Parameters.AddWithValue("@MaHD", maHD);

//                    cmdTong.ExecuteNonQuery();

//                    tran.Commit();
//                }
//                catch
//                {
//                    tran.Rollback();
//                    throw;
//                }
//            }

//            return maHD;
//        }
//    }
//}



namespace QLBanSach_DAL
{
    public class HoaDonDAL
    {
        // Lưu hoá đơn + chi tiết trong 1 transaction, trả về MaHD (int)
        public int LuuHoaDon(string maNV, int maKH, DataTable chiTiet)
        {
            if (chiTiet == null || chiTiet.Rows.Count == 0)
                throw new ArgumentException("Chi tiết hóa đơn rỗng.", nameof(chiTiet));

            int maHD = 0;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        // 1) Thêm hóa đơn (TongTien tạm = 0)
                        string sqlHD = @"INSERT INTO HoaDon (MaNV, MaKH, NgayLap, TongTien)
                                         OUTPUT INSERTED.MaHD
                                         VALUES (@MaNV, @MaKH, GETDATE(), 0)";
                        using (SqlCommand cmdHD = new SqlCommand(sqlHD, conn, tran))
                        {
                            cmdHD.Parameters.AddWithValue("@MaNV", maNV ?? (object)DBNull.Value);
                            cmdHD.Parameters.AddWithValue("@MaKH", maKH);
                            maHD = Convert.ToInt32(cmdHD.ExecuteScalar());
                        }

                        // 2) Thêm chi tiết (nếu có cột ThanhTien dùng giá trị, nếu không thì tự tính)
                        foreach (DataRow row in chiTiet.Rows)
                        {
                            int maSach = row.Table.Columns.Contains("MaSach") ? Convert.ToInt32(row["MaSach"]) : 0;
                            int soLuong = row.Table.Columns.Contains("SoLuong") ? Convert.ToInt32(row["SoLuong"]) : 0;
                            decimal donGia = row.Table.Columns.Contains("DonGia") ? Convert.ToDecimal(row["DonGia"]) : 0m;

                            decimal thanhTien = 0m;
                            if (row.Table.Columns.Contains("ThanhTien") && row["ThanhTien"] != DBNull.Value)
                            {
                                decimal.TryParse(row["ThanhTien"].ToString(), out thanhTien);
                            }
                            else
                            {
                                thanhTien = soLuong * donGia;
                            }

                            string sqlCT = @"INSERT INTO ChiTietHoaDon (MaHD, MaSach, SoLuong, DonGia)
                                             VALUES (@MaHD, @MaSach, @SoLuong, @DonGia)";
                            using (SqlCommand cmdCT = new SqlCommand(sqlCT, conn, tran))
                            {
                                cmdCT.Parameters.AddWithValue("@MaHD", maHD);
                                cmdCT.Parameters.AddWithValue("@MaSach", maSach);
                                cmdCT.Parameters.AddWithValue("@SoLuong", soLuong);
                                cmdCT.Parameters.AddWithValue("@DonGia", donGia);
                                cmdCT.ExecuteNonQuery();
                            }
                        }

                        // 3) Cập nhật tổng tiền cho hóa đơn (dùng SUM(ThanhTien))
                        string sqlUpdate = @"UPDATE HoaDon
                                             SET TongTien = (
                                                 SELECT ISNULL(SUM(c.SoLuong * c.DonGia), 0)
                                                 FROM ChiTietHoaDon c
                                                 WHERE c.MaHD = @MaHD
                                             )
                                             WHERE MaHD = @MaHD";
                        using (SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, conn, tran))
                        {
                            cmdUpdate.Parameters.AddWithValue("@MaHD", maHD);
                            cmdUpdate.ExecuteNonQuery();
                        }

                        tran.Commit();
                    }
                    catch
                    {
                        try { tran.Rollback(); } catch { }
                        throw;
                    }
                }
            }

            return maHD;
        }
    }
}