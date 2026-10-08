namespace WinFormsApp
{
    partial class frmBai03
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblA;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.Label lblUCLN;
        private System.Windows.Forms.Label lblBCNN;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.TextBox txtUCLN;
        private System.Windows.Forms.TextBox txtBCNN;
        private System.Windows.Forms.Button btnThucHien;
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
            this.lblA = new System.Windows.Forms.Label();
            this.lblB = new System.Windows.Forms.Label();
            this.lblUCLN = new System.Windows.Forms.Label();
            this.lblBCNN = new System.Windows.Forms.Label();
            this.txtA = new System.Windows.Forms.TextBox();
            this.txtB = new System.Windows.Forms.TextBox();
            this.txtUCLN = new System.Windows.Forms.TextBox();
            this.txtBCNN = new System.Windows.Forms.TextBox();
            this.btnThucHien = new System.Windows.Forms.Button();
            this.btnTiepTuc = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(55, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(305, 23);
            this.lblTitle.Text = "Ước Số Chung - Bội Số Chung";

            // lblA
            this.lblA.AutoSize = true;
            this.lblA.Location = new System.Drawing.Point(50, 65);
            this.lblA.Name = "lblA";
            this.lblA.Size = new System.Drawing.Size(78, 17);
            this.lblA.Text = "Nhập số a :";

            // txtA
            this.txtA.Location = new System.Drawing.Point(215, 62);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(120, 23);
            this.txtA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNum_KeyPress);
            this.txtA.TextChanged += new System.EventHandler(this.txtNum_TextChanged);

            // lblB
            this.lblB.AutoSize = true;
            this.lblB.Location = new System.Drawing.Point(50, 100);
            this.lblB.Name = "lblB";
            this.lblB.Size = new System.Drawing.Size(78, 17);
            this.lblB.Text = "Nhập số b :";

            // txtB
            this.txtB.Location = new System.Drawing.Point(215, 97);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(120, 23);
            this.txtB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNum_KeyPress);
            this.txtB.TextChanged += new System.EventHandler(this.txtNum_TextChanged);

            // lblUCLN
            this.lblUCLN.AutoSize = true;
            this.lblUCLN.Location = new System.Drawing.Point(50, 135);
            this.lblUCLN.Name = "lblUCLN";
            this.lblUCLN.Size = new System.Drawing.Size(147, 17);
            this.lblUCLN.Text = "Ước số chung lớn nhất :";

            // txtUCLN
            this.txtUCLN.Location = new System.Drawing.Point(215, 132);
            this.txtUCLN.Name = "txtUCLN";
            this.txtUCLN.ReadOnly = true;
            this.txtUCLN.Size = new System.Drawing.Size(60, 23);

            // lblBCNN
            this.lblBCNN.AutoSize = true;
            this.lblBCNN.Location = new System.Drawing.Point(50, 170);
            this.lblBCNN.Name = "lblBCNN";
            this.lblBCNN.Size = new System.Drawing.Size(145, 17);
            this.lblBCNN.Text = "Bội số chung nhỏ nhất :";

            // txtBCNN
            this.txtBCNN.Location = new System.Drawing.Point(215, 167);
            this.txtBCNN.Name = "txtBCNN";
            this.txtBCNN.ReadOnly = true;
            this.txtBCNN.Size = new System.Drawing.Size(60, 23);

            // btnThucHien
            this.btnThucHien.Location = new System.Drawing.Point(50, 210);
            this.btnThucHien.Name = "btnThucHien";
            this.btnThucHien.Size = new System.Drawing.Size(100, 32);
            this.btnThucHien.Text = "Thực Hiện";
            this.btnThucHien.Click += new System.EventHandler(this.btnThucHien_Click);

            // btnTiepTuc
            this.btnTiepTuc.Location = new System.Drawing.Point(160, 210);
            this.btnTiepTuc.Name = "btnTiepTuc";
            this.btnTiepTuc.Size = new System.Drawing.Size(100, 32);
            this.btnTiepTuc.Text = "Tiếp Tục";
            this.btnTiepTuc.Click += new System.EventHandler(this.btnTiepTuc_Click);

            // btnThoat
            this.btnThoat.Location = new System.Drawing.Point(270, 210);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(100, 32);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            // errorProvider1
            this.errorProvider1.ContainerControl = this;

            // frmBai03
            this.ClientSize = new System.Drawing.Size(420, 265);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblA);
            this.Controls.Add(this.txtA);
            this.Controls.Add(this.lblB);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.lblUCLN);
            this.Controls.Add(this.txtUCLN);
            this.Controls.Add(this.lblBCNN);
            this.Controls.Add(this.txtBCNN);
            this.Controls.Add(this.btnThucHien);
            this.Controls.Add(this.btnTiepTuc);
            this.Controls.Add(this.btnThoat);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.Name = "frmBai03";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ước Số - Bội Số";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBai03_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
