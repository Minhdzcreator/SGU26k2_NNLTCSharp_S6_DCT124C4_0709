#nullable disable
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
namespace QuanLyLopApp
{
    public partial class Form1 : Form
    {
        // Chuỗi kết nối CSDL QLSinhVien
        private string connectionString = @"Data Source=.;Initial Catalog=QLSinhVien;Integrated Security=True;TrustServerCertificate=True";
        // Khai báo các Control giao diện
        private Label lblMaKhoa, lblMaLop, lblTenLop;
        private TextBox txtMaKhoa, txtMaLop, txtTenLop;
        private Button btnThem, btnXoa, btnSua;
        public Form1()
        {
            InitializeCustomComponent();
        }
        private void InitializeCustomComponent()
        {
            // Cấu hình Form
            this.Text = "frmLop";
            this.Size = new Size(380, 260);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            // 1. Mã khoa
            lblMaKhoa = new Label { Text = "Mã khoa", Location = new Point(30, 25), AutoSize = true };
            txtMaKhoa = new TextBox { Location = new Point(110, 22), Size = new Size(220, 25) };
            // 2. Mã lớp
            lblMaLop = new Label { Text = "Mã lớp", Location = new Point(30, 65), AutoSize = true };
            txtMaLop = new TextBox { Location = new Point(110, 62), Size = new Size(220, 25) };
            // 3. Tên lớp
            lblTenLop = new Label { Text = "Tên lớp", Location = new Point(30, 105), AutoSize = true };
            txtTenLop = new TextBox { Location = new Point(110, 102), Size = new Size(220, 25) };
            // 4. Các nút chức năng
            btnThem = new Button { Text = "Thêm", Location = new Point(30, 155), Size = new Size(90, 35) };
            btnThem.Click += BtnThem_Click;
            btnXoa = new Button { Text = "Xóa", Location = new Point(135, 155), Size = new Size(90, 35) };
            btnXoa.Click += BtnXoa_Click;
            btnSua = new Button { Text = "Sửa", Location = new Point(240, 155), Size = new Size(90, 35) };
            btnSua.Click += BtnSua_Click;
            // Thêm vào Form
            this.Controls.Add(lblMaKhoa); this.Controls.Add(txtMaKhoa);
            this.Controls.Add(lblMaLop); this.Controls.Add(txtMaLop);
            this.Controls.Add(lblTenLop); this.Controls.Add(txtTenLop);
            this.Controls.Add(btnThem);
            this.Controls.Add(btnXoa);
            this.Controls.Add(btnSua);
        }
        // --- 1. CHỨC NĂNG THÊM DỮ LIỆU ---
        private void BtnThem_Click(object sender, EventArgs e)
        {
            string maKhoa = txtMaKhoa.Text.Trim();
            string maLop = txtMaLop.Text.Trim();
            string tenLop = txtTenLop.Text.Trim();
            // Yêu cầu: Mã khoa, Mã lớp, Tên lớp không được để trống
            if (string.IsNullOrWhiteSpace(maKhoa) || string.IsNullOrWhiteSpace(maLop) || string.IsNullOrWhiteSpace(tenLop))
            {
                MessageBox.Show("Mã khoa, Mã lớp và Tên lớp không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string query = "INSERT INTO Lop (MaKhoa, MaLop, TenLop) VALUES (@MaKhoa, @MaLop, @TenLop)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaKhoa", maKhoa);
                        cmd.Parameters.AddWithValue("@MaLop", maLop);
                        cmd.Parameters.AddWithValue("@TenLop", tenLop);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thêm lớp mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearInputs();
                        }
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627 || ex.Number == 2601) // Trùng khóa chính Mã lớp
                    {
                        MessageBox.Show("Mã lớp này đã tồn tại trong cơ sở dữ liệu!", "Lỗi trùng khóa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (ex.Number == 547) // Vi phạm khóa ngoại Mã khoa không tồn tại
                    {
                        MessageBox.Show("Mã khoa không tồn tại trong CSDL!", "Lỗi liên kết CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        // --- 2. CHỨC NĂNG XÓA DỮ LIỆU ---
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            string maLop = txtMaLop.Text.Trim();
            string maKhoa = txtMaKhoa.Text.Trim();
            string tenLop = txtTenLop.Text.Trim();
            // Yêu cầu: Mã lớp không được để trống
            if (string.IsNullOrWhiteSpace(maLop))
            {
                MessageBox.Show("Vui lòng nhập Mã lớp cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaLop.Focus();
                return;
            }
            if (!string.IsNullOrWhiteSpace(maKhoa) || !string.IsNullOrWhiteSpace(tenLop))
            {
                MessageBox.Show("Theo yêu cầu: Mã khoa và Tên lớp không được nhập dữ liệu khi thực hiện Xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKhoa.Clear();
                txtTenLop.Clear();
                return;
            }
            DialogResult dr = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa lớp có mã '{maLop}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (dr == DialogResult.No) return;
            string query = "DELETE FROM Lop WHERE MaLop = @MaLop";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaLop", maLop);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa thông tin lớp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearInputs();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy lớp có mã vừa nhập để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // --- 3. CHỨC NĂNG SỬA DỮ LIỆU ---
        private void BtnSua_Click(object sender, EventArgs e)
        {
            string maLop = txtMaLop.Text.Trim();
            string maKhoa = txtMaKhoa.Text.Trim();
            string tenLop = txtTenLop.Text.Trim();
            // Yêu cầu: Mã lớp không được để trống
            if (string.IsNullOrWhiteSpace(maLop))
            {
                MessageBox.Show("Vui lòng nhập Mã lớp cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaLop.Focus();
                return;
            }
            // Yêu cầu: Mã khoa, Tên lớp phải có ít nhất 1 trường có dữ liệu
            if (string.IsNullOrWhiteSpace(maKhoa) && string.IsNullOrWhiteSpace(tenLop))
            {
                MessageBox.Show("Vui lòng nhập Mã khoa hoặc Tên lớp để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Xây dựng câu truy vấn linh hoạt theo các ô có dữ liệu
            List<string> updateFields = new List<string>();
            if (!string.IsNullOrWhiteSpace(maKhoa)) updateFields.Add("MaKhoa = @MaKhoa");
            if (!string.IsNullOrWhiteSpace(tenLop)) updateFields.Add("TenLop = @TenLop");
            string query = $"UPDATE Lop SET {string.Join(", ", updateFields)} WHERE MaLop = @MaLop";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaLop", maLop);
                        if (!string.IsNullOrWhiteSpace(maKhoa)) cmd.Parameters.AddWithValue("@MaKhoa", maKhoa);
                        if (!string.IsNullOrWhiteSpace(tenLop)) cmd.Parameters.AddWithValue("@TenLop", tenLop);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cập nhật thông tin lớp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearInputs();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy mã lớp tương ứng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ClearInputs()
        {
            txtMaKhoa.Clear();
            txtMaLop.Clear();
            txtTenLop.Clear();
            txtMaKhoa.Focus();
        }
    }
}
