using System;
using System.Data;
using System.Windows.Forms;

namespace QLBanSach_GUI
{
    public partial class FrmChiTietHoaDon : Form
    {
        public int MaHD { get; }  // giữ Mã Hóa Đơn để chỉnh sửa/đổi trả

        public FrmChiTietHoaDon(DataTable chiTiet, int maHD, string tongTien, DateTime ngayLap, string khuyenMaiInfo = null)
        {
            InitializeComponent();
            MaHD = maHD;
            lblMaHD.Text = "Mã hóa đơn: " + maHD;
            lblNgay.Text = "Ngày lập: " + ngayLap.ToString("dd/MM/yyyy HH:mm");
            lblTongTien.Text = "Tổng tiền: " + tongTien;
            lblKhuyenMai.Text = "Khuyến mãi: " + (string.IsNullOrWhiteSpace(khuyenMaiInfo) ? "-" : khuyenMaiInfo);
            dgvChiTiet.DataSource = chiTiet;
        }

        private void FrmChiTietHoaDon_Load(object sender, EventArgs e)
        {
            dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTiet.ReadOnly = true;
            if (dgvChiTiet.Columns.Contains("DonGia"))
                dgvChiTiet.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            if (dgvChiTiet.Columns.Contains("ThanhTien"))
                dgvChiTiet.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
