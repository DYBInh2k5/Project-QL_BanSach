using QLBanSach_DAL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLBanSach_GUI.UserControls
{
    public partial class UC_KhuyenMai : UserControl
    {
        private readonly KhuyenMaiDAL dal = new KhuyenMaiDAL();

        public UC_KhuyenMai()
        {
            InitializeComponent();

            // Wire các nút CRUD (chỉ 1 lần)
            btnThem.Click += (s, e) => AddPromotion();
            btnSua.Click += (s, e) => UpdatePromotion();
            btnXoa.Click += (s, e) => DeletePromotion();

            // Wire toggle coupon input
            cbHinhThuc.SelectedIndexChanged += cbHinhThuc_SelectedIndexChanged;
        }

        private void UC_KhuyenMai_Load(object sender, EventArgs e)
        {
            // ngày mặc định để hiển thị: hôm nay nằm trong khoảng
            dtBD.Value = DateTime.Today;
            dtKT.Value = DateTime.Today.AddDays(30);

            if (cbHinhThuc.Items.Count > 0)
                cbHinhThuc.SelectedIndex = 0;

            RefreshGrid();

            dgvKM.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKM.MultiSelect = false;
            dgvKM.ReadOnly = true;
            dgvKM.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // NOTE: KHÔNG wire lại các button ở đây để tránh nhân đôi handler
        }

        private void RefreshGrid()
        {
            // Luôn requery lại từ DB vì DAL đang lọc theo GETDATE()
            var dt = dal.GetAllKhuyenMai();
            dgvKM.DataSource = null;
            dgvKM.DataSource = dt;
        }

        private void cbHinhThuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            // KHÔNG thêm Items ở đây (tránh trùng)
            // Có thể tùy biến UI theo hình thức:
            // - Nếu "%": txtGiaTri là phần trăm (vd 10 = 10%)
            // - Nếu "COUPON": yêu cầu nhập txtCoupon (mã)
            // - Nếu "TANG1": có thể dùng txtGiaTri = số lượng hoặc bỏ qua
            var ht = cbHinhThuc.SelectedItem?.ToString();
            txtCoupon.Enabled = string.Equals(ht, "COUPON", StringComparison.OrdinalIgnoreCase);
        }

        // Helper lấy giá trị UI với kiểm tra đơn giản
        private bool TryGetInputs(out string tenKM, out string hinhThuc, out decimal giaTri, out string coupon, out DateTime ngayBD, out DateTime ngayKT)
        {
            tenKM = txtTenKM.Text?.Trim();
            hinhThuc = cbHinhThuc.SelectedItem?.ToString();
            coupon = txtCoupon.Text?.Trim();
            ngayBD = dtBD.Value.Date;
            ngayKT = dtKT.Value.Date;
            giaTri = 0m;

            if (string.IsNullOrWhiteSpace(tenKM)) { MessageBox.Show("Vui lòng nhập tên khuyến mãi."); return false; }
            if (string.IsNullOrWhiteSpace(hinhThuc)) { MessageBox.Show("Vui lòng chọn hình thức."); return false; }
            if (!decimal.TryParse(txtGiaTri.Text?.Trim(), out giaTri) || giaTri < 0) { MessageBox.Show("Giá trị khuyến mãi không hợp lệ."); return false; }
            if (string.Equals(hinhThuc, "COUPON", StringComparison.OrdinalIgnoreCase) && string.IsNullOrWhiteSpace(coupon))
            { MessageBox.Show("Vui lòng nhập mã coupon."); return false; }
            if (ngayKT < ngayBD) { MessageBox.Show("Ngày kết thúc phải sau hoặc bằng ngày bắt đầu."); return false; }
            return true;
        }

        private void AddPromotion()
        {
            try
            {
                if (!TryGetInputs(out var tenKM, out var hinhThuc, out var giaTri, out var coupon, out var ngayBD, out var ngayKT)) return;
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    var sql = @"INSERT INTO KhuyenMai(TenKM, HinhThuc, GiaTri, MaCoupon, NgayBD, NgayKT)
                                VALUES (@TenKM, @HinhThuc, @GiaTri, @MaCoupon, @NgayBD, @NgayKT);";
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenKM", tenKM);
                        cmd.Parameters.AddWithValue("@HinhThuc", hinhThuc);
                        var pGiaTri = cmd.Parameters.Add("@GiaTri", SqlDbType.Decimal); pGiaTri.Precision = 18; pGiaTri.Scale = 2; pGiaTri.Value = giaTri;
                        cmd.Parameters.AddWithValue("@MaCoupon", string.IsNullOrWhiteSpace(coupon) ? (object)DBNull.Value : coupon);
                        cmd.Parameters.AddWithValue("@NgayBD", ngayBD);
                        cmd.Parameters.AddWithValue("@NgayKT", ngayKT);
                        cmd.ExecuteNonQuery();
                    }
                }
                RefreshGrid();
                MessageBox.Show("Thêm khuyến mãi thành công.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi thêm khuyến mãi: " + ex.Message); }
        }

        private DataRow GetSelectedPromotion()
        {
            if (dgvKM.CurrentRow == null || dgvKM.CurrentRow.DataBoundItem == null) return null;
            var drv = dgvKM.CurrentRow.DataBoundItem as DataRowView;
            return drv?.Row;
        }

        private void UpdatePromotion()
        {
            try
            {
                var row = GetSelectedPromotion();
                if (row == null) { MessageBox.Show("Vui lòng chọn dòng để sửa."); return; }
                if (!row.Table.Columns.Contains("MaKM")) { MessageBox.Show("Bảng KhuyenMai thiếu cột khóa MaKM."); return; }
                int maKM = Convert.ToInt32(row["MaKM"]);

                if (!TryGetInputs(out var tenKM, out var hinhThuc, out var giaTri, out var coupon, out var ngayBD, out var ngayKT)) return;

                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    var sql = @"UPDATE KhuyenMai
                                SET TenKM=@TenKM, HinhThuc=@HinhThuc, GiaTri=@GiaTri, MaCoupon=@MaCoupon, NgayBD=@NgayBD, NgayKT=@NgayKT
                                WHERE MaKM=@MaKM;";

                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaKM", maKM);
                        cmd.Parameters.AddWithValue("@TenKM", tenKM);
                        cmd.Parameters.AddWithValue("@HinhThuc", hinhThuc);
                        var pGiaTri = cmd.Parameters.Add("@GiaTri", SqlDbType.Decimal); pGiaTri.Precision = 18; pGiaTri.Scale = 2; pGiaTri.Value = giaTri;
                        cmd.Parameters.AddWithValue("@MaCoupon", string.IsNullOrWhiteSpace(coupon) ? (object)DBNull.Value : coupon);
                        cmd.Parameters.AddWithValue("@NgayBD", ngayBD);
                        cmd.Parameters.AddWithValue("@NgayKT", ngayKT);
                        cmd.ExecuteNonQuery();
                    }
                }
                RefreshGrid();
                MessageBox.Show("Sửa khuyến mãi thành công.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi sửa khuyến mãi: " + ex.Message); }
        }

        private void DeletePromotion()
        {
            try
            {
                var row = GetSelectedPromotion();
                if (row == null) { MessageBox.Show("Vui lòng chọn dòng để xóa."); return; }
                if (!row.Table.Columns.Contains("MaKM")) { MessageBox.Show("Bảng KhuyenMai thiếu cột khóa MaKM."); return; }
                int maKM = Convert.ToInt32(row["MaKM"]);

                if (MessageBox.Show("Bạn chắc chắn xóa khuyến mãi này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("DELETE FROM KhuyenMai WHERE MaKM=@MaKM;", conn))
                    {
                        cmd.Parameters.AddWithValue("@MaKM", maKM);
                        cmd.ExecuteNonQuery();
                    }
                }
                RefreshGrid();
                MessageBox.Show("Xóa khuyến mãi thành công.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi xóa khuyến mãi: " + ex.Message); }
        }
    }
}
