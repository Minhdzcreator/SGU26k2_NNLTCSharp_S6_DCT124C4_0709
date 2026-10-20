#nullable disable
using System;
using System.Data;
using Microsoft.Data.SqlClient; // Thư viện kết nối CSDL SQL Server
using System.Drawing;
using System.Windows.Forms;
namespace QuanLyDiemApp
{
    public partial class Form1 : Form
    {
        // Chuỗi kết nối CSDL
        private string connectionString = @"Data Source=.;Initial Catalog=QLSinhVien;Integrated Security=True;TrustServerCertificate=True";
        private Label lblMaSV, lblMaMH, lblDiem;
        private TextBox txtMaSV, txtMaMH, txtDiem;
        private Button btnThem, btnXoa, btnSua;
        public Form1()
        {
            InitializeCustomComponent();
        }
        private void InitializeCustomComponent()
        {
            this.Text = "Quản lý Điểm";
            this.Size = new Size(380, 260);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            lblMaSV = new Label { Text = "Mã sv", Location = new Point(30, 25), AutoSize = true };
            txtMaSV = new TextBox { Location = new Point(110, 22), Size = new Size(220, 25) };
            lblMaMH = new Label { Text = "Mã mh", Location = new Point(30, 65), AutoSize = true };
            txtMaMH = new TextBox { Location = new Point(110, 62), Size = new Size(220, 25) };
            lblDiem = new Label { Text = "Điểm", Location = new Point(30, 105), AutoSize = true };
            txtDiem = new TextBox { Location = new Point(110, 102), Size = new Size(220, 25) };
            btnThem = new Button { Text = "Thêm", Location = new Point(30, 155), Size = new Size(90, 35) };
            btnThem.Click += BtnThem_Click;
            btnXoa = new Button { Text = "Xóa", Location = new Point(135, 155), Size = new Size(90, 35) };
            btnXoa.Click += BtnXoa_Click;
            btnSua = new Button { Text = "Sửa", Location = new Point(240, 155), Size = new Size(90, 35) };
            btnSua.Click += BtnSua_Click;
            this.Controls.Add(lblMaSV); this.Controls.Add(txtMaSV);
            this.Controls.Add(lblMaMH); this.Controls.Add(txtMaMH);
            this.Controls.Add(lblDiem); this.Controls.Add(txtDiem);
            this.Controls.Add(btnThem); this.Controls.Add(btnXoa); this.Controls.Add(btnSua);
        }
        private void BtnThem_Click(object sender, EventArgs e)
        {
            string maSV = txtMaSV.Text.Trim();
            string maMH = txtMaMH.Text.Trim();
            string strDiem = txtDiem.Text.Trim();
            if (string.IsNullOrWhiteSpace(maSV) || string.IsNullOrWhiteSpace(maMH) || string.IsNullOrWhiteSpace(strDiem))
            {
                MessageBox.Show("Mã sinh viên, Mã môn học và Điểm không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!double.TryParse(strDiem, out double diem) || diem < 0 || diem > 10)
            {
                MessageBox.Show("Điểm phải là số thực từ 0 đến 10!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string query = "INSERT INTO Diem (MaSV, MaMH, Diem) VALUES (@MaSV, @MaMH, @Diem)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSV", maSV);
                        cmd.Parameters.AddWithValue("@MaMH", maMH);
                        cmd.Parameters.AddWithValue("@Diem", diem);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thêm điểm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearInputs();
                        }
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("Sinh viên này đã có điểm môn học này trong hệ thống!", "Cảnh báo trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (ex.Number == 547)
                    {
                        MessageBox.Show("Mã sinh viên hoặc Mã môn học chưa tồn tại trong hệ thống! Vui lòng kiểm tra lại.", "Lỗi khóa ngoại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            string maSV = txtMaSV.Text.Trim();
            string maMH = txtMaMH.Text.Trim();
            string strDiem = txtDiem.Text.Trim();
            if (string.IsNullOrWhiteSpace(maSV) || string.IsNullOrWhiteSpace(maMH))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã sinh viên và Mã môn học cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!string.IsNullOrWhiteSpace(strDiem))
            {
                MessageBox.Show("Theo yêu cầu: Điểm không được nhập dữ liệu khi thực hiện Xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiem.Clear();
                return;
            }
            string query = "DELETE FROM Diem WHERE MaSV = @MaSV AND MaMH = @MaMH";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSV", maSV);
                        cmd.Parameters.AddWithValue("@MaMH", maMH);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa điểm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearInputs();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void BtnSua_Click(object sender, EventArgs e)
        {
            string maSV = txtMaSV.Text.Trim();
            string maMH = txtMaMH.Text.Trim();
            string strDiem = txtDiem.Text.Trim();
            if (string.IsNullOrWhiteSpace(maSV) || string.IsNullOrWhiteSpace(maMH) || string.IsNullOrWhiteSpace(strDiem))
            {
                MessageBox.Show("Mã sinh viên, Mã môn học và Điểm không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!double.TryParse(strDiem, out double diem) || diem < 0 || diem > 10)
            {
                MessageBox.Show("Điểm phải là số thực hợp lệ (0 - 10)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string query = "UPDATE Diem SET Diem = @Diem WHERE MaSV = @MaSV AND MaMH = @MaMH";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSV", maSV);
                        cmd.Parameters.AddWithValue("@MaMH", maMH);
                        cmd.Parameters.AddWithValue("@Diem", diem);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cập nhật điểm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearInputs();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ClearInputs()
        {
            txtMaSV.Clear();
            txtMaMH.Clear();
            txtDiem.Clear();
            txtMaSV.Focus();
        }
    }
}
