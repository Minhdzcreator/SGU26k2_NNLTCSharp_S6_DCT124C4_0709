#nullable disable
using System;
using System.Drawing;
using System.Windows.Forms;
namespace BTVN_Tuan6App
{
    public partial class frmBaiTapVeNha1 : Form
    {
        private Label lblTime;
        private Button btnStart;
        // Sử dụng System.Windows.Forms.Timer
        private System.Windows.Forms.Timer timerCountdown;
        private int totalSeconds = 30 * 60; // 30 phút = 1800 giây
        private bool isRunning = false;
        public frmBaiTapVeNha1()
        {
            InitializeCustomComponent();
        }
        private void InitializeCustomComponent()
        {
            // Cấu hình Form
            this.Text = "Đồng hồ đếm ngược";
            this.Size = new Size(260, 170);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            // Label hiển thị thời gian
            lblTime = new Label();
            lblTime.Text = "30:00";
            lblTime.Font = new Font("Consolas", 20, FontStyle.Bold);
            lblTime.TextAlign = ContentAlignment.MiddleCenter;
            lblTime.Size = new Size(200, 40);
            lblTime.Location = new Point((this.ClientSize.Width - lblTime.Width) / 2, 20);
            // Nút Bắt đầu
            btnStart = new Button();
            btnStart.Text = "Bắt đầu";
            btnStart.Font = new Font("Arial", 10, FontStyle.Regular);
            btnStart.Size = new Size(90, 35);
            btnStart.Location = new Point((this.ClientSize.Width - btnStart.Width) / 2, 70);
            btnStart.Click += BtnStart_Click;
            // Khởi tạo Timer của Windows Forms
            timerCountdown = new System.Windows.Forms.Timer();
            timerCountdown.Interval = 1000; // 1 giây
            timerCountdown.Tick += TimerCountdown_Tick;
            this.Controls.Add(lblTime);
            this.Controls.Add(btnStart);
        }
        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                if (totalSeconds <= 0)
                {
                    totalSeconds = 30 * 60;
                    UpdateTimeDisplay();
                }
                timerCountdown.Start();
                isRunning = true;
                btnStart.Text = "Tạm dừng";
            }
            else
            {
                timerCountdown.Stop();
                isRunning = false;
                btnStart.Text = "Bắt đầu";
            }
        }
        private void TimerCountdown_Tick(object sender, EventArgs e)
        {
            if (totalSeconds > 0)
            {
                totalSeconds--;
                UpdateTimeDisplay();
            }
            else
            {
                timerCountdown.Stop();
                isRunning = false;
                btnStart.Text = "Bắt đầu";
                MessageBox.Show("Hết giờ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void UpdateTimeDisplay()
        {
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;
            lblTime.Text = $"{minutes:D2}:{seconds:D2}";
        }
    }
}
