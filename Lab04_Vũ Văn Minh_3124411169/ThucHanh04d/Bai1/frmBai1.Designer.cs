namespace WinFormsApp
{
    partial class frmBai01TL
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpChon;
        private System.Windows.Forms.RadioButton rdoBacNhat;
        private System.Windows.Forms.RadioButton rdoBacHai;
        private System.Windows.Forms.Label lblA;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.Label lblC;
        private System.Windows.Forms.Label lblKetQua;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.TextBox txtC;
        private System.Windows.Forms.TextBox txtKetQua;
        private System.Windows.Forms.Button btnGiai;
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
            this.grpChon = new System.Windows.Forms.GroupBox();
            this.rdoBacNhat = new System.Windows.Forms.RadioButton();
            this.rdoBacHai = new System.Windows.Forms.RadioButton();
            this.lblA = new System.Windows.Forms.Label();
            this.lblB = new System.Windows.Forms.Label();
            this.lblC = new System.Windows.Forms.Label();
            this.lblKetQua = new System.Windows.Forms.Label();
            this.txtA = new System.Windows.Forms.TextBox();
            this.txtB = new System.Windows.Forms.TextBox();
            this.txtC = new System.Windows.Forms.TextBox();
            this.txtKetQua = new System.Windows.Forms.TextBox();
            this.btnGiai = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);

            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(60, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(236, 27);
            this.lblTitle.Text = "GIẢI PHƯƠNG TRÌNH";

            // grpChon
            this.grpChon.Controls.Add(this.rdoBacNhat);
            this.grpChon.Controls.Add(this.rdoBacHai);
            this.grpChon.Location = new System.Drawing.Point(30, 50);
            this.grpChon.Name = "grpChon";
            this.grpChon.Size = new System.Drawing.Size(290, 80);
            this.grpChon.Text = "Bạn vui lòng chọn";

            // rdoBacNhat
            this.rdoBacNhat.AutoSize = true;
            this.rdoBacNhat.Checked = true;
            this.rdoBacNhat.Location = new System.Drawing.Point(30, 22);
            this.rdoBacNhat.Name = "rdoBacNhat";
            this.rdoBacNhat.Size = new System.Drawing.Size(155, 21);
            this.rdoBacNhat.Text = "Phương trình bậc nhất";
            this.rdoBacNhat.CheckedChanged += new System.EventHandler(this.rdoLoaiPT_CheckedChanged);

            // rdoBacHai
            this.rdoBacHai.AutoSize = true;
            this.rdoBacHai.Location = new System.Drawing.Point(30, 48);
            this.rdoBacHai.Name = "rdoBacHai";
            this.rdoBacHai.Size = new System.Drawing.Size(148, 21);
            this.rdoBacHai.Text = "Phương trình bậc hai";
            this.rdoBacHai.CheckedChanged += new System.EventHandler(this.rdoLoaiPT_CheckedChanged);

            // lblA
            this.lblA.AutoSize = true;
            this.lblA.Location = new System.Drawing.Point(30, 150);
            this.lblA.Text = "Nhập a";

            // txtA
            this.txtA.Location = new System.Drawing.Point(100, 147);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(110, 24);
            this.txtA.TextChanged += new System.EventHandler(this.txtInput_TextChanged);

            // lblB
            this.lblB.AutoSize = true;
            this.lblB.Location = new System.Drawing.Point(30, 185);
            this.lblB.Text = "Nhập b";

            // txtB
            this.txtB.Location = new System.Drawing.Point(100, 182);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(110, 24);
            this.txtB.TextChanged += new System.EventHandler(this.txtInput_TextChanged);

            // lblC
            this.lblC.AutoSize = true;
            this.lblC.Location = new System.Drawing.Point(30, 220);
            this.lblC.Text = "Nhập c";

            // txtC
            this.txtC.Location = new System.Drawing.Point(100, 217);
            this.txtC.Name = "txtC";
            this.txtC.Size = new System.Drawing.Size(110, 24);
            this.txtC.TextChanged += new System.EventHandler(this.txtInput_TextChanged);

            // btnGiai
            this.btnGiai.Enabled = false;
            this.btnGiai.Location = new System.Drawing.Point(230, 147);
            this.btnGiai.Name = "btnGiai";
            this.btnGiai.Size = new System.Drawing.Size(90, 40);
            this.btnGiai.Text = "Giải";
            this.btnGiai.Click += new System.EventHandler(this.btnGiai_Click);

            // btnThoat
            this.btnThoat.Location = new System.Drawing.Point(230, 197);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(90, 40);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            // lblKetQua
            this.lblKetQua.AutoSize = true;
            this.lblKetQua.Location = new System.Drawing.Point(30, 260);
            this.lblKetQua.Text = "Kết quả";

            // txtKetQua
            this.txtKetQua.Location = new System.Drawing.Point(100, 257);
            this.txtKetQua.Multiline = true;
            this.txtKetQua.Name = "txtKetQua";
            this.txtKetQua.ReadOnly = true;
            this.txtKetQua.Size = new System.Drawing.Size(220, 50);

            // errorProvider1
            this.errorProvider1.ContainerControl = this;

            // frmBai01TL
            this.ClientSize = new System.Drawing.Size(350, 330);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.grpChon);
            this.Controls.Add(this.lblA);
            this.Controls.Add(this.txtA);
            this.Controls.Add(this.lblB);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.lblC);
            this.Controls.Add(this.txtC);
            this.Controls.Add(this.btnGiai);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.lblKetQua);
            this.Controls.Add(this.txtKetQua);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmBai01TL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giải phương trình bậc 1-2";
            this.Load += new System.EventHandler(this.frmBai01TL_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBai01TL_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
