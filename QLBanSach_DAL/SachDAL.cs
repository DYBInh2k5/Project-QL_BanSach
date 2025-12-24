using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QLBanSach_DTO;

namespace QLBanSach_DAL
{
    public class SachDAL
    {
        // 🔗 Chuỗi kết nối
        private string connectionString =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=QLBanSach;Integrated Security=True";

        // 📘 Lấy toàn bộ danh sách sách
        public List<SachDTO> GetAllSach()
        {
            List<SachDTO> list = new List<SachDTO>();
            string query = "SELECT * FROM Sach";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new SachDTO
                    {
                        MaSach = Convert.ToInt32(row["MaSach"]),
                        TenSach = row["TenSach"].ToString(),
                        TacGia = row["TacGia"].ToString(),
                        TheLoai = row["TheLoai"].ToString(),
                        DonGia = Convert.ToDecimal(row["DonGia"]),
                        SoLuong = Convert.ToInt32(row["SoLuong"]),
                        AnhBia = row.Table.Columns.Contains("AnhBia") ? row["AnhBia"].ToString() : null
                    });
                }
            }
            return list;
        }

        // 🆕 Thêm sách
        public bool Insert(SachDTO s)
        {
            string query = @"INSERT INTO Sach (TenSach, TacGia, TheLoai, DonGia, SoLuong, AnhBia)
                             VALUES (@TenSach, @TacGia, @TheLoai, @DonGia, @SoLuong, @AnhBia)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenSach", s.TenSach);
                cmd.Parameters.AddWithValue("@TacGia", s.TacGia);
                cmd.Parameters.AddWithValue("@TheLoai", s.TheLoai);
                cmd.Parameters.AddWithValue("@DonGia", s.DonGia);
                cmd.Parameters.AddWithValue("@SoLuong", s.SoLuong);
                cmd.Parameters.AddWithValue("@AnhBia", (object)s.AnhBia ?? DBNull.Value);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // ✏️ Cập nhật sách
        public bool Update(SachDTO s)
        {
            string query = @"UPDATE Sach 
                             SET TenSach=@TenSach, TacGia=@TacGia, TheLoai=@TheLoai, 
                                 DonGia=@DonGia, SoLuong=@SoLuong, AnhBia=@AnhBia
                             WHERE MaSach=@MaSach";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSach", s.MaSach);
                cmd.Parameters.AddWithValue("@TenSach", s.TenSach);
                cmd.Parameters.AddWithValue("@TacGia", s.TacGia);
                cmd.Parameters.AddWithValue("@TheLoai", s.TheLoai);
                cmd.Parameters.AddWithValue("@DonGia", s.DonGia);
                cmd.Parameters.AddWithValue("@SoLuong", s.SoLuong);
                cmd.Parameters.AddWithValue("@AnhBia", (object)s.AnhBia ?? DBNull.Value);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // ❌ Xóa sách
        public bool Delete(int maSach)
        {
            string query = "DELETE FROM Sach WHERE MaSach=@MaSach";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSach", maSach);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // 🔍 Tìm kiếm sách
        public List<SachDTO> Search(string keyword)
        {
            List<SachDTO> list = new List<SachDTO>();
            string query = @"SELECT * FROM Sach 
                             WHERE TenSach LIKE @key OR TheLoai LIKE @key OR TacGia LIKE @key";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@key", "%" + keyword + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new SachDTO
                    {
                        MaSach = Convert.ToInt32(row["MaSach"]),
                        TenSach = row["TenSach"].ToString(),
                        TacGia = row["TacGia"].ToString(),
                        TheLoai = row["TheLoai"].ToString(),
                        DonGia = Convert.ToDecimal(row["DonGia"]),
                        SoLuong = Convert.ToInt32(row["SoLuong"]),
                        AnhBia = row.Table.Columns.Contains("AnhBia") ? row["AnhBia"].ToString() : null
                    });
                }
            }
            return list;
        }

        // 🔁 Trả về dạng DataTable (cho DataGridView nếu cần)
        public DataTable LayDanhSachSach()
        {
            string query = "SELECT * FROM Sach";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        //public void CapNhatSoLuong(int ma, int soNhap)
        //{
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();
        //        string sql = "UPDATE Sach SET SoLuong = SoLuong + @sl WHERE MaSach = @ma";

        //        SqlCommand cmd = new SqlCommand(sql, conn);
        //        cmd.Parameters.AddWithValue("@sl", soNhap);
        //        cmd.Parameters.AddWithValue("@ma", ma);
        //        cmd.ExecuteNonQuery();
        //    }
        //}
        public void UpdateSoLuong(int ma, int soNhap)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "UPDATE Sach SET SoLuong = SoLuong + @sl WHERE MaSach = @ma";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@sl", soNhap);
                cmd.Parameters.AddWithValue("@ma", ma);
                cmd.ExecuteNonQuery();
            }
        }


    }
}
