using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using QLBanSach_DAL;

namespace QLBanSach_GUI.UserControls
{
    public partial class UC_DanhSachSach : UserControl
    {
        private DataTable _dt;
        private BindingSource _bs;
        private Timer _debounce;

        public UC_DanhSachSach()
        {
            InitializeComponent();

            _bs = new BindingSource();
            _debounce = new Timer { Interval = 250 };
            _debounce.Tick += (s, e) => { _debounce.Stop(); ApplyFilter(); };

            this.Load += UC_DanhSachSach_Load;
            this.txtTimKiem.TextChanged += (s, e) => { _debounce.Stop(); _debounce.Start(); };
            this.btnRefresh.Click += (s, e) => LoadData();
            this.btnExport.Click += (s, e) => ExportCsv();
            this.dgvSach.SelectionChanged += (s, e) => UpdatePreview();
        }

        private void UC_DanhSachSach_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                // Ưu tiên dùng DatabaseHelper cho DataTable + lọc nhanh
                string sql = "SELECT MaSach, TenSach, TacGia, TheLoai, DonGia, SoLuong, AnhBia FROM Sach";
                _dt = DatabaseHelper.ExecuteQuery(sql);

                _bs.DataSource = _dt;
                dgvSach.DataSource = _bs;

                if (dgvSach.Columns.Contains("DonGia"))
                    dgvSach.Columns["DonGia"].DefaultCellStyle.Format = "N0";

                UpdatePreview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string EscapeRowFilter(string value)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;
            return value.Replace("'", "''")
                        .Replace("[", "[[]")
                        .Replace("]", "[]]")
                        .Replace("%", "[%]")
                        .Replace("*", "[*]");
        }

        private void ApplyFilter()
        {
            if (_bs == null) return;
            var kw = (txtTimKiem.Text ?? string.Empty).Trim();
            if (string.IsNullOrEmpty(kw))
            {
                _bs.RemoveFilter();
                return;
            }

            var f = EscapeRowFilter(kw);
            _bs.Filter = $"TenSach LIKE '%{f}%' OR TacGia LIKE '%{f}%' OR TheLoai LIKE '%{f}%'";
        }

        private void UpdatePreview()
        {
            if (dgvSach.CurrentRow == null)
            {
                SetPreviewImage(null);
                return;
            }

            string path = null;
            try
            {
                if (dgvSach.Columns.Contains("AnhBia"))
                    path = dgvSach.CurrentRow.Cells["AnhBia"].Value?.ToString();
            }
            catch { }

            LoadImageSafe(path);
        }

        private void LoadImageSafe(string path)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
                {
                    SetPreviewImage(SystemIcons.Application.ToBitmap());
                    return;
                }

                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var ms = new MemoryStream())
                {
                    fs.CopyTo(ms);
                    using (var tmp = Image.FromStream(ms))
                    {
                        var clone = (Image)tmp.Clone();
                        SetPreviewImage(clone);
                    }
                }
            }
            catch
            {
                SetPreviewImage(SystemIcons.Application.ToBitmap());
            }
        }

        private void SetPreviewImage(Image img)
        {
            try
            {
                var old = pbCover.Image;
                pbCover.Image = null;
                if (old != null)
                {
                    try { old.Dispose(); } catch { }
                }
            }
            catch { }

            pbCover.Image = img;
        }

        private void ExportCsv()
        {
            try
            {
                using (var sfd = new SaveFileDialog
                {
                    Title = "Xuất danh sách sách",
                    Filter = "CSV|*.csv",
                    FileName = $"DanhSachSach_{DateTime.Now:yyyyMMddHHmmss}.csv"
                })
                {
                    if (sfd.ShowDialog() != DialogResult.OK) return;

                    var dv = _bs.List as DataView ?? _dt?.DefaultView;
                    if (dv == null || dv.Count == 0)
                    {
                        MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    var sb = new StringBuilder();
                    // header
                    for (int i = 0; i < dv.Table.Columns.Count; i++)
                    {
                        if (i > 0) sb.Append(",");
                        sb.Append(CsvEscape(dv.Table.Columns[i].ColumnName));
                    }
                    sb.AppendLine();
                    // rows
                    foreach (DataRowView rv in dv)
                    {
                        var row = rv.Row;
                        for (int i = 0; i < dv.Table.Columns.Count; i++)
                        {
                            if (i > 0) sb.Append(",");
                            sb.Append(CsvEscape(row[i]?.ToString() ?? ""));
                        }
                        sb.AppendLine();
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

        private static string CsvEscape(string s)
        {
            if (s.IndexOfAny(new[] { '"', ',', '\n', '\r' }) >= 0)
            {
                return "\"" + s.Replace("\"", "\"\"") + "\"";
            }
            return s;
        }

        // ========= NEW: Đổi ảnh bìa =========

        private void btnChangeCover_Click(object sender, EventArgs e)
        {
            if (dgvSach.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một cuốn sách.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!dgvSach.Columns.Contains("MaSach"))
            {
                MessageBox.Show("Không tìm thấy cột 'MaSach'.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int maSach;
            if (!int.TryParse(dgvSach.CurrentRow.Cells["MaSach"].Value?.ToString(), out maSach))
            {
                MessageBox.Show("Mã sách không hợp lệ.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string oldPath = null;
            if (dgvSach.Columns.Contains("AnhBia"))
                oldPath = dgvSach.CurrentRow.Cells["AnhBia"].Value?.ToString();

            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn ảnh bìa";
                ofd.Filter = "Ảnh|*.png;*.jpg;*.jpeg;*.bmp;*.gif";
                if (ofd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    var sourcePath = ofd.FileName;
                    var ext = Path.GetExtension(sourcePath)?.ToLowerInvariant();
                    if (string.IsNullOrEmpty(ext) ||
                        (ext != ".png" && ext != ".jpg" && ext != ".jpeg" && ext != ".bmp" && ext != ".gif"))
                    {
                        MessageBox.Show("Vui lòng chọn tệp ảnh hợp lệ.", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var folder = Path.Combine(Application.StartupPath, "Covers");
                    if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

                    var fileName = $"{Guid.NewGuid()}{ext}";
                    var destPath = Path.Combine(folder, fileName);
                    File.Copy(sourcePath, destPath, overwrite: false);

                    var sql = "UPDATE Sach SET AnhBia = @p WHERE MaSach = @id";
                    var p = new[]
                    {
                        new SqlParameter("@p", SqlDbType.NVarChar, 255) { Value = destPath },
                        new SqlParameter("@id", SqlDbType.Int) { Value = maSach }
                    };

                    DatabaseHelper.ExecuteNonQuery(sql, p);

                    // Refresh grid and keep selection
                    LoadData();
                    SelectRowByMaSach(maSach);
                    UpdatePreview();

                    // Try to delete the old file if different
                    if (!string.IsNullOrWhiteSpace(oldPath) &&
                        !string.Equals(oldPath, destPath, StringComparison.OrdinalIgnoreCase))
                    {
                        try { if (File.Exists(oldPath)) File.Delete(oldPath); } catch { }
                    }

                    MessageBox.Show("Cập nhật ảnh bìa thành công.", "Hoàn tất",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi cập nhật ảnh bìa: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SelectRowByMaSach(int maSach)
        {
            if (dgvSach.DataSource == null) return;
            foreach (DataGridViewRow r in dgvSach.Rows)
            {
                if (r.Cells["MaSach"].Value != null &&
                    int.TryParse(r.Cells["MaSach"].Value.ToString(), out int id) &&
                    id == maSach)
                {
                    r.Selected = true;
                    DataGridViewCell cell = null;
                    if (dgvSach.Columns.Contains("TenSach"))
                        cell = r.Cells["TenSach"];
                    else if (r.Cells.Count > 0)
                        cell = r.Cells[0];

                    if (cell != null) dgvSach.CurrentCell = cell;
                    if (r.Index >= 0) dgvSach.FirstDisplayedScrollingRowIndex = r.Index;
                    break;
                }
            }
        }
    }
}
