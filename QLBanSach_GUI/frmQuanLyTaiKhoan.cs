using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QLBanSach_GUI
{
    public partial class frmQuanLyTaiKhoan : Form
    {
        private readonly string connStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=QLBanSach;Integrated Security=True";
        private DataTable dt;
        private BindingSource _bs;
        private string _avatarPath;
        private Timer _searchDebounceTimer;

        // Define allowed roles here
        private static readonly string[] AllowedRoles = new[]
        {
            "Admin",
            "Nhân viên bán hàng",
            "Quản lý kho",
            "Kế toán",
            "Chăm sóc khách hàng",
            "Marketing"
        };

        public frmQuanLyTaiKhoan()
        {
            InitializeComponent();

            picAvatar.BorderStyle = BorderStyle.FixedSingle;
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.AllowDrop = true;
            picAvatar.DragEnter += (s, e) =>
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    var files = (string[])e.Data.GetData(DataFormats.FileDrop);
                    if (files != null && files.Length > 0 && IsImageFile(files[0]))
                        e.Effect = DragDropEffects.Copy;
                    else
                        e.Effect = DragDropEffects.None;
                }
            };
            picAvatar.DragDrop += (s, e) =>
            {
                try
                {
                    var files = (string[])e.Data.GetData(DataFormats.FileDrop);
                    if (files == null || files.Length == 0) return;
                    UpdateAvatarFromFile(files[0]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kéo-thả ảnh: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            dgvTaiKhoan.AutoGenerateColumns = true;
            dgvTaiKhoan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTaiKhoan.MultiSelect = false;
            dgvTaiKhoan.ReadOnly = true;
            dgvTaiKhoan.AllowUserToAddRows = false;
            dgvTaiKhoan.RowHeadersVisible = false;
            dgvTaiKhoan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvTaiKhoan.CellClick += dgvTaiKhoan_CellClick;
            dgvTaiKhoan.SelectionChanged += dgvTaiKhoan_SelectionChanged;

            tvRoleGroup.AfterSelect += tvRoleGroup_AfterSelect;
            lvAvatar.SelectedIndexChanged += lvAvatar_SelectedIndexChanged;

            _searchDebounceTimer = new Timer(this.components) { Interval = 250 };
            _searchDebounceTimer.Tick += (s, e) =>
            {
                _searchDebounceTimer.Stop();
                ApplySearchFilter();
            };

            this.FormClosed += (s, e) =>
            {
                try { _searchDebounceTimer?.Stop(); } catch { }
            };
        }

        private void frmQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            InitializeImageList();

            // Bind allowed roles to cbVaiTro (single binding only)
            cbVaiTro.DropDownStyle = ComboBoxStyle.DropDownList;
            cbVaiTro.Items.Clear();
            cbVaiTro.Items.AddRange(AllowedRoles);

            LoadDataGrid();
            LoadListView();
            LoadTreeView();
        }

        private void EnsureImageList()
        {
            if (this.components == null)
                this.components = new System.ComponentModel.Container();

            if (this.imageList1 == null)
                this.imageList1 = new ImageList(this.components);

            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(64, 64);
            imageList1.TransparentColor = Color.Transparent;
        }

        private void InitializeImageList()
        {
            EnsureImageList();
            imageList1.Images.Clear();

            var rm = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanLyTaiKhoan));

            Image adminImg = rm.GetObject("admin") as Image;
            if (adminImg == null)
            {
                try
                {
                    var adminPath = Path.Combine(Application.StartupPath, "Resources", "admin.png");
                    if (File.Exists(adminPath)) adminImg = Image.FromFile(adminPath);
                }
                catch { }
            }
            if (adminImg == null) adminImg = SystemIcons.Shield.ToBitmap();
            imageList1.Images.Add("admin", adminImg);

            Image userImg = rm.GetObject("user") as Image;
            if (userImg == null)
            {
                try
                {
                    var userPath = Path.Combine(Application.StartupPath, "Resources", "user.png");
                    if (File.Exists(userPath)) userImg = Image.FromFile(userPath);
                }
                catch { }
            }
            if (userImg == null) userImg = SystemIcons.Application.ToBitmap();
            imageList1.Images.Add("user", userImg);
        }

        private void LoadListView()
        {
            EnsureImageList();
            lvAvatar.LargeImageList = imageList1;

            lvAvatar.Items.Clear();
            var view = GetCurrentView();
            if (view == null) return;

            foreach (DataRowView rowv in view)
            {
                var row = rowv.Row;
                string name = Convert.ToString(row["HoTen"]);
                string role = Convert.ToString(row["VaiTro"]);
                string key = string.Equals(role, "Admin", StringComparison.OrdinalIgnoreCase) ? "admin" : "user";
                var ma = Convert.ToString(row["MaNV"]);

                var it = new ListViewItem(name) { ImageKey = key, Tag = ma };
                lvAvatar.Items.Add(it);
            }
        }

        private void LoadTreeView()
        {
            tvRoleGroup.Nodes.Clear();

            // "Tất cả"
            var allNode = new TreeNode("Tất cả") { Tag = "all" };
            tvRoleGroup.Nodes.Add(allNode);

            if (dt != null && dt.Rows.Count > 0)
            {
                var roles = dt.AsEnumerable()
                              .Select(r => (r["VaiTro"] ?? string.Empty).ToString())
                              .Where(s => !string.IsNullOrWhiteSpace(s))
                              .Distinct(StringComparer.OrdinalIgnoreCase)
                              .OrderBy(s => s);

                foreach (var role in roles)
                {
                    var roleNode = new TreeNode(role) { Tag = "role:" + role };
                    var rows = dt.AsEnumerable()
                                 .Where(r => string.Equals((r["VaiTro"] ?? "").ToString(), role, StringComparison.OrdinalIgnoreCase));
                    foreach (var r in rows)
                    {
                        var name = (r["HoTen"] ?? "").ToString();
                        var ma = (r["MaNV"] ?? "").ToString();
                        roleNode.Nodes.Add(new TreeNode(name) { Tag = "nv:" + ma });
                    }
                    tvRoleGroup.Nodes.Add(roleNode);
                }
            }

            tvRoleGroup.ExpandAll();
        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) FillDetailFromRow(dgvTaiKhoan.Rows[e.RowIndex]);
        }

        private void dgvTaiKhoan_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.CurrentRow != null)
            {
                FillDetailFromRow(dgvTaiKhoan.CurrentRow);
                btnThem.Enabled = false;
                btnSua.Enabled = true;
            }
            else
            {
                btnThem.Enabled = true;
                btnSua.Enabled = false;
            }
        }

        private void FillDetailFromRow(DataGridViewRow row)
        {
            if (row == null) return;

            string GetCell(string name) => dgvTaiKhoan.Columns.Contains(name) ? row.Cells[name].Value?.ToString() : null;

            txtMaNV.Text = GetCell("MaNV") ?? "";
            txtHoTen.Text = GetCell("HoTen") ?? "";
            txtSdt.Text = GetCell("DienThoai") ?? "";
            txtEmail.Text = GetCell("Email") ?? "";
            txtCCCD.Text = GetCell("CCCD") ?? "";
            txtTaiKhoan.Text = GetCell("TaiKhoan") ?? "";
            cbVaiTro.Text = GetCell("VaiTro") ?? "";

            DateTime ns, nt;
            if (dgvTaiKhoan.Columns.Contains("NgaySinh") && DateTime.TryParse(GetCell("NgaySinh"), out ns))
                dtNgaySinh.Value = ns;
            if (dgvTaiKhoan.Columns.Contains("NgayTao") && DateTime.TryParse(GetCell("NgayTao"), out nt))
                dtNgayTao.Value = nt;

            var path = GetCell("AvatarPath");
            LoadAvatarToPictureBox(path, picAvatar);
            _avatarPath = path;

            var tt = GetCell("TrangThai");
            chkTrangThai.Checked = string.IsNullOrEmpty(tt) ? true : tt == "1" || tt.Equals("True", StringComparison.OrdinalIgnoreCase);
        }

        private static void LoadAvatarToPictureBox(string path, PictureBox pb)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
                {
                    SetPictureBoxImageSafe(pb, SystemIcons.Application.ToBitmap());
                    return;
                }

                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var ms = new MemoryStream())
                {
                    fs.CopyTo(ms);
                    using (var tmp = Image.FromStream(ms))
                    {
                        var clone = (Image)tmp.Clone();
                        SetPictureBoxImageSafe(pb, clone);
                      }
                }
            }
            catch
            {
                SetPictureBoxImageSafe(pb, SystemIcons.Application.ToBitmap());
            }
        }

        private static void SetPictureBoxImageSafe(PictureBox pb, Image newImage)
        {
            try
            {
                var old = pb.Image;
                pb.Image = null;
                if (old != null)
                {
                    try { old.Dispose(); } catch { }
                }
            }
            catch { }
            pb.Image = newImage;
        }

        // Debounced search
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            _searchDebounceTimer.Stop();
            _searchDebounceTimer.Start();
        }

        private static string EscapeForRowFilter(string value)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;
            return value.Replace("'", "''")
                        .Replace("[", "[[]")
                        .Replace("]", "[]]")
                        .Replace("%", "[%]")
                        .Replace("*", "[*]");
        }

        private void ApplySearchFilter()
        {
            if (_bs == null) return;

            string raw = (txtTimKiem.Text ?? string.Empty).Trim();
            if (string.IsNullOrEmpty(raw))
            {
                _bs.RemoveFilter();
            }
            else
            {
                string filter = EscapeForRowFilter(raw);
                _bs.Filter =
                    $"HoTen LIKE '%{filter}%' OR DienThoai LIKE '%{filter}%' OR CCCD LIKE '%{filter}%' OR TaiKhoan LIKE '%{filter}%'";
            }

            // refresh avatars according to current view
            LoadListView();
        }

        private void lvAvatar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvAvatar.SelectedItems.Count == 0) return;
            var id = lvAvatar.SelectedItems[0].Tag as string;
            SelectRowByMaNV(id);
        }

        private void SelectRowByMaNV(string maNV)
        {
            if (string.IsNullOrWhiteSpace(maNV) || dgvTaiKhoan.DataSource == null) return;
            foreach (DataGridViewRow r in dgvTaiKhoan.Rows)
            {
                var cellVal = r.Cells["MaNV"].Value?.ToString();
                if (string.Equals(cellVal, maNV, StringComparison.OrdinalIgnoreCase))
                {
                    r.Selected = true;

                    DataGridViewCell cell = null;
                    if (dgvTaiKhoan.Columns.Contains("HoTen"))
                        cell = r.Cells["HoTen"];
                    else if (r.Cells.Count > 0)
                        cell = r.Cells[0];

                    if (cell != null) dgvTaiKhoan.CurrentCell = cell;

                    FillDetailFromRow(r);
                    dgvTaiKhoan.FirstDisplayedScrollingRowIndex = r.Index;
                    break;
                }
            }
        }

        // Filter by role or employee from TreeView
        private void tvRoleGroup_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (_bs == null || e.Node == null) return;

            var tag = e.Node.Tag as string;
            if (string.IsNullOrWhiteSpace(tag))
                return;

            if (tag == "all")
            {
                _bs.RemoveFilter();
                LoadListView();
                return;
            }

            if (tag.StartsWith("role:", StringComparison.Ordinal))
            {
                var role = tag.Substring("role:".Length);
                _bs.Filter = $"VaiTro = '{EscapeForRowFilter(role)}'";
                LoadListView();
                return;
            }

            if (tag.StartsWith("nv:", StringComparison.Ordinal))
            {
                var ma = tag.Substring("nv:".Length);
                _bs.Filter = $"MaNV = '{EscapeForRowFilter(ma)}'";
                LoadListView();
                return;
            }
        }

        // Unused integer overload (kept for designer safety)
        private void SelectRowByMaNV(int maNV)
        {
            if (dgvTaiKhoan.DataSource == null) return;

            foreach (DataGridViewRow r in dgvTaiKhoan.Rows)
            {
                if (r.Cells["MaNV"].Value != null && int.TryParse(r.Cells["MaNV"].Value.ToString(), out int id) && id == maNV)
                {
                    r.Selected = true;

                    DataGridViewCell cell = null;
                    if (dgvTaiKhoan.Columns.Contains("HoTen"))
                        cell = r.Cells["HoTen"];
                    else if (r.Cells.Count > 0)
                        cell = r.Cells[0];

                    if (cell != null) dgvTaiKhoan.CurrentCell = cell;

                    FillDetailFromRow(r);
                    dgvTaiKhoan.FirstDisplayedScrollingRowIndex = r.Index;
                    break;
                }
            }
        }

        private void dgvTaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // not used
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var frm = new FrmRegister();
            frm.ShowDialog();
        }

        private void btnDoiAnh_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn ảnh đại diện";
                ofd.Filter = "Ảnh|*.png;*.jpg;*.jpeg;*.bmp;*.gif";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        UpdateAvatarFromFile(ofd.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi cập nhật ảnh: " + ex.Message, "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void UpdateAvatarFromFile(string sourcePath)
        {
            if (string.IsNullOrWhiteSpace(sourcePath) || !File.Exists(sourcePath))
                throw new FileNotFoundException("Không tìm thấy tệp ảnh.", sourcePath);

            if (!IsImageFile(sourcePath))
                throw new InvalidOperationException("Vui lòng chọn tệp ảnh hợp lệ.");

            string oldPath = _avatarPath;

            string folder = Path.Combine(Application.StartupPath, "Avatars");
            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

            string ext = Path.GetExtension(sourcePath);
            string fileName = $"{Guid.NewGuid()}{ext}";
            string destPath = Path.Combine(folder, fileName);
            File.Copy(sourcePath, destPath, overwrite: false);

            _avatarPath = destPath;
            LoadAvatarToPictureBox(_avatarPath, picAvatar);

            if (!string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                using (var conn = new SqlConnection(connStr))
                using (var cmd = new SqlCommand("UPDATE NhanVien SET AvatarPath=@p WHERE MaNV=@id", conn))
                {
                    cmd.Parameters.Add("@p", SqlDbType.NVarChar, 260).Value = _avatarPath;
                    cmd.Parameters.Add("@id", SqlDbType.NVarChar, 20).Value = txtMaNV.Text.Trim();
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                // Refresh data without losing selection
                string idKeep = txtMaNV.Text.Trim();
                LoadDataGrid();
                SelectRowByMaNV(idKeep);

                // Try delete old file
                if (!string.IsNullOrWhiteSpace(oldPath) && !string.Equals(oldPath, _avatarPath, StringComparison.OrdinalIgnoreCase))
                {
                    try { if (File.Exists(oldPath)) File.Delete(oldPath); } catch { }
                }
            }
        }

        private static bool IsImageFile(string path)
        {
            var ext = Path.GetExtension(path)?.ToLowerInvariant();
            return ext == ".png" || ext == ".jpg" || ext == ".jpeg" || ext == ".bmp" || ext == ".gif";
        }

        // Count how many invoices reference this employee
        private int CountHoaDonByMaNV(string maNV)
        {
            if (string.IsNullOrWhiteSpace(maNV)) return 0;
            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand("SELECT COUNT(*) FROM HoaDon WHERE MaNV = @MaNV", conn))
            {
                cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar, 10).Value = maNV.Trim();
                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        // Optional: reassign all invoices from oldMaNV to newMaNV
        private void ReassignHoaDon(string oldMaNV, string newMaNV)
        {
            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand("UPDATE HoaDon SET MaNV=@New WHERE MaNV=@Old", conn))
            {
                cmd.Parameters.Add("@New", SqlDbType.NVarChar, 10).Value = newMaNV.Trim();
                cmd.Parameters.Add("@Old", SqlDbType.NVarChar, 10).Value = oldMaNV.Trim();
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var maNV = txtMaNV.Text?.Trim();
            if (string.IsNullOrWhiteSpace(maNV))
            {
                MessageBox.Show("Mã nhân viên không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check references in HoaDon
            int refCount = 0;
            try { refCount = CountHoaDonByMaNV(maNV); }
            catch (Exception ex)
            {
                MessageBox.Show("Không kiểm tra được tham chiếu hóa đơn: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (refCount > 0)
            {
                // Soft delete path
                var r = MessageBox.Show(
                    $"Nhân viên này đang được tham chiếu bởi {refCount} hóa đơn.\n" +
                    $"Bạn muốn vô hiệu hóa (đánh dấu ngừng hoạt động) thay vì xóa?",
                    "Đang được tham chiếu",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (r == DialogResult.Yes)
                {
                    try
                    {
                        using (var conn = new SqlConnection(connStr))
                        using (var cmd = new SqlCommand(
                            "UPDATE NhanVien SET TrangThai = 0 WHERE MaNV = @MaNV", conn))
                        {
                            cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar, 10).Value = maNV;
                            conn.Open();
                            var n = cmd.ExecuteNonQuery();
                            if (n == 0)
                            {
                                MessageBox.Show("Không tìm thấy nhân viên.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }

                        MessageBox.Show("Đã vô hiệu hóa tài khoản nhân viên.", "Hoàn tất",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataGrid();
                        LoadListView();
                        LoadTreeView();
                        ClearForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi vô hiệu hóa: " + ex.Message, "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Không thể xóa vì đang được tham chiếu bởi hóa đơn.", "Không thể xóa",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                return;
            }

            // No references: proceed with hard delete
            if (MessageBox.Show("Bạn có chắc muốn xóa tài khoản này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return;

            string oldPath = _avatarPath;
            try
            {
                using (var conn = new SqlConnection(connStr))
                using (var cmd = new SqlCommand("DELETE FROM NhanVien WHERE MaNV=@MaNV", conn))
                {
                    cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar, 10).Value = maNV;
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 0)
                    {
                        MessageBox.Show("Không tìm thấy tài khoản để xóa.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                try { if (!string.IsNullOrWhiteSpace(oldPath) && File.Exists(oldPath)) File.Delete(oldPath); } catch { }

                MessageBox.Show("Đã xóa tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGrid();
                LoadListView();
                LoadTreeView();
                ClearForm();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi xóa tài khoản: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Helper: ensure string length fits column
        private static string Fit(string s, int max)
        {
            if (string.IsNullOrWhiteSpace(s)) return null;
            s = s.Trim();
            return s.Length <= max ? s : s.Substring(0, max);
        }

        // Generate MaNV with max 10 chars (NV + yyMMdd + 2 hex)
        private static string GenerateMaNV10()
        {
            var date = DateTime.Now.ToString("yyMMdd");
            var rnd = Guid.NewGuid().ToString("N").Substring(0, 2);
            return "NV" + date + rnd; // 10 chars
        }

        // SINGLE definition — keep this one
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(isUpdate: false)) return;

            string maNV = GenerateMaNV10();

            try
            {
                using (var conn = new SqlConnection(connStr))
                using (var cmd = new SqlCommand(
                    @"INSERT INTO NhanVien(MaNV, HoTen, TaiKhoan, MatKhau, VaiTro, DienThoai, Email, NgaySinh, NgayTao, CCCD, AvatarPath) 
                      VALUES(@MaNV, @HoTen, @TaiKhoan, @MatKhau, @VaiTro, @DienThoai, @Email, @NgaySinh, GETDATE(), @CCCD, @AvatarPath)", conn))
                {
                    cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar, 10).Value = maNV;

                    cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar, 50).Value = (object)Fit(txtHoTen.Text, 50) ?? DBNull.Value;
                    cmd.Parameters.Add("@TaiKhoan", SqlDbType.NVarChar, 30).Value = (object)Fit(txtTaiKhoan.Text, 30) ?? DBNull.Value;
                    cmd.Parameters.Add("@MatKhau", SqlDbType.NVarChar, 30).Value = (object)Fit(txtMatKhau.Text, 30) ?? DBNull.Value;
                    cmd.Parameters.Add("@VaiTro", SqlDbType.NVarChar, 20).Value = (object)Fit(cbVaiTro.Text, 20) ?? DBNull.Value;

                    cmd.Parameters.Add("@DienThoai", SqlDbType.NVarChar, 20).Value = (object)Fit(txtSdt.Text, 20) ?? DBNull.Value;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = (object)Fit(txtEmail.Text, 100) ?? DBNull.Value;

                    cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = dtNgaySinh.Value.Date;

                    cmd.Parameters.Add("@CCCD", SqlDbType.NVarChar, 20).Value = (object)Fit(txtCCCD.Text, 20) ?? DBNull.Value;

                    cmd.Parameters.Add("@AvatarPath", SqlDbType.NVarChar, 260).Value =
                        string.IsNullOrWhiteSpace(_avatarPath) ? (object)DBNull.Value : Fit(_avatarPath, 260);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Thêm tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGrid();
                LoadListView();
                LoadTreeView();
                ClearForm();
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                MessageBox.Show("Trùng khóa: 'MaNV' hoặc 'TaiKhoan/CCCD'. Vui lòng kiểm tra.",
                    "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm tài khoản: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(isUpdate: true)) return;

            try
            {
                using (var conn = new SqlConnection(connStr))
                using (var cmd = new SqlCommand(
                    @"UPDATE NhanVien SET HoTen=@HoTen, TaiKhoan=@TaiKhoan, MatKhau=@MatKhau, VaiTro=@VaiTro,
                                        DienThoai=@DienThoai, Email=@Email, NgaySinh=@NgaySinh, CCCD=@CCCD, AvatarPath=@AvatarPath
                      WHERE MaNV=@MaNV", conn))
                {
                    cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar, 10).Value = Fit(txtMaNV.Text, 10) ?? (object)DBNull.Value;

                    cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar, 50).Value = (object)Fit(txtHoTen.Text, 50) ?? DBNull.Value;
                    cmd.Parameters.Add("@TaiKhoan", SqlDbType.NVarChar, 30).Value = (object)Fit(txtTaiKhoan.Text, 30) ?? DBNull.Value;
                    cmd.Parameters.Add("@MatKhau", SqlDbType.NVarChar, 30).Value = (object)Fit(txtMatKhau.Text, 30) ?? DBNull.Value;
                    cmd.Parameters.Add("@VaiTro", SqlDbType.NVarChar, 20).Value = (object)Fit(cbVaiTro.Text, 20) ?? DBNull.Value;

                    cmd.Parameters.Add("@DienThoai", SqlDbType.NVarChar, 20).Value = (object)Fit(txtSdt.Text, 20) ?? DBNull.Value;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = (object)Fit(txtEmail.Text, 100) ?? DBNull.Value;

                    cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = dtNgaySinh.Value.Date;

                    cmd.Parameters.Add("@CCCD", SqlDbType.NVarChar, 20).Value = (object)Fit(txtCCCD.Text, 20) ?? DBNull.Value;

                    cmd.Parameters.Add("@AvatarPath", SqlDbType.NVarChar, 260).Value =
                        string.IsNullOrWhiteSpace(_avatarPath) ? (object)DBNull.Value : Fit(_avatarPath, 260);

                    conn.Open();
                    var n = cmd.ExecuteNonQuery();
                    if (n == 0)
                    {
                        MessageBox.Show("Không tìm thấy nhân viên để cập nhật.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                MessageBox.Show("Cập nhật tài khoản thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                var keep = txtMaNV.Text.Trim();
                LoadDataGrid();
                SelectRowByMaNV(keep);
                LoadListView();
                LoadTreeView();
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                MessageBox.Show("Trùng khóa: 'TaiKhoan/CCCD'. Vui lòng kiểm tra.",
                    "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Ensure selected role is among AllowedRoles
        private bool EnsureRoleValid()
        {
            var role = (cbVaiTro.Text ?? "").Trim();
            if (string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Vui lòng chọn vai trò.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbVaiTro.Focus();
                return false;
            }

            if (!AllowedRoles.Contains(role, StringComparer.OrdinalIgnoreCase))
            {
                MessageBox.Show("Vai trò không hợp lệ. Vui lòng chọn trong danh sách.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbVaiTro.Focus();
                return false;
            }
            return true;
        }

        private bool ValidateInputs(bool isUpdate)
        {
            if (isUpdate && string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Mã nhân viên không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Họ tên không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus(); return false;
            }
            if (string.IsNullOrWhiteSpace(txtTaiKhoan.Text))
            {
                MessageBox.Show("Tài khoản không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTaiKhoan.Focus(); return false;
            }
            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Email không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus(); return false;
            }
            if (!string.IsNullOrWhiteSpace(txtSdt.Text) && !Regex.IsMatch(txtSdt.Text.Trim(), @"^\+?\d{8,15}$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSdt.Focus(); return false;
            }
            if (!string.IsNullOrWhiteSpace(txtCCCD.Text) && !Regex.IsMatch(txtCCCD.Text.Trim(), @"^\d{9,12}$"))
            {
                MessageBox.Show("CCCD không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCCCD.Focus(); return false;
            }
            if (string.IsNullOrWhiteSpace(cbVaiTro.Text))
            {
                MessageBox.Show("Vui lòng chọn vai trò.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbVaiTro.Focus(); return false;
            }
            if (!EnsureRoleValid()) return false;

            if (!isUpdate && string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Mật khẩu không được để trống khi tạo mới.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus(); return false;
            }
            return true;
        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                return Regex.IsMatch(email,
                    @"^[A-Za-z0-9._%+\-]+@[A-Za-z0-9.\-]+\.[A-Za-z]{2,}$",
                    RegexOptions.IgnoreCase);
            }
            catch { return false; }
        }

        private void cbVaiTro_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtMatKhau_TextChanged(object sender, EventArgs e) { }
        private void txtTaiKhoan_TextChanged(object sender, EventArgs e) { }
        private void txtCCCD_TextChanged(object sender, EventArgs e) { }
        private void txtEmail_TextChanged(object sender, EventArgs e) { }
        private void txtSdt_TextChanged(object sender, EventArgs e) { }
        private void txtHoTen_TextChanged(object sender, EventArgs e) { }
        private void txtMaNV_TextChanged(object sender, EventArgs e) { }

        private void ClearForm()
        {
            txtMaNV.Text = "";
            txtHoTen.Text = "";
            txtSdt.Text = "";
            txtEmail.Text = "";
            txtCCCD.Text = "";
            txtTaiKhoan.Text = "";
            txtMatKhau.Text = "";
            cbVaiTro.SelectedIndex = -1;
            dtNgaySinh.Value = DateTime.Now;
            dtNgayTao.Value = DateTime.Now;
            _avatarPath = null;
            SetPictureBoxImageSafe(picAvatar, SystemIcons.Application.ToBitmap());
            btnThem.Enabled = true;
            btnSua.Enabled = false;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void LoadDataGrid()
        {
            try
            {
                using (var conn = new SqlConnection(connStr))
                using (var cmd = new SqlCommand(
                    @"SELECT MaNV, HoTen, DienThoai, Email, CCCD, TaiKhoan, VaiTro, NgaySinh, NgayTao, AvatarPath, TrangThai 
              FROM NhanVien", conn))
                using (var da = new SqlDataAdapter(cmd))
                {
                    var table = new DataTable();
                    conn.Open();
                    da.Fill(table);
                    dt = table;

                    if (_bs == null) { _bs = new BindingSource(); }
                    _bs.DataSource = dt;
                    dgvTaiKhoan.DataSource = _bs;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu nhân viên: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataView GetCurrentView()
        {
            if (_bs != null && _bs.List is DataView dv)
                return dv;
            return dt?.DefaultView;
        }
    }
}
