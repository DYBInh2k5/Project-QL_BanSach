namespace QLBanSach_GUI
{
    partial class FrmCheckout
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.TableLayoutPanel tblTop;
        private System.Windows.Forms.Label lblMaNV;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label lblMaKH;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.Label lblCoupon;
        private System.Windows.Forms.TextBox txtCoupon;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Label lblTotal;

        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.GroupBox grpBooks;
        private System.Windows.Forms.DataGridView dgvBooks;
        private System.Windows.Forms.Panel pnlBooksActions;
        private System.Windows.Forms.FlowLayoutPanel flowBooksActions;
        private System.Windows.Forms.Button btnAddToCart;

        private System.Windows.Forms.SplitContainer splitRight;
        private System.Windows.Forms.GroupBox grpCart;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Panel pnlCartActions;
        private System.Windows.Forms.FlowLayoutPanel flowCartActions;
        private System.Windows.Forms.Button btnRemoveFromCart;

        private System.Windows.Forms.GroupBox grpQr;
        private System.Windows.Forms.PictureBox picQr;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.tblTop = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaNV = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.lblMaKH = new System.Windows.Forms.Label();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.lblCoupon = new System.Windows.Forms.Label();
            this.txtCoupon = new System.Windows.Forms.TextBox();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.grpBooks = new System.Windows.Forms.GroupBox();
            this.dgvBooks = new System.Windows.Forms.DataGridView();
            this.pnlBooksActions = new System.Windows.Forms.Panel();
            this.flowBooksActions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.splitRight = new System.Windows.Forms.SplitContainer();
            this.grpCart = new System.Windows.Forms.GroupBox();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.pnlCartActions = new System.Windows.Forms.Panel();
            this.flowCartActions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRemoveFromCart = new System.Windows.Forms.Button();
            this.grpQr = new System.Windows.Forms.GroupBox();
            this.picQr = new System.Windows.Forms.PictureBox();
            this.pnlTop.SuspendLayout();
            this.tblTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.grpBooks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
            this.pnlBooksActions.SuspendLayout();
            this.flowBooksActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitRight)).BeginInit();
            this.splitRight.Panel1.SuspendLayout();
            this.splitRight.Panel2.SuspendLayout();
            this.splitRight.SuspendLayout();
            this.grpCart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.pnlCartActions.SuspendLayout();
            this.flowCartActions.SuspendLayout();
            this.grpQr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQr)).BeginInit();
            this.SuspendLayout();
            // 
            // FrmCheckout
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(245, 246, 250);
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Checkout";
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.tblTop);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(12);
            this.pnlTop.Size = new System.Drawing.Size(1100, 88);
            this.pnlTop.TabIndex = 0;
            // 
            // tblTop
            // 
            this.tblTop.ColumnCount = 8;
            this.tblTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tblTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tblTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tblTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tblTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tblTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.tblTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tblTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblTop.Controls.Add(this.lblMaNV, 0, 0);
            this.tblTop.Controls.Add(this.txtMaNV, 1, 0);
            this.tblTop.Controls.Add(this.lblMaKH, 2, 0);
            this.tblTop.Controls.Add(this.txtMaKH, 3, 0);
            this.tblTop.Controls.Add(this.lblCoupon, 4, 0);
            this.tblTop.Controls.Add(this.txtCoupon, 5, 0);
            this.tblTop.Controls.Add(this.btnCheckout, 6, 0);
            this.tblTop.Controls.Add(this.lblTotal, 7, 0);
            this.tblTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblTop.Location = new System.Drawing.Point(12, 12);
            this.tblTop.Name = "tblTop";
            this.tblTop.RowCount = 1;
            this.tblTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tblTop.Size = new System.Drawing.Size(1076, 64);
            this.tblTop.TabIndex = 0;
            // 
            // lblMaNV
            // 
            this.lblMaNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaNV.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMaNV.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblMaNV.Location = new System.Drawing.Point(3, 0);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(64, 64);
            this.lblMaNV.TabIndex = 0;
            this.lblMaNV.Text = "Nhân viên:";
            this.lblMaNV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMaNV
            // 
            this.txtMaNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaNV.Location = new System.Drawing.Point(73, 3);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(174, 23);
            this.txtMaNV.TabIndex = 1;
            // 
            // lblMaKH
            // 
            this.lblMaKH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaKH.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMaKH.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblMaKH.Location = new System.Drawing.Point(253, 0);
            this.lblMaKH.Name = "lblMaKH";
            this.lblMaKH.Size = new System.Drawing.Size(64, 64);
            this.lblMaKH.TabIndex = 2;
            this.lblMaKH.Text = "Khách hàng:";
            this.lblMaKH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMaKH
            // 
            this.txtMaKH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaKH.Location = new System.Drawing.Point(323, 3);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(174, 23);
            this.txtMaKH.TabIndex = 3;
            // 
            // lblCoupon
            // 
            this.lblCoupon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCoupon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCoupon.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblCoupon.Location = new System.Drawing.Point(503, 0);
            this.lblCoupon.Name = "lblCoupon";
            this.lblCoupon.Size = new System.Drawing.Size(74, 64);
            this.lblCoupon.TabIndex = 4;
            this.lblCoupon.Text = "Coupon:";
            this.lblCoupon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCoupon
            // 
            this.txtCoupon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCoupon.Location = new System.Drawing.Point(583, 3);
            this.txtCoupon.Name = "txtCoupon";
            this.txtCoupon.Size = new System.Drawing.Size(214, 23);
            this.txtCoupon.TabIndex = 5;
            // 
            // btnCheckout
            // 
            this.btnCheckout.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnCheckout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCheckout.FlatAppearance.BorderSize = 0;
            this.btnCheckout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCheckout.ForeColor = System.Drawing.Color.White;
            this.btnCheckout.Location = new System.Drawing.Point(803, 3);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(194, 58);
            this.btnCheckout.TabIndex = 6;
            this.btnCheckout.Text = "Thanh toán & Tạo QR";
            this.btnCheckout.UseVisualStyleBackColor = false;
            // 
            // lblTotal
            // 
            this.lblTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblTotal.Location = new System.Drawing.Point(1003, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(70, 64);
            this.lblTotal.TabIndex = 7;
            this.lblTotal.Text = "Tổng: 0";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 88);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.grpBooks);
            this.splitMain.Panel1.Padding = new System.Windows.Forms.Padding(12);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.splitRight);
            this.splitMain.Panel2.Padding = new System.Windows.Forms.Padding(12);
            this.splitMain.Size = new System.Drawing.Size(1100, 612);
            this.splitMain.SplitterDistance = 540;
            this.splitMain.SplitterWidth = 6;
            this.splitMain.TabIndex = 1;
            // 
            // grpBooks
            // 
            this.grpBooks.Controls.Add(this.dgvBooks);
            this.grpBooks.Controls.Add(this.pnlBooksActions);
            this.grpBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBooks.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpBooks.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.grpBooks.Location = new System.Drawing.Point(12, 12);
            this.grpBooks.Name = "grpBooks";
            this.grpBooks.Padding = new System.Windows.Forms.Padding(10);
            this.grpBooks.Size = new System.Drawing.Size(516, 588);
            this.grpBooks.TabIndex = 0;
            this.grpBooks.TabStop = false;
            this.grpBooks.Text = "Danh sách sách";
            // 
            // dgvBooks
            // 
            this.dgvBooks.AllowUserToAddRows = false;
            this.dgvBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBooks.BackgroundColor = System.Drawing.Color.White;
            this.dgvBooks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBooks.Location = new System.Drawing.Point(10, 26);
            this.dgvBooks.MultiSelect = false;
            this.dgvBooks.Name = "dgvBooks";
            this.dgvBooks.ReadOnly = true;
            this.dgvBooks.RowHeadersVisible = false;
            this.dgvBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBooks.Size = new System.Drawing.Size(496, 518);
            this.dgvBooks.TabIndex = 0;
            // 
            // pnlBooksActions
            // 
            this.pnlBooksActions.Controls.Add(this.flowBooksActions);
            this.pnlBooksActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBooksActions.Location = new System.Drawing.Point(10, 544);
            this.pnlBooksActions.Name = "pnlBooksActions";
            this.pnlBooksActions.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.pnlBooksActions.Size = new System.Drawing.Size(496, 34);
            this.pnlBooksActions.TabIndex = 1;
            // 
            // flowBooksActions
            // 
            this.flowBooksActions.Controls.Add(this.btnAddToCart);
            this.flowBooksActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowBooksActions.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowBooksActions.Location = new System.Drawing.Point(10, 8);
            this.flowBooksActions.Name = "flowBooksActions";
            this.flowBooksActions.Size = new System.Drawing.Size(476, 18);
            this.flowBooksActions.TabIndex = 0;
            this.flowBooksActions.WrapContents = false;
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnAddToCart.FlatAppearance.BorderSize = 0;
            this.btnAddToCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddToCart.ForeColor = System.Drawing.Color.White;
            this.btnAddToCart.Location = new System.Drawing.Point(333, 3);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(140, 26);
            this.btnAddToCart.TabIndex = 0;
            this.btnAddToCart.Text = "Thêm vào giỏ >>";
            this.btnAddToCart.UseVisualStyleBackColor = false;
            // 
            // splitRight
            // 
            this.splitRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitRight.Location = new System.Drawing.Point(12, 12);
            this.splitRight.Name = "splitRight";
            // 
            // splitRight.Panel1
            // 
            this.splitRight.Panel1.Controls.Add(this.grpCart);
            // 
            // splitRight.Panel2
            // 
            this.splitRight.Panel2.Controls.Add(this.grpQr);
            this.splitRight.Size = new System.Drawing.Size(542, 588);
            this.splitRight.SplitterDistance = 360;
            this.splitRight.SplitterWidth = 6;
            this.splitRight.TabIndex = 0;
            // 
            // grpCart
            // 
            this.grpCart.Controls.Add(this.dgvCart);
            this.grpCart.Controls.Add(this.pnlCartActions);
            this.grpCart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpCart.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.grpCart.Location = new System.Drawing.Point(0, 0);
            this.grpCart.Name = "grpCart";
            this.grpCart.Padding = new System.Windows.Forms.Padding(10);
            this.grpCart.Size = new System.Drawing.Size(360, 588);
            this.grpCart.TabIndex = 0;
            this.grpCart.TabStop = false;
            this.grpCart.Text = "Giỏ hàng";
            // 
            // dgvCart
            // 
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCart.BackgroundColor = System.Drawing.Color.White;
            this.dgvCart.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCart.Location = new System.Drawing.Point(10, 26);
            this.dgvCart.MultiSelect = false;
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.RowHeadersVisible = false;
            this.dgvCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCart.Size = new System.Drawing.Size(340, 528);
            this.dgvCart.TabIndex = 0;
            // 
            // pnlCartActions
            // 
            this.pnlCartActions.Controls.Add(this.flowCartActions);
            this.pnlCartActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCartActions.Location = new System.Drawing.Point(10, 554);
            this.pnlCartActions.Name = "pnlCartActions";
            this.pnlCartActions.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.pnlCartActions.Size = new System.Drawing.Size(340, 34);
            this.pnlCartActions.TabIndex = 1;
            // 
            // flowCartActions
            // 
            this.flowCartActions.Controls.Add(this.btnRemoveFromCart);
            this.flowCartActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowCartActions.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowCartActions.Location = new System.Drawing.Point(10, 8);
            this.flowCartActions.Name = "flowCartActions";
            this.flowCartActions.Size = new System.Drawing.Size(320, 18);
            this.flowCartActions.TabIndex = 0;
            this.flowCartActions.WrapContents = false;
            // 
            // btnRemoveFromCart
            // 
            this.btnRemoveFromCart.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnRemoveFromCart.FlatAppearance.BorderSize = 0;
            this.btnRemoveFromCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveFromCart.ForeColor = System.Drawing.Color.White;
            this.btnRemoveFromCart.Location = new System.Drawing.Point(190, 3);
            this.btnRemoveFromCart.Name = "btnRemoveFromCart";
            this.btnRemoveFromCart.Size = new System.Drawing.Size(120, 26);
            this.btnRemoveFromCart.TabIndex = 0;
            this.btnRemoveFromCart.Text = "Xóa khỏi giỏ";
            this.btnRemoveFromCart.UseVisualStyleBackColor = false;
            // 
            // grpQr
            // 
            this.grpQr.Controls.Add(this.picQr);
            this.grpQr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpQr.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpQr.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.grpQr.Location = new System.Drawing.Point(0, 0);
            this.grpQr.Name = "grpQr";
            this.grpQr.Padding = new System.Windows.Forms.Padding(10);
            this.grpQr.Size = new System.Drawing.Size(176, 588);
            this.grpQr.TabIndex = 0;
            this.grpQr.TabStop = false;
            this.grpQr.Text = "QR thanh toán";
            // 
            // picQr
            // 
            this.picQr.BackColor = System.Drawing.Color.White;
            this.picQr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picQr.Location = new System.Drawing.Point(10, 26);
            this.picQr.Name = "picQr";
            this.picQr.Size = new System.Drawing.Size(156, 556);
            this.picQr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picQr.TabIndex = 0;
            this.picQr.TabStop = false;
            // 
            // finalize
            // 
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.pnlTop);
            this.ResumeLayout(false);
        }
    }
}