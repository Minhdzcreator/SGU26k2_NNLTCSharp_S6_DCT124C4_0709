namespace WinFormsApp
{
    partial class frmBai2
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle, lblNhapMang, lblKetQuaMang;
        private System.Windows.Forms.TextBox txtNhapMang, txtKetQuaMang;
        private System.Windows.Forms.Button btnReset, btnThoat, btnThucHien;

        // Sap xep
        private System.Windows.Forms.GroupBox grpSapXep;
        private System.Windows.Forms.RadioButton rdoSapXepTang, rdoSapXepGiam;

        // Tim kiem
        private System.Windows.Forms.GroupBox grpTimKiem;
        private System.Windows.Forms.RadioButton rdoTimGiaTri, rdoTimViTri;
        private System.Windows.Forms.TextBox txtTimGiaTri, txtTimViTri, txtSoTimDuoc;
        private System.Windows.Forms.Label lblSoTimDuoc;

        // Xoa
        private System.Windows.Forms.GroupBox grpXoa;
        private System.Windows.Forms.RadioButton rdoXoaGiaTri, rdoXoaViTri;
        private System.Windows.Forms.TextBox txtXoaGiaTri, txtXoaViTri;

        // Them
        private System.Windows.Forms.GroupBox grpThem;
        private System.Windows.Forms.RadioButton rdoGiaTriThem;
        private System.Windows.Forms.Label lblViTriThem;
        private System.Windows.Forms.TextBox txtGiaTriThem, txtViTriThem;

        // Tong
        private System.Windows.Forms.GroupBox grpTong;
        private System.Windows.Forms.Label lblTongMang, lblTongChan, lblTongLe;
        private System.Windows.Forms.TextBox txtTongMang, txtTongChan, txtTongLe;
        private System.Windows.Forms.Button btnTong;

        // Max Min
        private System.Windows.Forms.GroupBox grpMaxMin;
        private System.Windows.Forms.Label lblMax, lblMin;
        private System.Windows.Forms.TextBox txtMax, txtMin;
        private System.Windows.Forms.Button btnTimMaxMin;

        // Thay the
        private System.Windows.Forms.GroupBox grpThayThe;
        private System.Windows.Forms.RadioButton rdoThayTheGiaTri, rdoThayTheViTri;
        private System.Windows.Forms.Label lblSoThayThe;
        private System.Windows.Forms.TextBox txtThayTheGiaTri, txtThayTheViTri, txtSoThayThe;

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
            this.lblNhapMang = new System.Windows.Forms.Label();
            this.txtNhapMang = new System.Windows.Forms.TextBox();
            this.lblKetQuaMang = new System.Windows.Forms.Label();
            this.txtKetQuaMang = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnThucHien = new System.Windows.Forms.Button();

            // Sắp xếp
            this.grpSapXep = new System.Windows.Forms.GroupBox();
            this.rdoSapXepTang = new System.Windows.Forms.RadioButton();
            this.rdoSapXepGiam = new System.Windows.Forms.RadioButton();

            // Tìm kiếm
            this.grpTimKiem = new System.Windows.Forms.GroupBox();
            this.rdoTimGiaTri = new System.Windows.Forms.RadioButton();
            this.rdoTimViTri = new System.Windows.Forms.RadioButton();
            this.txtTimGiaTri = new System.Windows.Forms.TextBox();
            this.txtTimViTri = new System.Windows.Forms.TextBox();
            this.lblSoTimDuoc = new System.Windows.Forms.Label();
            this.txtSoTimDuoc = new System.Windows.Forms.TextBox();

            // Xóa
            this.grpXoa = new System.Windows.Forms.GroupBox();
            this.rdoXoaGiaTri = new System.Windows.Forms.RadioButton();
            this.rdoXoaViTri = new System.Windows.Forms.RadioButton();
            this.txtXoaGiaTri = new System.Windows.Forms.TextBox();
            this.txtXoaViTri = new System.Windows.Forms.TextBox();

            // Thêm
            this.grpThem = new System.Windows.Forms.GroupBox();
            this.rdoGiaTriThem = new System.Windows.Forms.RadioButton();
            this.lblViTriThem = new System.Windows.Forms.Label();
            this.txtGiaTriThem = new System.Windows.Forms.TextBox();
            this.txtViTriThem = new System.Windows.Forms.TextBox();

            // Tổng
            this.grpTong = new System.Windows.Forms.GroupBox();
            this.lblTongMang = new System.Windows.Forms.Label();
            this.lblTongChan = new System.Windows.Forms.Label();
            this.lblTongLe = new System.Windows.Forms.Label();
            this.txtTongMang = new System.Windows.Forms.TextBox();
            this.txtTongChan = new System.Windows.Forms.TextBox();
            this.txtTongLe = new System.Windows.Forms.TextBox();
            this.btnTong = new System.Windows.Forms.Button();

            // Max - Min
            this.grpMaxMin = new System.Windows.Forms.GroupBox();
            this.lblMax = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.btnTimMaxMin = new System.Windows.Forms.Button();

            // Thay thế
            this.grpThayThe = new System.Windows.Forms.GroupBox();
            this.rdoThayTheGiaTri = new System.Windows.Forms.RadioButton();
            this.rdoThayTheViTri = new System.Windows.Forms.RadioButton();
            this.lblSoThayThe = new System.Windows.Forms.Label();
            this.txtThayTheGiaTri = new System.Windows.Forms.TextBox();
            this.txtThayTheViTri = new System.Windows.Forms.TextBox();
            this.txtSoThayThe = new System.Windows.Forms.TextBox();

            this.grpSapXep.SuspendLayout();
            this.grpTimKiem.SuspendLayout();
            this.grpXoa.SuspendLayout();
            this.grpThem.SuspendLayout();
            this.grpTong.SuspendLayout();
            this.grpMaxMin.SuspendLayout();
            this.grpThayThe.SuspendLayout();
            this.SuspendLayout();

            // Top Header
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(120, 10);
            this.lblTitle.Text = "Mảng Số Nguyên";

            this.lblNhapMang.AutoSize = true;
            this.lblNhapMang.Location = new System.Drawing.Point(20, 50);
            this.lblNhapMang.Text = "Nhập mảng :";

            this.txtNhapMang.Location = new System.Drawing.Point(110, 47);
            this.txtNhapMang.Size = new System.Drawing.Size(180, 23);

            this.lblKetQuaMang.AutoSize = true;
            this.lblKetQuaMang.Location = new System.Drawing.Point(20, 80);
            this.lblKetQuaMang.Text = "Kết quả mảng :";

            this.txtKetQuaMang.Location = new System.Drawing.Point(110, 77);
            this.txtKetQuaMang.ReadOnly = true;
            this.txtKetQuaMang.Size = new System.Drawing.Size(180, 23);

            this.btnReset.Location = new System.Drawing.Point(300, 46);
            this.btnReset.Size = new System.Drawing.Size(65, 25);
            this.btnReset.Text = "Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);

            this.btnThoat.Location = new System.Drawing.Point(300, 76);
            this.btnThoat.Size = new System.Drawing.Size(65, 25);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            this.btnThucHien.Location = new System.Drawing.Point(20, 115);
            this.btnThucHien.Size = new System.Drawing.Size(80, 40);
            this.btnThucHien.Text = "Thực Hiện";
            this.btnThucHien.Click += new System.EventHandler(this.btnThucHien_Click);

            // Group Sắp Xếp
            this.grpSapXep.Controls.Add(this.rdoSapXepTang);
            this.grpSapXep.Controls.Add(this.rdoSapXepGiam);
            this.grpSapXep.Location = new System.Drawing.Point(110, 105);
            this.grpSapXep.Size = new System.Drawing.Size(255, 50);
            this.grpSapXep.Text = "Sắp Xếp";

            this.rdoSapXepTang.Checked = true;
            this.rdoSapXepTang.Location = new System.Drawing.Point(10, 20);
            this.rdoSapXepTang.Text = "Sắp xếp Tăng";

            this.rdoSapXepGiam.Location = new System.Drawing.Point(120, 20);
            this.rdoSapXepGiam.Text = "Sắp xếp Giảm";

            // Group Tìm Kiếm
            this.grpTimKiem.Controls.Add(this.rdoTimGiaTri);
            this.grpTimKiem.Controls.Add(this.rdoTimViTri);
            this.grpTimKiem.Controls.Add(this.txtTimGiaTri);
            this.grpTimKiem.Controls.Add(this.txtTimViTri);
            this.grpTimKiem.Controls.Add(this.lblSoTimDuoc);
            this.grpTimKiem.Controls.Add(this.txtSoTimDuoc);
            this.grpTimKiem.Location = new System.Drawing.Point(20, 160);
            this.grpTimKiem.Size = new System.Drawing.Size(170, 105);
            this.grpTimKiem.Text = "Tìm Kiếm";

            this.rdoTimGiaTri.Location = new System.Drawing.Point(5, 20);
            this.rdoTimGiaTri.Size = new System.Drawing.Size(110, 20);
            this.rdoTimGiaTri.Text = "Tìm giá trị cần tìm";

            this.rdoTimViTri.Checked = true;
            this.rdoTimViTri.Location = new System.Drawing.Point(5, 45);
            this.rdoTimViTri.Size = new System.Drawing.Size(110, 20);
            this.rdoTimViTri.Text = "Tìm vị trí cần tìm";

            this.txtTimGiaTri.Location = new System.Drawing.Point(120, 18);
            this.txtTimGiaTri.Size = new System.Drawing.Size(40, 23);

            this.txtTimViTri.Location = new System.Drawing.Point(120, 43);
            this.txtTimViTri.Size = new System.Drawing.Size(40, 23);

            this.lblSoTimDuoc.Location = new System.Drawing.Point(20, 75);
            this.lblSoTimDuoc.Text = "Số tìm được là :";

            this.txtSoTimDuoc.Location = new System.Drawing.Point(120, 72);
            this.txtSoTimDuoc.ReadOnly = true;
            this.txtSoTimDuoc.Size = new System.Drawing.Size(40, 23);

            // Group Xóa
            this.grpXoa.Controls.Add(this.rdoXoaGiaTri);
            this.grpXoa.Controls.Add(this.rdoXoaViTri);
            this.grpXoa.Controls.Add(this.txtXoaGiaTri);
            this.grpXoa.Controls.Add(this.txtXoaViTri);
            this.grpXoa.Location = new System.Drawing.Point(195, 160);
            this.grpXoa.Size = new System.Drawing.Size(170, 105);
            this.grpXoa.Text = "Xóa";

            this.rdoXoaGiaTri.Location = new System.Drawing.Point(5, 20);
            this.rdoXoaGiaTri.Size = new System.Drawing.Size(110, 20);
            this.rdoXoaGiaTri.Text = "Tìm giá trị cần xóa";

            this.rdoXoaViTri.Checked = true;
            this.rdoXoaViTri.Location = new System.Drawing.Point(5, 45);
            this.rdoXoaViTri.Size = new System.Drawing.Size(110, 20);
            this.rdoXoaViTri.Text = "Tìm vị trí cần xóa";

            this.txtXoaGiaTri.Location = new System.Drawing.Point(120, 18);
            this.txtXoaGiaTri.Size = new System.Drawing.Size(40, 23);

            this.txtXoaViTri.Location = new System.Drawing.Point(120, 43);
            this.txtXoaViTri.Size = new System.Drawing.Size(40, 23);

            // Group Thêm
            this.grpThem.Controls.Add(this.rdoGiaTriThem);
            this.grpThem.Controls.Add(this.lblViTriThem);
            this.grpThem.Controls.Add(this.txtGiaTriThem);
            this.grpThem.Controls.Add(this.txtViTriThem);
            this.grpThem.Location = new System.Drawing.Point(20, 270);
            this.grpThem.Size = new System.Drawing.Size(170, 90);
            this.grpThem.Text = "Thêm";

            this.rdoGiaTriThem.Checked = true;
            this.rdoGiaTriThem.Location = new System.Drawing.Point(5, 20);
            this.rdoGiaTriThem.Size = new System.Drawing.Size(110, 20);
            this.rdoGiaTriThem.Text = "Tìm giá trị cần thêm";

            this.lblViTriThem.Location = new System.Drawing.Point(10, 50);
            this.lblViTriThem.Text = "Tại vị trí cần thêm :";

            this.txtGiaTriThem.Location = new System.Drawing.Point(120, 18);
            this.txtGiaTriThem.Size = new System.Drawing.Size(40, 23);

            this.txtViTriThem.Location = new System.Drawing.Point(120, 47);
            this.txtViTriThem.Size = new System.Drawing.Size(40, 23);

            // Group Tổng
            this.grpTong.Controls.Add(this.lblTongMang);
            this.grpTong.Controls.Add(this.lblTongChan);
            this.grpTong.Controls.Add(this.lblTongLe);
            this.grpTong.Controls.Add(this.txtTongMang);
            this.grpTong.Controls.Add(this.txtTongChan);
            this.grpTong.Controls.Add(this.txtTongLe);
            this.grpTong.Controls.Add(this.btnTong);
            this.grpTong.Location = new System.Drawing.Point(195, 270);
            this.grpTong.Size = new System.Drawing.Size(170, 90);
            this.grpTong.Text = "Tổng";

            this.lblTongMang.Location = new System.Drawing.Point(5, 18);
            this.lblTongMang.Text = "Tổng mảng";
            this.lblTongChan.Location = new System.Drawing.Point(5, 40);
            this.lblTongChan.Text = "Tổng chẵn";
            this.lblTongLe.Location = new System.Drawing.Point(5, 62);
            this.lblTongLe.Text = "Tổng lẻ";

            this.txtTongMang.Location = new System.Drawing.Point(70, 15);
            this.txtTongMang.ReadOnly = true;
            this.txtTongMang.Size = new System.Drawing.Size(45, 23);

            this.txtTongChan.Location = new System.Drawing.Point(70, 37);
            this.txtTongChan.ReadOnly = true;
            this.txtTongChan.Size = new System.Drawing.Size(45, 23);

            this.txtTongLe.Location = new System.Drawing.Point(70, 59);
            this.txtTongLe.ReadOnly = true;
            this.txtTongLe.Size = new System.Drawing.Size(45, 23);

            this.btnTong.Location = new System.Drawing.Point(120, 15);
            this.btnTong.Size = new System.Drawing.Size(45, 67);
            this.btnTong.Text = "Tổng";
            this.btnTong.Click += new System.EventHandler(this.btnTong_Click);

            // Group Max-Min
            this.grpMaxMin.Controls.Add(this.lblMax);
            this.grpMaxMin.Controls.Add(this.lblMin);
            this.grpMaxMin.Controls.Add(this.txtMax);
            this.grpMaxMin.Controls.Add(this.txtMin);
            this.grpMaxMin.Controls.Add(this.btnTimMaxMin);
            this.grpMaxMin.Location = new System.Drawing.Point(20, 365);
            this.grpMaxMin.Size = new System.Drawing.Size(170, 80);
            this.grpMaxMin.Text = "Max - Min";

            this.lblMax.Location = new System.Drawing.Point(5, 20);
            this.lblMax.Text = "Giá trị lớn nhất";
            this.lblMin.Location = new System.Drawing.Point(5, 48);
            this.lblMin.Text = "Giá trị nhỏ nhất";

            this.txtMax.Location = new System.Drawing.Point(85, 17);
            this.txtMax.ReadOnly = true;
            this.txtMax.Size = new System.Drawing.Size(35, 23);

            this.txtMin.Location = new System.Drawing.Point(85, 45);
            this.txtMin.ReadOnly = true;
            this.txtMin.Size = new System.Drawing.Size(35, 23);

            this.btnTimMaxMin.Location = new System.Drawing.Point(125, 17);
            this.btnTimMaxMin.Size = new System.Drawing.Size(40, 51);
            this.btnTimMaxMin.Text = "Tìm";
            this.btnTimMaxMin.Click += new System.EventHandler(this.btnTimMaxMin_Click);

            // Group Thay Thế
            this.grpThayThe.Controls.Add(this.rdoThayTheGiaTri);
            this.grpThayThe.Controls.Add(this.rdoThayTheViTri);
            this.grpThayThe.Controls.Add(this.lblSoThayThe);
            this.grpThayThe.Controls.Add(this.txtThayTheGiaTri);
            this.grpThayThe.Controls.Add(this.txtThayTheViTri);
            this.grpThayThe.Controls.Add(this.txtSoThayThe);
            this.grpThayThe.Location = new System.Drawing.Point(195, 365);
            this.grpThayThe.Size = new System.Drawing.Size(170, 100);
            this.grpThayThe.Text = "Thay Thế";

            this.rdoThayTheGiaTri.Checked = true;
            this.rdoThayTheGiaTri.Location = new System.Drawing.Point(5, 20);
            this.rdoThayTheGiaTri.Size = new System.Drawing.Size(110, 20);
            this.rdoThayTheGiaTri.Text = "Giá trị cần thay thế";

            this.rdoThayTheViTri.Location = new System.Drawing.Point(5, 45);
            this.rdoThayTheViTri.Size = new System.Drawing.Size(110, 20);
            this.rdoThayTheViTri.Text = "Vị trí cần thay thế";

            this.txtThayTheGiaTri.Location = new System.Drawing.Point(120, 18);
            this.txtThayTheGiaTri.Size = new System.Drawing.Size(40, 23);

            this.txtThayTheViTri.Location = new System.Drawing.Point(120, 43);
            this.txtThayTheViTri.Size = new System.Drawing.Size(40, 23);

            this.lblSoThayThe.Location = new System.Drawing.Point(20, 72);
            this.lblSoThayThe.Text = "Số thay thế là :";

            this.txtSoThayThe.Location = new System.Drawing.Point(120, 69);
            this.txtSoThayThe.Size = new System.Drawing.Size(40, 23);

            // Form Main
            this.ClientSize = new System.Drawing.Size(385, 475);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblNhapMang);
            this.Controls.Add(this.txtNhapMang);
            this.Controls.Add(this.lblKetQuaMang);
            this.Controls.Add(this.txtKetQuaMang);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnThucHien);
            this.Controls.Add(this.grpSapXep);
            this.Controls.Add(this.grpTimKiem);
            this.Controls.Add(this.grpXoa);
            this.Controls.Add(this.grpThem);
            this.Controls.Add(this.grpTong);
            this.Controls.Add(this.grpMaxMin);
            this.Controls.Add(this.grpThayThe);

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmBai2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mảng Số Nguyên";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBai2_FormClosing);

            this.grpSapXep.ResumeLayout(false);
            this.grpTimKiem.ResumeLayout(false);
            this.grpTimKiem.PerformLayout();
            this.grpXoa.ResumeLayout(false);
            this.grpXoa.PerformLayout();
            this.grpThem.ResumeLayout(false);
            this.grpThem.PerformLayout();
            this.grpTong.ResumeLayout(false);
            this.grpTong.PerformLayout();
            this.grpMaxMin.ResumeLayout(false);
            this.grpMaxMin.PerformLayout();
            this.grpThayThe.ResumeLayout(false);
            this.grpThayThe.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
