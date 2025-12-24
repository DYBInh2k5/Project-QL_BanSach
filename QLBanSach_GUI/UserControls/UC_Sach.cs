using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Spreadsheet;
using QLBanSach_BLL;
using QLBanSach_DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBanSach_GUI.UserControls
{
    public partial class UC_Sach : UserControl
    {
        private SachBLL bll = new SachBLL();

        public UC_Sach()
        {
            InitializeComponent();
            this.Load += UC_Sach_Load;
        }

        private void UC_Sach_Load(object sender, EventArgs e)
        {
            SetupControls();
            LoadData();
        }

        private void SetupControls()
        {
            txtTimKiem.PlaceholderText = "Tìm theo tên hoặc thể loại...";
            dgvSach.AutoGenerateColumns = true;
            dgvSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSach.MultiSelect = false;
            dgvSach.ReadOnly = true;
            dgvSach.AllowUserToAddRows = false;
            dgvSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSach.RowHeadersVisible = false;
        }

        private void LoadData()
        {
            try
            {
                dgvSach.DataSource = bll.LayDanhSachSach();
                FormatGrid();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu: " + ex.Message);
            }
        }

        private void FormatGrid()
        {
            if (dgvSach.Columns.Contains("MaSach"))
            {
                dgvSach.Columns["MaSach"].HeaderText = "Mã";
                dgvSach.Columns["MaSach"].Width = 60;
            }
            if (dgvSach.Columns.Contains("TenSach"))
                dgvSach.Columns["TenSach"].HeaderText = "Tên sách";
            if (dgvSach.Columns.Contains("TacGia"))
                dgvSach.Columns["TacGia"].HeaderText = "Tác giả";
            if (dgvSach.Columns.Contains("TheLoai"))
                dgvSach.Columns["TheLoai"].HeaderText = "Thể loại";
            if (dgvSach.Columns.Contains("DonGia"))
            {
                dgvSach.Columns["DonGia"].HeaderText = "Đơn giá";
                dgvSach.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            }
            if (dgvSach.Columns.Contains("SoLuong"))
                dgvSach.Columns["SoLuong"].HeaderText = "Số lượng";
        }

        private void ClearInputs()
        {
            txtTenSach.Text = "";
            txtTacGia.Text = "";
            txtTheLoai.Text = "";
            txtDonGia.Text = "";
            txtSoLuong.Text = "";
            txtTimKiem.Text = "";
            btnThem.Enabled = true;
        }

        private bool ValidateInputs(out SachDTO s)
        {
            s = null;
            if (string.IsNullOrWhiteSpace(txtTenSach.Text))
            {
                MessageBox.Show("Nhập tên sách!");
                txtTenSach.Focus();
                return false;
            }

            if (!double.TryParse(txtDonGia.Text, out double gia))
            {
                MessageBox.Show("Đơn giá không hợp lệ!");
                txtDonGia.Focus();
                return false;
            }

            if (!int.TryParse(txtSoLuong.Text, out int sl))
            {
                MessageBox.Show("Số lượng không hợp lệ!");
                txtSoLuong.Focus();
                return false;
            }

            s = new SachDTO
            {
                TenSach = txtTenSach.Text.Trim(),
                TacGia = txtTacGia.Text.Trim(),
                TheLoai = txtTheLoai.Text.Trim(),
                DonGia = (decimal)gia,
                SoLuong = sl
            };
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInputs(out SachDTO s)) return;
                bll.ThemSach(s);
                LoadData();
                MessageBox.Show("Thêm sách thành công!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSach.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Chọn 1 sách để sửa!");
                    return;
                }

                if (!ValidateInputs(out SachDTO s)) return;

                int ma = Convert.ToInt32(dgvSach.SelectedRows[0].Cells["MaSach"].Value);
                s.MaSach = ma;

                bll.SuaSach(s);
                LoadData();
                MessageBox.Show("Cập nhật thành công!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSach.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Chọn 1 sách để xóa!");
                    return;
                }

                int ma = Convert.ToInt32(dgvSach.SelectedRows[0].Cells["MaSach"].Value);
                var r = MessageBox.Show($"Bạn có chắc muốn xóa sách (Mã {ma}) không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    bll.XoaSach(ma);
                    LoadData();
                    MessageBox.Show("Xóa thành công!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInputs();
            LoadData();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string key = txtTimKiem.Text.Trim();
                dgvSach.DataSource = string.IsNullOrEmpty(key)
                    ? bll.LayDanhSachSach()
                    : bll.TimKiemSach(key);
                FormatGrid();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Search error: " + ex.Message);
            }
        }

        private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvSach.Rows[e.RowIndex].Cells["MaSach"].Value != null)
            {
                txtTenSach.Text = dgvSach.Rows[e.RowIndex].Cells["TenSach"].Value.ToString();
                txtTacGia.Text = dgvSach.Rows[e.RowIndex].Cells["TacGia"].Value.ToString();
                txtTheLoai.Text = dgvSach.Rows[e.RowIndex].Cells["TheLoai"].Value.ToString();
                txtDonGia.Text = dgvSach.Rows[e.RowIndex].Cells["DonGia"].Value.ToString();
                txtSoLuong.Text = dgvSach.Rows[e.RowIndex].Cells["SoLuong"].Value.ToString();
                btnThem.Enabled = false;
            }
        }

        private DataTable ConvertToDataTable(List<SachDTO> list)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("MaSach", typeof(int));
            dt.Columns.Add("TenSach", typeof(string));
            dt.Columns.Add("TacGia", typeof(string));
            dt.Columns.Add("TheLoai", typeof(string));
            dt.Columns.Add("DonGia", typeof(decimal));
            dt.Columns.Add("SoLuong", typeof(int));

            foreach (var s in list)
            {
                dt.Rows.Add(s.MaSach, s.TenSach, s.TacGia, s.TheLoai, s.DonGia, s.SoLuong);
            }

            return dt;
        }

        // ✅ EXPORT EXCEL WITH PROGRESS BAR
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel File (*.xlsx)|*.xlsx";
                sfd.FileName = "DanhSachSach_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    // Show progress
                    pnlProgressContainer.Visible = true;
                    lblProgressStatus.Visible = true;
                    progressBarImport.Visible = true;
                    lblProgressStatus.Text = "Đang xuất dữ liệu Excel...";
                    progressBarImport.Value = 0;
                    progressBarImport.Style = ProgressBarStyle.Marquee;

                    Application.DoEvents();

                    List<SachDTO> list = bll.LayDanhSachSach();
                    DataTable dt = ConvertToDataTable(list);

                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        wb.Worksheets.Add(dt, "Sach");
                        
                        // Add some formatting
                        var worksheet = wb.Worksheet("Sach");
                        worksheet.Columns().AdjustToContents();
                        worksheet.Row(1).Style.Font.Bold = true;
                        worksheet.Row(1).Style.Fill.BackgroundColor = XLColor.LightBlue;

                        wb.SaveAs(sfd.FileName);
                    }

                    progressBarImport.Style = ProgressBarStyle.Continuous;
                    progressBarImport.Value = 100;
                    lblProgressStatus.Text = "Xuất file thành công!";
                    MessageBox.Show("Xuất Excel thành công!\n" + sfd.FileName, "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    Thread.Sleep(1000);
                    pnlProgressContainer.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi export: " + ex.Message);
                pnlProgressContainer.Visible = false;
            }
        }

        // ✅ IMPORT EXCEL WITH PROGRESS BAR
        private DataTable ImportExcel()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel File|*.xlsx";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                DataTable dt = new DataTable();

                using (XLWorkbook wb = new XLWorkbook(ofd.FileName))
                {
                    var ws = wb.Worksheet(1);
                    bool firstRow = true;

                    foreach (var row in ws.RowsUsed())
                    {
                        if (firstRow)
                        {
                            foreach (var cell in row.Cells())
                                dt.Columns.Add(cell.Value.ToString());
                            firstRow = false;
                        }
                        else
                            dt.Rows.Add(row.Cells().Select(c => c.Value.ToString()).ToArray());
                    }
                }

                return dt;
            }

            return null;
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = ImportExcel();
                if (dt == null)
                {
                    MessageBox.Show("Không có dữ liệu!");
                    return;
                }

                // Show progress container
                pnlProgressContainer.Visible = true;
                lblProgressStatus.Visible = true;
                progressBarImport.Visible = true;
                progressBarImport.Style = ProgressBarStyle.Continuous;
                progressBarImport.Minimum = 0;
                progressBarImport.Maximum = dt.Rows.Count;
                progressBarImport.Value = 0;

                int processedCount = 0;
                int totalCount = dt.Rows.Count;

                foreach (DataRow row in dt.Rows)
                {
                    try
                    {
                        SachDTO s = new SachDTO
                        {
                            TenSach = row["TenSach"].ToString(),
                            TacGia = row["TacGia"].ToString(),
                            TheLoai = row["TheLoai"].ToString(),
                            DonGia = Convert.ToDecimal(row["DonGia"]),
                            SoLuong = Convert.ToInt32(row["SoLuong"])
                        };

                        bll.ThemSach(s);
                        processedCount++;

                        // Update progress
                        progressBarImport.Value = Math.Min(processedCount, progressBarImport.Maximum);
                        lblProgressStatus.Text = $"Đang nhập sách: {processedCount}/{totalCount}";
                        Application.DoEvents();
                    }
                    catch (Exception ex)
                    {
                        // Log lỗi nhưng tiếp tục xử lý các dòng khác
                        Console.WriteLine("Lỗi nhập dòng: " + ex.Message);
                    }
                }

                LoadData();
                
                lblProgressStatus.Text = $"Nhập thành công! {processedCount}/{totalCount} sách";
                progressBarImport.Value = progressBarImport.Maximum;
                
                MessageBox.Show($"Import sách thành công!\nTổng cộng: {processedCount}/{totalCount} sách", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                Thread.Sleep(1500);
                pnlProgressContainer.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi import: " + ex.Message);
                pnlProgressContainer.Visible = false;
            }
        }

        private void ImportUpdateSoLuong(DataTable dt)
        {
            pnlProgressContainer.Visible = true;
            lblProgressStatus.Visible = true;
            progressBarImport.Visible = true;
            progressBarImport.Style = ProgressBarStyle.Continuous;
            progressBarImport.Minimum = 0;
            progressBarImport.Maximum = dt.Rows.Count;
            progressBarImport.Value = 0;

            int processed = 0;

            foreach (DataRow r in dt.Rows)
            {
                try
                {
                    int ma = Convert.ToInt32(r["MaSach"]);
                    int soNhap = Convert.ToInt32(r["SoLuongNhap"]);

                    bll.CapNhatSoLuong(ma, soNhap);
                    processed++;

                    progressBarImport.Value = Math.Min(processed, progressBarImport.Maximum);
                    lblProgressStatus.Text = $"Cập nhật tồn kho: {processed}/{dt.Rows.Count}";
                    Application.DoEvents();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi cập nhật: " + ex.Message);
                }
            }

            LoadData();
            lblProgressStatus.Text = "Cập nhật tồn kho thành công!";
            MessageBox.Show("Cập nhật tồn kho thành công!");
            
            Thread.Sleep(1500);
            pnlProgressContainer.Visible = false;
        }

        private void ImportExcel_UpdateSoLuong(string file)
        {
            pnlProgressContainer.Visible = true;
            lblProgressStatus.Visible = true;
            progressBarImport.Visible = true;
            progressBarImport.Style = ProgressBarStyle.Marquee;
            lblProgressStatus.Text = "Đang cập nhật tồn kho...";

            using (var workbook = new XLWorkbook(file))
            {
                var ws = workbook.Worksheet(1);
                var rows = ws.RangeUsed().RowsUsed().Skip(1).ToList();

                progressBarImport.Style = ProgressBarStyle.Continuous;
                progressBarImport.Maximum = rows.Count;
                progressBarImport.Value = 0;

                int processed = 0;

                foreach (var row in rows)
                {
                    try
                    {
                        int ma = row.Cell(1).GetValue<int>();
                        int soNhap = row.Cell(6).GetValue<int>();

                        bll.CapNhatSoLuong(ma, soNhap);
                        processed++;

                        progressBarImport.Value = processed;
                        lblProgressStatus.Text = $"Cập nhật: {processed}/{rows.Count}";
                        Application.DoEvents();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Lỗi: " + ex.Message);
                    }
                }
            }

            LoadData();
            MessageBox.Show("Import thành công!");
            pnlProgressContainer.Visible = false;
        }
    }
}
