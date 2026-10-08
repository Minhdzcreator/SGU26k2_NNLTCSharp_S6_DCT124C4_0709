namespace WinFormsApp
{
    partial class frmBai01NangCao
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblManAnh;
        private System.Windows.Forms.Label lblThanhTien;
        private System.Windows.Forms.TextBox txtThanhTien;
        private System.Windows.Forms.Button btnChon;
        private System.Windows.Forms.Button btnHuyBo;
        private System.Windows.Forms.Button btnKetThuc;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            } base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblManAnh = new System.Windows.Forms.Label();
            this.lblThanhTien = new System.Windows.Forms.Label();
            this.txtThanhTien = new System.Windows.Forms.TextBox();
            this.btnChon = new System.Windows.Forms.Button();
            this.btnHuyBo = new System.Windows.Forms.Button();
            this.btnKetThuc = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblManAnh
            this.lblManAnh.BackColor = System.Drawing.Color.Gray;
            this.lblManAnh.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lblManAnh.ForeColor = System.Drawing.Color.Black;
            this.lblManAnh.Location = new System.Drawing.Point(20, 15);
            this.lblManAnh.Name = "lblManAnh";
            this.lblManAnh.Size = new System.Drawing.Size(340, 35);
            this.lblManAnh.Text = "MÀN ẢNH";
            this.lblManAnh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Tự động khởi tạo 15 nút ghế ngồi (3 hàng x 5 cột)
            for (int i = 0; i < 15; i++)
            {
                int row = i / 5;
                int col = i % 5;

                System.Windows.Forms.Button btnGhe = new System.Windows.Forms.Button();
                btnGhe.Name = "btnGhe" + (i + 1);
                btnGhe.Text = (i + 1).ToString();
                btnGhe.Size = new System.Drawing.Size(60, 45);
                btnGhe.Location = new System.Drawing.Point(20 + col * 68, 65 + row * 52);
                btnGhe.BackColor = System.Drawing.Color.White; // Mặc định màu Trắng (chưa bán)
                btnGhe.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
                btnGhe.Click += new System.EventHandler(this.Ghe_Click); // Gán chung sự kiện Click

                this.Controls.Add(btnGhe);
            }

            // lblThanhTien
            this.lblThanhTien.AutoSize = true;
            this.lblThanhTien.Location = new System.Drawing.Point(20, 235);
            this.lblThanhTien.Name = "lblThanhTien";
            this.lblThanhTien.Size = new System.Drawing.Size(85, 17);
            this.lblThanhTien.Text = "Thành Tiền:";

            // txtThanhTien
            this.txtThanhTien.Location = new System.Drawing.Point(115, 232);
            this.txtThanhTien.Name = "txtThanhTien";
            this.txtThanhTien.ReadOnly = true;
            this.txtThanhTien.Size = new System.Drawing.Size(245, 23);
            this.txtThanhTien.Text = "0";

            // btnChon
            this.btnChon.Location = new System.Drawing.Point(20, 270);
            this.btnChon.Name = "btnChon";
            this.btnChon.Size = new System.Drawing.Size(100, 32);
            this.btnChon.Text = "Chọn";
            this.btnChon.Click += new System.EventHandler(this.btnChon_Click);

            // btnHuyBo
            this.btnHuyBo.Location = new System.Drawing.Point(140, 270);
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.Size = new System.Drawing.Size(100, 32);
            this.btnHuyBo.Text = "Hủy bỏ";
            this.btnHuyBo.Click += new System.EventHandler(this.btnHuyBo_Click);

            // btnKetThuc
            this.btnKetThuc.Location = new System.Drawing.Point(260, 270);
            this.btnKetThuc.Name = "btnKetThuc";
            this.btnKetThuc.Size = new System.Drawing.Size(100, 32);
            this.btnKetThuc.Text = "Kết thúc";
            this.btnKetThuc.Click += new System.EventHandler(this.btnKetThuc_Click);

            // frmBai01NangCao
            this.ClientSize = new System.Drawing.Size(380, 320);
            this.Controls.Add(this.lblManAnh);
            this.Controls.Add(this.lblThanhTien);
            this.Controls.Add(this.txtThanhTien);
            this.Controls.Add(this.btnChon);
            this.Controls.Add(this.btnHuyBo);
            this.Controls.Add(this.btnKetThuc);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.Name = "frmBai01NangCao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BÁN VÉ TẠI RẠP CHIẾU PHIM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBai01NangCao_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
