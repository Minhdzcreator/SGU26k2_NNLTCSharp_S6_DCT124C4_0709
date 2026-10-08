using System;
using System.Windows.Forms;
namespace WinFormsApp
{
    public partial class frmBai05 : Form
    {
        public frmBai05()
        {
            InitializeComponent();
        }
        // --- CHẶN KÝ TỰ KHÔNG PHẢI SỐ KHI NHẬP ---
        private void txtNhapSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Vui lòng chỉ nhập số!", "Thông báo", 
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        // --- SỰ KIỆN NÚT THỰC HIỆN ---
        private void btnThucHien_Click(object sender, EventArgs e)
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
                if (number < 1 || number > 999)
                {
                    errorProvider1.SetError(txtNhapSo, "Vui lòng nhập số trong khoảng từ 1 đến 999!");
                    MessageBox.Show("Chỉ chấp nhận số nguyên từ 1 đến 999!", "Lỗi nhập liệu", 
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNhapSo.SelectAll();
                    txtNhapSo.Focus();
                    return;
                }
                // Chuyển đổi số thành chữ
                txtKetQua.Text = DocSoThanhChu(number);
            }
            else
            {
                errorProvider1.SetError(txtNhapSo, "Dữ liệu nhập không đúng định dạng!");
            }
        }
        // --- THUẬT TOÁN ĐỌC SỐ NGUYÊN TỪ 1 ĐẾN 999 ---
        private string DocSoThanhChu(int number)
        {
            string[] arrayDonVi = { "", "Một", "Hai", "Ba", "Bốn", "Năm", "Sáu", "Bảy", "Tám", "Chín" };
            int tramtram = number / 100;
            int chuc = (number % 100) / 10;
            int donvi = number % 10;
            string res = "";
            // 1. Xử lý hàng trăm
            if (tramtram > 0)
            {
                res += arrayDonVi[tramtram] + " Trăm ";
            }
            // 2. Xử lý hàng chục
            if (chuc > 1)
            {
                res += arrayDonVi[chuc] + " Mươi ";
            }
            else if (chuc == 1)
            {
                res += "Mười ";
            }
            else if (tramtram > 0 && donvi > 0) // Trường hợp số có chữ số 0 ở giữa (vd: 105 -> Một Trăm Lẻ Năm)
            {
                res += "Lẻ ";
            }
            // 3. Xử lý hàng đơn vị
            if (donvi > 0)
            {
                if (donvi == 1 && chuc > 1)
                {
                    res += "Mốt";
                }
                else if (donvi == 5 && chuc > 0)
                {
                    res += "Lăm";
                }
                else
                {
                    res += arrayDonVi[donvi];
                }
            }
            return res.Trim();
        }
        // --- SỰ KIỆN NÚT XÓA (TRẢ VỀ TRẠNG THÁI BAN ĐẦU) ---
        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtNhapSo.Clear();
            txtKetQua.Clear();
            errorProvider1.Clear();
            txtNhapSo.Focus(); // Trả con trỏ nhập liệu về txtNhapSo
        }
        // --- SỰ KIỆN NÚT THOÁT ---
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // --- HỎI XÁC NHẬN TRƯỚC KHI ĐÓNG FORM ---
        private void frmBai05_FormClosing(object sender, FormClosingEventArgs e)
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
