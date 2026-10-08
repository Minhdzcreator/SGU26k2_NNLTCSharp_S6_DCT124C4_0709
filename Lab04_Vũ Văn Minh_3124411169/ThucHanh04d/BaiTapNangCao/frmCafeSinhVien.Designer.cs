namespace WinFormsApp
{
    partial class frmCafeSinhVien
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTenKhach;
        private System.Windows.Forms.Label lblSoKhach;
        private System.Windows.Forms.TextBox txtTenKhach;
        private System.Windows.Forms.TextBox txtSoKhach;
        private System.Windows.Forms.CheckBox chkSinhVien;

        private System.Windows.Forms.GroupBox grpNuocUong;
        private System.Windows.Forms.RadioButton rdoCafeDen;
        private System.Windows.Forms.RadioButton rdoCafeDa;
        private System.Windows.Forms.RadioButton rdoCafeSua;
        private System.Windows.Forms.RadioButton rdoCafeSuaDa;
        private System.Windows.Forms.RadioButton rdoCafeKem;

        private System.Windows.Forms.GroupBox grpThucAn;
        private System.Windows.Forms.CheckBox chkBanhMyTrung;
        private System.Windows.Forms.CheckBox chkBanhMyCa;
        private System.Windows.Forms.CheckBox chkMyTomTrung;
        private System.Windows.Forms.CheckBox chkMyXaoBo;
        private System.Windows.Forms.CheckBox chkMyCay;

        private System.Windows.Forms.Button btnTinhTien;
        private System.Windows.Forms.Button btnNhapLai;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnThoat;

        private System.Windows.Forms.Label lblTongKhachHang;
        private System.Windows.Forms.Label lblTongTienThanhToan;
        private System.Windows.Forms.TextBox txtTongKhachHang;
        private System.Windows.Forms.TextBox txtTongTienThanhToan;

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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTenKhach = new System.Windows.Forms.Label();
            this.lblSoKhach = new System.Windows.Forms.Label();
            this.txtTenKhach = new System.Windows.Forms.TextBox();
            this.txtSoKhach = new System.Windows.Forms.TextBox();
            this.chkSinhVien = new System.Windows.Forms.CheckBox();

            this.grpNuocUong = new System.Windows.Forms.GroupBox();
            this.rdoCafeDen = new System.Windows.Forms.RadioButton();
            this.rdoCafeDa = new System.Windows.Forms.RadioButton();
            this.rdoCafeSua = new System.Windows.Forms.RadioButton();
            this.rdoCafeSuaDa = new System.Windows.Forms.RadioButton();
            this.rdoCafeKem = new System.Windows.Forms.RadioButton();

            this.grpThucAn = new System.Windows.Forms.GroupBox();
            this.chkBanhMyTrung = new System.Windows.Forms.CheckBox();
            this.chkBanhMyCa = new System.Windows.Forms.CheckBox();
            this.chkMyTomTrung = new System.Windows.Forms.CheckBox();
            this.chkMyXaoBo = new System.Windows.Forms.CheckBox();
            this.chkMyCay = new System.Windows.Forms.CheckBox();

            this.btnTinhTien = new System.Windows.Forms.Button();
            this.btnNhapLai = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();

            this.lblTongKhachHang = new System.Windows.Forms.Label();
            this.lblTongTienThanhToan = new System.Windows.Forms.Label();
            this.txtTongKhachHang = new System.Windows.Forms.TextBox();
            this.txtTongTienThanhToan = new System.Windows.Forms.TextBox();

            this.grpNuocUong.SuspendLayout();
            this.grpThucAn.SuspendLayout();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblTitle.Location = new System.Drawing.Point(120, 15);
            this.lblTitle.Text = "CAFE SINH VIÊN";

            // lblTenKhach
            this.lblTenKhach.AutoSize = true;
            this.lblTenKhach.Location = new System.Drawing.Point(30, 60);
            this.lblTenKhach.Text = "Tên khách hàng";

            // txtTenKhach
            this.txtTenKhach.Location = new System.Drawing.Point(140, 57);
            this.txtTenKhach.Size = new System.Drawing.Size(250, 23);
            this.txtTenKhach.TextChanged += new System.EventHandler(this.Input_Changed);

            // lblSoKhach
            this.lblSoKhach.AutoSize = true;
            this.lblSoKhach.Location = new System.Drawing.Point(30, 90);
            this.lblSoKhach.Text = "Số khách hàng";

            // txtSoKhach
            this.txtSoKhach.Location = new System.Drawing.Point(140, 87);
            this.txtSoKhach.Size = new System.Drawing.Size(250, 23);
            this.txtSoKhach.TextChanged += new System.EventHandler(this.Input_Changed);
            this.txtSoKhach.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoKhach_KeyPress);

            // chkSinhVien
            this.chkSinhVien.AutoSize = true;
            this.chkSinhVien.Location = new System.Drawing.Point(170, 120);
            this.chkSinhVien.Text = "Sinh viên ?";

            // grpNuocUong
            this.grpNuocUong.Controls.Add(this.rdoCafeDen);
            this.grpNuocUong.Controls.Add(this.rdoCafeDa);
            this.grpNuocUong.Controls.Add(this.rdoCafeSua);
            this.grpNuocUong.Controls.Add(this.rdoCafeSuaDa);
            this.grpNuocUong.Controls.Add(this.rdoCafeKem);
            this.grpNuocUong.Location = new System.Drawing.Point(30, 155);
            this.grpNuocUong.Size = new System.Drawing.Size(180, 150);
            this.grpNuocUong.Text = "Nước uống";

            this.rdoCafeDen.Location = new System.Drawing.Point(10, 20);
            this.rdoCafeDen.Text = "Cafe đen";
            this.rdoCafeDen.CheckedChanged += new System.EventHandler(this.Input_Changed);

            this.rdoCafeDa.Location = new System.Drawing.Point(10, 45);
            this.rdoCafeDa.Text = "Cafe đá";
            this.rdoCafeDa.CheckedChanged += new System.EventHandler(this.Input_Changed);

            this.rdoCafeSua.Location = new System.Drawing.Point(10, 70);
            this.rdoCafeSua.Text = "Cafe sữa";
            this.rdoCafeSua.CheckedChanged += new System.EventHandler(this.Input_Changed);

            this.rdoCafeSuaDa.Location = new System.Drawing.Point(10, 95);
            this.rdoCafeSuaDa.Text = "Cafe sữa đá";
            this.rdoCafeSuaDa.CheckedChanged += new System.EventHandler(this.Input_Changed);

            this.rdoCafeKem.Location = new System.Drawing.Point(10, 120);
            this.rdoCafeKem.Text = "Cafe kem";
            this.rdoCafeKem.CheckedChanged += new System.EventHandler(this.Input_Changed);

            // grpThucAn
            this.grpThucAn.Controls.Add(this.chkBanhMyTrung);
            this.grpThucAn.Controls.Add(this.chkBanhMyCa);
            this.grpThucAn.Controls.Add(this.chkMyTomTrung);
            this.grpThucAn.Controls.Add(this.chkMyXaoBo);
            this.grpThucAn.Controls.Add(this.chkMyCay);
            this.grpThucAn.Location = new System.Drawing.Point(220, 155);
            this.grpThucAn.Size = new System.Drawing.Size(170, 150);
            this.grpThucAn.Text = "Thức ăn";

            this.chkBanhMyTrung.Location = new System.Drawing.Point(10, 20);
            this.chkBanhMyTrung.Text = "Bánh mì trứng";
            this.chkBanhMyTrung.CheckedChanged += new System.EventHandler(this.Input_Changed);

            this.chkBanhMyCa.Location = new System.Drawing.Point(10, 45);
            this.chkBanhMyCa.Text = "Bánh mì cá";
            this.chkBanhMyCa.CheckedChanged += new System.EventHandler(this.Input_Changed);

            this.chkMyTomTrung.Location = new System.Drawing.Point(10, 70);
            this.chkMyTomTrung.Text = "Mỳ tôm trứng";
            this.chkMyTomTrung.CheckedChanged += new System.EventHandler(this.Input_Changed);

            this.chkMyXaoBo.Location = new System.Drawing.Point(10, 95);
            this.chkMyXaoBo.Text = "Mỳ xào bò";
            this.chkMyXaoBo.CheckedChanged += new System.EventHandler(this.Input_Changed);

            this.chkMyCay.Location = new System.Drawing.Point(10, 120);
            this.chkMyCay.Text = "Mỳ cay";
            this.chkMyCay.CheckedChanged += new System.EventHandler(this.Input_Changed);

            // Buttons
            this.btnTinhTien.Location = new System.Drawing.Point(30, 325);
            this.btnTinhTien.Size = new System.Drawing.Size(80, 30);
            this.btnTinhTien.Text = "Tính tiền";
            this.btnTinhTien.Click += new System.EventHandler(this.btnTinhTien_Click);

            this.btnNhapLai.Location = new System.Drawing.Point(120, 325);
            this.btnNhapLai.Size = new System.Drawing.Size(80, 30);
            this.btnNhapLai.Text = "Nhập lại";
            this.btnNhapLai.Click += new System.EventHandler(this.btnNhapLai_Click);

            this.btnThanhToan.Location = new System.Drawing.Point(210, 325);
            this.btnThanhToan.Size = new System.Drawing.Size(80, 30);
            this.btnThanhToan.Text = "Thanh toán";
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);

            this.btnThoat.Location = new System.Drawing.Point(300, 325);
            this.btnThoat.Size = new System.Drawing.Size(80, 30);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            // Bottom Labels & TextBoxes
            this.lblTongKhachHang.AutoSize = true;
            this.lblTongKhachHang.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTongKhachHang.Location = new System.Drawing.Point(30, 375);
            this.lblTongKhachHang.Text = "Tổng khách hàng";

            this.txtTongKhachHang.Location = new System.Drawing.Point(170, 372);
            this.txtTongKhachHang.ReadOnly = true;
            this.txtTongKhachHang.Size = new System.Drawing.Size(220, 23);

            this.lblTongTienThanhToan.AutoSize = true;
            this.lblTongTienThanhToan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTongTienThanhToan.Location = new System.Drawing.Point(30, 405);
            this.lblTongTienThanhToan.Text = "Tổng tiền thanh toán";

            this.txtTongTienThanhToan.Location = new System.Drawing.Point(170, 402);
            this.txtTongTienThanhToan.ReadOnly = true;
            this.txtTongTienThanhToan.Size = new System.Drawing.Size(220, 23);

            // Form Main
            this.ClientSize = new System.Drawing.Size(420, 450);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblTenKhach);
            this.Controls.Add(this.lblSoKhach);
            this.Controls.Add(this.txtTenKhach);
            this.Controls.Add(this.txtSoKhach);
            this.Controls.Add(this.chkSinhVien);
            this.Controls.Add(this.grpNuocUong);
            this.Controls.Add(this.grpThucAn);
            this.Controls.Add(this.btnTinhTien);
            this.Controls.Add(this.btnNhapLai);
            this.Controls.Add(this.btnThanhToan);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.lblTongKhachHang);
            this.Controls.Add(this.lblTongTienThanhToan);
            this.Controls.Add(this.txtTongKhachHang);
            this.Controls.Add(this.txtTongTienThanhToan);

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmCafeSinhVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thanh toán tiền";
            this.Load += new System.EventHandler(this.frmCafeSinhVien_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCafeSinhVien_FormClosing);

            this.grpNuocUong.ResumeLayout(false);
            this.grpThucAn.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
