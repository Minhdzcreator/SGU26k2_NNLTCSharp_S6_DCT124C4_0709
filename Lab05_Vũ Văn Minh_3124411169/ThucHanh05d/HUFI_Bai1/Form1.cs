#nullable disable
using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
namespace QuanLyMonHocApp
{
    public partial class Form1 : Form
    {
        // Chuỗi kết nối đến CSDL QLSinhVien
        private string connectionString = @"Data Source=.;Initial Catalog=QLSinhVien;Integrated Security=True;TrustServerCertificate=True";
        private Label lblMaMH, lblTenMH;
        private TextBox txtMaMH, txtTenMH;
        private Button btnThem, btnXoa, btnSua;
        public Form1()
        {
            InitializeCustomComponent();
        }
        private void InitializeCustomComponent()
        {
            this.Text = "Quản lý môn học";
            this.Size = new Size(380, 220);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            lblMaMH = new Label { Text = "Mã mh", Location = new Point(30, 25), AutoSize = true };
            txtMaMH = new TextBox { Location = new Point(110, 22), Size = new Size(220, 25) };
            lblTenMH = new Label { Text = "Tên mh", Location = new Point(30, 65), AutoSize = true };
            txtTenMH = new TextBox { Location = new Point(110, 62), Size = new Size(220, 25) };
            btnThem = new Button { Text = "Thêm", Location = new Point(30, 115), Size = new Size(90, 35) };
            btnThem.Click += BtnThem_Click;
            btnXoa = new Button { Text = "Xóa", Location = new Point(135, 115), Size = new Size(90, 35) };
            btnXoa.Click += BtnXoa_Click;
            btnSua = new Button { Text = "Sửa", Location = new Point(240, 115), Size = new Size(90, 35) };
            btnSua.Click += BtnSua_Click;
            this.Controls.Add(lblMaMH); this.Controls.Add(txtMaMH);
            this.Controls.Add(lblTenMH); this.Controls.Add(txtTenMH);
            this.Controls.Add(btnThem);
            this.Controls.Add(btnXoa);
            this.Controls.Add(btnSua);
        }
        // --- 1. THÊM MÔN HỌC ---
        private void BtnThem_Click(object sender, EventArgs e)
        {
            string maMH = txtMaMH.Text.Trim();
            string tenMH = txtTenMH.Text.Trim();
            if (string.IsNullOrWhiteSpace(maMH) || string.IsNullOrWhiteSpace(tenMH))
            {
                MessageBox.Show("Mã môn học và Tên môn học không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string query = "INSERT INTO MonHoc (MaMH, TenMH) VALUES (@MaMH, @TenMH)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaMH", maMH);
                        cmd.Parameters.AddWithValue("@TenMH", tenMH);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thêm môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearInputs();
                        }
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("Mã môn học này đã tồn tại!", "Lỗi trùng khóa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        // --- 2. XÓA MÔN HỌC ---
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            string maMH = txtMaMH.Text.Trim();
            string tenMH = txtTenMH.Text.Trim();
            if (string.IsNullOrWhiteSpace(maMH))
            {
                MessageBox.Show("Vui lòng nhập Mã môn học cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaMH.Focus();
                return;
            }
            if (!string.IsNullOrWhiteSpace(tenMH))
            {
                MessageBox.Show("Theo yêu cầu: Tên môn học không được nhập dữ liệu khi thực hiện Xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenMH.Clear();
                return;
            }
            DialogResult dr = MessageBox.Show($"Bạn có chắc muốn xóa môn học '{maMH}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No) return;
            string query = "DELETE FROM MonHoc WHERE MaMH = @MaMH";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaMH", maMH);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearInputs();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy mã môn học để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // --- 3. SỬA MÔN HỌC ---
        private void BtnSua_Click(object sender, EventArgs e)
        {
            string maMH = txtMaMH.Text.Trim();
            string tenMH = txtTenMH.Text.Trim();
            if (string.IsNullOrWhiteSpace(maMH) || string.IsNullOrWhiteSpace(tenMH))
            {
                MessageBox.Show("Mã môn học và Tên môn học không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string query = "UPDATE MonHoc SET TenMH = @TenMH WHERE MaMH = @MaMH";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaMH", maMH);
                        cmd.Parameters.AddWithValue("@TenMH", tenMH);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearInputs();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy mã môn học để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi cập nhật CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ClearInputs()
        {
            txtMaMH.Clear();
            txtTenMH.Clear();
            txtMaMH.Focus();
        }
    }
}
