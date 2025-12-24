using System;
using System.Data;
using System.Data.SqlClient;

namespace QLBanSach_DAL
{
    public static class DatabaseHelper
    {
        // 👉 Chỉnh chuỗi kết nối tùy theo bạn đang dùng SQL nào
        private static readonly string connectionString =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=QLBanSach;Integrated Security=True";
        // Nếu bạn dùng LocalDB thì thay dòng trên bằng:
         //"Server=(localdb)\\MSSQLLocalDB;Database=QLBanSach;Trusted_Connection=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        // Lấy dữ liệu (SELECT) – có thể truyền tham số hoặc không
        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Dùng cho INSERT, UPDATE, DELETE
        public static int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteNonQuery();
            }
        }

        // Lấy một giá trị đơn (COUNT, SUM, SELECT TOP 1, ...)
        public static object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteScalar();
            }
        }

        // Hàm hỗ trợ nhanh nếu bạn chỉ cần SELECT cơ bản, không tham số
        public static DataTable GetData(string sql)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Hàm hỗ trợ nhanh cho câu truy vấn không trả kết quả (không cần tham số)
        public static void ExecuteSimple(string sql)
        {
            ExecuteNonQuery(sql);
        }
    }
}
