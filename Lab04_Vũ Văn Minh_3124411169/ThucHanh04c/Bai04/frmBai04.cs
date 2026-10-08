using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
namespace WinFormsApp
{
    public partial class frmBai04 : Form
    {
        // Danh sách lưu trữ dãy số nhập vào
        private List<int> listNumbers = new List<int>();
        public frmBai04()
        {
            InitializeComponent();
        }
        // --- CHẶN KÝ TỰ KHÔNG PHẢI SỐ (CHO PHÉP DẤU ÂM NẾU CÓ) ---
        private void txtNhapSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cho phép nhập số, phím xóa (Backspace) và dấu trừ '-' ở đầu
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
                MessageBox.Show("Vui lòng chỉ nhập số nguyên!", "Thông báo", 
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            // Dấu trừ chỉ được đứng ở vị trí đầu tiên
            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1 || (sender as TextBox).SelectionStart != 0))
            {
                e.Handled = true;
            }
        }
        // --- SỰ KIỆN NÚT NHẬP ---
        private void btnNhap_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (string.IsNullOrWhiteSpace(txtNhapSo.Text))
            {
                errorProvider1.SetError(txtNhapSo, "Vui lòng nhập số!");
                txtNhapSo.Focus();
                return;
            }
            if (int.TryParse(txtNhapSo.Text, out int number))
            {
                // 1. Thêm số vào danh sách
                listNumbers.Add(number);
                // 2. Cập nhật chuỗi Dãy vừa nhập
                txtDaySo.Text = string.Join(" ", listNumbers);
                // 3. Tính toán Tổng các phần tử, Tổng Chẵn và Tổng Lẻ
                int tongDay = listNumbers.Sum();
                int tongChan = listNumbers.Where(n => n % 2 == 0).Sum();
                int tongLe = listNumbers.Where(n => n % 2 != 0).Sum();
                // 4. Xuất kết quả ra các Textbox tương ứng
                txtTongDay.Text = tongDay.ToString();
                txtTongChan.Text = tongChan.ToString();
                txtTongLe.Text = tongLe.ToString();
                // 5. Reset ô nhập số để tiếp tục nhập số tiếp theo
                txtNhapSo.Clear();
                txtNhapSo.Focus();
            }
            else
            {
                errorProvider1.SetError(txtNhapSo, "Số vừa nhập không hợp lệ!");
                txtNhapSo.SelectAll();
                txtNhapSo.Focus();
            }
        }
        // --- SỰ KIỆN NÚT TIẾP TỤC (TRẢ LẠI TRẠNG THÁI BAN ĐẦU) ---
        private void btnTiepTuc_Click(object sender, EventArgs e)
        {
            listNumbers.Clear(); // Xóa dữ liệu trong list
            txtNhapSo.Clear();
            txtDaySo.Clear();
            txtTongDay.Clear();
            txtTongChan.Clear();
            txtTongLe.Clear();
            errorProvider1.Clear();
            txtNhapSo.Focus(); // Trả con trỏ về ô nhập số
        }
        // --- SỰ KIỆN NÚT THOÁT ---
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // --- HỎI XÁC NHẬN TRƯỚC KHI ĐÓNG FORM ---
        private void frmBai04_FormClosing(object sender, FormClosingEventArgs e)
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
