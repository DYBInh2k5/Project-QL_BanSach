using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using QLBanSach_DAL;

namespace QLBanSach_GUI.UserControls
{
    public partial class UC_TheLoaiSach : UserControl
    {
        public UC_TheLoaiSach()
        {
            InitializeComponent();
        }

        private void UC_TheLoaiSach_Load(object sender, EventArgs e)
        {
            // Configure ListView appearance once
            lvSach.View = View.Details; // default to details; switch to tile when showing thumbnails
            lvSach.LargeImageList = imageList1;
            lvSach.SmallImageList = imageList1;

            imageList1.ImageSize = new Size(60, 80);
            imageList1.ColorDepth = ColorDepth.Depth32Bit;

            LoadTreeLoai();
            // Ensure columns are present but not duplicated
            LoadListViewColumns();

            var cm = new ContextMenuStrip();
            cm.Items.Add("Thêm thể loại", null, (s, a) => AddCategory());
            cm.Items.Add("Đổi tên", null, (s, a) => RenameCategory());
            cm.Items.Add("Xóa", null, (s, a) => DeleteCategory());
            cm.Items.Add("Làm mới", null, (s, a) => LoadTreeLoai());
            tvTheLoai.ContextMenuStrip = cm;
        }

        private void LoadListViewColumns()
        {
            // Clear only if empty or mismatched
            lvSach.Columns.Clear();
            lvSach.Columns.Add("Mã Sách", 100);
            lvSach.Columns.Add("Tên Sách", 220);
            lvSach.Columns.Add("Tác Giả", 160);
            lvSach.Columns.Add("Đơn Giá", 120);
        }

        private void LoadTreeLoai()
        {
            tvTheLoai.Nodes.Clear();
            const string query = "SELECT DISTINCT TheLoai FROM Sach WHERE TheLoai IS NOT NULL AND TheLoai <> '' ORDER BY TheLoai";

            try
            {
                var dt = DatabaseHelper.ExecuteQuery(query);
                foreach (DataRow r in dt.Rows)
                {
                    string theLoai = r["TheLoai"]?.ToString() ?? "";
                    if (string.IsNullOrWhiteSpace(theLoai)) continue;
                    tvTheLoai.Nodes.Add(new TreeNode(theLoai));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thể loại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSachTheoLoai(string loai)
        {
            lvSach.Items.Clear();
            imageList1.Images.Clear();

            const string sql = @"SELECT MaSach, TenSach, TacGia, DonGia, AnhBia
                                 FROM Sach
                                 WHERE TheLoai = @theLoai
                                 ORDER BY TenSach";
            var p = new[] { new SqlParameter("@theLoai", loai ?? string.Empty) };

            try
            {
                var dt = DatabaseHelper.ExecuteQuery(sql, p);

                // Choose tile view when we have images; otherwise keep details
                bool anyImage = false;

                foreach (DataRow row in dt.Rows)
                {
                    string ma = Convert.ToString(row["MaSach"]);
                    string ten = row["TenSach"]?.ToString() ?? "";
                    string tacgia = row["TacGia"]?.ToString() ?? "";
                    decimal dongia = row["DonGia"] != DBNull.Value ? Convert.ToDecimal(row["DonGia"]) : 0m;
                    string anh = dt.Columns.Contains("AnhBia") ? row["AnhBia"]?.ToString() : null;

                    if (!string.IsNullOrWhiteSpace(anh) && File.Exists(anh))
                    {
                        try
                        {
                            using (var img = Image.FromFile(anh))
                            {
                                imageList1.Images.Add(ma, (Image)img.Clone());
                                anyImage = true;
                            }
                        }
                        catch { /* ignore image errors */ }
                    }

                    var it = new ListViewItem(ma);
                    it.SubItems.Add(ten);
                    it.SubItems.Add(tacgia);
                    it.SubItems.Add(dongia.ToString("N0"));
                    if (imageList1.Images.ContainsKey(ma)) it.ImageKey = ma;

                    lvSach.Items.Add(it);
                }

                // Switch view based on image availability
                lvSach.View = anyImage ? View.Tile : View.Details;
                if (anyImage)
                {
                    lvSach.TileSize = new Size(300, 90);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tvTheLoai_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null) return;
            LoadSachTheoLoai(e.Node.Text);
        }

        private void ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Optionally preview large cover
            if (lvSach.SelectedItems.Count == 0) { picAnhTo.Visible = false; return; }

            var it = lvSach.SelectedItems[0];
            if (!string.IsNullOrEmpty(it.ImageKey) && imageList1.Images.ContainsKey(it.ImageKey))
            {
                picAnhTo.Image = imageList1.Images[it.ImageKey];
                picAnhTo.Visible = true;
            }
            else
            {
                picAnhTo.Visible = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string kw = (txtSearch.Text ?? "").Trim();
            if (kw.Length == 0)
            {
                lvSach.Items.Clear();
                imageList1.Images.Clear();
                return;
            }
            SearchSach(kw);
        }

        private void SearchSach(string keyword)
        {
            lvSach.Items.Clear();
            imageList1.Images.Clear();

            const string sql = @"SELECT MaSach, TenSach, TacGia, DonGia, AnhBia
                                 FROM Sach
                                 WHERE TenSach LIKE '%' + @kw + '%'
                                 ORDER BY TenSach";
            var p = new[] { new SqlParameter("@kw", keyword ?? string.Empty) };

            try
            {
                var dt = DatabaseHelper.ExecuteQuery(sql, p);
                bool anyImage = false;

                foreach (DataRow row in dt.Rows)
                {
                    string ma = Convert.ToString(row["MaSach"]);
                    string ten = row["TenSach"]?.ToString() ?? "";
                    string tacgia = row["TacGia"]?.ToString() ?? "";
                    decimal gia = row["DonGia"] != DBNull.Value ? Convert.ToDecimal(row["DonGia"]) : 0m;
                    string anh = dt.Columns.Contains("AnhBia") ? row["AnhBia"]?.ToString() : null;

                    if (!string.IsNullOrWhiteSpace(anh) && File.Exists(anh))
                    {
                        try
                        {
                            using (var img = Image.FromFile(anh))
                            {
                                imageList1.Images.Add(ma, (Image)img.Clone());
                                anyImage = true;
                            }
                        }
                        catch { }
                    }

                    var item = new ListViewItem(ma);
                    item.SubItems.Add(ten);
                    item.SubItems.Add(tacgia);
                    item.SubItems.Add(gia.ToString("N0"));
                    if (imageList1.Images.ContainsKey(ma)) item.ImageKey = ma;
                    lvSach.Items.Add(item);
                }

                lvSach.View = anyImage ? View.Tile : View.Details;
                if (anyImage) lvSach.TileSize = new Size(300, 90);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // TODO: open form add-book or raise event for host form
            MessageBox.Show("Mở màn hình thêm sách.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AddCategory()
        {
            string name = PromptText("Nhập tên thể loại mới:");
            if (string.IsNullOrWhiteSpace(name)) return;
            name = name.Trim();
            // TODO: call DAL/BLL to insert if not exists, then reload
            // CategoryDAL.Insert(name);
            LoadTreeLoai();
        }

        private void RenameCategory()
        {
            var node = tvTheLoai.SelectedNode;
            if (node == null) return;
            string newName = PromptText($"Đổi tên thể loại \"{node.Text}\" thành:");
            if (string.IsNullOrWhiteSpace(newName)) return;
            newName = newName.Trim();
            // TODO: BLL: rename category and update books’ TheLoai where oldName
            // CategoryBLL.Rename(node.Text, newName);
            LoadTreeLoai();
        }

        private void DeleteCategory()
        {
            var node = tvTheLoai.SelectedNode;
            if (node == null) return;
            var r = MessageBox.Show($"Xóa thể loại \"{node.Text}\"?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No) return;
            // TODO: BLL: check if category has books; block or reassign
            // if (CategoryBLL.HasBooks(node.Text)) { MessageBox.Show("Thể loại đang có sách. Vui lòng chuyển sách sang thể loại khác."); return; }
            // CategoryBLL.Delete(node.Text);
            LoadTreeLoai();
        }

        private string PromptText(string title)
        {
            using (var f = new Form { Text = title, Width = 380, Height = 140, StartPosition = FormStartPosition.CenterParent })
            {
                var tb = new TextBox { Left = 12, Top = 12, Width = 340 };
                var ok = new Button { Text = "OK", Left = 192, Top = 50, Width = 75, DialogResult = DialogResult.OK };
                var cancel = new Button { Text = "Hủy", Left = 277, Top = 50, Width = 75, DialogResult = DialogResult.Cancel };
                f.Controls.Add(tb); f.Controls.Add(ok); f.Controls.Add(cancel);
                f.AcceptButton = ok; f.CancelButton = cancel;
                return f.ShowDialog(FindForm()) == DialogResult.OK ? tb.Text : null;
            }
        }
        private void ReassignSelectedBooks(string targetCategory)
        {
            if (string.IsNullOrWhiteSpace(targetCategory)) return;
            foreach (ListViewItem it in lvSach.SelectedItems)
            {
                int ma = int.Parse(it.SubItems[0].Text);
                // TODO: BLL/DAL: update TheLoai for book id = ma
                // SachBLL.UpdateCategory(ma, targetCategory);
            }
            if (tvTheLoai.SelectedNode != null)
                LoadSachTheoLoai(tvTheLoai.SelectedNode.Text);
        }

// Designer menu item handlers -> call your existing methods
private void miThemTheLoai_Click(object sender, EventArgs e)
{
    AddCategory();
}

private void miDoiTen_Click(object sender, EventArgs e)
{
    RenameCategory();
}

private void miXoa_Click(object sender, EventArgs e)
{
    DeleteCategory();
}

private void miLamMoi_Click(object sender, EventArgs e)
{
    LoadTreeLoai();
}
    }
}
