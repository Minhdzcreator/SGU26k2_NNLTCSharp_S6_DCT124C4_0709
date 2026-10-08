using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace WinFormsApp
{
    public partial class frmBai02 : Form
    {
        public frmBai02()
        {
            InitializeComponent();
        }
        // --- KIỂM TRA ĐỊNH DẠNG EMAIL KHI RỜI KHỎI TEXTBOX (SỰ KIỆN LEAVE) ---
        private void txtEmail_Leave(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            if (!string.IsNullOrEmpty(email) && !IsValidEmail(email))
            {
                errorProvider1.SetError(txtEmail, "Địa chỉ email không đúng định dạng!");
            }
            else
            {
                errorProvider1.SetError(txtEmail, "");
            }
        }
        // Hàm hỗ trợ kiểm tra định dạng email bằng Regex
        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }
        // --- XỬ LÝ SỰ KIỆN SỰ KIỆN NÚT ĐĂNG KÝ (HOẶC NHẤN ENTER TỪ TXTXACNHANMK) ---
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            bool hasError = false;
            errorProvider1.Clear();
            // 1. Kiểm tra các ô bắt buộc nhập (*)
            if (string.IsNullOrWhiteSpace(txtTenDN.Text))
            {
                errorProvider1.SetError(txtTenDN, "Vui lòng nhập Tên đăng nhập!");
                hasError = true;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "Vui lòng nhập Địa chỉ email!");
                hasError = true;
            }
            else if (!IsValidEmail(txtEmail.Text.Trim()))
            {
                errorProvider1.SetError(txtEmail, "Địa chỉ email không đúng định dạng!");
                hasError = true;
            }
            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                errorProvider1.SetError(txtMatKhau, "Vui lòng nhập Mật khẩu!");
                hasError = true;
            }
            // 2. Kiểm tra khớp mật khẩu xác nhận
            if (txtMatKhau.Text != txtXacNhanMK.Text)
            {
                errorProvider1.SetError(txtXacNhanMK, "Mật khẩu xác nhận không trùng khớp!");
                hasError = true;
            }
            if (hasError)
            {
                MessageBox.Show("Vui lòng điền đầy đủ và chính xác các thông tin bắt buộc!", 
                                "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // 3. Hiển thị thông tin lên MessageBox khi đăng ký thành công
            string info = $"ĐĂNG KÝ TÀI KHOẢN THÀNH CÔNG!\n\n" +
                          $"• Tên đăng nhập: {txtTenDN.Text.Trim()}\n" +
                          $"• Địa chỉ Email: {txtEmail.Text.Trim()}\n" +
                          $"• Mật khẩu: {txtMatKhau.Text}";
            MessageBox.Show(info, "Thông tin đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        // --- HỎI XÁC NHẬN TRƯỚC KHI ĐÓNG FORM ---
        private void frmBai02_FormClosing(object sender, FormClosingEventArgs e)
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
