namespace WinFormsApp
{
    partial class frmBai01VeNha
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtHienThi;

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
            this.txtHienThi = new System.Windows.Forms.TextBox();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(40, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(201, 27);
            this.lblTitle.Text = "Máy Tính Bỏ Túi";

            // txtHienThi
            this.txtHienThi.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.txtHienThi.ForeColor = System.Drawing.Color.Blue;
            this.txtHienThi.Location = new System.Drawing.Point(20, 55);
            this.txtHienThi.Name = "txtHienThi";
            this.txtHienThi.ReadOnly = true;
            this.txtHienThi.Size = new System.Drawing.Size(240, 30);
            this.txtHienThi.Text = "0";
            this.txtHienThi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // Tạo danh sách các phím máy tính (4x4)
            string[,] buttons = new string[4, 4] {
                { "1", "2", "3", "4" },
                { "5", "6", "7", "8" },
                { "9", "0", "=", "C" },
                { "+", "-", "*", "/" }
            };

            for (int r = 0; r < 4; r++)
            {
                for (int c = 0; c < 4; c++)
                {
                    System.Windows.Forms.Button btn = new System.Windows.Forms.Button();
                    btn.Text = buttons[r, c];
                    btn.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
                    btn.Size = new System.Drawing.Size(52, 40);
                    btn.Location = new System.Drawing.Point(20 + c * 60, 98 + r * 48);

                    // Gán sự kiện tương ứng
                    if (char.IsDigit(buttons[r, c][0]))
                    {
                        btn.Click += new System.EventHandler(this.BtnSo_Click);
                    }
                    else if (buttons[r, c] == "C")
                    {
                        btn.Click += new System.EventHandler(this.BtnXoa_Click);
                    }
                    else if (buttons[r, c] == "=")
                    {
                        btn.Click += new System.EventHandler(this.BtnBang_Click);
                    }
                    else
                    {
                        btn.Click += new System.EventHandler(this.BtnPhepTinh_Click);
                    }

                    this.Controls.Add(btn);
                }
            }

            // frmBai01VeNha
            this.ClientSize = new System.Drawing.Size(280, 300);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtHienThi);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmBai01VeNha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Máy Tính Bỏ Túi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBai01VeNha_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
