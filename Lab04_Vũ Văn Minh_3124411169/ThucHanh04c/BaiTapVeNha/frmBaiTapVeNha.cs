using System;
using System.Windows.Forms;
namespace WinFormsApp
{
    public partial class frmBai01VeNha : Form
    {
        private double soThuNhat = 0;
        private string phepTinh = "";
        private bool isPhepTinhClicked = false;
        public frmBai01VeNha()
        {
            InitializeComponent();
        }
        // --- BẮT SỰ KIỆN KHI NHẤN PHÍM SỐ (0-9) ---
        private void BtnSo_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            // Nếu vừa bấm phím phép tính hoặc màn hình đang là '0' thì xóa để nhập số mới
            if (txtHienThi.Text == "0" || isPhepTinhClicked)
            {
                txtHienThi.Text = btn.Text;
                isPhepTinhClicked = false;
            }
            else
            {
                txtHienThi.Text += btn.Text;
            }
        }
        // --- BẮT SỰ KIỆN KHI NHẤN CÁC NÚT PHÉP TÍNH (+, -, *, /) ---
        private void BtnPhepTinh_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (!double.TryParse(txtHienThi.Text, out soThuNhat))
            {
                soThuNhat = 0;
            }
            phepTinh = btn.Text;
            isPhepTinhClicked = true;
        }
        // --- BẮT SỰ KIỆN KHI NHẤN NÚT BẰNG (=) ---
        private void BtnBang_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(phepTinh)) return;
            if (double.TryParse(txtHienThi.Text, out double soThuHai))
            {
                double ketQua = 0;
                switch (phepTinh)
                {
                    case "+":
                        ketQua = soThuNhat + soThuHai;
                        break;
                    case "-":
                        ketQua = soThuNhat - soThuHai;
                        break;
                    case "*":
                        ketQua = soThuNhat * soThuHai;
                        break;
                    case "/":
                        if (soThuHai == 0)
                        {
                            MessageBox.Show("Không thể chia cho 0!", "Lỗi tính toán", 
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        ketQua = soThuNhat / soThuHai;
                        break;
                }
                txtHienThi.Text = ketQua.ToString();
                phepTinh = ""; // Reset phép tính sau khi tính xong
                isPhepTinhClicked = true;
            }
        }
        // --- BẮT SỰ KIỆN KHI NHẤN NÚT XÓA (C) ---
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            txtHienThi.Text = "0";
            soThuNhat = 0;
            phepTinh = "";
            isPhepTinhClicked = false;
        }
        // --- HỎI XÁC NHẬN TRƯỚC KHI ĐÓNG FORM ---
        private void frmBai01VeNha_FormClosing(object sender, FormClosingEventArgs e)
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
