namespace WinFormsApp
{
    partial class frmBai04
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblNhapSo;
        private System.Windows.Forms.Label lblDaySo;
        private System.Windows.Forms.Label lblTongDay;
        private System.Windows.Forms.Label lblTongChan;
        private System.Windows.Forms.Label lblTongLe;
        private System.Windows.Forms.TextBox txtNhapSo;
        private System.Windows.Forms.TextBox txtDaySo;
        private System.Windows.Forms.TextBox txtTongDay;
        private System.Windows.Forms.TextBox txtTongChan;
        private System.Windows.Forms.TextBox txtTongLe;
        private System.Windows.Forms.Button btnNhap;
        private System.Windows.Forms.Button btnTiepTuc;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.ErrorProvider errorProvider1;

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
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblNhapSo = new System.Windows.Forms.Label();
            this.lblDaySo = new System.Windows.Forms.Label();
            this.lblTongDay = new System.Windows.Forms.Label();
            this.lblTongChan = new System.Windows.Forms.Label();
            this.lblTongLe = new System.Windows.Forms.Label();
            this.txtNhapSo = new System.Windows.Forms.TextBox();
            this.txtDaySo = new System.Windows.Forms.TextBox();
            this.txtTongDay = new System.Windows.Forms.TextBox();
            this.txtTongChan = new System.Windows.Forms.TextBox();
            this.txtTongLe = new System.Windows.Forms.TextBox();
            this.btnNhap = new System.Windows.Forms.Button();
            this.btnTiepTuc = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(50, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(271, 23);
            this.lblTitle.Text = "Nhập Dãy Số và Tính Tổng";

            // lblNhapSo
            this.lblNhapSo.AutoSize = true;
            this.lblNhapSo.Location = new System.Drawing.Point(35, 60);
            this.lblNhapSo.Name = "lblNhapSo";
            this.lblNhapSo.Size = new System.Drawing.Size(70, 17);
            this.lblNhapSo.Text = "Nhập số :";

            // txtNhapSo
            this.txtNhapSo.Location = new System.Drawing.Point(120, 57);
            this.txtNhapSo.Name = "txtNhapSo";
            this.txtNhapSo.Size = new System.Drawing.Size(100, 23);
            this.txtNhapSo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNhapSo_KeyPress);

            // btnNhap
            this.btnNhap.Location = new System.Drawing.Point(235, 55);
            this.btnNhap.Name = "btnNhap";
            this.btnNhap.Size = new System.Drawing.Size(80, 27);
            this.btnNhap.Text = "Nhập";
            this.btnNhap.Click += new System.EventHandler(this.btnNhap_Click);

            // lblDaySo
            this.lblDaySo.AutoSize = true;
            this.lblDaySo.Location = new System.Drawing.Point(35, 95);
            this.lblDaySo.Name = "lblDaySo";
            this.lblDaySo.Size = new System.Drawing.Size(98, 17);
            this.lblDaySo.Text = "Dãy vừa nhập :";

            // txtDaySo
            this.txtDaySo.Location = new System.Drawing.Point(135, 92);
            this.txtDaySo.Name = "txtDaySo";
            this.txtDaySo.ReadOnly = true;
            this.txtDaySo.Size = new System.Drawing.Size(180, 23);

            // lblTongDay
            this.lblTongDay.AutoSize = true;
            this.lblTongDay.Location = new System.Drawing.Point(35, 130);
            this.lblTongDay.Name = "lblTongDay";
            this.lblTongDay.Size = new System.Drawing.Size(180, 17);
            this.lblTongDay.Text = "Tổng các phần tử trong dãy :";

            // txtTongDay
            this.txtTongDay.Location = new System.Drawing.Point(220, 127);
            this.txtTongDay.Name = "txtTongDay";
            this.txtTongDay.ReadOnly = true;
            this.txtTongDay.Size = new System.Drawing.Size(95, 23);

            // lblTongChan
            this.lblTongChan.AutoSize = true;
            this.lblTongChan.Location = new System.Drawing.Point(35, 165);
            this.lblTongChan.Name = "lblTongChan";
            this.lblTongChan.Size = new System.Drawing.Size(83, 17);
            this.lblTongChan.Text = "Tổng Chẵn :";

            // txtTongChan
            this.txtTongChan.Location = new System.Drawing.Point(120, 162);
            this.txtTongChan.Name = "txtTongChan";
            this.txtTongChan.ReadOnly = true;
            this.txtTongChan.Size = new System.Drawing.Size(55, 23);

            // lblTongLe
            this.lblTongLe.AutoSize = true;
            this.lblTongLe.Location = new System.Drawing.Point(190, 165);
            this.lblTongLe.Name = "lblTongLe";
            this.lblTongLe.Size = new System.Drawing.Size(68, 17);
            this.lblTongLe.Text = "Tổng Lẻ :";

            // txtTongLe
            this.txtTongLe.Location = new System.Drawing.Point(260, 162);
            this.txtTongLe.Name = "txtTongLe";
            this.txtTongLe.ReadOnly = true;
            this.txtTongLe.Size = new System.Drawing.Size(55, 23);

            // btnTiepTuc
            this.btnTiepTuc.Location = new System.Drawing.Point(70, 205);
            this.btnTiepTuc.Name = "btnTiepTuc";
            this.btnTiepTuc.Size = new System.Drawing.Size(100, 32);
            this.btnTiepTuc.Text = "Tiếp Tục";
            this.btnTiepTuc.Click += new System.EventHandler(this.btnTiepTuc_Click);

            // btnThoat
            this.btnThoat.Location = new System.Drawing.Point(190, 205);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(100, 32);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            // errorProvider1
            this.errorProvider1.ContainerControl = this;

            // frmBai04
            this.AcceptButton = this.btnNhap;
            this.ClientSize = new System.Drawing.Size(360, 255);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblNhapSo);
            this.Controls.Add(this.txtNhapSo);
            this.Controls.Add(this.btnNhap);
            this.Controls.Add(this.lblDaySo);
            this.Controls.Add(this.txtDaySo);
            this.Controls.Add(this.lblTongDay);
            this.Controls.Add(this.txtTongDay);
            this.Controls.Add(this.lblTongChan);
            this.Controls.Add(this.txtTongChan);
            this.Controls.Add(this.lblTongLe);
            this.Controls.Add(this.txtTongLe);
            this.Controls.Add(this.btnTiepTuc);
            this.Controls.Add(this.btnThoat);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.Name = "frmBai04";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dãy số và Tính Tổng";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBai04_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
