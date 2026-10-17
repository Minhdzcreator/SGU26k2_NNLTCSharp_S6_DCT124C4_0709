#nullable disable
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace QuanLyTaiKhoanApp
{
    public partial class Form1 : Form
    {
        // Khai báo các Control giao diện
        private Label lblTitle;
        private Label lblSoTK, lblTenKH, lblDiaChi, lblSoTien, lblTongTien;
        private TextBox txtSoTK, txtTenKH, txtDiaChi, txtSoTien, txtTongTien;
        private Button btnThem, btnLuu, btnXoa, btnThoat;
        private ListView lsvTaiKhoan;
        public Form1()
        {
            InitializeCustomComponent();
            InitData();
        }
        private void InitializeCustomComponent()
        {
            // Cấu hình Form cơ bản
            this.Text = "frmBaiTap2";
            this.Size = new Size(680, 560);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            // 1. Tiêu đề "QUẢN LÝ THÔNG TIN TÀI KHOẢN"
            lblTitle = new Label();
            lblTitle.Text = "QUẢN LÝ THÔNG TIN TÀI KHOẢN";
            lblTitle.Font = new Font("Arial", 16, FontStyle.Bold);
            lblTitle.ForeColor = Color.Blue;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Size = new Size(630, 35);
            lblTitle.Location = new Point(10, 15);
            this.Controls.Add(lblTitle);
            int startXLabel = 100;
            int startXText = 250;
            int startY = 65;
            int rowGap = 35;
            int textWidth = 320;
            // 2. Nhập các ô thông tin
            // Số tài khoản
            lblSoTK = new Label { Text = "Số tài khoản", Location = new Point(startXLabel, startY), AutoSize = true };
            txtSoTK = new TextBox { Location = new Point(startXText, startY - 3), Size = new Size(textWidth, 25) };
            // Tên khách hàng
            startY += rowGap;
            lblTenKH = new Label { Text = "Tên khách hàng", Location = new Point(startXLabel, startY), AutoSize = true };
            txtTenKH = new TextBox { Location = new Point(startXText, startY - 3), Size = new Size(textWidth, 25) };
            // Địa chỉ khách hàng
            startY += rowGap;
            lblDiaChi = new Label { Text = "Địa chỉ khách hàng", Location = new Point(startXLabel, startY), AutoSize = true };
            txtDiaChi = new TextBox { Location = new Point(startXText, startY - 3), Size = new Size(textWidth, 25) };
            // Số tiền trong tài khoản
            startY += rowGap;
            lblSoTien = new Label { Text = "Số tiền trong tài khoản", Location = new Point(startXLabel, startY), AutoSize = true };
            txtSoTien = new TextBox { Location = new Point(startXText, startY - 3), Size = new Size(textWidth, 25), TextAlign = HorizontalAlignment.Right };
            // 3. Các nút chức năng
            startY += 40;
            int btnWidth = 85;
            int btnHeight = 32;
            btnThem = new Button { Text = "Thêm", Location = new Point(startXText, startY), Size = new Size(btnWidth, btnHeight) };
            btnThem.Click += BtnThem_Click;
            btnLuu = new Button { Text = "Lưu", Location = new Point(startXText + 95, startY), Size = new Size(btnWidth, btnHeight), Enabled = false }; // Ban đầu mờ
            btnLuu.Click += BtnLuu_Click;
            btnXoa = new Button { Text = "Xóa", Location = new Point(startXText + 190, startY), Size = new Size(btnWidth, btnHeight), Enabled = false }; // Ban đầu mờ
            btnXoa.Click += BtnXoa_Click;
            btnThoat = new Button { Text = "Thoát", Location = new Point(startXText + 285, startY), Size = new Size(btnWidth, btnHeight) };
            btnThoat.Click += BtnThoat_Click;
            // 4. ListView hiển thị danh sách tài khoản
            startY += 45;
            lsvTaiKhoan = new ListView();
            lsvTaiKhoan.Location = new Point(25, startY);
            lsvTaiKhoan.Size = new Size(615, 200);
            lsvTaiKhoan.View = View.Details;
            lsvTaiKhoan.FullRowSelect = true;
            lsvTaiKhoan.GridLines = true;
            lsvTaiKhoan.Columns.Add("STT", 50);
            lsvTaiKhoan.Columns.Add("Số tài khoản", 130);
            lsvTaiKhoan.Columns.Add("Tên khách hàng", 170);
            lsvTaiKhoan.Columns.Add("Địa chỉ", 120);
            lsvTaiKhoan.Columns.Add("Số tiền", 120, HorizontalAlignment.Right);
            lsvTaiKhoan.SelectedIndexChanged += LsvTaiKhoan_SelectedIndexChanged;
            // 5. Ô Tổng tiền bên dưới
            startY += 210;
            lblTongTien = new Label { Text = "Tổng tiền", Location = new Point(360, startY + 3), AutoSize = true };
            txtTongTien = new TextBox { Location = new Point(440, startY), Size = new Size(200, 25), ReadOnly = true, TextAlign = HorizontalAlignment.Right };
            // Thêm các Controls vào Form
            this.Controls.Add(lblTitle);
            this.Controls.Add(lblSoTK); this.Controls.Add(txtSoTK);
            this.Controls.Add(lblTenKH); this.Controls.Add(txtTenKH);
            this.Controls.Add(lblDiaChi); this.Controls.Add(txtDiaChi);
            this.Controls.Add(lblSoTien); this.Controls.Add(txtSoTien);
            this.Controls.Add(btnThem); this.Controls.Add(btnLuu); this.Controls.Add(btnXoa); this.Controls.Add(btnThoat);
            this.Controls.Add(lsvTaiKhoan);
            this.Controls.Add(lblTongTien); this.Controls.Add(txtTongTien);
            this.FormClosing += Form1_FormClosing;
        }
        // Khởi tạo dữ liệu mẫu giống hình 2
        private void InitData()
        {
            ThemDongDuyNhat("0160901609", "Nguyễn Văn An", "TPHCM", 5200000);
            ThemDongDuyNhat("0160901610", "Trần Văn Anh", "Tây Ninh", 1200000);
            CapNhatSTTVaTongTien();
        }
        // Hàm phụ hỗ trợ thêm dữ liệu vào ListView
        private void ThemDongDuyNhat(string soTK, string tenKH, string diaChi, decimal soTien)
        {
            ListViewItem item = new ListViewItem(""); // STT sẽ tự cập nhật sau
            item.SubItems.Add(soTK);
            item.SubItems.Add(tenKH);
            item.SubItems.Add(diaChi);
            item.SubItems.Add(soTien.ToString("#,##0"));
            lsvTaiKhoan.Items.Add(item);
        }
        // Yêu cầu: Nút "Thêm" đổi tên thành "Hủy", bật nút "Lưu", xóa rỗng textbox và focus ô Số tài khoản
        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                btnThem.Text = "Hủy";
                btnLuu.Enabled = true;
                XoaRongCacTextbox();
                txtSoTK.Focus();
            }
            else // Khi đang là "Hủy"
            {
                btnThem.Text = "Thêm";
                btnLuu.Enabled = false;
                XoaRongCacTextbox();
            }
        }
        // Yêu cầu: Nút "Lưu" thêm thông tin mới vào ListView
        private void BtnLuu_Click(object sender, EventArgs e)
        {
            string soTK = txtSoTK.Text.Trim();
            string tenKH = txtTenKH.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string strSoTien = txtSoTien.Text.Trim();
            // Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(soTK) || string.IsNullOrWhiteSpace(tenKH) || 
                string.IsNullOrWhiteSpace(diaChi) || string.IsNullOrWhiteSpace(strSoTien))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Kiểm tra trùng Số tài khoản
            foreach (ListViewItem item in lsvTaiKhoan.Items)
            {
                if (item.SubItems[1].Text.Equals(soTK, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Số tài khoản này đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoTK.Focus();
                    return;
                }
            }
            // Kiểm tra định dạng số tiền
            if (!decimal.TryParse(strSoTien, out decimal soTien) || soTien < 0)
            {
                MessageBox.Show("Số tiền phải là một số hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoTien.Focus();
                return;
            }
            // Thêm vào ListView
            ThemDongDuyNhat(soTK, tenKH, diaChi, soTien);
            // Tự động đánh lại STT và tính lại tổng tiền
            CapNhatSTTVaTongTien();
            // Đưa Form về trạng thái ban đầu
            btnThem.Text = "Thêm";
            btnLuu.Enabled = false;
            XoaRongCacTextbox();
            MessageBox.Show("Thêm tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        // Yêu cầu: Chọn dòng trên ListView sẽ hiển thị dữ liệu lên TextBox và bật nút "Xóa"
        private void LsvTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvTaiKhoan.SelectedItems.Count > 0)
            {
                ListViewItem item = lsvTaiKhoan.SelectedItems[0];
                txtSoTK.Text = item.SubItems[1].Text;
                txtTenKH.Text = item.SubItems[2].Text;
                txtDiaChi.Text = item.SubItems[3].Text;
                // Loại bỏ dấu phẩy để hiển thị nguyên giá trị số trên textbox
                txtSoTien.Text = item.SubItems[4].Text.Replace(",", "").Replace(".", "");
                btnXoa.Enabled = true; // Bật nút Xóa khi có mẫu tin được chọn
            }
            else
            {
                btnXoa.Enabled = false;
            }
        }
        // Yêu cầu: Nút "Xóa" xóa mẫu tin hiện hành
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (lsvTaiKhoan.SelectedItems.Count == 0) return;
            DialogResult dr = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa tài khoản này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (dr == DialogResult.Yes)
            {
                lsvTaiKhoan.Items.Remove(lsvTaiKhoan.SelectedItems[0]);
                // Tự động đánh lại STT và tính lại tổng tiền sau khi xóa
                CapNhatSTTVaTongTien();
                XoaRongCacTextbox();
                btnXoa.Enabled = false;
                MessageBox.Show("Xóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // Yêu cầu: Đánh STT tự động và Tính Tổng tiền
        private void CapNhatSTTVaTongTien()
        {
            decimal tongTien = 0;
            for (int i = 0; i < lsvTaiKhoan.Items.Count; i++)
            {
                ListViewItem item = lsvTaiKhoan.Items[i];
                item.SubItems[0].Text = (i + 1).ToString(); // Đánh STT tự động
                if (decimal.TryParse(item.SubItems[4].Text.Replace(",", "").Replace(".", ""), out decimal tien))
                {
                    tongTien += tien; // Cộng dồn tổng tiền
                }
            }
            txtTongTien.Text = tongTien.ToString("#,##0"); // Hiển thị tổng tiền dạng 6,400,000
        }
        private void XoaRongCacTextbox()
        {
            txtSoTK.Clear();
            txtTenKH.Clear();
            txtDiaChi.Clear();
            txtSoTien.Clear();
        }
        // Nút Thoát
        private void BtnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Bạn có muốn thoát chương trình?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (dr == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
