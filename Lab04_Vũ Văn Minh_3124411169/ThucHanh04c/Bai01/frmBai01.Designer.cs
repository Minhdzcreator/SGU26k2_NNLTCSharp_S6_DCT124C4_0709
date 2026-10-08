namespace WinFormsApp
{
    partial class frmBaiTap1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblA;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.Label lblKQ;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.TextBox txtKQ;
        private System.Windows.Forms.Button btnCong;
        private System.Windows.Forms.Button btnTru;
        private System.Windows.Forms.Button btnNhan;
        private System.Windows.Forms.Button btnChia;
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
            this.lblA = new System.Windows.Forms.Label();
            this.lblB = new System.Windows.Forms.Label();
            this.lblKQ = new System.Windows.Forms.Label();
            this.txtA = new System.Windows.Forms.TextBox();
            this.txtB = new System.Windows.Forms.TextBox();
            this.txtKQ = new System.Windows.Forms.TextBox();
            this.btnCong = new System.Windows.Forms.Button();
            this.btnTru = new System.Windows.Forms.Button();
            this.btnNhan = new System.Windows.Forms.Button();
            this.btnChia = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();

            // lblA
            this.lblA.AutoSize = true;
            this.lblA.Location = new System.Drawing.Point(30, 25);
            this.lblA.Name = "lblA";
            this.lblA.Size = new System.Drawing.Size(30, 17);
            this.lblA.Text = "a =";

            // txtA
            this.txtA.Location = new System.Drawing.Point(70, 22);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(100, 23);
            this.txtA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNum_KeyPress);
            this.txtA.TextChanged += new System.EventHandler(this.txtNum_TextChanged);

            // lblB
            this.lblB.AutoSize = true;
            this.lblB.Location = new System.Drawing.Point(190, 25);
            this.lblB.Name = "lblB";
            this.lblB.Size = new System.Drawing.Size(30, 17);
            this.lblB.Text = "b=";

            // txtB
            this.txtB.Location = new System.Drawing.Point(225, 22);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(100, 23);
            this.txtB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNum_KeyPress);
            this.txtB.TextChanged += new System.EventHandler(this.txtNum_TextChanged);

            // lblKQ
            this.lblKQ.AutoSize = true;
            this.lblKQ.Location = new System.Drawing.Point(30, 65);
            this.lblKQ.Name = "lblKQ";
            this.lblKQ.Size = new System.Drawing.Size(57, 17);
            this.lblKQ.Text = "Kết quả";

            // txtKQ
            this.txtKQ.Location = new System.Drawing.Point(95, 62);
            this.txtKQ.Name = "txtKQ";
            this.txtKQ.ReadOnly = true;
            this.txtKQ.Size = new System.Drawing.Size(230, 23);

            // btnCong
            this.btnCong.Location = new System.Drawing.Point(40, 105);
            this.btnCong.Name = "btnCong";
            this.btnCong.Size = new System.Drawing.Size(60, 30);
            this.btnCong.Text = "+";
            this.btnCong.Click += new System.EventHandler(this.btnPhepTinh_Click);

            // btnTru
            this.btnTru.Location = new System.Drawing.Point(110, 105);
            this.btnTru.Name = "btnTru";
            this.btnTru.Size = new System.Drawing.Size(60, 30);
            this.btnTru.Text = "-";
            this.btnTru.Click += new System.EventHandler(this.btnPhepTinh_Click);

            // btnNhan
            this.btnNhan.Location = new System.Drawing.Point(180, 105);
            this.btnNhan.Name = "btnNhan";
            this.btnNhan.Size = new System.Drawing.Size(60, 30);
            this.btnNhan.Text = "x";
            this.btnNhan.Click += new System.EventHandler(this.btnPhepTinh_Click);

            // btnChia
            this.btnChia.Location = new System.Drawing.Point(250, 105);
            this.btnChia.Name = "btnChia";
            this.btnChia.Size = new System.Drawing.Size(60, 30);
            this.btnChia.Text = "/";
            this.btnChia.Click += new System.EventHandler(this.btnPhepTinh_Click);

            // errorProvider1
            this.errorProvider1.ContainerControl = this;

            // frmBaiTap1
            this.ClientSize = new System.Drawing.Size(360, 160);
            this.Controls.Add(this.lblA);
            this.Controls.Add(this.txtA);
            this.Controls.Add(this.lblB);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.lblKQ);
            this.Controls.Add(this.txtKQ);
            this.Controls.Add(this.btnCong);
            this.Controls.Add(this.btnTru);
            this.Controls.Add(this.btnNhan);
            this.Controls.Add(this.btnChia);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.Name = "frmBaiTap1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cộng trừ nhân chia";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBaiTap1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
