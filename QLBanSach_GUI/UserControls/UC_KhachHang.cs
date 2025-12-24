using QLBanSach_DAL;
using QLBanSach_DTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace QLBanSach_GUI.UserControls
{
    public partial class UC_KhachHang : UserControl

    {
        private readonly KhachHangDAL dal = new KhachHangDAL();
        //string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QLBanSach;Integrated Security=True";
        // Sự kiện để thông báo parent khi user chọn 1 khách (trả về MaKH dưới dạng int nếu có thể)
        public event EventHandler<int> CustomerSelected;


        public UC_KhachHang()
        {
            InitializeComponent();
        }
        private void UC_KhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        //private void LoadData()
        //{
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            string query = "SELECT MaKH, TenKH, DienThoai, DiaChi FROM KhachHang";
        //            SqlDataAdapter da = new SqlDataAdapter(query, conn);
        //            DataTable dt = new DataTable();
        //            da.Fill(dt);
        //            dgvKhachHang.DataSource = dt;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
        //    }
        //}
        private void LoadData()
        {
            try
            {
                DataTable dt = dal.GetAllKhachHang();
                dgvKhachHang.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }
        private void ClearInput()
        {
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtTimKiem.Clear();
        }



        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }



        // 🔹 Cập nhật khách hàng
        //private void btnSua_Click(object sender, EventArgs e)
        //{
        //    if (txtMaKH.Text == "")
        //    {
        //        MessageBox.Show("Vui lòng chọn khách hàng để sửa!");
        //        return;
        //    }

        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        string query = "UPDATE KhachHang SET TenKH=@TenKH, DienThoai=@DienThoai, DiaChi=@DiaChi WHERE MaKH=@MaKH";
        //        SqlCommand cmd = new SqlCommand(query, conn);
        //        cmd.Parameters.AddWithValue("@MaKH", txtMaKH.Text);
        //        cmd.Parameters.AddWithValue("@TenKH", txtTenKH.Text);
        //        cmd.Parameters.AddWithValue("@DienThoai", txtSDT.Text);
        //        cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);

        //        try
        //        {
        //            conn.Open();
        //            cmd.ExecuteNonQuery();
        //            MessageBox.Show("Cập nhật thành công!");
        //            LoadData();
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Lỗi sửa: " + ex.Message);
        //        }
        //    }
        //}
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKH.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng để sửa!");
                return;
            }

            var kh = new KhachHangDTO
            {
                MaKH = txtMaKH.Text,
                TenKH = txtTenKH.Text,
                DienThoai = txtSDT.Text,
                DiaChi = txtDiaChi.Text,
                Email = "" // nếu control có Email, gán tương ứng
            };

            try
            {
                if (dal.UpdateKhachHang(kh))
                {
                    MessageBox.Show("Cập nhật thành công!");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Cập nhật không thành công.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa: " + ex.Message);
            }
        }

        //private void btnThem_Click(object sender, EventArgs e)
        //{
        //    if (txtMaKH.Text == "" || txtTenKH.Text == "")
        //    {
        //        MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
        //        return;
        //    }

        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        string query = "INSERT INTO KhachHang ( TenKH, DienThoai, DiaChi) VALUES ( @TenKH, @DienThoai, @DiaChi)";
        //        SqlCommand cmd = new SqlCommand(query, conn);
        //        //cmd.Parameters.AddWithValue("@MaKH", txtMaKH.Text);
        //        cmd.Parameters.AddWithValue("@TenKH", txtTenKH.Text);
        //        cmd.Parameters.AddWithValue("@DienThoai", txtSDT.Text);
        //        cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);

        //        try
        //        {
        //            conn.Open();
        //            cmd.ExecuteNonQuery();
        //            MessageBox.Show("Thêm khách hàng thành công!");
        //            LoadData();
        //            ClearInput();
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Lỗi thêm: " + ex.Message);
        //        }
        //    }
        //}
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenKH.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            var kh = new KhachHangDTO
            {
                TenKH = txtTenKH.Text,
                DienThoai = txtSDT.Text,
                DiaChi = txtDiaChi.Text,
                Email = "" // nếu control có Email, gán tương ứng
            };

            try
            {
                if (dal.InsertKhachHang(kh))
                {
                    MessageBox.Show("Thêm khách hàng thành công!");
                    LoadData();
                    ClearInput();
                }
                else
                {
                    MessageBox.Show("Thêm không thành công.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm: " + ex.Message);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInput();
            LoadData();
        }

        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {

        }

        // 🔹 Xóa khách hàng
        //private void btnXoa_Click(object sender, EventArgs e)
        //{
        //    if (txtMaKH.Text == "")
        //    {
        //        MessageBox.Show("Vui lòng chọn khách hàng để xóa!");
        //        return;
        //    }

        //    var r = MessageBox.Show("Bạn có chắc muốn xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo);
        //    if (r == DialogResult.No) return;

        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        string query = "DELETE FROM KhachHang WHERE MaKH=@MaKH";
        //        SqlCommand cmd = new SqlCommand(query, conn);
        //        cmd.Parameters.AddWithValue("@MaKH", txtMaKH.Text);

        //        try
        //        {
        //            conn.Open();
        //            cmd.ExecuteNonQuery();
        //            MessageBox.Show("Xóa thành công!");
        //            LoadData();
        //            ClearInput();
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Lỗi xóa: " + ex.Message);
        //        }
        //    }
        //}
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKH.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng để xóa!");
                return;
            }

            var r = MessageBox.Show("Bạn có chắc muốn xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (r == DialogResult.No) return;

            try
            {
                if (dal.DeleteKhachHang(txtMaKH.Text))
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                    ClearInput();
                }
                else
                {
                    MessageBox.Show("Xóa không thành công.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa: " + ex.Message);
            }
        }

        //private void btnTim_Click(object sender, EventArgs e)
        //{
        //    string keyword = txtTimKiem.Text.Trim();
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        string query = @"SELECT MaKH, TenKH, DienThoai, DiaChi 
        //                         FROM KhachHang 
        //                         WHERE TenKH LIKE N'%' + @kw + '%' OR DienThoai LIKE '%' + @kw + '%'";
        //        SqlDataAdapter da = new SqlDataAdapter(query, conn);
        //        da.SelectCommand.Parameters.AddWithValue("@kw", keyword);
        //        DataTable dt = new DataTable();
        //        da.Fill(dt);
        //        dgvKhachHang.DataSource = dt;
        //    }
        //}
        private void btnTim_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            try
            {
                DataTable dt = dal.Search(keyword);
                dgvKhachHang.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }


        private void dgvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaKH.Text = dgvKhachHang.Rows[e.RowIndex].Cells["MaKH"].Value.ToString();
                txtTenKH.Text = dgvKhachHang.Rows[e.RowIndex].Cells["TenKH"].Value.ToString();
                txtSDT.Text = dgvKhachHang.Rows[e.RowIndex].Cells["DienThoai"].Value.ToString();
                txtDiaChi.Text = dgvKhachHang.Rows[e.RowIndex].Cells["DiaChi"].Value.ToString();
            }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn 1 khách hàng!");
                return;
            }

            var cellValue = dgvKhachHang.SelectedRows[0].Cells["MaKH"].Value;
            if (cellValue == null) return;

            int id;
            if (int.TryParse(cellValue.ToString(), out id))
            {
                CustomerSelected?.Invoke(this, id);
            }
            else
            {
                // nếu MaKH là string, bạn có thể raise event string hoặc show message
                MessageBox.Show("MaKH không phải số. Nếu dùng mã chuỗi, điều chỉnh sự kiện.");
            }
        }
    }
}
