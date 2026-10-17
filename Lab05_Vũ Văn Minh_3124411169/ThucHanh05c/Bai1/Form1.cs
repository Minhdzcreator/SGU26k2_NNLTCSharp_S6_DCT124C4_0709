#nullable disable
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace QuanLyUocSo
{
    public partial class Form1 : Form
    {
        private Label lblNhapSo, lblDanhSach;
        private TextBox txtNhapSo;
        private ComboBox cmbSo;
        private ListBox lstUocSo;
        private Button btnCapNhat, btnTongUocSo, btnSoLuongChan, btnSoLuongNguyenTo, btnThoat;
        public Form1()
        {
            InitializeCustomComponent();
        }
        private void InitializeCustomComponent()
        {
            // 1. Cấu hình Form
            this.Text = "Combobox";
            this.Size = new Size(530, 330);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.FormClosing += Form1_FormClosing;
            // --- BÊN TRÁI ---
            // Label "Nhập Số"
            lblNhapSo = new Label();
            lblNhapSo.Text = "Nhập Số";
            lblNhapSo.Location = new Point(30, 30);
            lblNhapSo.AutoSize = true;
            this.Controls.Add(lblNhapSo);
            // TextBox Nhập số
            txtNhapSo = new TextBox();
            txtNhapSo.Location = new Point(110, 27);
            txtNhapSo.Size = new Size(110, 25);
            this.Controls.Add(txtNhapSo);
            // Nút Cập nhật (HotKey: Alt + P)
            btnCapNhat = new Button();
            btnCapNhat.Text = "Cậ&p nhật";
            btnCapNhat.Location = new Point(230, 25);
            btnCapNhat.Size = new Size(80, 28);
            btnCapNhat.Click += BtnCapNhat_Click;
            this.Controls.Add(btnCapNhat);
            // ComboBox hiển thị danh sách các số
            cmbSo = new ComboBox();
            cmbSo.Location = new Point(110, 70);
            cmbSo.Size = new Size(200, 25);
            cmbSo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSo.SelectedIndexChanged += CmbSo_SelectedIndexChanged;
            this.Controls.Add(cmbSo);
            // Nút Thoát (HotKey: Alt + T)
            btnThoat = new Button();
            btnThoat.Text = "Thoá&t";
            btnThoat.Location = new Point(170, 225);
            btnThoat.Size = new Size(80, 30);
            btnThoat.Click += BtnThoat_Click;
            this.Controls.Add(btnThoat);
            // --- BÊN PHẢI ---
            // Label "Danh sách các ước số"
            lblDanhSach = new Label();
            lblDanhSach.Text = "Danh sách các ước số";
            lblDanhSach.Location = new Point(340, 10);
            lblDanhSach.AutoSize = true;
            this.Controls.Add(lblDanhSach);
            // ListBox hiển thị các ước số
            lstUocSo = new ListBox();
            lstUocSo.Location = new Point(340, 30);
            lstUocSo.Size = new Size(150, 95);
            this.Controls.Add(lstUocSo);
            // Nút "Tổng các ước số" (HotKey: Alt + S)
            btnTongUocSo = new Button();
            btnTongUocSo.Text = "Tổn&g các ước số";
            btnTongUocSo.Location = new Point(330, 135);
            btnTongUocSo.Size = new Size(170, 28);
            btnTongUocSo.Click += BtnTongUocSo_Click;
            this.Controls.Add(btnTongUocSo);
            // Nút "Số lượng các ước số chẵn" (HotKey: Alt + C)
            btnSoLuongChan = new Button();
            btnSoLuongChan.Text = "Số lượng các ước số &chẵn";
            btnSoLuongChan.Location = new Point(330, 170);
            btnSoLuongChan.Size = new Size(170, 28);
            btnSoLuongChan.Click += BtnSoLuongChan_Click;
            this.Controls.Add(btnSoLuongChan);
            // Nút "Số lượng các ước số nguyên tố" (HotKey: Alt + N)
            btnSoLuongNguyenTo = new Button();
            btnSoLuongNguyenTo.Text = "Số lượng các ước số &nguyên tố";
            btnSoLuongNguyenTo.Location = new Point(330, 205);
            btnSoLuongNguyenTo.Size = new Size(170, 28);
            btnSoLuongNguyenTo.Click += BtnSoLuongNguyenTo_Click;
            this.Controls.Add(btnSoLuongNguyenTo);
            // Đặt phím Enter mặc định là bấm nút Cập nhật
            this.AcceptButton = btnCapNhat;
        }
        // --- YÊU CẦU 1 & 2: Nút Cập nhật ---
        private void BtnCapNhat_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu nhập có phải là số nguyên hợp lệ
            if (!int.TryParse(txtNhapSo.Text.Trim(), out int val) || val <= 0)
            {
                MessageBox.Show("Vui lòng nhập một số nguyên dương hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNhapSo.SelectAll();
                txtNhapSo.Focus();
                return;
            }
            string inputVal = val.ToString();
            // Kiểm tra số vừa nhập đã tồn tại trong ComboBox chưa
            if (cmbSo.Items.Contains(inputVal))
            {
                MessageBox.Show("Số này đã tồn tại trong danh sách chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                cmbSo.Items.Add(inputVal);
                cmbSo.SelectedItem = inputVal; // Tự động chọn số mới thêm
            }
            // Xóa dữ liệu trong TextBox và đặt lại con trỏ
            txtNhapSo.Clear();
            txtNhapSo.Focus();
        }
        // --- YÊU CẦU 3: Lấy danh sách ước số khi chọn số trong ComboBox ---
        private void CmbSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstUocSo.Items.Clear();
            if (cmbSo.SelectedItem != null && int.TryParse(cmbSo.SelectedItem.ToString(), out int n))
            {
                for (int i = 1; i <= n; i++)
                {
                    if (n % i == 0)
                    {
                        lstUocSo.Items.Add(i);
                    }
                }
            }
        }
        // --- YÊU CẦU 4.1: Tính tổng các ước số ---
        private void BtnTongUocSo_Click(object sender, EventArgs e)
        {
            if (lstUocSo.Items.Count == 0)
            {
                MessageBox.Show("Chưa chọn số hoặc danh sách ước số trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int sum = lstUocSo.Items.Cast<int>().Sum();
            MessageBox.Show($"Tổng các ước số là: {sum}", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        // --- YÊU CẦU 4.2: Đếm số lượng các ước số chẵn ---
        private void BtnSoLuongChan_Click(object sender, EventArgs e)
        {
            if (lstUocSo.Items.Count == 0)
            {
                MessageBox.Show("Chưa chọn số hoặc danh sách ước số trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int countEven = lstUocSo.Items.Cast<int>().Count(x => x % 2 == 0);
            MessageBox.Show($"Số lượng các ước số chẵn là: {countEven}", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        // --- YÊU CẦU 4.3: Đếm số lượng các ước số nguyên tố ---
        private void BtnSoLuongNguyenTo_Click(object sender, EventArgs e)
        {
            if (lstUocSo.Items.Count == 0)
            {
                MessageBox.Show("Chưa chọn số hoặc danh sách ước số trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int countPrime = lstUocSo.Items.Cast<int>().Count(x => KiemTraNguyenTo(x));
            MessageBox.Show($"Số lượng các ước số nguyên tố là: {countPrime}", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        // Hàm kiểm tra số nguyên tố
        private bool KiemTraNguyenTo(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
        // --- YÊU CẦU 5: Nút Thoát có xác nhận ---
        private void BtnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Bạn có muốn thoát chương trình không?", 
                "Xác nhận thoát", 
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
