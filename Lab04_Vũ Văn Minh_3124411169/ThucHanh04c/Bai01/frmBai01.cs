using System;
using System.Windows.Forms;
namespace WinFormsApp
{
    public partial class frmBaiTap1 : Form
    {
        public frmBaiTap1()
        {
            InitializeComponent();
        }
        // --- MỨC 2: CHẶN DỮ LIỆU KHÔNG PHẢI SỐ KHI ĐANG NHẬP 
        private void txtNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            // Cho phép phím Backspace, các chữ số, dấu '-' (số âm) và dấu '.' hoặc ',' (số thực)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && 
                (e.KeyChar != '-') && (e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true; // Chặn ký tự không hợp lệ
                MessageBox.Show("Vui lòng chỉ nhập giá trị số!", "Thông báo lỗi", 
                                MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                return;
            }
            // Chỉ cho phép nhập 1 dấu trừ ở đầu
            if (e.KeyChar == '-' && txt.Text.Length > 0)
            {
                e.Handled = true;
            }
            // Chỉ cho phép nhập 1 dấu thập phân
            if ((e.KeyChar == '.' || e.KeyChar == ',') && (txt.Text.Contains(".") || txt.Text.Contains(",")))
            {
                e.Handled = true;
            }
        }
        // --- MỨC 1: HIỂN THỊ LỖI BẰNG ERRORPROVIDER NẾU BỎ TRỐNG HOẶC SAI ĐỊNH DẠNG 
        private void txtNum_TextChanged(object sender, EventArgs e)
        {
            Control ctr = (Control)sender; 
            if (string.IsNullOrWhiteSpace(ctr.Text))
            {
                this.errorProvider1.SetError(ctr, "Không được để trống!"); 
            }
            else if (!double.TryParse(ctr.Text, out _))
            {
                this.errorProvider1.SetError(ctr, "Dữ liệu nhập vào không hợp lệ!"); 
            }
            else
            {
                this.errorProvider1.Clear(); 
            }
        }
        // --- THỰC HIỆN CÁC PHÉP TÁN (+, -, x, /) 
        private void btnPhepTinh_Click(object sender, EventArgs e)
        {
            // Kiểm tra hợp lệ dữ liệu trước khi tính toán
            if (!double.TryParse(txtA.Text, out double a))
            {
                MessageBox.Show("Số a không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtA.Focus();
                return;
            }
            if (!double.TryParse(txtB.Text, out double b))
            {
                MessageBox.Show("Số b không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtB.Focus();
                return;
            }
            Button btn = (Button)sender;
            double ketQua = 0;
            switch (btn.Text)
            {
                case "+":
                    ketQua = a + b;
                    break;
                case "-":
                    ketQua = a - b;
                    break;
                case "x":
                    ketQua = a * b;
                    break;
                case "/":
                    if (b == 0)
                    {
                        MessageBox.Show("Không thể chia cho 0!", "Lỗi phép tính", 
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtKQ.Text = "";
                        return;
                    }
                    ketQua = a / b;
                    break;
            }
            txtKQ.Text = ketQua.ToString(); // Hiển thị kết quả
        }
        // --- HỎI XÁC NHẬN TRƯỚC KHI ĐÓNG FORM
        private void frmBaiTap1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát?", "Thoát", 
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
