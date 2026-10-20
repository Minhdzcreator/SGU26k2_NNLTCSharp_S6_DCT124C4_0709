#nullable disable
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace ThucHanh06b_Bai2
{
    public class frmDiem_combo : Form
    {
        private string connectionString = @"Data Source=.;Initial Catalog=QLSinhVien;Integrated Security=True;TrustServerCertificate=True";

        private Label lblSinhVien, lblMonHoc, lblDiem;
        private ComboBox cboSinhVien, cboMonHoc;
        private TextBox txtDiem;
        private Button btnThem, btnXoa, btnSua;

        public frmDiem_combo()
        {
            InitializeCustomComponent();
        }

        private void InitializeCustomComponent()
        {
            this.Text = "frmDiem_combo";
            this.Size = new Size(380, 240);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            lblSinhVien = new Label { Text = "Sinh viên", Location = new Point(30, 25), AutoSize = true };
            cboSinhVien = new ComboBox { Location = new Point(110, 22), Size = new Size(220, 25), DropDownStyle = ComboBoxStyle.DropDownList };

            lblMonHoc = new Label { Text = "Môn học", Location = new Point(30, 65), AutoSize = true };
            cboMonHoc = new ComboBox { Location = new Point(110, 62), Size = new Size(220, 25), DropDownStyle = ComboBoxStyle.DropDownList };

            lblDiem = new Label { Text = "Điểm", Location = new Point(30, 105), AutoSize = true };
            txtDiem = new TextBox { Location = new Point(110, 102), Size = new Size(220, 25) };

            btnThem = new Button { Text = "Thêm", Location = new Point(30, 150), Size = new Size(90, 32) };
            btnThem.Click += BtnThem_Click;

            btnXoa = new Button { Text = "Xóa", Location = new Point(135, 150), Size = new Size(90, 32) };
            btnXoa.Click += BtnXoa_Click;

            btnSua = new Button { Text = "Sửa", Location = new Point(240, 150), Size = new Size(90, 32) };
            btnSua.Click += BtnSua_Click;

            this.Controls.Add(lblSinhVien);
            this.Controls.Add(cboSinhVien);
            this.Controls.Add(lblMonHoc);
            this.Controls.Add(cboMonHoc);
            this.Controls.Add(lblDiem);
            this.Controls.Add(txtDiem);
            this.Controls.Add(btnThem);
            this.Controls.Add(btnXoa);
            this.Controls.Add(btnSua);

            this.Load += FrmDiem_combo_Load;
        }

        private void FrmDiem_combo_Load(object sender, EventArgs e)
        {
            LoadSinhVien_ComboBox();
            LoadMonHoc_ComboBox();
        }

        // 1. Hiển thị mã sinh viên trên combobox Sinh viên
        private void LoadSinhVien_ComboBox()
        {
            cboSinhVien.Items.Clear();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT MaSinhVien FROM SinhVien";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            cboSinhVien.Items.Add(rd["MaSinhVien"].ToString());
                        }
                    }
                    if (cboSinhVien.Items.Count > 0) cboSinhVien.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 2. Hiển thị mã môn học lên combobox Môn học
        private void LoadMonHoc_ComboBox()
        {
            cboMonHoc.Items.Clear();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT MaMH FROM MonHoc";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            cboMonHoc.Items.Add(rd["MaMH"].ToString());
                        }
                    }
                    if (cboMonHoc.Items.Count > 0) cboMonHoc.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải môn học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 3. Kiểm tra khóa chính bảng Điểm: cặp (MaSV, MaMH)
        // Trả về true nếu chưa có (thêm được), false nếu đã có
        public bool KT_KhoaChinh(string maSV, string maMH)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT 1 FROM Diem WHERE MaSV = @MaSV AND MaMH = @MaMH";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSV", maSV);
                        cmd.Parameters.AddWithValue("@MaMH", maMH);
                        using (SqlDataReader rd = cmd.ExecuteReader())
                        {
                            if (rd.HasRows) return false; // Đã tồn tại
                        }
                    }
                    return true; // Chưa tồn tại
                }
                catch
                {
                    return false;
                }
            }
        }

        // Kiểm tra khóa ngoại: Mã SV tồn tại trong SinhVien
        private bool KT_TonTaiSinhVien(string maSV)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT 1 FROM SinhVien WHERE MaSinhVien = @MaSV";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSV", maSV);
                        using (SqlDataReader rd = cmd.ExecuteReader())
                        {
                            return rd.HasRows;
                        }
                    }
                }
                catch { return false; }
            }
        }

        // Kiểm tra khóa ngoại: Mã MH tồn tại trong MonHoc
        private bool KT_TonTaiMonHoc(string maMH)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT 1 FROM MonHoc WHERE MaMH = @MaMH";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaMH", maMH);
                        using (SqlDataReader rd = cmd.ExecuteReader())
                        {
                            return rd.HasRows;
                        }
                    }
                }
                catch { return false; }
            }
        }

        // 4. THÊM ĐIỂM
        private void BtnThem_Click(object sender, EventArgs e)
        {
            string maSV = cboSinhVien.SelectedItem?.ToString();
            string maMH = cboMonHoc.SelectedItem?.ToString();
            string diemText = txtDiem.Text.Trim();

            if (string.IsNullOrEmpty(maSV))
            {
                MessageBox.Show("Vui lòng chọn Mã sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboSinhVien.Focus();
                return;
            }
            if (string.IsNullOrEmpty(maMH))
            {
                MessageBox.Show("Vui lòng chọn Mã môn học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMonHoc.Focus();
                return;
            }
            if (string.IsNullOrEmpty(diemText))
            {
                MessageBox.Show("Vui lòng nhập Điểm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiem.Focus();
                return;
            }

            if (!double.TryParse(diemText.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double diem) || diem < 0 || diem > 10)
            {
                MessageBox.Show("Điểm phải là số và nằm trong khoảng từ 0 đến 10!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiem.Focus();
                return;
            }

            // Kiểm tra khóa ngoại
            if (!KT_TonTaiSinhVien(maSV))
            {
                MessageBox.Show("Mã sinh viên không tồn tại trong cơ sở dữ liệu!", "Lỗi khóa ngoại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!KT_TonTaiMonHoc(maMH))
            {
                MessageBox.Show("Mã môn học không tồn tại trong cơ sở dữ liệu!", "Lỗi khóa ngoại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra trùng khóa chính (MaSV, MaMH)
            if (!KT_KhoaChinh(maSV, maMH))
            {
                MessageBox.Show($"Sinh viên '{maSV}' đã có điểm cho môn học '{maMH}' rồi! (Trùng khóa chính)", "Lỗi trùng khóa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Diem (MaSV, MaMH, Diem) VALUES (@MaSV, @MaMH, @Diem)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSV", maSV);
                        cmd.Parameters.AddWithValue("@MaMH", maMH);
                        cmd.Parameters.AddWithValue("@Diem", diem);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Thêm điểm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtDiem.Clear();
                            txtDiem.Focus();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 5. XÓA ĐIỂM
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            string maSV = cboSinhVien.SelectedItem?.ToString();
            string maMH = cboMonHoc.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(maSV) || string.IsNullOrEmpty(maMH))
            {
                MessageBox.Show("Vui lòng chọn Sinh viên và Môn học cần xóa điểm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra khóa chính: điểm có tồn tại để xóa không?
            if (KT_KhoaChinh(maSV, maMH))
            {
                MessageBox.Show($"Không tìm thấy bản ghi điểm của sinh viên '{maSV}' môn '{maMH}' để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn xóa điểm môn '{maMH}' của sinh viên '{maSV}'?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM Diem WHERE MaSV = @MaSV AND MaMH = @MaMH";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSV", maSV);
                        cmd.Parameters.AddWithValue("@MaMH", maMH);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Xóa điểm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtDiem.Clear();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 6. SỬA ĐIỂM
        private void BtnSua_Click(object sender, EventArgs e)
        {
            string maSV = cboSinhVien.SelectedItem?.ToString();
            string maMH = cboMonHoc.SelectedItem?.ToString();
            string diemText = txtDiem.Text.Trim();

            if (string.IsNullOrEmpty(maSV) || string.IsNullOrEmpty(maMH))
            {
                MessageBox.Show("Vui lòng chọn Sinh viên và Môn học cần cập nhật điểm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra điểm có tồn tại không
            if (KT_KhoaChinh(maSV, maMH))
            {
                MessageBox.Show($"Không tìm thấy bản ghi điểm của sinh viên '{maSV}' môn '{maMH}' để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(diemText))
            {
                MessageBox.Show("Vui lòng nhập điểm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiem.Focus();
                return;
            }

            if (!double.TryParse(diemText.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double diem) || diem < 0 || diem > 10)
            {
                MessageBox.Show("Điểm phải là số và nằm trong khoảng từ 0 đến 10!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiem.Focus();
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE Diem SET Diem = @Diem WHERE MaSV = @MaSV AND MaMH = @MaMH";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Diem", diem);
                        cmd.Parameters.AddWithValue("@MaSV", maSV);
                        cmd.Parameters.AddWithValue("@MaMH", maMH);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Cập nhật điểm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}