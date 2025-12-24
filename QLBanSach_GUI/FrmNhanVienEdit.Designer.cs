    namespace QLBanSach_GUI.Forms
{
    partial class FrmNhanVienEdit
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblMaNV = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblTaiKhoan = new System.Windows.Forms.Label();
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.lblDienThoai = new System.Windows.Forms.Label();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblVaiTro = new System.Windows.Forms.Label();
            this.cmbVaiTro = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMaNV
            // 
            this.lblMaNV.AutoSize = true;
            this.lblMaNV.Location = new System.Drawing.Point(12, 15);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(40, 13);
            this.lblMaNV.Text = "Mã NV";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(110, 12);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(220, 20);
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(12, 45);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(39, 13);
            this.lblHoTen.Text = "Họ tên";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(110, 42);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(220, 20);
            // 
            // lblTaiKhoan
            // 
            this.lblTaiKhoan.AutoSize = true;
            this.lblTaiKhoan.Location = new System.Drawing.Point(12, 75);
            this.lblTaiKhoan.Name = "lblTaiKhoan";
            this.lblTaiKhoan.Size = new System.Drawing.Size(56, 13);
            this.lblTaiKhoan.Text = "Tài khoản";
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.Location = new System.Drawing.Point(110, 72);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Size = new System.Drawing.Size(220, 20);
            // 
            // lblMatKhau
            // 
            this.lblMatKhau.AutoSize = true;
            this.lblMatKhau.Location = new System.Drawing.Point(12, 105);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Size = new System.Drawing.Size(52, 13);
            this.lblMatKhau.Text = "Mật khẩu";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(110, 102);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(220, 20);
            this.txtMatKhau.UseSystemPasswordChar = true;
            // 
            // lblDienThoai
            // 
            this.lblDienThoai.AutoSize = true;
            this.lblDienThoai.Location = new System.Drawing.Point(12, 135);
            this.lblDienThoai.Name = "lblDienThoai";
            this.lblDienThoai.Size = new System.Drawing.Size(61, 13);
            this.lblDienThoai.Text = "Điện thoại";
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Location = new System.Drawing.Point(110, 132);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(220, 20);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(12, 165);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(110, 162);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(220, 20);
            // 
            // lblVaiTro
            // 
            this.lblVaiTro.AutoSize = true;
            this.lblVaiTro.Location = new System.Drawing.Point(12, 195);
            this.lblVaiTro.Name = "lblVaiTro";
            this.lblVaiTro.Size = new System.Drawing.Size(38, 13);
            this.lblVaiTro.Text = "Vai trò";
            // 
            // cmbVaiTro
            // 
            this.cmbVaiTro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVaiTro.Items.AddRange(new object[] { "Nhân viên", "Admin" });
            this.cmbVaiTro.Location = new System.Drawing.Point(110, 192);
            this.cmbVaiTro.Name = "cmbVaiTro";
            this.cmbVaiTro.Size = new System.Drawing.Size(220, 21);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(110, 230);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 28);
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(240, 230);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 28);
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmNhanVienEdit
            // 
            this.ClientSize = new System.Drawing.Size(360, 280);
            this.Controls.Add(this.lblMaNV);
            this.Controls.Add(this.txtMaNV);
            this.Controls.Add(this.lblHoTen);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.lblTaiKhoan);
            this.Controls.Add(this.txtTaiKhoan);
            this.Controls.Add(this.lblMatKhau);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.lblDienThoai);
            this.Controls.Add(this.txtDienThoai);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblVaiTro);
            this.Controls.Add(this.cmbVaiTro);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmNhanVienEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblMaNV;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblTaiKhoan;
        private System.Windows.Forms.TextBox txtTaiKhoan;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Label lblDienThoai;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblVaiTro;
        private System.Windows.Forms.ComboBox cmbVaiTro;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}