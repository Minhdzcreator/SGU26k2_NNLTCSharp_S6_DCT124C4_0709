using System;
using System.Windows.Forms;
namespace WinFormsApp
{
    public partial class frmDangkyKS : Form
    {
        // Khai báo các biến cộng dồn tổng kết
        private int tongSoLuotKhach = 0;
        private double tongSoTien = 0;
        public frmDangkyKS()
        {
            InitializeComponent();
        }
        // --- FORM LOAD ---
        private void frmDangkyKS_Load(object sender, EventArgs e)
        {
            ResetForm();
            txtHoTen.Focus(); // Con trỏ văn bản đặt vào ô tên khách hàng
        }
        // Đưa Form về trạng thái ban đầu để nhập khách mới
        private void ResetForm()
        {
            txtHoTen.Clear();
            txtDiaChi.Clear();
            txtSoNgayO.Clear();
            txtThanhTien.Clear();
            txtTongSoKhach.Clear();
            txtTongSoTien.Clear();
            // Mặc định chọn Phòng đơn
            rdoPhongDon.Checked = true;
            rdoPhongDoi.Checked = false;
            rdoPhongBa.Checked = false;
            // Bỏ chọn Tiện nghi
            chkTivi.Checked = false;
            chkInternet.Checked = false;
            chkMayNuocNong.Checked = false;
            // Bỏ chọn Dịch vụ
            chkKaraoke.Checked = false;
            chkAnSang.Checked = false;
            // Về trạng thái Enabled của các nút bấm
            btnThanhToan.Enabled = false;
            btnNhapMoi.Enabled = false;
            btnTongKet.Enabled = (tongSoLuotKhach > 0); // Cho phép tổng kết nếu đã có giao dịch
            txtHoTen.Focus();
        }
        // --- KIỂM TRA ĐIỀU KIỆN KHI NHẬP THÔNG TIN ---
        private void KiemTraThongTin()
        {
            bool coHoTen = !string.IsNullOrWhiteSpace(txtHoTen.Text);
            bool coDiaChi = !string.IsNullOrWhiteSpace(txtDiaChi.Text);
            bool coSoNgay = int.TryParse(txtSoNgayO.Text, out int n) && n > 0;
            // Khi nhập đầy đủ thông tin thì btnThanhToan mới sáng lên
            btnThanhToan.Enabled = coHoTen && coDiaChi && coSoNgay;
        }
        private void Input_Changed(object sender, EventArgs e)
        {
            KiemTraThongTin();
        }
        // Ràng buộc chỉ cho nhập số vào ô Số ngày ở
        private void txtSoNgayO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        // --- NÚT THANH TOÁN ---
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            int soNgay = int.Parse(txtSoNgayO.Text);
            double tienPhongMotNgay = 0;
            // 1. Tính giá loại phòng/ngày
            if (rdoPhongDon.Checked) tienPhongMotNgay = 300000;
            else if (rdoPhongDoi.Checked) tienPhongMotNgay = 350000;
            else if (rdoPhongBa.Checked) tienPhongMotNgay = 400000;
            // 2. Tính tiền tiện nghi (+10.000đ/ngày cho mỗi tiện nghi chọn)
            int soTienNghi = 0;
            if (chkTivi.Checked) soTienNghi++;
            if (chkInternet.Checked) soTienNghi++;
            if (chkMayNuocNong.Checked) soTienNghi++;
            double tienTienNghi = soTienNghi * 10000;
            // 3. Tính tiền dịch vụ
            double tienDichVu = 0;
            if (chkKaraoke.Checked) tienDichVu += 50000;         // Karaoke: 50.000đ
            if (chkAnSang.Checked) tienDichVu += 15000 * soNgay;  // Ăn sáng: 15.000đ/1 ngày
            // Tổng tiền phòng cho khách hàng này
            double thanhTien = (tienPhongMotNgay + tienTienNghi) * soNgay + tienDichVu;
            // Hiển thị lên ô Thành tiền
            txtThanhTien.Text = $"{thanhTien:N0} VNĐ";
            // Lưu lại thông tin tổng cộng
            tongSoLuotKhach += 1;
            tongSoTien += thanhTien;
            // Nút Nhập mới và Tổng kết sáng lên
            btnNhapMoi.Enabled = true;
            btnTongKet.Enabled = true;
        }
        // --- NÚT NHẬP MỚI ---
        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            ResetForm(); // Khởi tạo lại trạng thái ban đầu, btnNhapMoi bị mờ
        }
        // --- NÚT TỔNG KẾT ---
        private void btnTongKet_Click(object sender, EventArgs e)
        {
            // Ghi lại thông tin tổng số khách và tổng tiền vào label/textbox tương ứng
            txtTongSoKhach.Text = tongSoLuotKhach.ToString();
            txtTongSoTien.Text = $"{tongSoTien:N0} VNĐ";
            // Reset giá trị biến tổng về 0 và mờ nút TongKet
            tongSoLuotKhach = 0;
            tongSoTien = 0;
            btnTongKet.Enabled = false;
        }
        // --- NÚT THOÁT ---
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmDangkyKS_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc chắn thoát khỏi chương trình hay không?", 
                                             "Xác nhận", 
                                             MessageBoxButtons.YesNo, 
                                             MessageBoxIcon.Question);
            if (r == DialogResult.No)
            {
                e.Cancel = true; // Hủy thao tác thoát
            }
        }
    }
}
