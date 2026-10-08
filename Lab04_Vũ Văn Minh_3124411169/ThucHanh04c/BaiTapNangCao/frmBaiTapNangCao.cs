using System;
using System.Drawing;
using System.Windows.Forms;
namespace WinFormsApp
{
    public partial class frmBai01NangCao : Form
    {
        public frmBai01NangCao()
        {
            InitializeComponent();
        }
        // --- SỰ KIỆN CLICK CHUỘT VÀO MỘT VỊ TRÍ GHẾ ---
        private void Ghe_Click(object sender, EventArgs e)
        {
            Button btnGhe = (Button)sender;
            // 1. Nếu vị trí đã bán (màu Vàng) -> Thông báo lỗi
            if (btnGhe.BackColor == Color.Yellow)
            {
                MessageBox.Show($"Vé số {btnGhe.Text} đã được bán!", "Thông báo", 
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            // 2. Nếu chưa bán (màu Trắng) -> Đổi sang đang chọn (màu Xanh)
            else if (btnGhe.BackColor == Color.White)
            {
                btnGhe.BackColor = Color.Blue;
                btnGhe.ForeColor = Color.White; // Đổi màu chữ cho dễ nhìn trên nền xanh
            }
            // 3. Nếu đang chọn (màu Xanh) -> Đổi trở lại chưa bán (màu Trắng)
            else if (btnGhe.BackColor == Color.Blue)
            {
                btnGhe.BackColor = Color.White;
                btnGhe.ForeColor = Color.Black;
            }
        }
        // --- SỰ KIỆN NÚT CHỌN (THANH TOÁN) ---
        private void btnChon_Click(object sender, EventArgs e)
        {
            long tongTien = 0;
            bool coGheDuocChon = false;
            // Duyệt qua tất cả các Controls để tìm các ghế đang chọn (màu Blue)
            foreach (Control ctr in this.Controls)
            {
                if (ctr is Button && ctr.Name.StartsWith("btnGhe"))
                {
                    Button btnGhe = (Button)ctr;
                    if (btnGhe.BackColor == Color.Blue)
                    {
                        coGheDuocChon = true;
                        int soGhe = int.Parse(btnGhe.Text);
                        // Tính giá tiền theo Lô A, B, C
                        if (soGhe >= 1 && soGhe <= 5)
                        {
                            tongTien += 1000; // Lô A: 1000/vé
                        }
                        else if (soGhe >= 6 && soGhe <= 10)
                        {
                            tongTien += 1500; // Lô B: 1500/vé
                        }
                        else if (soGhe >= 11 && soGhe <= 15)
                        {
                            tongTien += 2000; // Lô C: 2000/vé
                        }
                        // Đổi màu ghế sang màu Vàng (đã bán thành công)
                        btnGhe.BackColor = Color.Yellow;
                        btnGhe.ForeColor = Color.Black;
                    }
                }
            }
            if (coGheDuocChon)
            {
                // Xuất tổng tiền lên label/textbox Thành Tiền
                txtThanhTien.Text = tongTien.ToString("N0"); // Định dạng hiển thị phân cách hàng nghìn
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ít nhất một ghế trước khi bấm Chọn!", "Thông báo", 
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // --- SỰ KIỆN NÚT HỦY BỎ ---
        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            // Đổi các ghế đang chọn (màu Blue) trở lại màu Trắng
            foreach (Control ctr in this.Controls)
            {
                if (ctr is Button && ctr.Name.StartsWith("btnGhe"))
                {
                    Button btnGhe = (Button)ctr;
                    if (btnGhe.BackColor == Color.Blue)
                    {
                        btnGhe.BackColor = Color.White;
                        btnGhe.ForeColor = Color.Black;
                    }
                }
            }
            // Đưa giá trị Thành Tiền về 0
            txtThanhTien.Text = "0";
        }
        // --- SỰ KIỆN NÚT KẾT THÚC ---
        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // --- HỎI XÁC NHẬN TRƯỚC KHI ĐÓNG FORM ---
        private void frmBai01NangCao_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát chương trình?", "Thoát",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question,
                                             MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
