using ClosedXML.Excel;
using QLBanSach_BLL;
using QLBanSach_DAL;
using QLBanSach_DTO;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace QLBanSach_GUI.UserControls
{
    public partial class UC_NhapKho : UserControl
    {
        private readonly NhapKhoBLL nhapKhoBLL = new NhapKhoBLL();
        public NhanVienDTO CurrentUser { get; set; }

        public UC_NhapKho()
        {
            InitializeComponent();
            dgvSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSach.MultiSelect = false;

            pnlProgressContainer.Visible = false;
            lblProgressStatus.Visible = false;
            progressBarNhapKho.Visible = false;
        }

        private void UC_NhapKho_Load(object sender, EventArgs e)
        {
            if (this.DesignMode || (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime))
                return;

            LoadSach();
            LoadNhanVien();

            if (CurrentUser != null && !string.IsNullOrWhiteSpace(CurrentUser.MaNV))
            {
                // Try select current user
                var dt = cboNhanVien.DataSource as DataTable;
                if (dt != null && dt.Columns.Contains("MaNV"))
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (string.Equals(Convert.ToString(dt.Rows[i]["MaNV"]), CurrentUser.MaNV, StringComparison.OrdinalIgnoreCase))
                        {
                            cboNhanVien.SelectedIndex = i;
                            break;
                        }
                    }
                    cboNhanVien.Enabled = false;
                }
            }

            dtpNgayNhap.Value = DateTime.Now;
            txtMaPN.Text = "";
            UpdateStatus("Sẵn sàng");
        }

        // Load sách to left grid
        private void LoadSach()
        {
            try
            {
                string sql = "SELECT MaSach, TenSach, DonGia, SoLuong FROM Sach ORDER BY TenSach";
                var dt = DatabaseHelper.ExecuteQuery(sql);
                dgvSach.DataSource = dt;
                if (dgvSach.Columns.Contains("DonGia"))
                    dgvSach.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateStatus("Lỗi tải sách");
            }
        }

        // Load nhân viên to combobox
        private void LoadNhanVien()
        {
            try
            {
                var dt = DatabaseHelper.ExecuteQuery("SELECT MaNV, HoTen FROM NhanVien ORDER BY HoTen");
                cboNhanVien.DataSource = dt;
                cboNhanVien.DisplayMember = "HoTen";
                cboNhanVien.ValueMember = "MaNV";
                if (dt.Rows.Count > 0) cboNhanVien.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateStatus("Lỗi tải nhân viên");
            }
        }

        private void btnSearchBook_Click(object sender, EventArgs e)
        {
            try
            {
                var kw = txtSearchBook.Text.Trim();
                string sql = @"
                    SELECT MaSach, TenSach, DonGia, SoLuong
                    FROM Sach
                    WHERE (@kw = '' OR TenSach LIKE @like OR CONVERT(varchar(10), MaSach) LIKE @like)
                    ORDER BY TenSach";
                var dt = DatabaseHelper.ExecuteQuery(sql, new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@kw", kw),
                    new System.Data.SqlClient.SqlParameter("@like", "%" + kw + "%")
                });
                dgvSach.DataSource = dt;
                UpdateStatus("Đã lọc danh sách sách");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateStatus("Lỗi tìm kiếm");
            }
        }

        private void dgvSach_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            AddCurrentBookToList();
        }

        private void btnThemVaoPhieu_Click(object sender, EventArgs e)
        {
            AddCurrentBookToList();
        }

        private void AddCurrentBookToList()
        {
            if (dgvSach.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maSachStr = Convert.ToString(dgvSach.CurrentRow.Cells["MaSach"].Value);
            string tenSach = Convert.ToString(dgvSach.CurrentRow.Cells["TenSach"].Value);
            string donGiaStr = Convert.ToString(dgvSach.CurrentRow.Cells["DonGia"].Value);

            if (!int.TryParse(maSachStr, out int maSach))
            {
                MessageBox.Show("Mã sách không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtSoLuong.Text.Trim(), out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên > 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal donGia;
            // ưu tiên đơn giá user nhập; nếu bỏ trống thì lấy giá từ grid
            if (!decimal.TryParse(txtDonGia.Text.Trim(), out donGia) || donGia < 0)
            {
                if (!decimal.TryParse(donGiaStr, out donGia)) donGia = 0m;
            }

            // merge nếu đã có
            var existing = lvNhapKho.Items.Cast<ListViewItem>().FirstOrDefault(it => it.SubItems[0].Text == maSachStr);
            if (existing != null)
            {
                int oldSL = int.Parse(existing.SubItems[2].Text);
                decimal oldDG = decimal.Parse(existing.SubItems[3].Text.Replace(",", ""));
                // nếu đơn giá mới khác, cập nhật theo giá mới
                existing.SubItems[2].Text = (oldSL + soLuong).ToString();
                existing.SubItems[3].Text = donGia.ToString("N0");
                decimal newThanhTien = (oldSL + soLuong) * donGia;
                existing.SubItems[4].Text = newThanhTien.ToString("N0");
            }
            else
            {
                var item = new ListViewItem(maSachStr);
                item.SubItems.Add(tenSach);
                item.SubItems.Add(soLuong.ToString());
                item.SubItems.Add(donGia.ToString("N0"));
                item.SubItems.Add((soLuong * donGia).ToString("N0"));
                lvNhapKho.Items.Add(item);
            }

            TinhTongTien();
            UpdateStatus("Đã thêm vào phiếu");
        }

        private void btnXoaChiTiet_Click(object sender, EventArgs e)
        {
            if (lvNhapKho.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dòng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            lvNhapKho.SelectedItems[0].Remove();
            TinhTongTien();
            UpdateStatus("Đã xóa dòng");
        }

        private void TinhTongTien()
        {
            decimal tong = 0;
            foreach (ListViewItem item in lvNhapKho.Items)
            {
                decimal thanhTien = 0;
                decimal.TryParse(item.SubItems[4].Text.Replace(",", ""), out thanhTien);
                tong += thanhTien;
            }
            lblTongTien.Text = tong.ToString("N0") + " VNĐ";
        }

        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            if (lvNhapKho.Items.Count == 0)
            {
                MessageBox.Show("Phiếu nhập chưa có sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboNhanVien.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var r = MessageBox.Show("Xác nhận nhập kho?", "Nhập kho", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes) return;

            try
            {
                // Đóng gói sang DataTable cho BLL.LuuPhieuNhap
                DataTable dtForBLL = new DataTable();
                dtForBLL.Columns.Add("MaSach", typeof(int));
                dtForBLL.Columns.Add("SoLuongNhap", typeof(int));
                dtForBLL.Columns.Add("DonGia", typeof(decimal));

                foreach (ListViewItem item in lvNhapKho.Items)
                {
                    var nr = dtForBLL.NewRow();
                    nr["MaSach"] = int.Parse(item.SubItems[0].Text);
                    nr["SoLuongNhap"] = int.Parse(item.SubItems[2].Text);
                    nr["DonGia"] = decimal.Parse(item.SubItems[3].Text.Replace(",", ""));
                    dtForBLL.Rows.Add(nr);
                }

                pnlProgressContainer.Visible = true;
                lblProgressStatus.Visible = true;
                progressBarNhapKho.Visible = true;
                progressBarNhapKho.Style = ProgressBarStyle.Marquee;
                UpdateStatus("Đang lưu phiếu nhập...");

                string maNV = Convert.ToString(cboNhanVien.SelectedValue);
                int maPN = nhapKhoBLL.LuuPhieuNhap(maNV, dtForBLL);

                txtMaPN.Text = maPN.ToString();
                progressBarNhapKho.Style = ProgressBarStyle.Continuous;
                progressBarNhapKho.Value = 100;
                lblProgressStatus.Text = "Đã lưu!";
                UpdateStatus("Lưu thành công");

                MessageBox.Show("Nhập kho thành công! Mã PN: " + maPN, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // reset phiếu
                lvNhapKho.Items.Clear();
                TinhTongTien();
                LoadSach();

                Thread.Sleep(600);
                pnlProgressContainer.Visible = false;
                lblProgressStatus.Visible = false;
                progressBarNhapKho.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nhập kho: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateStatus("Lỗi nhập kho");
                pnlProgressContainer.Visible = false;
                lblProgressStatus.Visible = false;
                progressBarNhapKho.Visible = false;
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvNhapKho.Items.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "Excel File (*.xlsx)|*.xlsx",
                    FileName = "PhieuNhapKho_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    // Build DataTable from ListView
                    DataTable dtExport = new DataTable();
                    dtExport.Columns.Add("MaSach", typeof(int));
                    dtExport.Columns.Add("TenSach", typeof(string));
                    dtExport.Columns.Add("SoLuongNhap", typeof(int));
                    dtExport.Columns.Add("DonGia", typeof(decimal));
                    dtExport.Columns.Add("ThanhTien", typeof(decimal));

                    foreach (ListViewItem item in lvNhapKho.Items)
                    {
                        var nr = dtExport.NewRow();
                        nr["MaSach"] = int.Parse(item.SubItems[0].Text);
                        nr["TenSach"] = item.SubItems[1].Text;
                        nr["SoLuongNhap"] = int.Parse(item.SubItems[2].Text);
                        nr["DonGia"] = decimal.Parse(item.SubItems[3].Text.Replace(",", ""));
                        nr["ThanhTien"] = decimal.Parse(item.SubItems[4].Text.Replace(",", ""));
                        dtExport.Rows.Add(nr);
                    }

                    pnlProgressContainer.Visible = true;
                    lblProgressStatus.Visible = true;
                    progressBarNhapKho.Visible = true;
                    lblProgressStatus.Text = "Đang xuất Excel...";
                    progressBarNhapKho.Style = ProgressBarStyle.Marquee;

                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        wb.Worksheets.Add(dtExport, "PhieuNhap");
                        var ws = wb.Worksheet("PhieuNhap");
                        ws.Columns().AdjustToContents();
                        ws.Row(1).Style.Font.Bold = true;
                        ws.Row(1).Style.Fill.BackgroundColor = XLColor.LightBlue;
                        wb.SaveAs(sfd.FileName);
                    }

                    progressBarNhapKho.Style = ProgressBarStyle.Continuous;
                    progressBarNhapKho.Value = 100;
                    lblProgressStatus.Text = "Xuất thành công!";
                    UpdateStatus("Xuất Excel OK");

                    Thread.Sleep(600);
                    pnlProgressContainer.Visible = false;
                    lblProgressStatus.Visible = false;
                    progressBarNhapKho.Visible = false;

                    MessageBox.Show("Xuất Excel thành công!\n" + sfd.FileName, "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi export: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateStatus("Lỗi export");
                pnlProgressContainer.Visible = false;
                lblProgressStatus.Visible = false;
                progressBarNhapKho.Visible = false;
            }
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog { Filter = "Excel File|*.xlsx" };
                if (ofd.ShowDialog() != DialogResult.OK) return;

                DataTable dtImport = new DataTable();
                using (XLWorkbook wb = new XLWorkbook(ofd.FileName))
                {
                    var ws = wb.Worksheet(1);
                    bool firstRow = true;
                    foreach (var row in ws.RowsUsed())
                    {
                        if (firstRow)
                        {
                            foreach (var cell in row.Cells()) dtImport.Columns.Add(cell.Value.ToString());
                            firstRow = false;
                        }
                        else
                        {
                            dtImport.Rows.Add(row.Cells().Select(c => c.Value.ToString()).ToArray());
                        }
                    }
                }

                if (dtImport.Rows.Count == 0)
                {
                    MessageBox.Show("File không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                lvNhapKho.Items.Clear();
                foreach (DataRow r in dtImport.Rows)
                {
                    int maSach = Convert.ToInt32(r["MaSach"]);
                    string tenSach = Convert.ToString(r["TenSach"]);
                    int soLuong = Convert.ToInt32(r["SoLuongNhap"]);
                    decimal donGia = Convert.ToDecimal(r["DonGia"]);

                    var item = new ListViewItem(maSach.ToString());
                    item.SubItems.Add(tenSach);
                    item.SubItems.Add(soLuong.ToString());
                    item.SubItems.Add(donGia.ToString("N0"));
                    item.SubItems.Add((soLuong * donGia).ToString("N0"));
                    lvNhapKho.Items.Add(item);
                }

                TinhTongTien();
                UpdateStatus("Đã nhập dữ liệu từ Excel");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi import: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateStatus("Lỗi import");
            }
        }

        private void UpdateStatus(string text)
        {
            statusLabel.Text = text;
        }

        private void splitMain_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (!this.IsHandleCreated || (this.Site != null && this.Site.DesignMode)) return;
            var minLeft = 280;
            var minRight = 360;
            var total = splitMain.Width - splitMain.SplitterWidth;
            var left = splitMain.SplitterDistance;
            if (left < minLeft) splitMain.SplitterDistance = minLeft;
            else if (total - left < minRight) splitMain.SplitterDistance = total - minRight;
        }
    }
}
