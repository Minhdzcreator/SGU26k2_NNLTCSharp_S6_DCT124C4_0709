using System;
using System.Windows.Forms;
namespace WinFormsApp
{
    public partial class frmBai03 : Form
    {
        public frmBai03()
        {
            InitializeComponent();
        }
        // --- MỨC 2: CHẶN KÝ TỰ KHÔNG PHẢI SỐ NGUYÊN DƯƠNG KHI NHẬP ---
        private void txtNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập phím Backspace và các chữ số 0-9
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Vui lòng chỉ nhập số nguyên dương!", "Thông báo lỗi", 
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        // --- MỨC 1: KIỂM TRA TÍNH HỢP LỆ VÀ BÁO LỖI BẰNG ERRORPROVIDER ---
        private void txtNum_TextChanged(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (string.IsNullOrWhiteSpace(ctr.Text))
            {
                errorProvider1.SetError(ctr, "Vui lòng nhập giá trị!");
            }
            else if (!long.TryParse(ctr.Text, out long val) || val <= 0)
            {
                errorProvider1.SetError(ctr, "Vui lòng nhập số nguyên dương lớn hơn 0!");
            }
            else
            {
                errorProvider1.SetError(ctr, "");
            }
        }
        // --- TÍNH UCLN (THUẬT TOÁN EUCLID) ---
        private long TinhUCLN(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        // --- TÍNH BCNN ---
        private long TinhBCNN(long a, long b, long ucln)
        {
            return (a * b) / ucln;
        }
        // --- SỰ KIỆN NÚT THỰC HIỆN ---
        private void btnThucHien_Click(object sender, EventArgs e)
        {
            if (!long.TryParse(txtA.Text, out long a) || a <= 0)
            {
                MessageBox.Show("Số a không hợp lệ! Vui lòng kiểm tra lại.", "Lỗi nhập liệu", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtA.Focus();
                return;
            }
            if (!long.TryParse(txtB.Text, out long b) || b <= 0)
            {
                MessageBox.Show("Số b không hợp lệ! Vui lòng kiểm tra lại.", "Lỗi nhập liệu", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtB.Focus();
                return;
            }
            // Tính toán và hiển thị
            long ucln = TinhUCLN(a, b);
            long bcnn = TinhBCNN(a, b, ucln);
            txtUCLN.Text = ucln.ToString();
            txtBCNN.Text = bcnn.ToString();
        }
        // --- SỰ KIỆN NÚT TIẾP TỤC (RESET FORM) ---
        private void btnTiepTuc_Click(object sender, EventArgs e)
        {
            txtA.Clear();
            txtB.Clear();
            txtUCLN.Clear();
            txtBCNN.Clear();
            errorProvider1.Clear();
            txtA.Focus(); // Reset tiêu điểm về ô nhập số a
        }
        // --- SỰ KIỆN NÚT THOÁT ---
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // --- HỎI XÁC NHẬN TRƯỚC KHI ĐÓNG FORM ---
        private void frmBai03_FormClosing(object sender, FormClosingEventArgs e)
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
