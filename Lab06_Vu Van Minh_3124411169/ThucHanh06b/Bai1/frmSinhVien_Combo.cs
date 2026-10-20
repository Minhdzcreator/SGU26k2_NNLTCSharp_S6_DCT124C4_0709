#nullable disable
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace ThucHanh06b_Bai1
{
    public class frmSinhVien_Combo : Form
    {
        private string connectionString = @"Data Source=.;Initial Catalog=QLSinhVien;Integrated Security=True;TrustServerCertificate=True";

        private Label lblLop, lblMaSV, lblHoTen, lblNgaySinh;
        private ComboBox cboLop;
        private TextBox txtMaSV, txtHoTen;
        private MaskedTextBox txtNgaySinh;
        private Button btnThem, btnXoa, btnSua;

        public frmSinhVien_Combo()
        {
            InitializeCustomComponent();
        }

        private void InitializeCustomComponent()
        {
            this.Text = "frmSinhVien_Combo";
            this.Size = new Size(380, 260);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            lblLop = new Label { Text = "Lớp", Location = new Point(30, 25), AutoSize = true };
            cboLop = new ComboBox { Location = new Point(110, 22), Size = new Size(220, 25), DropDownStyle = ComboBoxStyle.DropDownList };

            lblMaSV = new Label { Text = "Mã sv", Location = new Point(30, 60), AutoSize = true };
            txtMaSV = new TextBox { Location = new Point(110, 57), Size = new Size(220, 25) };

            lblHoTen = new Label { Text = "Họ tên", Location = new Point(30, 95), AutoSize = true };
            txtHoTen = new TextBox { Location = new Point(110, 92), Size = new Size(220, 25) };

            lblNgaySinh = new Label { Text = "Ngày sinh", Location = new Point(30, 130), AutoSize = true };
            txtNgaySinh = new MaskedTextBox
            {
                Mask = "00/00/0000",
                Location = new Point(110, 127),
                Size = new Size(220, 25)
            };

            btnThem = new Button { Text = "Thêm", Location = new Point(30, 175), Size = new Size(90, 32) };
            btnThem.Click += BtnThem_Click;

            btnXoa = new Button { Text = "Xóa", Location = new Point(135, 175), Size = new Size(90, 32) };
            btnXoa.Click += BtnXoa_Click;

            btnSua = new Button { Text = "Sửa", Location = new Point(240, 175), Size = new Size(90, 32) };
            btnSua.Click += BtnSua_Click;

            this.Controls.Add(lblLop);
            this.Controls.Add(cboLop);
            this.Controls.Add(lblMaSV);
            this.Controls.Add(txtMaSV);
            this.Controls.Add(lblHoTen);
            this.Controls.Add(txtHoTen);
            this.Controls.Add(lblNgaySinh);
            this.Controls.Add(txtNgaySinh);
            this.Controls.Add(btnThem);
            this.Controls.Add(btnXoa);
            this.Controls.Add(btnSua);

            this.Load += FrmSinhVien_Combo_Load;
        }

        private void FrmSinhVien_Combo_Load(object sender, EventArgs e)
        {
            LoadLop_ComboBox();
        }

        // 1. Dùng SqlDataReader load mã lớp lên combobox Lớp
        private void LoadLop_ComboBox()
        {
            cboLop.Items.Clear();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT MaLop FROM Lop";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            cboLop.Items.Add(rd["MaLop"].ToString());
                        }
                    }
                    if (cboLop.Items.Count > 0)
                        cboLop.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải danh sách lớp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 2. Kiểm tra trùng khóa chính (Mã SV) bằng SqlDataReader
        public bool KT_KhoaChinh(string maSV)
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
                            if (rd.HasRows) return false; // Đã tồn tại -> không thêm được
                        }
                    }
                    return true; // Chưa tồn tại -> thêm được
                }
                catch
                {
                    return false;
                }
            }
        }

        // 3. Kiểm tra khóa ngoại: Sinh viên đã có dữ liệu trong bảng Điểm chưa
        private bool KT_KhoaNgoai(string maSV)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT 1 FROM Diem WHERE MaSV = @MaSV";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSV", maSV);
                        using (SqlDataReader rd = cmd.ExecuteReader())
                        {
                            return rd.HasRows; // true nếu đã có điểm
                        }
                    }
                }
                catch
                {
                    return false;
                }
            }
        }

        // 4. XỬ LÝ NÚT THÊM
        private void BtnThem_Click(object sender, EventArgs e)
        {
            string maLop = cboLop.SelectedItem?.ToString();
            string maSV = txtMaSV.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string ngaySinhText = txtNgaySinh.Text.Trim();

            // Ràng buộc không được để trống
            if (string.IsNullOrEmpty(maLop))
            {
                MessageBox.Show("Vui lòng chọn Mã lớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboLop.Focus();
                return;
            }
            if (string.IsNullOrEmpty(maSV))
            {
                MessageBox.Show("Vui lòng nhập Mã sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSV.Focus();
                return;
            }
            if (string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Vui lòng nhập Họ tên sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }
            if (!txtNgaySinh.MaskCompleted)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Ngày sinh theo định dạng dd/MM/yyyy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNgaySinh.Focus();
                return;
            }

            // Kiểm tra định dạng ngày sinh
            if (!DateTime.TryParseExact(ngaySinhText, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ngaySinh))
            {
                MessageBox.Show("Ngày sinh không hợp lệ!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNgaySinh.Focus();
                return;
            }

            // Kiểm tra sinh viên phải có tuổi từ 17 trở lên (tính theo năm sinh: DateTime.Now.Year - namSinh >= 17)
            int currentYear = DateTime.Now.Year;
            if (currentYear - ngaySinh.Year < 17)
            {
                MessageBox.Show($"Sinh viên phải có tuổi từ 17 trở lên! (Năm sinh {ngaySinh.Year} -> {currentYear - ngaySinh.Year} tuổi)", "Vi phạm ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNgaySinh.Focus();
                return;
            }

            // Kiểm tra trùng mã sinh viên (khóa chính)
            if (!KT_KhoaChinh(maSV))
            {
                MessageBox.Show("Trùng mã sinh viên! Mã sinh viên này đã tồn tại trong hệ thống.", "Lỗi trùng khóa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaSV.Focus();
                return;
            }

            // Thêm sinh viên vào CSDL
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO SinhVien (MaSinhVien, HoTen, NgaySinh, MaLop) VALUES (@MaSV, @HoTen, @NgaySinh, @MaLop)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSV", maSV);
                        cmd.Parameters.AddWithValue("@HoTen", hoTen);
                        cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                        cmd.Parameters.AddWithValue("@MaLop", maLop);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearInputs();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 5. XỬ LÝ NÚT XÓA (kiểm tra khóa chính và khóa ngoại)
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            string maSV = txtMaSV.Text.Trim();
            if (string.IsNullOrEmpty(maSV))
            {
                MessageBox.Show("Vui lòng nhập Mã sinh viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSV.Focus();
                return;
            }

            // Kiểm tra khóa chính: Sinh viên có tồn tại không?
            if (KT_KhoaChinh(maSV))
            {
                MessageBox.Show("Không tìm thấy mã sinh viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra khóa ngoại: Sinh viên đã có điểm môn học chưa?
            if (KT_KhoaNgoai(maSV))
            {
                MessageBox.Show("Không thể xóa sinh viên này vì đã có dữ liệu điểm thi trong bảng Điểm (ràng buộc khóa ngoại)!", "Lỗi ràng buộc khóa ngoại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn xóa sinh viên '{maSV}'?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM SinhVien WHERE MaSinhVien = @MaSV";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSV", maSV);
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearInputs();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 6. XỬ LÝ NÚT SỬA (kiểm tra khóa chính và cập nhật)
        private void BtnSua_Click(object sender, EventArgs e)
        {
            string maLop = cboLop.SelectedItem?.ToString();
            string maSV = txtMaSV.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string ngaySinhText = txtNgaySinh.Text.Trim();

            if (string.IsNullOrEmpty(maSV))
            {
                MessageBox.Show("Vui lòng nhập Mã sinh viên cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSV.Focus();
                return;
            }

            // Kiểm tra sinh viên có tồn tại không
            if (KT_KhoaChinh(maSV))
            {
                MessageBox.Show("Mã sinh viên không tồn tại trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Vui lòng nhập Họ tên mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            if (!txtNgaySinh.MaskCompleted || !DateTime.TryParseExact(ngaySinhText, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ngaySinh))
            {
                MessageBox.Show("Ngày sinh không hợp lệ!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNgaySinh.Focus();
                return;
            }

            int currentYear = DateTime.Now.Year;
            if (currentYear - ngaySinh.Year < 17)
            {
                MessageBox.Show($"Sinh viên phải có tuổi từ 17 trở lên! (Năm sinh {ngaySinh.Year})", "Vi phạm ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNgaySinh.Focus();
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE SinhVien SET HoTen = @HoTen, NgaySinh = @NgaySinh, MaLop = @MaLop WHERE MaSinhVien = @MaSV";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@HoTen", hoTen);
                        cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                        cmd.Parameters.AddWithValue("@MaLop", maLop);
                        cmd.Parameters.AddWithValue("@MaSV", maSV);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Cập nhật thông tin sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearInputs();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearInputs()
        {
            txtMaSV.Clear();
            txtHoTen.Clear();
            txtNgaySinh.Clear();
            if (cboLop.Items.Count > 0) cboLop.SelectedIndex = 0;
            txtMaSV.Focus();
        }
    }
}