using Guna.UI2.WinForms;
using QLBanSach_DTO;
using QLBanSach_GUI.Dialogs;
using QLBanSach_GUI.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBanSach_GUI
{
    public partial class FrmMain : Form
    {
        #region Khai báo biến

        private Form currentFormChild = null;
        private UserControl currentUC;
        private NhanVienDTO currentUser;
        private int selectedCustomerId = 0;
        private string textToScroll = "Chào mừng bạn đến với bản điều khiển của Thư viên Võ Duy Bình";
        private float textY = 0;
        private Timer timer;

        private MenuStrip menuStrip;

        // Keep references to menu items for role-based access
        private ToolStripMenuItem mNhanSu;
        private ToolStripMenuItem mThongKe;
        private ToolStripMenuItem mTaiKhoan;
        private ToolStripMenuItem mKhachHang; // FIX: add missing field

        #endregion

        #region Constructor & Load

        public FrmMain()
        {
            InitializeComponent();
        }

        public FrmMain(NhanVienDTO nv) : this()
        {
            currentUser = nv;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                this.FormBorderStyle = FormBorderStyle.None;

                // Khởi tạo MenuStrip
                EnsureMenuStrip();

                // Initialize user info display
                if (currentUser == null)
                {
                    lblUsername.Text = "Xin chào: (chưa đăng nhập)";
                    lblRole.Text = "Vai trò: (chưa xác định)";
                    UpdateStatusBar("Chưa đăng nhập");
                }
                else
                {
                    lblUsername.Text = "Xin chào: " + currentUser.HoTen;
                    lblRole.Text = "Vai trò: " + currentUser.VaiTro;
                    UpdateStatusBar($"Đã đăng nhập: {currentUser.HoTen} ({currentUser.VaiTro})");
                }

                // NEW: Áp dụng phân quyền UI
                ApplyRolePermissions();

                // Initialize timer for scrolling text
                InitializeTimer();

                // Load home page
                lblTitle.Text = "Trang chủ";
                OpenUserControl(new UC_Home());
            }
            catch (Exception ex)
            {
                UpdateStatusBar("Lỗi: " + ex.Message);
                MessageBox.Show("Lỗi khi khởi động: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnsureMenuStrip()
        {
            if (menuStrip != null) return;

            menuStrip = new MenuStrip { Dock = DockStyle.Top };
            var mHeThong = new ToolStripMenuItem("Hệ thống");
            var mTrangChu = new ToolStripMenuItem("Trang chủ", null, (s, e) => btnHome_Click(s, e));
            var mBanHang = new ToolStripMenuItem("Bán hàng (POS)", null, (s, e) => guna2Button2_Click(s, e));
            var mHoaDon = new ToolStripMenuItem("Hóa đơn", null, (s, e) => btnInvoice_Click(s, e));
            var mKhuyenMai = new ToolStripMenuItem("Khuyến mãi", null, (s, e) => btnKhuyenMai_Click(s, e));
            var mNhapKho = new ToolStripMenuItem("Nhập kho", null, (s, e) => btnNhapKho_Click(s, e));

            // NEW: assign to fields so we can disable/hide later
            mNhanSu = new ToolStripMenuItem("Nhân sự", null, (s, e) => guna2Button1_Click(s, e));
            mKhachHang = new ToolStripMenuItem("Khách hàng", null, (s, e) => btnCustomer_Click(s, e));
            mThongKe = new ToolStripMenuItem("Thống kê", null, (s, e) => btnThongKe_Click(s, e));
            mTaiKhoan = new ToolStripMenuItem("Quản lý tài khoản", null, (s, e) => btnAccount_Click(s, e));
            var mDangXuat = new ToolStripMenuItem("Đăng xuất", null, (s, e) => btnLogout_Click(s, e));
            var mThoat = new ToolStripMenuItem("Thoát", null, (s, e) => btnClose_Click(s, e));

            mHeThong.DropDownItems.AddRange(new ToolStripItem[]
            {
                mTrangChu, mBanHang, mHoaDon, mKhuyenMai, mNhapKho, mNhanSu, mKhachHang, mThongKe,
                new ToolStripSeparator(), mTaiKhoan, mDangXuat, new ToolStripSeparator(), mThoat
            });

            menuStrip.Items.Add(mHeThong);

            // Chèn MenuStrip vào đầu form (trước các panel khác)
            Controls.Add(menuStrip);
            Controls.SetChildIndex(menuStrip, 0);
        }

        #endregion

        #region Form Control Methods

        private void OpenChildForm(Form childForm)
        {
            try
            {
                if (currentFormChild != null)
                    currentFormChild.Close();

                currentFormChild = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;

                pnlMain.Controls.Clear();
                pnlMain.Controls.Add(childForm);

                childForm.BringToFront();
                childForm.Show();

                UpdateStatusBar($"Đã mở: {childForm.Text}");
            }
            catch (Exception ex)
            {
                UpdateStatusBar("Lỗi: " + ex.Message);
            }
        }

        private void OpenUserControl(UserControl uc)
        {
            try
            {
                pnlMain.SuspendLayout();

                if (currentUC != null)
                {
                    pnlMain.Controls.Remove(currentUC);
                    currentUC.Dispose();
                }

                currentUC = uc;
                uc.Dock = DockStyle.Fill;
                pnlMain.Controls.Add(uc);
                uc.BringToFront();

                UpdateStatusBar("Sẵn sàng");
            }
            catch (Exception ex)
            {
                UpdateStatusBar("Lỗi: " + ex.Message);
            }
            finally
            {
                pnlMain.ResumeLayout();
            }
        }

        #endregion

        #region Navigation Button Events

        private void btnHome_Click(object sender, EventArgs e)
        {
            try
            {
                lblTitle.Text = "Trang chủ";
                OpenUserControl(new UC_Home());
            }
            catch (Exception ex)
            {
                UpdateStatusBar("Lỗi: " + ex.Message);
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            try
            {
                lblTitle.Text = "Quản lý Sách";
                UpdateStatusBar("Đang tải danh sách sách...");
                
                UC_Sach uc = new UC_Sach();
                uc.Dock = DockStyle.Fill;
                pnlMain.Controls.Clear();
                pnlMain.Controls.Add(uc);
                currentUC = uc;
                
                UpdateStatusBar("Quản lý Sách - Sẵn sàng");
            }
            catch (Exception ex)
            {
                UpdateStatusBar("Lỗi: " + ex.Message);
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                lblTitle.Text = "Quản lý Hóa đơn";
                UpdateStatusBar("Đang tải quản lý hóa đơn...");

                UC_HoaDon ucHoaDon = new UC_HoaDon
                {
                    CurrentUser = currentUser,
                    CurrentCustomerId = selectedCustomerId
                };
                OpenUserControl(ucHoaDon);
                
                UpdateStatusBar("Quản lý Hóa đơn - Sẵn sàng");
            }
            catch (Exception ex)
            {
                UpdateStatusBar("Lỗi: " + ex.Message);
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                lblTitle.Text = "Quản lý Khách hàng";
                UpdateStatusBar("Đang tải danh sách khách hàng...");

                UC_KhachHang uc = new UC_KhachHang();
                uc.CustomerSelected += (s, maKH) =>
                {
                    selectedCustomerId = maKH;
                    lblSelectedCustomer.Text = "Khách: " + maKH.ToString();
                    UpdateStatusBar($"Đã chọn khách: {maKH}");

                    if (currentUC is UC_HoaDon ucHoaDon)
                    {
                        ucHoaDon.CurrentCustomerId = selectedCustomerId;
                        ucHoaDon.SetSelectedCustomerDisplay("Khách: " + selectedCustomerId.ToString());
                    }
                };

                OpenUserControl(uc);
                UpdateStatusBar("Quản lý Khách hàng - Sẵn sàng");
            }
            catch (Exception ex)
            {
                UpdateStatusBar("Lỗi: " + ex.Message);
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                // NEW: Chặn người không phải Admin
                if (!IsAdmin())
                {
                    MessageBox.Show("Chức năng này chỉ dành cho Admin.", "Truy cập bị từ chối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                lblTitle.Text = "Thống kê Doanh Thu";
                UpdateStatusBar("Đang tải thống kê doanh thu...");
                
                OpenUserControl(new UC_ThongKe());
                
                UpdateStatusBar("Thống kê Doanh Thu - Sẵn sàng");
            }
            catch (Exception ex)
            {
                UpdateStatusBar("Lỗi: " + ex.Message);
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            try
            {
                // NEW: Chặn người không phải Admin
                if (!IsAdmin())
                {
                    MessageBox.Show("Chức năng này chỉ dành cho Admin.", "Truy cập bị từ chối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                lblTitle.Text = "Quản lý tài khoản";
                UpdateStatusBar("Đang tải quản lý tài khoản...");
                
                OpenChildForm(new frmQuanLyTaiKhoan());
                
                UpdateStatusBar("Quản lý tài khoản - Sẵn sàng");
            }
            catch (Exception ex)
            {
                UpdateStatusBar("Lỗi: " + ex.Message);
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                // NEW: Chặn người không phải Admin
                if (!IsAdmin())
                {
                    MessageBox.Show("Chức năng này chỉ dành cho Admin.", "Truy cập bị từ chối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                lblTitle.Text = "Quản lý Nhân sự";
                UpdateStatusBar("Đang tải quản lý nhân sự...");
                
                OpenUserControl(new UC_NhanSu());
                
                UpdateStatusBar("Quản lý Nhân sự - Sẵn sàng");
            }
            catch (Exception ex)
            {
                UpdateStatusBar("Lỗi: " + ex.Message);
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            FrmPlayground frm = new FrmPlayground();
            frm.ShowDialog();
        }

        private void btnNguyenVatLieu_Click(object sender, EventArgs e)
        {
            try
            {
                lblTitle.Text = "Quản lý Thể Loại";
                UpdateStatusBar("Đang tải quản lý thể loại...");
                
                OpenUserControl(new UC_TheLoaiSach());
                
                UpdateStatusBar("Quản lý Thể Loại - Sẵn sàng");
            }
            catch (Exception ex)
            {
                UpdateStatusBar("Lỗi: " + ex.Message);
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                lblTitle.Text = "Bán hàng (POS)";
                UpdateStatusBar("Đang tải POS...");
                
                UC_POS pos = new UC_POS();
                pos.Dock = DockStyle.Fill;
                pnlMain.Controls.Clear();
                pnlMain.Controls.Add(pos);
                currentUC = pos;
                
                UpdateStatusBar("Bán hàng (POS) - Sẵn sàng");
            }
            catch (Exception ex)
            {
                UpdateStatusBar("Lỗi: " + ex.Message);
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDoiTra_Click(object sender, EventArgs e)
        {
            try
            {
                lblTitle.Text = "Quản lý Đổi Trả";
                UpdateStatusBar("Đang tải quản lý đổi trả...");
                
                UC_DoiTra dt = new UC_DoiTra();
                dt.maHD = 123;
                pnlMain.Controls.Clear();
                pnlMain.Controls.Add(dt);
                dt.Dock = DockStyle.Fill;
                currentUC = dt;
                
                UpdateStatusBar("Quản lý Đổi Trả - Sẵn sàng");
            }
            catch (Exception ex)
            {
                UpdateStatusBar("Lỗi: " + ex.Message);
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            try
            {
                lblTitle.Text = "Quản lý Nhập kho";
                UpdateStatusBar("Đang tải quản lý nhập kho...");
                
                var uc = new UC_NhapKho
                {
                    CurrentUser = currentUser // NEW: truyền NV đăng nhập
                };
                OpenUserControl(uc);
                
                UpdateStatusBar("Quản lý Nhập kho - Sẵn sàng");
            }
            catch (Exception ex)
            {
                UpdateStatusBar("Lỗi: " + ex.Message);
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region ToolStrip Quick Action Buttons

        /// <summary>
        /// Refresh - F5
        /// </summary>
        private void btnToolRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateStatusBar("Đang làm mới dữ liệu...");

                if (currentUC != null)
                {
                    currentUC.Refresh();
                }

                UpdateStatusBar("Dữ liệu đã được làm mới");
            }
            catch (Exception ex)
            {
                UpdateStatusBar("Lỗi: " + ex.Message);
                MessageBox.Show("Lỗi khi làm mới: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Save - Ctrl+S
        /// </summary>
        private void btnToolSave_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateStatusBar("Đang lưu dữ liệu...");
                MessageBox.Show("Dữ liệu đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateStatusBar("Dữ liệu đã được lưu");
            }
            catch (Exception ex)
            {
                UpdateStatusBar("Lỗi: " + ex.Message);
                MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Print - Ctrl+P
        /// </summary>
        private void btnToolPrint_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateStatusBar("Đang chuẩn bị in...");
                MessageBox.Show("Chức năng in sẽ được triển khai!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateStatusBar("Sẵn sàng");
            }
            catch (Exception ex)
            {
                UpdateStatusBar("Lỗi: " + ex.Message);
            }
        }

        /// <summary>
        /// Export - Xuất Excel
        /// </summary>
        private void btnToolExport_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateStatusBar("Đang chuẩn bị xuất dữ liệu...");
                MessageBox.Show("Chức năng xuất Excel sẽ được triển khai!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateStatusBar("Sẵn sàng");
            }
            catch (Exception ex)
            {
                UpdateStatusBar("Lỗi: " + ex.Message);
            }
        }

        /// <summary>
        /// Search - Ctrl+F
        /// </summary>
        private void btnToolSearch_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateStatusBar("Mở cửa sổ tìm kiếm...");
                
                string searchTerm = PromptForInput("Nhập từ khóa tìm kiếm:", "Tìm kiếm");
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    UpdateStatusBar($"Tìm kiếm: '{searchTerm}'");
                }
                else
                {
                    UpdateStatusBar("Sẵn sàng");
                }
            }
            catch (Exception ex)
            {
                UpdateStatusBar("Lỗi: " + ex.Message);
            }
        }

        /// <summary>
        /// Settings
        /// </summary>
        private void btnToolSettings_Click(object sender, EventArgs e)
        {
            try
            {
                // NEW: Chặn người không phải Admin
                if (!IsAdmin())
                {
                    MessageBox.Show("Chức năng này chỉ dành cho Admin.", "Truy cập bị từ chối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                UpdateStatusBar("Mở cài đặt hệ thống...");

                FrmSettingsDialog settingsFrm = new FrmSettingsDialog();
                if (settingsFrm.ShowDialog() == DialogResult.OK)
                {
                    UpdateStatusBar("Cài đặt đã lưu thành công");
                    MessageBox.Show("Cài đặt đã được lưu. Một số thay đổi có thể cần khởi động lại ứng dụng.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                UpdateStatusBar("Lỗi: " + ex.Message);
                MessageBox.Show("Lỗi khi mở cài đặt: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public Color ShowColorDialog(Color initialColor = default)
        {
            if (initialColor == default)
                initialColor = Color.White;

            FrmColorDialog colorDlg = new FrmColorDialog(initialColor);
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                return colorDlg.SelectedColor;
            }
            return initialColor;
        }

        /// <summary>
        /// Show font picker dialog
        /// </summary>
        public Font ShowFontDialog(Font initialFont = null)
        {
            if (initialFont == null)
                initialFont = SystemFonts.DefaultFont;

            FrmFontDialog fontDlg = new FrmFontDialog(initialFont);
            if (fontDlg.ShowDialog() == DialogResult.OK)
            {
                return fontDlg.SelectedFont;
            }
            return initialFont;
        }
        public void ShowAboutDialog()
        {
            FrmAboutDialog aboutDlg = new FrmAboutDialog();
            aboutDlg.ShowDialog();
        }

        /// <summary>
        /// Help - F1
        /// </summary>
        private void btnToolHelp_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateStatusBar("Mở trợ giúp...");
                string helpText = "Hệ Thống Quản Lý Bán Sách v1.0\n\n" +
                                 "Các chức năng chính:\n" +
                                 "• F5: Làm mới dữ liệu\n" +
                                 "• Ctrl+S: Lưu dữ liệu\n" +
                                 "• Ctrl+P: In tài liệu\n" +
                                 "• Ctrl+F: Tìm kiếm\n" +
                                 "• F1: Trợ giúp\n\n" +
                                 "Liên hệ hỗ trợ: support@example.com";
                
                MessageBox.Show(helpText, "Trợ giúp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateStatusBar("Sẵn sàng");
            }
            catch (Exception ex)
            {
                UpdateStatusBar("Lỗi: " + ex.Message);
            }
        }

        #endregion

        #region Other Events

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                var r = MessageBox.Show("Bạn có chắc muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    UpdateStatusBar("Đang thoát ứng dụng...");
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                UpdateStatusBar("Lỗi: " + ex.Message);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                var r = MessageBox.Show("Bạn có chắc muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {
                    UpdateStatusBar("Đang đăng xuất...");
                    this.Hide();

                    FrmLogin frmLogin = new FrmLogin();
                    frmLogin.Show();

                    frmLogin.FormClosed += (s, args) => this.Close();
                }
            }
            catch (Exception ex)
            {
                UpdateStatusBar("Lỗi: " + ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                lblTime.Text = DateTime.Now.ToString("HH:mm:ss  dd/MM/yyyy");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Timer error: " + ex.Message);
            }
        }

        private void lblTime_Click(object sender, EventArgs e)
        {
            // Display current date/time info
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {
            // Panel paint event
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
            // Panel paint event
        }

        private void PnlLeft_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                e.Graphics.Clear(PnlLeft.BackColor);

                var state = e.Graphics.Save();
                e.Graphics.TranslateTransform(10, textY);
                e.Graphics.RotateTransform(-90);
                e.Graphics.DrawString(textToScroll, PnlLeft.Font, Brushes.White, 0, 0);
                e.Graphics.Restore(state);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Paint error: " + ex.Message);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            textY += 2;
            if (textY > PnlLeft.Height)
                textY = -TextRenderer.MeasureText(textToScroll, PnlLeft.Font).Width;

            PnlLeft.Invalidate();
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// NEW: Kiểm tra quyền Admin
        /// </summary>
        private bool IsAdmin()
        {
            return currentUser != null &&
                   !string.IsNullOrEmpty(currentUser.VaiTro) &&
                   string.Equals(currentUser.VaiTro, "Admin", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// NEW: Áp dụng phân quyền vào UI (ẩn/khóa các chức năng)
        /// </summary>
        private void ApplyRolePermissions()
        {
            bool isAdmin = IsAdmin();

            // Khóa/hide các menu dành cho Admin
            if (mNhanSu != null) mNhanSu.Visible = isAdmin;
            if (mThongKe != null) mThongKe.Visible = isAdmin;
            if (mTaiKhoan != null) mTaiKhoan.Visible = isAdmin;

            // Nếu có các nút toolbar/bên trái tương ứng, khóa chúng (an toàn)
            // Lưu ý: những control này cần tồn tại trong Designer
            try
            {
                // Ví dụ các nút tính năng:
                // btnThongKe: mở thống kê
                btnThongKe.Enabled = isAdmin;
            }
            catch { /* ignore if control not present */ }

            try
            {
                // nút mở Quản lý tài khoản
                // Nếu tên khác (ví dụ btnAccount), chúng ta đã chặn trong handler
                // ở đây chỉ cố gắng disable nếu có
                // btnAccountButton.Enabled = isAdmin; // nếu tồn tại
            }
            catch { }

            try
            {
                // nút mở Nhân sự
                // btnNhanSu.Enabled = isAdmin; // nếu tồn tại
            }
            catch { }

            // Cài đặt hệ thống: chỉ admin
            try
            {
                btnToolSettings.Enabled = isAdmin;
            }
            catch { }

            // Hồ sơ cá nhân: vẫn cho người dùng thường, chỉ tắt nếu muốn
            // Ở phiên bản trước có nhắc tới btnToolProfile; bỏ disable để người dùng vẫn xem hồ sơ
        }

        /// <summary>
        /// Update StatusStrip message
        /// </summary>
        private void UpdateStatusBar(string message)
        {
            try
            {
                toolStripStatusLabel.Text = message;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("StatusBar update error: " + ex.Message);
            }
        }

        /// <summary>
        /// Show input dialog
        /// </summary>
        private string PromptForInput(string prompt, string title)
        {
            Form promptForm = new Form()
            {
                Text = title,
                Width = 350,
                Height = 150,
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label label = new Label() { Left = 20, Top = 20, Text = prompt, Width = 310 };
            TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 310, Height = 30 };
            Button okBtn = new Button() { Text = "OK", Left = 150, Width = 80, Top = 80, DialogResult = DialogResult.OK };
            Button cancelBtn = new Button() { Text = "Hủy", Left = 235, Width = 80, Top = 80, DialogResult = DialogResult.Cancel };

            promptForm.Controls.Add(label);
            promptForm.Controls.Add(textBox);
            promptForm.Controls.Add(okBtn);
            promptForm.Controls.Add(cancelBtn);
            promptForm.AcceptButton = okBtn;
            promptForm.CancelButton = cancelBtn;

            return promptForm.ShowDialog() == DialogResult.OK ? textBox.Text : null;
        }

        /// <summary>
        /// Initialize timer for scrolling text
        /// </summary>
        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 30;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        #endregion

        private void tlpContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentUser == null)
                {
                    MessageBox.Show("Bạn chưa đăng nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                new QLBanSach_GUI.Dialogs.FrmProfile(currentUser).ShowDialog();
            }
            catch (Exception ex)
            {
                UpdateStatusBar("Lỗi: " + ex.Message);
            }
        }

        // Stop the scrolling timer when closing
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            try { timer?.Stop(); timer?.Dispose(); } catch { }
            base.OnFormClosed(e);
        }

        private void btnDanhSachSach_Click(object sender, EventArgs e)
        {
            try
            {
                lblTitle.Text = "Danh sách Sách";
                UpdateStatusBar("Đang tải danh sách sách...");

                OpenUserControl(new UC_DanhSachSach());

                UpdateStatusBar("Danh sách Sách - Sẵn sàng");
            }
            catch (Exception ex)
            {
                UpdateStatusBar("Lỗi: " + ex.Message);
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Navigation Button Events

        // Thêm handler mở màn hình Khuyến mãi
        private void btnKhuyenMai_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    // Nếu bạn đã thêm RequireLogin() ở bước trước, có thể dùng:
            //    // if (!RequireLogin()) return;

            //    if (currentUser == null)
            //    {
            //        MessageBox.Show("Vui lòng đăng nhập để sử dụng chức năng này.", "Thông báo",
            //            MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        UpdateStatusBar("Chưa đăng nhập");
            //        return;
            //    }

            //    lblTitle.Text = "Quản lý Khuyến mãi";
            //    UpdateStatusBar("Đang tải quản lý khuyến mãi...");

            //    OpenUserControl(new UC_KhuyenMai());

            //    UpdateStatusBar("Quản lý Khuyến mãi - Sẵn sàng");
            //}
            //catch (Exception ex)
            //{
            //    UpdateStatusBar("Lỗi: " + ex.Message);
            //    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        #endregion

        private void btnKhuyenMai_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Nếu bạn đã thêm RequireLogin() ở bước trước, có thể dùng:
                // if (!RequireLogin()) return;

                if (currentUser == null)
                {
                    MessageBox.Show("Vui lòng đăng nhập để sử dụng chức năng này.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateStatusBar("Chưa đăng nhập");
                    return;
                }

                lblTitle.Text = "Quản lý Khuyến mãi";
                UpdateStatusBar("Đang tải quản lý khuyến mãi...");

                OpenUserControl(new UC_KhuyenMai());

                UpdateStatusBar("Quản lý Khuyến mãi - Sẵn sàng");
            }
            catch (Exception ex)
            {
                UpdateStatusBar("Lỗi: " + ex.Message);
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOpenCheckout_Click(object sender, EventArgs e)
        {
            if (currentUser == null)
            {
                MessageBox.Show("Vui lòng đăng nhập trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (selectedCustomerId <= 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng trước khi thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Optional: navigate to Khách hàng to pick
                btnCustomer_Click(sender, e);
                return;
            }

            using (var frm = new FrmCheckout(currentUser)) // pass employee from login
            {
                frm.SetSelectedCustomer(selectedCustomerId); // use customer selected in UC_KhachHang
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog(this);
            }
        }
    }
}
