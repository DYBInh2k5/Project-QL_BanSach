using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLBanSach_DAL;

namespace QLBanSach_GUI.UserControls
{
    public partial class UC_DoiTra : UserControl
    {
        public int maHD { get; set; } = 0;

        private DataTable _dtHoaDonItems;
        private DataTable _dtTatCaSach;
        private BindingSource _bsHDItems;
        private BindingSource _bsAllBooks;

        public UC_DoiTra()
        {
            InitializeComponent();
            Load += UC_DoiTra_Load;

            // Wire handlers
            btnLoadHD.Click += (s, e) => { LoadSachHoaDon(); UpdateActionStates(); };
            txtSearchHD.TextChanged += (s, e) => { ApplyFilterHDItems(); UpdateActionStates(); };
            txtFindBook.TextChanged += (s, e) => ApplyFilterAllBooks();
            cbTheLoai.SelectedIndexChanged += (s, e) => ApplyFilterAllBooks();
            btnSetSLDoi.Click += (s, e) => { ApplySelectedExchangeQuantity(); UpdateActionStates(); };
            btnClearSelected.Click += (s, e) => { dgvSachDoiTra.ClearSelection(); UpdateActionStates(); };
            btnReset.Click += (s, e) => { ResetForm(); UpdateActionStates(); };
            btnExportCSV.Click += (s, e) => ExportExchangeCSV();
            btnXacNhan.Click += (s, e) => ConfirmExchange();

            dgvSachDoiTra.CellValueChanged += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    RecomputeSummary();
                    UpdateActionStates();
                }
            };
            dgvSachDoiTra.CurrentCellDirtyStateChanged += (s, e) =>
            {
                if (dgvSachDoiTra.IsCurrentCellDirty)
                    dgvSachDoiTra.CommitEdit(DataGridViewDataErrorContexts.Commit);
            };
            dgvSachDoiTra.SelectionChanged += (s, e) => UpdateActionStates();

            dgvSachDoiTra.CellValidating += (s, e) =>
            {
                if (e.RowIndex >= 0 && dgvSachDoiTra.Columns[e.ColumnIndex].Name == "DeNghiDoi")
                {
                    var row = (dgvSachDoiTra.Rows[e.RowIndex].DataBoundItem as DataRowView)?.Row;
                    if (row != null)
                    {
                        int maxAllow = Convert.ToInt32(row["SoLuongMua"]) - Convert.ToInt32(row["DaDoi"]);
                        int want;
                        if (!int.TryParse(Convert.ToString(e.FormattedValue), out want)) want = 0;
                        if (want < 0 || want > maxAllow)
                        {
                            e.Cancel = true;
                            MessageBox.Show($"Số lượng đổi phải từ 0 đến {maxAllow}.", "Ràng buộc",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            };
        }

        private void UC_DoiTra_Load(object sender, EventArgs e)
        {
            // Init default range: current month
            dtFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtTo.Value = DateTime.Today;

            // Preload nếu có maHD truyền vào
            if (maHD > 0) txtMaHD.Text = maHD.ToString();

            // Load dữ liệu
            LoadSachHoaDon();
            LoadTatCaSach();
            UpdateActionStates();
        }

        // Bật/tắt nút theo trạng thái dữ liệu/chọn dòng
        private void UpdateActionStates()
        {
            var hasHDData = _dtHoaDonItems != null && _dtHoaDonItems.Rows.Count > 0;

            // Có dòng được chọn trong lưới hóa đơn
            var hasSelection = dgvSachDoiTra.CurrentRow != null
                               && dgvSachDoiTra.CurrentRow.Index >= 0;

            btnSetSLDoi.Enabled = hasHDData && hasSelection;
            btnClearSelected.Enabled = hasHDData && hasSelection;

            // Có dữ liệu để xuất CSV
            btnExportCSV.Enabled = hasHDData;

            // Có ít nhất một dòng có DeNghiDoi > 0 thì mới cho xác nhận
            var canConfirm = hasHDData && _dtHoaDonItems.AsEnumerable()
                                .Any(r => SafeInt(r["DeNghiDoi"]) > 0);
            btnXacNhan.Enabled = canConfirm;
        }

        // LOAD SÁCH THUỘC HOÁ ĐƠN
        private void LoadSachHoaDon()
        {
            try
            {
                var pars = new System.Collections.Generic.List<SqlParameter>();
                string where = "";

                if (int.TryParse(txtMaHD.Text, out var id) && id > 0)
                {
                    where += " AND c.MaHD = @MaHD";
                    pars.Add(new SqlParameter("@MaHD", id));
                }
                else
                {
                    // fallback filter theo khoảng ngày
                    where += " AND h.NgayLap >= @from AND h.NgayLap < @toPlusOne";
                    pars.Add(new SqlParameter("@from", dtFrom.Value.Date));
                    pars.Add(new SqlParameter("@toPlusOne", dtTo.Value.Date.AddDays(1)));
                }

                if (!string.IsNullOrWhiteSpace(txtSearchHD.Text))
                {
                    where += " AND s.TenSach LIKE @kw";
                    pars.Add(new SqlParameter("@kw", "%" + txtSearchHD.Text.Trim() + "%"));
                }

                string sql = @"
                    SELECT 
                        c.MaSach,
                        s.TenSach,
                        c.SoLuong AS SoLuongMua,
                        ISNULL(dt.DaDoi,0) AS DaDoi,
                        CAST(0 AS INT) AS DeNghiDoi,
                        s.DonGia
                    FROM ChiTietHoaDon c
                    JOIN HoaDon h ON h.MaHD = c.MaHD
                    JOIN Sach s ON c.MaSach = s.MaSach
                    OUTER APPLY
                    (
                        SELECT ISNULL(SUM(ct.SoLuong),0) AS DaDoi
                        FROM ChiTietDoiTra ct
                        JOIN DoiTra d ON ct.MaDT = d.MaDT
                        WHERE d.MaHD = c.MaHD AND ct.MaSach = c.MaSach
                    ) dt
                    WHERE 1=1 " + where + @"
                    ORDER BY s.TenSach";

                _dtHoaDonItems = DatabaseHelper.ExecuteQuery(sql, pars.ToArray());
                _bsHDItems = new BindingSource { DataSource = _dtHoaDonItems };
                dgvSachDoiTra.DataSource = _bsHDItems;

                // Định dạng cột
                if (dgvSachDoiTra.Columns.Contains("DonGia"))
                    dgvSachDoiTra.Columns["DonGia"].DefaultCellStyle.Format = "N0";
                if (dgvSachDoiTra.Columns.Contains("DeNghiDoi"))
                    dgvSachDoiTra.Columns["DeNghiDoi"].ReadOnly = false;
                if (dgvSachDoiTra.Columns.Contains("DaDoi"))
                    dgvSachDoiTra.Columns["DaDoi"].ReadOnly = true;
                if (dgvSachDoiTra.Columns.Contains("SoLuongMua"))
                    dgvSachDoiTra.Columns["SoLuongMua"].ReadOnly = true;

                RecomputeSummary();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải sách hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // LOAD TẤT CẢ SÁCH
        private void LoadTatCaSach()
        {
            try
            {
                string sql = "SELECT MaSach, TenSach, TheLoai, DonGia, SoLuong FROM Sach ORDER BY TenSach";
                _dtTatCaSach = DatabaseHelper.ExecuteQuery(sql);
                _bsAllBooks = new BindingSource { DataSource = _dtTatCaSach };
                dgvTatCaSach.DataSource = _bsAllBooks;

                if (dgvTatCaSach.Columns.Contains("DonGia"))
                    dgvTatCaSach.Columns["DonGia"].DefaultCellStyle.Format = "N0";

                // Fill thể loại dropdown
                cbTheLoai.Items.Clear();
                cbTheLoai.Items.Add("(Tất cả)");
                var view = new DataView(_dtTatCaSach);
                var distinct = view.ToTable(true, "TheLoai");
                foreach (DataRow r in distinct.Rows)
                {
                    var tl = r["TheLoai"]?.ToString();
                    if (!string.IsNullOrEmpty(tl)) cbTheLoai.Items.Add(tl);
                }
                cbTheLoai.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải tất cả sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // FILTER TRONG HÓA ĐƠN
        private void ApplyFilterHDItems()
        {
            try
            {
                var kw = (txtSearchHD.Text ?? "").Trim();
                _bsHDItems.RemoveFilter();
                if (!string.IsNullOrEmpty(kw))
                {
                    var f = kw.Replace("'", "''");
                    _bsHDItems.Filter = $"TenSach LIKE '%{f}%'";
                }
            }
            catch { }
        }

        // FILTER TẤT CẢ SÁCH
        private void ApplyFilterAllBooks()
        {
            try
            {
                var kw = (txtFindBook.Text ?? "").Trim().Replace("'", "''");
                var tl = cbTheLoai.SelectedItem?.ToString();

                var sb = new StringBuilder();
                if (!string.IsNullOrEmpty(kw))
                    sb.Append($"TenSach LIKE '%{kw}%'");
                if (!string.IsNullOrEmpty(tl) && tl != "(Tất cả)")
                {
                    if (sb.Length > 0) sb.Append(" AND ");
                    sb.Append($"TheLoai = '{tl.Replace("'", "''")}'");
                }

                _bsAllBooks.RemoveFilter();
                if (sb.Length > 0) _bsAllBooks.Filter = sb.ToString();
            }
            catch { }
        }

        // SET SL ĐỔI/TRẢ CHO DÒNG ĐANG CHỌN
        private void ApplySelectedExchangeQuantity()
        {
            try
            {
                if (dgvSachDoiTra.CurrentRow == null) return;

                var row = (dgvSachDoiTra.CurrentRow.DataBoundItem as DataRowView)?.Row;
                if (row == null) return;

                var maxAllow = Convert.ToInt32(row["SoLuongMua"]) - Convert.ToInt32(row["DaDoi"]);
                var want = (int)numSLDoiTra.Value;
                if (want < 0) want = 0;
                if (want > maxAllow) want = maxAllow;

                row["DeNghiDoi"] = want;
                dgvSachDoiTra.Refresh();
                RecomputeSummary();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đặt số lượng đổi/trả: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // TÍNH TỔNG
        private void RecomputeSummary()
        {
            try
            {
                int tongSL = 0;
                decimal tongTien = 0;

                if (_dtHoaDonItems != null)
                {
                    foreach (DataRow r in _dtHoaDonItems.Rows)
                    {
                        var sl = SafeInt(r["DeNghiDoi"]);
                        var donGia = SafeDecimal(r["DonGia"]);
                        tongSL += sl;
                        tongTien += sl * donGia;
                    }
                }

                lblTongSL.Text = $"Tổng SL đổi: {tongSL:N0}";
                lblTongTien.Text = $"Tổng tiền: {tongTien:N0}";
            }
            catch { }
        }

        private int SafeInt(object o)
        {
            if (o == null || o == DBNull.Value) return 0;
            int v;
            return int.TryParse(o.ToString(), out v) ? v : 0;
        }

        private decimal SafeDecimal(object o)
        {
            if (o == null || o == DBNull.Value) return 0m;
            decimal v;
            return decimal.TryParse(o.ToString(), out v) ? v : 0m;
        }

        // XÁC NHẬN ĐỔI/TRẢ
        private void ConfirmExchange()
        {
            try
            {
                var dtSelected = _dtHoaDonItems?.Select("DeNghiDoi > 0");
                if (dtSelected == null || dtSelected.Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập số lượng đổi/trả cho ít nhất 1 dòng.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var lyDo = txtLyDo.Text.Trim();
                var ghiChu = txtGhiChu.Text.Trim();
                var kieuXuLy = rbTraHangHoanTien.Checked ? 1 : 0;

                int maHoaDon;
                if (!int.TryParse(txtMaHD.Text, out maHoaDon) || maHoaDon <= 0)
                {
                    MessageBox.Show("Vui lòng nhập mã hóa đơn hợp lệ.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var tran = conn.BeginTransaction())
                    {
                        try
                        {
                            var cmdDoiTra = new SqlCommand(@"
                                INSERT INTO DoiTra(MaHD, NgayDoi, LyDo, GhiChu, KieuXuLy)
                                VALUES (@MaHD, @NgayDoi, @LyDo, @GhiChu, @KieuXuLy);
                                SELECT CAST(SCOPE_IDENTITY() AS INT);", conn, tran);
                            cmdDoiTra.Parameters.AddWithValue("@MaHD", maHoaDon);
                            cmdDoiTra.Parameters.AddWithValue("@NgayDoi", DateTime.Now);
                            cmdDoiTra.Parameters.AddWithValue("@LyDo", string.IsNullOrWhiteSpace(lyDo) ? (object)DBNull.Value : lyDo);
                            cmdDoiTra.Parameters.AddWithValue("@GhiChu", string.IsNullOrWhiteSpace(ghiChu) ? (object)DBNull.Value : ghiChu);
                            cmdDoiTra.Parameters.AddWithValue("@KieuXuLy", kieuXuLy);
                            // Lấy MaDT đúng kiểu
                            var maDTObj = cmdDoiTra.ExecuteScalar();
                            var maDT = Convert.ToInt32(maDTObj);

                            foreach (var r in dtSelected)
                            {
                                var maSach = SafeInt(r["MaSach"]);
                                var soLuong = SafeInt(r["DeNghiDoi"]);
                                var donGia = SafeDecimal(r["DonGia"]);
                                var thanhTien = soLuong * donGia;

                                // Insert chi tiết với decimal đúng precision/scale
                                var cmdCT = new SqlCommand(@"
                                    INSERT INTO ChiTietDoiTra(MaDT, MaSach, SoLuong, DonGia, ThanhTien)
                                    VALUES (@MaDT, @MaSach, @SoLuong, @DonGia, @ThanhTien);", conn, tran);

                                cmdCT.Parameters.AddWithValue("@MaDT", maDT);
                                cmdCT.Parameters.AddWithValue("@MaSach", maSach);
                                cmdCT.Parameters.AddWithValue("@SoLuong", soLuong);

                                var pDonGia = cmdCT.Parameters.Add("@DonGia", SqlDbType.Decimal);
                                pDonGia.Precision = 18; pDonGia.Scale = 2; pDonGia.Value = donGia;

                                var pThanhTien = cmdCT.Parameters.Add("@ThanhTien", SqlDbType.Decimal);
                                pThanhTien.Precision = 18; pThanhTien.Scale = 2; pThanhTien.Value = thanhTien;

                                cmdCT.ExecuteNonQuery();

                                if (kieuXuLy == 1)
                                {
                                    var cmdUpdateStock = new SqlCommand(@"
                                        UPDATE Sach SET SoLuong = ISNULL(SoLuong,0) + @SL
                                        WHERE MaSach = @MaSach;", conn, tran);
                                    cmdUpdateStock.Parameters.AddWithValue("@SL", soLuong);
                                    cmdUpdateStock.Parameters.AddWithValue("@MaSach", maSach);
                                    cmdUpdateStock.ExecuteNonQuery();
                                }
                            }

                            tran.Commit();
                            MessageBox.Show("Đã xác nhận đổi/trả thành công.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ResetForm();
                            UpdateActionStates();
                        }
                        catch (Exception exTran)
                        {
                            try { tran.Rollback(); } catch { }
                            MessageBox.Show("Lỗi lưu đổi/trả: " + exTran.Message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // XUẤT CSV
        private void ExportExchangeCSV()
        {
            try
            {
                if (_dtHoaDonItems == null || _dtHoaDonItems.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (var sfd = new SaveFileDialog
                {
                    Title = "Xuất biên bản đổi/trả",
                    Filter = "CSV|*.csv",
                    FileName = $"DoiTra_{DateTime.Now:yyyyMMddHHmmss}.csv"
                })
                {
                    if (sfd.ShowDialog() != DialogResult.OK) return;

                    var sb = new StringBuilder();
                    sb.AppendLine("MaSach,TenSach,SoLuongMua,DaDoi,DeNghiDoi,DonGia,ThanhTien");
                    foreach (DataRow r in _dtHoaDonItems.Rows)
                    {
                        var deNghi = SafeInt(r["DeNghiDoi"]);
                        var donGia = SafeDecimal(r["DonGia"]);
                        var thanhTien = deNghi * donGia;
                        sb.AppendLine(string.Join(",",
                            CsvEscape(r["MaSach"]),
                            CsvEscape(r["TenSach"]),
                            CsvEscape(r["SoLuongMua"]),
                            CsvEscape(r["DaDoi"]),
                            CsvEscape(deNghi),
                            CsvEscape(donGia),
                            CsvEscape(thanhTien)
                        ));
                    }

                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show("Xuất CSV thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất CSV: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string CsvEscape(object o)
        {
            var s = o?.ToString() ?? "";
            if (s.IndexOfAny(new[] { '"', ',', '\n', '\r' }) >= 0)
                return "\"" + s.Replace("\"", "\"\"") + "\"";
            return s;
        }

        // LÀM MỚI
        private void ResetForm()
        {
            try
            {
                numSLDoiTra.Value = 0;
                txtLyDo.Clear();
                txtGhiChu.Clear();
                rbDoiSach.Checked = true;

                if (_dtHoaDonItems != null)
                {
                    foreach (DataRow r in _dtHoaDonItems.Rows)
                        r["DeNghiDoi"] = 0;
                }
                dgvSachDoiTra.ClearSelection();
                RecomputeSummary();
            }
            catch { }
        }

        private void grpLyDo_Enter(object sender, EventArgs e)
        {

        }
    }
}
