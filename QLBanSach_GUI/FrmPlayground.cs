using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace QLBanSach_GUI
{
    // Make this partial so it works with the Designer-generated partial
    public partial class FrmPlayground : Form
    {
        private DataTable _table;

        public FrmPlayground()
        {
            InitializeComponent();
            WireEvents();
            ConfigureControls();
            LoadSampleData();
            UpdateStatus("Ready.");
        }

        private void ConfigureControls()
        {
            // Optional extra styling
            if (dgvData.Columns.Contains("Price"))
                dgvData.Columns["Price"].DefaultCellStyle.Format = "N0";
        }

        private void WireEvents()
        {
            // Menu
            mOpen.Click += (s, e) => ShowOpenFileDialog();
            mExit.Click += (s, e) => Close();
            mTile.Click += (s, e) => { lvItems.View = View.Tile; lvItems.TileSize = new Size(150, 60); };
            mDetails.Click += (s, e) => { lvItems.View = View.Details; };
            mAbout.Click += (s, e) => ShowAboutDialog();

            // ToolStrip
            tsRefresh.Click += (s, e) => LoadSampleData();
            tsExport.Click += (s, e) => ExportCsv();
            tsRunTask.Click += (s, e) => RunFakeProgress();

            // Left panel
            tvCategories.AfterSelect += (s, e) => FilterByCategory(e.Node?.Text);

            // Top flow actions
            btnSearch.Click += (s, e) => ApplySearch();
            btnOpenDialog.Click += (s, e) => ShowCommonDialogs();
            btnChooseImage.Click += (s, e) => ChooseImageForPreview();

            // Grid/list/picture
            dgvData.SelectionChanged += (s, e) => UpdatePreview();
            lvItems.SelectedIndexChanged += (s, e) => SelectGridRowByListView();
        }

        // =====================
        // Sample Data
        // =====================
        private void LoadSampleData()
        {
            var dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Category", typeof(string));
            dt.Columns.Add("Price", typeof(decimal));
            dt.Columns.Add("CoverPath", typeof(string));

            string[] cats = { "Fiction", "Science", "History", "Kids" };
            dt.Rows.Add(1, "The First Book", cats[0], 120000m, "");
            dt.Rows.Add(2, "Science of Life", cats[1], 235000m, "");
            dt.Rows.Add(3, "World Wars", cats[2], 199000m, "");
            dt.Rows.Add(4, "Fairy Tales", cats[3], 89000m, "");

            _table = dt;
            dgvData.DataSource = _table;
            if (dgvData.Columns.Contains("Price"))
                dgvData.Columns["Price"].DefaultCellStyle.Format = "N0";

            // categories to TreeView
            tvCategories.Nodes.Clear();
            foreach (var c in cats) tvCategories.Nodes.Add(new TreeNode(c));
            tvCategories.ExpandAll();

            // listview + images
            imageList.Images.Clear();
            lvItems.Items.Clear();
            var rnd = new Random();
            foreach (DataRow row in dt.Rows)
            {
                int id = (int)row["ID"];
                var bmp = new Bitmap(48, 48);
                using (var g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.FromArgb(rnd.Next(60, 200), rnd.Next(60, 200), rnd.Next(60, 200)));
                    g.DrawString(id.ToString(), SystemFonts.DefaultFont, Brushes.White, new PointF(4, 4));
                }
                imageList.Images.Add(id.ToString(), bmp);

                var item = new ListViewItem(id.ToString()) { ImageKey = id.ToString() };
                item.SubItems.Add(row["Name"].ToString());
                item.SubItems.Add(row["Category"].ToString());
                item.SubItems.Add(((decimal)row["Price"]).ToString("N0"));
                lvItems.Items.Add(item);
            }

            UpdatePreview();
            UpdateStatus("Sample data loaded.");
        }

        // =====================
        // Filtering / Search
        // =====================
        private void FilterByCategory(string category)
        {
            var dv = _table?.DefaultView;
            if (dv == null) return;

            if (string.IsNullOrWhiteSpace(category))
                dv.RowFilter = "";
            else
                dv.RowFilter = $"Category = '{Escape(category)}'";

            UpdateStatus($"Filter: {category}");
        }

        private void ApplySearch()
        {
            var dv = _table?.DefaultView;
            if (dv == null) return;

            var kw = (txtSearch.Text ?? "").Trim();
            if (kw.Length == 0)
            {
                dv.RowFilter = "";
                UpdateStatus("Search cleared.");
                return;
            }

            var f = Escape(kw);
            dv.RowFilter = $"Name LIKE '%{f}%' OR Category LIKE '%{f}%'";

            UpdateStatus($"Search: {kw}");
        }

        private static string Escape(string value)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;
            return value.Replace("'", "''").Replace("[", "[[]").Replace("]", "[]]");
        }

        // =====================
        // Preview
        // =====================
        private void UpdatePreview()
        {
            if (dgvData.CurrentRow == null)
            {
                SetPreview(SystemIcons.Application.ToBitmap());
                return;
            }

            string path = dgvData.CurrentRow.Cells["CoverPath"]?.Value?.ToString();
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
            {
                SetPreview(SystemIcons.Application.ToBitmap());
                return;
            }

            try
            {
                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var ms = new MemoryStream())
                {
                    fs.CopyTo(ms);
                    using (var tmp = Image.FromStream(ms))
                    {
                        SetPreview((Image)tmp.Clone());
                    }
                }
            }
            catch
            {
                SetPreview(SystemIcons.Application.ToBitmap());
            }
        }

        private void SetPreview(Image img)
        {
            try
            {
                var old = pbPreview.Image;
                pbPreview.Image = null;
                old?.Dispose();
            }
            catch { }
            pbPreview.Image = img;
        }

        // =====================
        // Dialogs and actions
        // =====================
        private void ShowOpenFileDialog()
        {
            using (var ofd = new OpenFileDialog
            {
                Title = "Open File",
                Filter = "All Files|*.*"
            })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    UpdateStatus($"Opened: {ofd.FileName}");
                }
            }
        }

        private void ShowCommonDialogs()
        {
            using (var colorDlg = new ColorDialog())
            {
                if (colorDlg.ShowDialog(this) == DialogResult.OK)
                    BackColor = colorDlg.Color;
            }

            using (var fontDlg = new FontDialog())
            {
                if (fontDlg.ShowDialog(this) == DialogResult.OK)
                    dgvData.Font = fontDlg.Font;
            }

            using (var folderDlg = new FolderBrowserDialog())
            {
                if (folderDlg.ShowDialog(this) == DialogResult.OK)
                    UpdateStatus($"Folder selected: {folderDlg.SelectedPath}");
            }
        }

        private void ChooseImageForPreview()
        {
            if (dgvData.CurrentRow == null)
            {
                MessageBox.Show("Please select a row first.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var ofd = new OpenFileDialog
            {
                Title = "Choose image",
                Filter = "Images|*.png;*.jpg;*.jpeg;*.bmp;*.gif"
            })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var folder = Path.Combine(Application.StartupPath, "Covers");
                        if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

                        var ext = Path.GetExtension(ofd.FileName);
                        var dest = Path.Combine(folder, $"{Guid.NewGuid()}{ext}");
                        File.Copy(ofd.FileName, dest, overwrite: false);

                        dgvData.CurrentRow.Cells["CoverPath"].Value = dest;
                        UpdatePreview();
                        UpdateStatus("Preview image set.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error setting image: " + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ShowAboutDialog()
        {
            MessageBox.Show("Playground demo — ListView, TreeView, DataGridView, PictureBox, ImageList,\n" +
                            "FlowLayoutPanel, TableLayoutPanel, SplitContainer, MenuStrip, ToolStrip,\n" +
                            "ProgressBar, StatusStrip, DateTimePicker, and common dialogs.",
                            "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SelectGridRowByListView()
        {
            if (lvItems.SelectedItems.Count == 0) return;
            var idText = lvItems.SelectedItems[0].Text;
            foreach (DataGridViewRow r in dgvData.Rows)
            {
                if (r.Cells["ID"].Value?.ToString() == idText)
                {
                    r.Selected = true;
                    dgvData.CurrentCell = r.Cells["Name"];
                    dgvData.FirstDisplayedScrollingRowIndex = r.Index;
                    break;
                }
            }
        }

        private void ExportCsv()
        {
            var dv = _table?.DefaultView;
            if (dv == null || dv.Count == 0)
            {
                MessageBox.Show("No data to export.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var sfd = new SaveFileDialog
            {
                Title = "Export CSV",
                Filter = "CSV|*.csv",
                FileName = $"Playground_{DateTime.Now:yyyyMMddHHmmss}.csv"
            })
            {
                if (sfd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    using (var sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
                    {
                        // header
                        for (int i = 0; i < dv.Table.Columns.Count; i++)
                        {
                            if (i > 0) sw.Write(",");
                            sw.Write(CsvEscape(dv.Table.Columns[i].ColumnName));
                        }
                        sw.WriteLine();

                        // rows
                        foreach (DataRowView rv in dv)
                        {
                            var row = rv.Row;
                            for (int i = 0; i < dv.Table.Columns.Count; i++)
                            {
                                if (i > 0) sw.Write(",");
                                sw.Write(CsvEscape(Convert.ToString(row[i] ?? "")));
                            }
                            sw.WriteLine();
                        }
                    }
                    UpdateStatus("Exported CSV successfully.");
                    MessageBox.Show("Exported CSV successfully.", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Export error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private static string CsvEscape(string s)
        {
            if (string.IsNullOrEmpty(s)) return "";
            if (s.IndexOfAny(new[] { '"', ',', '\n', '\r' }) >= 0)
                return "\"" + s.Replace("\"", "\"\"") + "\"";
            return s;
        }

        // =====================
        // Progress + Status
        // =====================
        private void RunFakeProgress()
        {
            progressBar.Value = 0;
            var t = new Timer { Interval = 50 };
            t.Tick += (s, e) =>
            {
                progressBar.Value = Math.Min(100, progressBar.Value + 5);
                statusLabel.Text = $"Progress: {progressBar.Value}%";
                if (progressBar.Value >= 100)
                {
                    t.Stop();
                    t.Dispose();
                    UpdateStatus("Task completed.");
                }
            };
            t.Start();
        }

        private void UpdateStatus(string text)
        {
            statusLabel.Text = text;
        }
    }
}
