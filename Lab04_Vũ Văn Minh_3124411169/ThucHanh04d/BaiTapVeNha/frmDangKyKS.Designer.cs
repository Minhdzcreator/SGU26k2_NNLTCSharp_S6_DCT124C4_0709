namespace WinFormsApp
{
    partial class frmDangkyKS
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.Label lblSoNgayO;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtSoNgayO;

        private System.Windows.Forms.GroupBox grpLoaiPhong;
        private System.Windows.Forms.RadioButton rdoPhongDon;
        private System.Windows.Forms.RadioButton rdoPhongDoi;
        private System.Windows.Forms.RadioButton rdoPhongBa;

        private System.Windows.Forms.GroupBox grpTienNghi;
        private System.Windows.Forms.CheckBox chkTivi;
        private System.Windows.Forms.CheckBox chkInternet;
        private System.Windows.Forms.CheckBox chkMayNuocNong;

        private System.Windows.Forms.GroupBox grpDichVu;
        private System.Windows.Forms.CheckBox chkKaraoke;
        private System.Windows.Forms.CheckBox chkAnSang;

        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnNhapMoi;
        private System.Windows.Forms.Label lblThanhTien;
        private System.Windows.Forms.TextBox txtThanhTien;

        private System.Windows.Forms.GroupBox grpTongKet;
        private System.Windows.Forms.Button btnTongKet;
        private System.Windows.Forms.Label lblTongSoKhach;
        private System.Windows.Forms.Label lblTongSoTien;
        private System.Windows.Forms.TextBox txtTongSoKhach;
        private System.Windows.Forms.TextBox txtTongSoTien;

        private System.Windows.Forms.Button btnThoat;

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
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.lblSoNgayO = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtSoNgayO = new System.Windows.Forms.TextBox();

            this.grpLoaiPhong = new System.Windows.Forms.GroupBox();
            this.rdoPhongDon = new System.Windows.Forms.RadioButton();
            this.rdoPhongDoi = new System.Windows.Forms.RadioButton();
            this.rdoPhongBa = new System.Windows.Forms.RadioButton();

            this.grpTienNghi = new System.Windows.Forms.GroupBox();
            this.chkTivi = new System.Windows.Forms.CheckBox();
            this.chkInternet = new System.Windows.Forms.CheckBox();
            this.chkMayNuocNong = new System.Windows.Forms.CheckBox();

            this.grpDichVu = new System.Windows.Forms.GroupBox();
            this.chkKaraoke = new System.Windows.Forms.CheckBox();
            this.chkAnSang = new System.Windows.Forms.CheckBox();

            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnNhapMoi = new System.Windows.Forms.Button();
            this.lblThanhTien = new System.Windows.Forms.Label();
            this.txtThanhTien = new System.Windows.Forms.TextBox();

            this.grpTongKet = new System.Windows.Forms.GroupBox();
            this.btnTongKet = new System.Windows.Forms.Button();
            this.lblTongSoKhach = new System.Windows.Forms.Label();
            this.lblTongSoTien = new System.Windows.Forms.Label();
            this.txtTongSoKhach = new System.Windows.Forms.TextBox();
            this.txtTongSoTien = new System.Windows.Forms.TextBox();

            this.btnThoat = new System.Windows.Forms.Button();

            this.grpLoaiPhong.SuspendLayout();
            this.grpTienNghi.SuspendLayout();
            this.grpDichVu.SuspendLayout();
            this.grpTongKet.SuspendLayout();
            this.SuspendLayout();

            // lblHeader
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Size = new System.Drawing.Size(650, 45);
            this.lblHeader.Text = "KHÁCH SẠN THANH THANH - TRẢ PHÒNG";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblHoTen, txtHoTen
            this.lblHoTen.Location = new System.Drawing.Point(20, 55);
            this.lblHoTen.Text = "Họ và tên:";
            this.txtHoTen.Location = new System.Drawing.Point(125, 52);
            this.txtHoTen.Size = new System.Drawing.Size(260, 23);
            this.txtHoTen.TextChanged += new System.EventHandler(this.Input_Changed);

            // lblDiaChi, txtDiaChi
            this.lblDiaChi.Location = new System.Drawing.Point(20, 88);
            this.lblDiaChi.Text = "Địa chỉ:";
            this.txtDiaChi.Location = new System.Drawing.Point(125, 85);
            this.txtDiaChi.Size = new System.Drawing.Size(260, 23);
            this.txtDiaChi.TextChanged += new System.EventHandler(this.Input_Changed);

            // lblSoNgayO, txtSoNgayO
            this.lblSoNgayO.Location = new System.Drawing.Point(20, 121);
            this.lblSoNgayO.Text = "Số ngày ở:";
            this.txtSoNgayO.Location = new System.Drawing.Point(125, 118);
            this.txtSoNgayO.Size = new System.Drawing.Size(100, 23);
            this.txtSoNgayO.TextChanged += new System.EventHandler(this.Input_Changed);
            this.txtSoNgayO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoNgayO_KeyPress);

            // grpLoaiPhong
            this.grpLoaiPhong.Controls.Add(this.rdoPhongDon);
            this.grpLoaiPhong.Controls.Add(this.rdoPhongDoi);
            this.grpLoaiPhong.Controls.Add(this.rdoPhongBa);
            this.grpLoaiPhong.Location = new System.Drawing.Point(20, 155);
            this.grpLoaiPhong.Size = new System.Drawing.Size(110, 120);
            this.grpLoaiPhong.Text = "Loại phòng";

            this.rdoPhongDon.Location = new System.Drawing.Point(10, 20);
            this.rdoPhongDon.Text = "Phòng đơn";
            this.rdoPhongDoi.Location = new System.Drawing.Point(10, 50);
            this.rdoPhongDoi.Text = "Phòng đôi";
            this.rdoPhongBa.Location = new System.Drawing.Point(10, 80);
            this.rdoPhongBa.Text = "Phòng ba";

            // grpTienNghi
            this.grpTienNghi.Controls.Add(this.chkTivi);
            this.grpTienNghi.Controls.Add(this.chkInternet);
            this.grpTienNghi.Controls.Add(this.chkMayNuocNong);
            this.grpTienNghi.Location = new System.Drawing.Point(140, 155);
            this.grpTienNghi.Size = new System.Drawing.Size(110, 120);
            this.grpTienNghi.Text = "Tiện nghi";

            this.chkTivi.Location = new System.Drawing.Point(10, 20);
            this.chkTivi.Text = "Tivi";
            this.chkInternet.Location = new System.Drawing.Point(10, 50);
            this.chkInternet.Text = "Internet";
            this.chkMayNuocNong.Location = new System.Drawing.Point(10, 80);
            this.chkMayNuocNong.Text = "Nước nóng";

            // grpDichVu
            this.grpDichVu.Controls.Add(this.chkKaraoke);
            this.grpDichVu.Controls.Add(this.chkAnSang);
            this.grpDichVu.Location = new System.Drawing.Point(260, 155);
            this.grpDichVu.Size = new System.Drawing.Size(100, 120);
            this.grpDichVu.Text = "Dịch vụ";

            this.chkKaraoke.Location = new System.Drawing.Point(10, 20);
            this.chkKaraoke.Text = "Karaoke";
            this.chkAnSang.Location = new System.Drawing.Point(10, 50);
            this.chkAnSang.Text = "Ăn sáng";

            // btnThanhToan & btnNhapMoi
            this.btnThanhToan.Location = new System.Drawing.Point(380, 50);
            this.btnThanhToan.Size = new System.Drawing.Size(90, 30);
            this.btnThanhToan.Text = "Thanh toán";
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);

            this.btnNhapMoi.Location = new System.Drawing.Point(480, 50);
            this.btnNhapMoi.Size = new System.Drawing.Size(90, 30);
            this.btnNhapMoi.Text = "Nhập mới";
            this.btnNhapMoi.Click += new System.EventHandler(this.btnNhapMoi_Click);

            // lblThanhTien & txtThanhTien
            this.lblThanhTien.Location = new System.Drawing.Point(380, 90);
            this.lblThanhTien.Text = "Thành tiền:";
            this.txtThanhTien.Location = new System.Drawing.Point(475, 87);
            this.txtThanhTien.Size = new System.Drawing.Size(180, 23);
            this.txtThanhTien.ReadOnly = true;

            // grpTongKet
            this.grpTongKet.Controls.Add(this.btnTongKet);
            this.grpTongKet.Controls.Add(this.lblTongSoKhach);
            this.grpTongKet.Controls.Add(this.lblTongSoTien);
            this.grpTongKet.Controls.Add(this.txtTongSoKhach);
            this.grpTongKet.Controls.Add(this.txtTongSoTien);
            this.grpTongKet.Location = new System.Drawing.Point(380, 125);
            this.grpTongKet.Size = new System.Drawing.Size(250, 120);
            this.grpTongKet.Text = "Thông tin tổng kết";

            this.btnTongKet.Location = new System.Drawing.Point(10, 20);
            this.btnTongKet.Size = new System.Drawing.Size(90, 28);
            this.btnTongKet.Text = "Tổng Kết";
            this.btnTongKet.Click += new System.EventHandler(this.btnTongKet_Click);

            this.lblTongSoKhach.Location = new System.Drawing.Point(10, 58);
            this.lblTongSoKhach.Text = "Số lượt người:";
            this.txtTongSoKhach.Location = new System.Drawing.Point(125, 55);
            this.txtTongSoKhach.Size = new System.Drawing.Size(140, 23);
            this.txtTongSoKhach.ReadOnly = true;

            this.lblTongSoTien.Location = new System.Drawing.Point(10, 88);
            this.lblTongSoTien.Text = "Tổng số tiền:";
            this.txtTongSoTien.Location = new System.Drawing.Point(125, 85);
            this.txtTongSoTien.Size = new System.Drawing.Size(140, 23);
            this.txtTongSoTien.ReadOnly = true;

            // btnThoat
            this.btnThoat.Location = new System.Drawing.Point(380, 250);
            this.btnThoat.Size = new System.Drawing.Size(90, 30);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            // Form Main
            this.ClientSize = new System.Drawing.Size(650, 300);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.lblHoTen);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.lblDiaChi);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.lblSoNgayO);
            this.Controls.Add(this.txtSoNgayO);
            this.Controls.Add(this.grpLoaiPhong);
            this.Controls.Add(this.grpTienNghi);
            this.Controls.Add(this.grpDichVu);
            this.Controls.Add(this.btnThanhToan);
            this.Controls.Add(this.btnNhapMoi);
            this.Controls.Add(this.lblThanhTien);
            this.Controls.Add(this.txtThanhTien);
            this.Controls.Add(this.grpTongKet);
            this.Controls.Add(this.btnThoat);

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmDangkyKS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDangkyKS";
            this.Load += new System.EventHandler(this.frmDangkyKS_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDangkyKS_FormClosing);

            this.grpLoaiPhong.ResumeLayout(false);
            this.grpTienNghi.ResumeLayout(false);
            this.grpDichVu.ResumeLayout(false);
            this.grpTongKet.ResumeLayout(false);
            this.grpTongKet.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

