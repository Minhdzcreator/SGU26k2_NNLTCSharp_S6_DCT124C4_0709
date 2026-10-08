using System;
using System.Windows.Forms;
namespace WinFormsApp
{
    public partial class frmCafeSinhVien : Form
    {
        // Khai báo biến lưu tổng cộng
        private int tongSoKhach = 0;
        private double tongTienThanhToan = 0;
        private double tienKhachHienTai = 0;
        public frmCafeSinhVien()
        {
            InitializeComponent();
        }
        // --- FORM LOAD ---
        private void frmCafeSinhVien_Load(object sender, EventArgs e)
        {
            ResetFormKhach();
            txtTenKhach.Focus(); // Con trỏ văn bản đặt vào ô tên khách hàng
        }
        // Đưa Form về trạng thái ban đầu để nhập khách hàng mới
        private void ResetFormKhach()
        {
            txtTenKhach.Clear();
            txtSoKhach.Clear();
            chkSinhVien.Checked = false;
            // Bỏ chọn tất cả radiobutton nước uống
            rdoCafeDen.Checked = false;
            rdoCafeDa.Checked = false;
            rdoCafeSua.Checked = false;
            rdoCafeSuaDa.Checked = false;
            rdoCafeKem.Checked = false;
            // Bỏ chọn tất cả checkbox thức ăn
            chkBanhMyTrung.Checked = false;
            chkBanhMyCa.Checked = false;
            chkMyTomTrung.Checked = false;
            chkMyXaoBo.Checked = false;
            chkMyCay.Checked = false;
            // Khóa/mở các nút bấm theo yêu cầu
            btnTinhTien.Enabled = false;
            btnNhapLai.Enabled = false;
            btnThanhToan.Enabled = false;
            txtTenKhach.Focus();
        }
        // --- KIỂM TRA ĐIỀU KIỆN KHI NHẬP THÔNG TIN ---
        private void KiemTraThongTinKhach()
        {
            bool coTen = !string.IsNullOrWhiteSpace(txtTenKhach.Text);
            bool coSoKhach = int.TryParse(txtSoKhach.Text, out int n) && n > 0;
            bool coNuocUong = rdoCafeDen.Checked || rdoCafeDa.Checked || rdoCafeSua.Checked || 
                             rdoCafeSuaDa.Checked || rdoCafeKem.Checked;
            bool coThucAn = chkBanhMyTrung.Checked || chkBanhMyCa.Checked || 
                            chkMyTomTrung.Checked || chkMyXaoBo.Checked || chkMyCay.Checked;
            // Khi nhập đầy đủ thông tin thì btnTinhTien có tác dụng
            btnTinhTien.Enabled = coTen && coSoKhach && (coNuocUong || coThucAn);
        }
        private void Input_Changed(object sender, EventArgs e)
        {
            KiemTraThongTinKhach();
        }
        // Ràng buộc chỉ cho nhập số ở ô Số khách hàng
        private void txtSoKhach_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        // --- NÚT TÍNH TIỀN ---
        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            double tienNuoc = 0;
            double tienThucAn = 0;
            // Bảng giá Nước uống
            if (rdoCafeDen.Checked) tienNuoc = 20000;
            else if (rdoCafeDa.Checked) tienNuoc = 25000;
            else if (rdoCafeSua.Checked) tienNuoc = 25000;
            else if (rdoCafeSuaDa.Checked) tienNuoc = 30000;
            else if (rdoCafeKem.Checked) tienNuoc = 35000;
            // Bảng giá Thức ăn
            if (chkBanhMyTrung.Checked) tienThucAn += 15000;
            if (chkBanhMyCa.Checked) tienThucAn += 15000;
            if (chkMyTomTrung.Checked) tienThucAn += 20000;
            if (chkMyXaoBo.Checked) tienThucAn += 30000;
            if (chkMyCay.Checked) tienThucAn += 50000;
            tienKhachHienTai = tienNuoc + tienThucAn;
            // Giảm giá 20% nếu là Sinh viên
            if (chkSinhVien.Checked)
            {
                tienKhachHienTai *= 0.8;
            }
            // Hiển thị lên MessageBox
            MessageBox.Show($"Khách hàng: {txtTenKhach.Text}\n" +
                            $"Số tiền cần thanh toán: {tienKhachHienTai:N0} VNĐ", 
                            "Hóa Đơn Tính Tiền", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Information);
            // btnNhapLai và btnThanhToan sáng lên
            btnNhapLai.Enabled = true;
            btnThanhToan.Enabled = true;
        }
        // --- NÚT NHẬP LẠI ---
        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            ResetFormKhach(); // Quay về trạng thái ban đầu, btnNhapLai mờ
        }
        // --- NÚT THANH TOÁN ---
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            int soKhach = int.Parse(txtSoKhach.Text);
            // Ghi lại thông tin tổng số khách và tổng tiền
            tongSoKhach += soKhach;
            tongTienThanhToan += tienKhachHienTai;
            txtTongKhachHang.Text = tongSoKhach.ToString();
            txtTongTienThanhToan.Text = $"{tongTienThanhToan:N0} VNĐ";
            // Sẵn sàng nhập nhóm khách mới
            ResetFormKhach();
        }
        // --- NÚT THOÁT ---
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmCafeSinhVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc chắn thoát khỏi chương trình hay không?", 
                                             "Xác nhận", 
                                             MessageBoxButtons.YesNo, 
                                             MessageBoxIcon.Question);
            if (r == DialogResult.No)
            {
                e.Cancel = true; // Không thoát
            }
        }
    }
}
