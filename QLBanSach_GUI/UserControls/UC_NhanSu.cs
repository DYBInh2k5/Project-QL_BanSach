using QLBanSach_DAL;
using QLBanSach_DTO;
using QLBanSach_GUI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBanSach_GUI.UserControls
{
    public partial class UC_NhanSu : UserControl
    {
        private string selectedNV = "";   // Lưu mã nhân viên đang chọn
        private readonly NhanVienDAL nvDal = new NhanVienDAL();

        private const string AttachTable = "NhanSuTaiLieu";
        private const string AttachRootFolder = "HRDocs";

        public UC_NhanSu()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e) { }
        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e) { }

        private void UC_NhanSu_Load(object sender, EventArgs e)
        {
            EnsureAttachmentTable();
            ConfigureAttachmentListView();
            LoadTreeNhanVien();
            SetupGrid();
        }

        private void SetupGrid()
        {
            dgvData.Columns.Clear();
            dgvData.AutoGenerateColumns = true;
            dgvData.AllowUserToAddRows = false;
            dgvData.RowHeadersVisible = false;
        }

        private void ConfigureAttachmentListView()
        {
            // Configure ListView for thumbnail view when showing "Tài liệu"
            lvData.Visible = false;
            lvData.MultiSelect = true;
            lvData.View = View.LargeIcon;
            imageList1.ImageSize = new Size(64, 64);
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            lvData.LargeImageList = imageList1;
            // Double-click to open file
            lvData.DoubleClick -= LvData_DoubleClick;
            lvData.DoubleClick += LvData_DoubleClick;
        }

        private void LoadTreeNhanVien()
        {
            tvMenu.Nodes.Clear();
            DataTable dt = DatabaseHelper.ExecuteQuery("SELECT MaNV, HoTen FROM NhanVien ORDER BY HoTen");
            foreach (DataRow row in dt.Rows)
            {
                TreeNode nvNode = new TreeNode(row["HoTen"].ToString());
                nvNode.Tag = row["MaNV"].ToString();
                nvNode.Nodes.Add("Lý lịch");
                nvNode.Nodes.Add("Bằng cấp");
                nvNode.Nodes.Add("Kinh nghiệm");
                nvNode.Nodes.Add("Công tác");
                nvNode.Nodes.Add("Tài liệu"); // NEW: attachments
                tvMenu.Nodes.Add(nvNode);
            }
            tvMenu.ExpandAll();
        }

        private void tvMenu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                selectedNV = e.Node.Tag.ToString();
                dgvData.DataSource = null;
                lvData.Visible = false;
                dgvData.Visible = true;
                return;
            }

            selectedNV = e.Node.Parent.Tag.ToString();
            string selectedMenu = e.Node.Text;

            // Switch view depending on node
            if (selectedMenu == "Tài liệu")
            {
                dgvData.Visible = false;
                lvData.Visible = true;
                LoadTaiLieu();
                return;
            }
            else
            {
                lvData.Visible = false;
                dgvData.Visible = true;
            }

            if (selectedMenu == "Lý lịch") LoadLyLich();
            if (selectedMenu == "Bằng cấp") LoadBangCap();
            if (selectedMenu == "Kinh nghiệm") LoadKinhNghiem();
            if (selectedMenu == "Công tác") LoadCongTac();
        }

        private void LoadLyLich()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Thông tin");
            dt.Columns.Add("Giá trị");

            string sql = "SELECT HoTen, TaiKhoan, VaiTro, DienThoai, Email FROM NhanVien WHERE MaNV = @MaNV";
            var p = new SqlParameter[] { new SqlParameter("@MaNV", selectedNV) };
            DataTable src = DatabaseHelper.ExecuteQuery(sql, p);
            if (src.Rows.Count == 0)
            {
                dgvData.DataSource = dt;
                return;
            }

            DataRow r = src.Rows[0];
            dt.Rows.Add("Họ tên", r["HoTen"]?.ToString() ?? "");
            dt.Rows.Add("Tài khoản", r["TaiKhoan"]?.ToString() ?? "");
            dt.Rows.Add("Vai trò", r["VaiTro"]?.ToString() ?? "");
            dt.Rows.Add("Điện thoại", r["DienThoai"]?.ToString() ?? "");
            dt.Rows.Add("Email", r["Email"]?.ToString() ?? "");

            dgvData.DataSource = dt;
        }

        private void LoadBangCap()
        {
            string sql = "SELECT TenBang, NoiCap, NgayCap FROM BangCap WHERE MaNV = @MaNV";
            var p = new SqlParameter[] { new SqlParameter("@MaNV", selectedNV) };
            DataTable dt = DatabaseHelper.ExecuteQuery(sql, p);
            if (dt.Columns.Contains("NgayCap"))
            {
                dt.Columns.Add("NgayCapText", typeof(string));
                foreach (DataRow r in dt.Rows)
                {
                    DateTime tmp;
                    r["NgayCapText"] = DateTime.TryParse(r["NgayCap"]?.ToString(), out tmp) ? tmp.ToString("dd/MM/yyyy") : "";
                }
                dt.Columns.Remove("NgayCap");
                dt.Columns["NgayCapText"].ColumnName = "Ngày cấp";
            }
            dgvData.DataSource = dt;
        }

        private void LoadKinhNghiem()
        {
            string sql = "SELECT NoiLam, ViTri, SoNam FROM KinhNghiem WHERE MaNV = @MaNV";
            var p = new SqlParameter[] { new SqlParameter("@MaNV", selectedNV) };
            DataTable dt = DatabaseHelper.ExecuteQuery(sql, p);
            dgvData.DataSource = dt;
        }

        private void LoadCongTac()
        {
            string sql = "SELECT NoiCongTac, ChucVu, TuNgay, DenNgay FROM LichSuCongTac WHERE MaNV = @MaNV";
            var p = new SqlParameter[] { new SqlParameter("@MaNV", selectedNV) };
            DataTable dt = DatabaseHelper.ExecuteQuery(sql, p);
            if (dt.Columns.Contains("TuNgay"))
            {
                dt.Columns.Add("TuNgayText", typeof(string));
                dt.Columns.Add("DenNgayText", typeof(string));
                foreach (DataRow r in dt.Rows)
                {
                    DateTime tu, den;
                    r["TuNgayText"] = DateTime.TryParse(r["TuNgay"]?.ToString(), out tu) ? tu.ToString("dd/MM/yyyy") : "";
                    r["DenNgayText"] = DateTime.TryParse(r["DenNgay"]?.ToString(), out den) ? den.ToString("dd/MM/yyyy") : "";
                }
                dt.Columns.Remove("TuNgay");
                dt.Columns.Remove("DenNgay");
                dt.Columns["TuNgayText"].ColumnName = "Từ ngày";
                dt.Columns["DenNgayText"].ColumnName = "Đến ngày";
            }
            dgvData.DataSource = dt;
        }

        private void lvData_SelectedIndexChanged(object sender, EventArgs e) { }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string kw = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(kw))
            {
                LoadTreeNhanVien();
                return;
            }

            string sql = "SELECT MaNV, HoTen FROM NhanVien WHERE HoTen LIKE @kw ORDER BY HoTen";
            var p = new SqlParameter[] { new SqlParameter("@kw", "%" + kw + "%") };
            DataTable dt = DatabaseHelper.ExecuteQuery(sql, p);

            tvMenu.Nodes.Clear();
            foreach (DataRow row in dt.Rows)
            {
                TreeNode nvNode = new TreeNode(row["HoTen"].ToString());
                nvNode.Tag = row["MaNV"].ToString();
                nvNode.Nodes.Add("Lý lịch");
                nvNode.Nodes.Add("Bằng cấp");
                nvNode.Nodes.Add("Kinh nghiệm");
                nvNode.Nodes.Add("Công tác");
                nvNode.Nodes.Add("Tài liệu"); // NEW
                tvMenu.Nodes.Add(nvNode);
            }
            tvMenu.ExpandAll();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            LoadTreeNhanVien();
            dgvData.DataSource = null;
            lvData.Items.Clear();
            lvData.Visible = false;
            dgvData.Visible = true;
        }

        private void btnAddNV_Click(object sender, EventArgs e)
        {
            using (FrmNhanVienEdit f = new FrmNhanVienEdit())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    LoadTreeNhanVien();
                }
            }
        }

        private void btnEditNV_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedNV))
            {
                MessageBox.Show("Vui lòng chọn nhân viên ở cây bên trái.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var nv = nvDal.GetNhanVienById(selectedNV);
            if (nv == null)
            {
                MessageBox.Show("Không tìm thấy nhân viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (FrmNhanVienEdit f = new FrmNhanVienEdit(nv))
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    LoadTreeNhanVien();
                }
            }
        }

        private void btnDeleteNV_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedNV))
            {
                MessageBox.Show("Vui lòng chọn nhân viên để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var r = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No) return;

            string sql = "DELETE FROM NhanVien WHERE MaNV = @MaNV";
            var p = new SqlParameter[] { new SqlParameter("@MaNV", selectedNV) };
            try
            {
                int affected = DatabaseHelper.ExecuteNonQuery(sql, p);
                if (affected > 0)
                {
                    MessageBox.Show("Xóa thành công.", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTreeNhanVien();
                    dgvData.DataSource = null;
                    lvData.Items.Clear();
                }
                else
                    MessageBox.Show("Xóa không thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvData.DataSource == null) return;
            if (dgvData.Columns.Count == 2 && dgvData.Columns[0].HeaderText == "Thông tin")
            {
                var field = dgvData.Rows[e.RowIndex].Cells[0].Value?.ToString();
                var value = dgvData.Rows[e.RowIndex].Cells[1].Value?.ToString();
                MessageBox.Show($"Sửa trường '{field}' (giá trị hiện tại: {value}) — mở dialog sửa.", "Sửa",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ====== NEW: Attachments (Tài liệu) ======

        private void EnsureAttachmentTable()
        {
            string sql = @"
                IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = N'NhanSuTaiLieu')
                BEGIN
                    CREATE TABLE NhanSuTaiLieu
                    (
                        Id INT IDENTITY(1,1) PRIMARY KEY,
                        MaNV NVARCHAR(10) NOT NULL,
                        Ten NVARCHAR(255) NOT NULL,
                        FilePath NVARCHAR(260) NOT NULL,
                        Loai NVARCHAR(50) NULL,
                        NgayThem DATETIME NOT NULL DEFAULT(GETDATE())
                    );
                    CREATE INDEX IX_NhanSuTaiLieu_MaNV ON NhanSuTaiLieu(MaNV);
                END";
            try
            {
                DatabaseHelper.ExecuteNonQuery(sql);
            }
            catch { /* ignore if no rights */ }
        }

        private void LoadTaiLieu()
        {
            if (string.IsNullOrEmpty(selectedNV)) return;

            lvData.BeginUpdate();
            try
            {
                lvData.Items.Clear();

                var p = new[] { new SqlParameter("@MaNV", selectedNV) };
                string sql = $"SELECT Id, Ten, FilePath, Loai, NgayThem FROM {AttachTable} WHERE MaNV = @MaNV ORDER BY NgayThem DESC";
                var dt = DatabaseHelper.ExecuteQuery(sql, p);

                // reset the image list (keep default icons once added)
                var keys = new HashSet<string>(imageList1.Images.Keys.Cast<string>(), StringComparer.OrdinalIgnoreCase);

                foreach (DataRow r in dt.Rows)
                {
                    int id = Convert.ToInt32(r["Id"]);
                    string ten = Convert.ToString(r["Ten"]);
                    string path = Convert.ToString(r["FilePath"]);
                    string loai = Convert.ToString(r["Loai"]);

                    string imgKey = GetImageKeyForFile(path, loai);
                    if (!keys.Contains(imgKey))
                    {
                        var iconImg = BuildThumbnailForFile(path, loai);
                        imageList1.Images.Add(imgKey, iconImg);
                        keys.Add(imgKey);
                    }

                    var item = new ListViewItem(ten)
                    {
                        ImageKey = imgKey,
                        Tag = new AttachmentTag { Id = id, FilePath = path }
                    };
                    lvData.Items.Add(item);
                }
            }
            finally
            {
                lvData.EndUpdate();
            }
        }

        private class AttachmentTag
        {
            public int Id { get; set; }
            public string FilePath { get; set; }
        }

        private static readonly string[] ImageExts = new[] { ".png", ".jpg", ".jpeg", ".bmp", ".gif" };

        private string GetImageKeyForFile(string path, string loai)
        {
            string ext = "";
            try { ext = Path.GetExtension(path)?.ToLowerInvariant() ?? ""; } catch { }
            if (!string.IsNullOrEmpty(loai)) return $"type:{loai.ToLowerInvariant()}";
            if (!string.IsNullOrEmpty(ext)) return $"ext:{ext}";
            return "default";
        }

        private Image BuildThumbnailForFile(string path, string loai)
        {
            try
            {
                var ext = Path.GetExtension(path)?.ToLowerInvariant();
                if (!string.IsNullOrEmpty(ext) && ImageExts.Contains(ext))
                {
                    // Build image thumbnail
                    using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (var img = Image.FromStream(fs))
                    {
                        return new Bitmap(img, new Size(64, 64));
                    }
                }
            }
            catch { /* fall back */ }

            // Fallback icons by type
            if (!string.IsNullOrEmpty(loai))
            {
                if (loai.IndexOf("pdf", StringComparison.OrdinalIgnoreCase) >= 0) return SystemIcons.Shield.ToBitmap();
                if (loai.IndexOf("word", StringComparison.OrdinalIgnoreCase) >= 0) return SystemIcons.Information.ToBitmap();
                if (loai.IndexOf("excel", StringComparison.OrdinalIgnoreCase) >= 0) return SystemIcons.Question.ToBitmap();
            }

            // Fallback by extension
            try
            {
                var ext = (Path.GetExtension(path) ?? "").ToLowerInvariant();
                if (ext == ".pdf") return SystemIcons.Shield.ToBitmap();
                if (ext == ".doc" || ext == ".docx") return SystemIcons.Information.ToBitmap();
                if (ext == ".xls" || ext == ".xlsx") return SystemIcons.Question.ToBitmap();
                if (ext == ".txt") return SystemIcons.Asterisk.ToBitmap();
            }
            catch { }

            return SystemIcons.Application.ToBitmap();
        }

        private void btnAddTaiLieu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedNV))
            {
                MessageBox.Show("Vui lòng chọn nhân viên ở cây bên trái.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var ofd = new OpenFileDialog
            {
                Title = "Chọn tài liệu đính kèm",
                Filter = "Tất cả|*.*|Ảnh|*.png;*.jpg;*.jpeg;*.bmp;*.gif|PDF|*.pdf|Word|*.doc;*.docx|Excel|*.xls;*.xlsx",
                Multiselect = true
            })
            {
                if (ofd.ShowDialog() != DialogResult.OK) return;

                string empFolder = Path.Combine(Application.StartupPath, AttachRootFolder, selectedNV);
                Directory.CreateDirectory(empFolder);

                int added = 0;
                foreach (var src in ofd.FileNames)
                {
                    try
                    {
                        string dest = Path.Combine(empFolder, Path.GetFileName(src));
                        // Avoid overwrite
                        dest = EnsureUniquePath(dest);

                        File.Copy(src, dest, overwrite: false);

                        string loai = DetectLoaiFromExtension(Path.GetExtension(dest));
                        string ten = Path.GetFileName(dest);

                        string sql = $@"INSERT INTO {AttachTable}(MaNV, Ten, FilePath, Loai) 
                                        VALUES(@MaNV, @Ten, @FilePath, @Loai)";
                        var p = new[]
                        {
                            new SqlParameter("@MaNV", selectedNV),
                            new SqlParameter("@Ten", ten),
                            new SqlParameter("@FilePath", dest),
                            new SqlParameter("@Loai", (object)loai ?? DBNull.Value)
                        };

                        DatabaseHelper.ExecuteNonQuery(sql, p);
                        added++;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể thêm tài liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (added > 0)
                {
                    LoadTaiLieu();
                }
            }
        }

        private string DetectLoaiFromExtension(string ext)
        {
            if (string.IsNullOrEmpty(ext)) return null;
            ext = ext.ToLowerInvariant();
            if (ImageExts.Contains(ext)) return "Image";
            if (ext == ".pdf") return "PDF";
            if (ext == ".doc" || ext == ".docx") return "Word";
            if (ext == ".xls" || ext == ".xlsx") return "Excel";
            if (ext == ".txt") return "Text";
            return ext.Trim('.');
        }

        private string EnsureUniquePath(string path)
        {
            if (!File.Exists(path)) return path;
            var dir = Path.GetDirectoryName(path);
            var name = Path.GetFileNameWithoutExtension(path);
            var ext = Path.GetExtension(path);
            int i = 1;
            string candidate;
            do
            {
                candidate = Path.Combine(dir, $"{name} ({i}){ext}");
                i++;
            } while (File.Exists(candidate));
            return candidate;
        }

        private void btnOpenTaiLieu_Click(object sender, EventArgs e)
        {
            if (lvData.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một tài liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var tag = lvData.SelectedItems[0].Tag as AttachmentTag;
            if (tag == null || string.IsNullOrWhiteSpace(tag.FilePath) || !File.Exists(tag.FilePath))
            {
                MessageBox.Show("Không tìm thấy tệp trên đĩa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                Process.Start(new ProcessStartInfo(tag.FilePath) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở tệp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteTaiLieu_Click(object sender, EventArgs e)
        {
            if (lvData.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn tài liệu cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var r = MessageBox.Show("Xóa các tài liệu đã chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No) return;

            int deleted = 0;
            foreach (ListViewItem it in lvData.SelectedItems)
            {
                var tag = it.Tag as AttachmentTag;
                if (tag == null) continue;

                try
                {
                    var p = new[] { new SqlParameter("@Id", tag.Id) };
                    DatabaseHelper.ExecuteNonQuery($"DELETE FROM {AttachTable} WHERE Id = @Id", p);
                    // Try delete physical file
                    try { if (!string.IsNullOrWhiteSpace(tag.FilePath) && File.Exists(tag.FilePath)) File.Delete(tag.FilePath); } catch { }
                    deleted++;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (deleted > 0) LoadTaiLieu();
        }

        private void LvData_DoubleClick(object sender, EventArgs e)
        {
            btnOpenTaiLieu_Click(sender, e);
        }

        // ====== Inline small dialogs (no separate forms required) ======

        private Form CreateBangCapDialog()
        {
            var f = new Form
            {
                Text = "Thêm bằng cấp",
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                ClientSize = new Size(380, 180)
            };

            var lblTenBang = new Label { Text = "Tên bằng:", Left = 10, Top = 15, Width = 100 };
            var txtTenBang = new TextBox { Name = "txtTenBang", Left = 120, Top = 12, Width = 230 };

            var lblNoiCap = new Label { Text = "Nơi cấp:", Left = 10, Top = 50, Width = 100 };
            var txtNoiCap = new TextBox { Name = "txtNoiCap", Left = 120, Top = 47, Width = 230 };

            var lblNgayCap = new Label { Text = "Ngày cấp:", Left = 10, Top = 85, Width = 100 };
            var dtNgayCap = new DateTimePicker { Name = "dtNgayCap", Left = 120, Top = 82, Width = 230, Format = DateTimePickerFormat.Custom, CustomFormat = "dd/MM/yyyy" };

            var btnOK = new Button { Text = "OK", DialogResult = DialogResult.OK, Left = 200, Top = 120, Width = 70 };
            var btnCancel = new Button { Text = "Hủy", DialogResult = DialogResult.Cancel, Left = 280, Top = 120, Width = 70 };

            f.Controls.AddRange(new Control[] { lblTenBang, txtTenBang, lblNoiCap, txtNoiCap, lblNgayCap, dtNgayCap, btnOK, btnCancel });
            f.AcceptButton = btnOK;
            f.CancelButton = btnCancel;
            return f;
        }

        private Form CreateKinhNghiemDialog()
        {
            var f = new Form
            {
                Text = "Thêm kinh nghiệm",
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                ClientSize = new Size(380, 180)
            };

            var lblNoiLam = new Label { Text = "Nơi làm:", Left = 10, Top = 15, Width = 100 };
            var txtNoiLam = new TextBox { Name = "txtNoiLam", Left = 120, Top = 12, Width = 230 };

            var lblViTri = new Label { Text = "Vị trí:", Left = 10, Top = 50, Width = 100 };
            var txtViTri = new TextBox { Name = "txtViTri", Left = 120, Top = 47, Width = 230 };

            var lblSoNam = new Label { Text = "Số năm:", Left = 10, Top = 85, Width = 100 };
            var numSoNam = new NumericUpDown { Name = "numSoNam", Left = 120, Top = 82, Width = 100, Minimum = 0, Maximum = 60, Value = 1 };

            var btnOK = new Button { Text = "OK", DialogResult = DialogResult.OK, Left = 200, Top = 120, Width = 70 };
            var btnCancel = new Button { Text = "Hủy", DialogResult = DialogResult.Cancel, Left = 280, Top = 120, Width = 70 };

            f.Controls.AddRange(new Control[] { lblNoiLam, txtNoiLam, lblViTri, txtViTri, lblSoNam, numSoNam, btnOK, btnCancel });
            f.AcceptButton = btnOK;
            f.CancelButton = btnCancel;
            return f;
        }

        private Form CreateCongTacDialog()
        {
            var f = new Form
            {
                Text = "Thêm công tác",
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                ClientSize = new Size(420, 220)
            };

            var lblNoiCT = new Label { Text = "Nơi công tác:", Left = 10, Top = 15, Width = 110 };
            var txtNoiCT = new TextBox { Name = "txtNoiCongTac", Left = 130, Top = 12, Width = 260 };

            var lblChucVu = new Label { Text = "Chức vụ:", Left = 10, Top = 50, Width = 110 };
            var txtChucVu = new TextBox { Name = "txtChucVu", Left = 130, Top = 47, Width = 260 };

            var lblTuNgay = new Label { Text = "Từ ngày:", Left = 10, Top = 85, Width = 110 };
            var dtTuNgay = new DateTimePicker { Name = "dtTuNgay", Left = 130, Top = 82, Width = 120, Format = DateTimePickerFormat.Custom, CustomFormat = "dd/MM/yyyy" };

            var lblDenNgay = new Label { Text = "Đến ngày:", Left = 260, Top = 85, Width = 110 };
            var dtDenNgay = new DateTimePicker { Name = "dtDenNgay", Left = 270, Top = 82, Width = 120, Format = DateTimePickerFormat.Custom, CustomFormat = "dd/MM/yyyy" };

            var btnOK = new Button { Text = "OK", DialogResult = DialogResult.OK, Left = 240, Top = 130, Width = 70 };
            var btnCancel = new Button { Text = "Hủy", DialogResult = DialogResult.Cancel, Left = 320, Top = 130, Width = 70 };

            f.Controls.AddRange(new Control[] { lblNoiCT, txtNoiCT, lblChucVu, txtChucVu, lblTuNgay, dtTuNgay, lblDenNgay, dtDenNgay, btnOK, btnCancel });
            f.AcceptButton = btnOK;
            f.CancelButton = btnCancel;
            return f;
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e) { }

        private void btnThiDua_Click(object sender, EventArgs e)
        {
            var frmMain = this.FindForm() as QLBanSach_GUI.FrmMain;
            if (frmMain != null)
            {
                frmMain.GetType().GetMethod("OpenUserControl", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                    ?.Invoke(frmMain, new object[] { new QLBanSach_GUI.UserControls.UC_ThiDua() });
            }
            else
            {
                var uc = new QLBanSach_GUI.UserControls.UC_ThiDua();
                uc.Dock = DockStyle.Fill;
                panelRight.Controls.Clear();
                panelRight.Controls.Add(uc);
            }
        }

        private bool EnsureNhanVienSelected()
        {
            if (string.IsNullOrEmpty(selectedNV))
            {
                MessageBox.Show("Vui lòng chọn nhân viên ở cây bên trái.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnAddBangCap_Click(object sender, EventArgs e)
        {
            if (!EnsureNhanVienSelected()) return;

            using (var f = CreateBangCapDialog())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    var tenBang = ((TextBox)f.Controls["txtTenBang"]).Text.Trim();
                    var noiCap = ((TextBox)f.Controls["txtNoiCap"]).Text.Trim();
                    var ngayCap = ((DateTimePicker)f.Controls["dtNgayCap"]).Value.Date;

                    if (string.IsNullOrEmpty(tenBang))
                    {
                        MessageBox.Show("Vui lòng nhập tên bằng.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    const string sql = "INSERT INTO BangCap (MaNV, TenBang, NoiCap, NgayCap) VALUES (@MaNV, @TenBang, @NoiCap, @NgayCap)";
                    var p = new[]
                    {
                        new SqlParameter("@MaNV", selectedNV),
                        new SqlParameter("@TenBang", tenBang),
                        new SqlParameter("@NoiCap", (object)noiCap ?? DBNull.Value),
                        new SqlParameter("@NgayCap", ngayCap)
                    };

                    try
                    {
                        int n = DatabaseHelper.ExecuteNonQuery(sql, p);
                        if (n > 0)
                        {
                            MessageBox.Show("Thêm bằng cấp thành công.", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadBangCap();
                        }
                        else
                            MessageBox.Show("Không thể thêm bằng cấp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi thêm bằng cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnAddKinhNghiem_Click(object sender, EventArgs e)
        {
            if (!EnsureNhanVienSelected()) return;

            using (var f = CreateKinhNghiemDialog())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    var noiLam = ((TextBox)f.Controls["txtNoiLam"]).Text.Trim();
                    var viTri = ((TextBox)f.Controls["txtViTri"]).Text.Trim();
                    var soNam = (int)((NumericUpDown)f.Controls["numSoNam"]).Value;

                    if (string.IsNullOrEmpty(noiLam))
                    {
                        MessageBox.Show("Vui lòng nhập nơi làm.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    const string sql = "INSERT INTO KinhNghiem (MaNV, NoiLam, ViTri, SoNam) VALUES (@MaNV, @NoiLam, @ViTri, @SoNam)";
                    var p = new[]
                    {
                        new SqlParameter("@MaNV", selectedNV),
                        new SqlParameter("@NoiLam", noiLam),
                        new SqlParameter("@ViTri", (object)viTri ?? DBNull.Value),
                        new SqlParameter("@SoNam", soNam)
                    };

                    try
                    {
                        int n = DatabaseHelper.ExecuteNonQuery(sql, p);
                        if (n > 0)
                        {
                            MessageBox.Show("Thêm kinh nghiệm thành công.", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadKinhNghiem();
                        }
                        else
                            MessageBox.Show("Không thể thêm kinh nghiệm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi thêm kinh nghiệm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnAddCongTac_Click(object sender, EventArgs e)
        {
            if (!EnsureNhanVienSelected()) return;

            using (var f = CreateCongTacDialog())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    var noiCT = ((TextBox)f.Controls["txtNoiCongTac"]).Text.Trim();
                    var chucVu = ((TextBox)f.Controls["txtChucVu"]).Text.Trim();
                    var tuNgay = ((DateTimePicker)f.Controls["dtTuNgay"]).Value.Date;
                    var denNgay = ((DateTimePicker)f.Controls["dtDenNgay"]).Value.Date;

                    if (string.IsNullOrEmpty(noiCT))
                    {
                        MessageBox.Show("Vui lòng nhập nơi công tác.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (denNgay < tuNgay)
                    {
                        MessageBox.Show("Ngày kết thúc không được nhỏ hơn ngày bắt đầu.", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    const string sql = "INSERT INTO LichSuCongTac (MaNV, NoiCongTac, ChucVu, TuNgay, DenNgay) VALUES (@MaNV, @NoiCongTac, @ChucVu, @TuNgay, @DenNgay)";
                    var p = new[]
                    {
                        new SqlParameter("@MaNV", selectedNV),
                        new SqlParameter("@NoiCongTac", noiCT),
                        new SqlParameter("@ChucVu", (object)chucVu ?? DBNull.Value),
                        new SqlParameter("@TuNgay", tuNgay),
                        new SqlParameter("@DenNgay", denNgay)
                    };

                    try
                    {
                        int n = DatabaseHelper.ExecuteNonQuery(sql, p);
                        if (n > 0)
                        {
                            MessageBox.Show("Thêm công tác thành công.", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadCongTac();
                        }
                        else
                            MessageBox.Show("Không thể thêm công tác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi thêm công tác: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}