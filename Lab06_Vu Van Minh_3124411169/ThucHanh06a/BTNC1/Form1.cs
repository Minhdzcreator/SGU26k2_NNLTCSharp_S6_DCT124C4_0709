#nullable disable
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace QuanLySinhVienDbApp
{
    public partial class Form1 : Form
    {
        // Chuỗi kết nối đến CSDL QLSinhVien
        private string connectionString = @"Data Source=.;Initial Catalog=QLSinhVien;Integrated Security=True;TrustServerCertificate=True";

        private Label lblMaLop, lblMaSV, lblTenSV, lblNgaySinh;
        private TextBox txtMaLop, txtMaSV, txtTenSV;
        private MaskedTextBox txtNgaySinh;
        private Button btnThem, btnXoa, btnSua;

        public Form1()
        {
            InitializeCustomComponent();
        }

        private void InitializeCustomComponent()
        {
            this.Text = "Quản lý sinh viên";
            this.Size = new Size(380, 280);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            int labelX = 25;
            int textX = 110;
            int textWidth = 220;
            int startY = 25;
            int rowGap = 35;

            // 1. Mã lớp
            lblMaLop = new Label { Text = "Mã lớp", Location = new Point(labelX, startY), AutoSize = true };
            txtMaLop = new TextBox { Location = new Point(textX, startY - 3), Size = new Size(textWidth, 23) };

            // 2. Mã sv (chuẩn hóa nhãn đúng form mẫu PDF)
            startY += rowGap;
            lblMaSV = new Label { Text = "Mã sv", Location = new Point(labelX, startY), AutoSize = true };
            txtMaSV = new TextBox { Location = new Point(textX, startY - 3), Size = new Size(textWidth, 23) };

            // 3. Họ tên (chuẩn hóa nhãn đúng form mẫu PDF)
            startY += rowGap;
            lblTenSV = new Label { Text = "Họ tên", Location = new Point(labelX, startY), AutoSize = true };
            txtTenSV = new TextBox { Location = new Point(textX, startY - 3), Size = new Size(textWidth, 23) };

            // 4. Ngày sinh (Sử dụng MaskedTextBox __/__/____ chuẩn form mẫu PDF)
            startY += rowGap;
            lblNgaySinh = new Label { Text = "Ngày sinh", Location = new Point(labelX, startY), AutoSize = true };
            txtNgaySinh = new MaskedTextBox
            {
                Location = new Point(textX, startY - 3),
                Size = new Size(textWidth, 23),
                Mask = "00/00/0000",
                ValidatingType = typeof(DateTime)
            };

            // 5. Các nút chức năng
            startY += 45;
            btnThem = new Button { Text = "Thêm", Location = new Point(35, startY), Size = new Size(85, 32) };
            btnThem.Click += BtnThem_Click;

            btnXoa = new Button { Text = "Xóa", Location = new Point(140, startY), Size = new Size(85, 32) };
            btnXoa.Click += BtnXoa_Click;

            btnSua = new Button { Text = "Sửa", Location = new Point(245, startY), Size = new Size(85, 32) };
            btnSua.Click += BtnSua_Click;

            this.Controls.Add(lblMaLop); this.Controls.Add(txtMaLop);
            this.Controls.Add(lblMaSV); this.Controls.Add(txtMaSV);
            this.Controls.Add(lblTenSV); this.Controls.Add(txtTenSV);
            this.Controls.Add(lblNgaySinh); this.Controls.Add(txtNgaySinh);
            this.Controls.Add(btnThem);
            this.Controls.Add(btnXoa);
            this.Controls.Add(btnSua);
        }

        private bool HasNgaySinhInput()
        {
            string raw = txtNgaySinh.Text.Replace("/", "").Replace("_", "").Trim();
            return !string.IsNullOrWhiteSpace(raw);
        }

        // --- 1. CHỨC NĂNG THÊM DỮ LIỆU ---
        // Yêu cầu: Nhập Mã lớp, Mã sinh viên, Họ tên, Ngày sinh. Không được để trống ô nào.
        private void BtnThem_Click(object sender, EventArgs e)
        {
            string maLop = txtMaLop.Text.Trim();
            string maSV = txtMaSV.Text.Trim();
            string tenSV = txtTenSV.Text.Trim();

            if (string.IsNullOrWhiteSpace(maLop) || string.IsNullOrWhiteSpace(maSV) || 
                string.IsNullOrWhiteSpace(tenSV) || !HasNgaySinhInput())
            {
                MessageBox.Show("Mã lớp, Mã sv, Họ tên và Ngày sinh không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra định dạng ngày sinh hợp lệ (dd/MM/yyyy)
            if (!txtNgaySinh.MaskCompleted || 
                !DateTime.TryParseExact(txtNgaySinh.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ngaySinh))
            {
                MessageBox.Show("Ngày sinh không đúng định dạng hợp lệ (dd/MM/yyyy)!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNgaySinh.Focus();
                return;
            }

            string query = "INSERT INTO SinhVien (MaSinhVien, HoTen, NgaySinh, MaLop) VALUES (@MaSV, @TenSV, @NgaySinh, @MaLop)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSV", maSV);
                        cmd.Parameters.AddWithValue("@TenSV", tenSV);
                        cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                        cmd.Parameters.AddWithValue("@MaLop", maLop);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearInputs();
                        }
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627 || ex.Number == 2601)
                    {
                        MessageBox.Show("Mã sinh viên này đã tồn tại trong CSDL!", "Lỗi trùng khóa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (ex.Number == 547)
                    {
                        MessageBox.Show("Mã lớp không tồn tại trong CSDL!", "Lỗi ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // --- 2. CHỨC NĂNG XÓA DỮ LIỆU ---
        // Yêu cầu: Nhập Mã sinh viên, Họ tên không được để trống. Mã lớp, Ngày sinh không nhập dữ liệu.
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            string maSV = txtMaSV.Text.Trim();
            string tenSV = txtTenSV.Text.Trim();
            string maLop = txtMaLop.Text.Trim();

            if (string.IsNullOrWhiteSpace(maSV) || string.IsNullOrWhiteSpace(tenSV))
            {
                MessageBox.Show("Mã sinh viên và Họ tên không được để trống khi xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrWhiteSpace(maLop) || HasNgaySinhInput())
            {
                MessageBox.Show("Theo yêu cầu: Mã lớp và Ngày sinh không được nhập dữ liệu khi thực hiện Xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaLop.Clear();
                txtNgaySinh.Clear();
                return;
            }

            DialogResult dr = MessageBox.Show($"Bạn có chắc muốn xóa sinh viên '{tenSV}' (Mã: {maSV})?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No) return;

            string query = "DELETE FROM SinhVien WHERE MaSinhVien = @MaSV AND HoTen = @TenSV";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSV", maSV);
                        cmd.Parameters.AddWithValue("@TenSV", tenSV);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearInputs();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy sinh viên có Mã và Tên khớp với thông tin vừa nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- 3. CHỨC NĂNG SỬA DỮ LIỆU ---
        // Yêu cầu: Mã sinh viên không để trống. Mã lớp, Họ tên, Ngày sinh phải có ít nhất một trường có dữ liệu.
        // Trường nào không nhập liệu thì không thay đổi.
        private void BtnSua_Click(object sender, EventArgs e)
        {
            string maSV = txtMaSV.Text.Trim();
            string maLop = txtMaLop.Text.Trim();
            string tenSV = txtTenSV.Text.Trim();

            if (string.IsNullOrWhiteSpace(maSV))
            {
                MessageBox.Show("Mã sinh viên không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSV.Focus();
                return;
            }

            bool hasNgaySinh = HasNgaySinhInput();
            if (string.IsNullOrWhiteSpace(maLop) && string.IsNullOrWhiteSpace(tenSV) && !hasNgaySinh)
            {
                MessageBox.Show("Mã lớp, Họ tên, Ngày sinh phải có ít nhất một trường có dữ liệu để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime parsedNgaySinh = DateTime.MinValue;
            if (hasNgaySinh)
            {
                if (!txtNgaySinh.MaskCompleted || 
                    !DateTime.TryParseExact(txtNgaySinh.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedNgaySinh))
                {
                    MessageBox.Show("Ngày sinh không đúng định dạng hợp lệ (dd/MM/yyyy)!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNgaySinh.Focus();
                    return;
                }
            }

            List<string> updateFields = new List<string>();
            if (!string.IsNullOrWhiteSpace(maLop)) updateFields.Add("MaLop = @MaLop");
            if (!string.IsNullOrWhiteSpace(tenSV)) updateFields.Add("HoTen = @TenSV");
            if (hasNgaySinh) updateFields.Add("NgaySinh = @NgaySinh");

            string query = $"UPDATE SinhVien SET {string.Join(", ", updateFields)} WHERE MaSinhVien = @MaSV";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSV", maSV);
                        if (!string.IsNullOrWhiteSpace(maLop)) cmd.Parameters.AddWithValue("@MaLop", maLop);
                        if (!string.IsNullOrWhiteSpace(tenSV)) cmd.Parameters.AddWithValue("@TenSV", tenSV);
                        if (hasNgaySinh) cmd.Parameters.AddWithValue("@NgaySinh", parsedNgaySinh);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cập nhật thông tin sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearInputs();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy mã sinh viên để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547)
                    {
                        MessageBox.Show("Mã lớp không tồn tại trong CSDL!", "Lỗi ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi cập nhật CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txtMaLop.Clear();
            txtMaSV.Clear();
            txtTenSV.Clear();
            txtNgaySinh.Clear();
            txtMaLop.Focus();
        }
    }
}
