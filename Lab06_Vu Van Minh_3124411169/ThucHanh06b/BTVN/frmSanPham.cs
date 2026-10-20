#nullable disable
using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace ThucHanh06b_BTVN
{
    public class frmSanPham : Form
    {
        private string connectionString = @"Data Source=.;Initial Catalog=QLCuaHang;Integrated Security=True;TrustServerCertificate=True";

        private Label lblTenSP;
        private TextBox txtTenSP;
        private Button btnThem, btnThoat;

        public frmSanPham()
        {
            InitializeCustomComponent();
        }

        private void InitializeCustomComponent()
        {
            this.Text = "Thêm sản phẩm mới";
            this.Size = new Size(380, 180);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            lblTenSP = new Label { Text = "Tên sản phẩm", Location = new Point(30, 35), AutoSize = true };
            txtTenSP = new TextBox { Location = new Point(125, 32), Size = new Size(200, 25) };

            btnThem = new Button { Text = "Thêm", Location = new Point(80, 85), Size = new Size(85, 32) };
            btnThem.Click += BtnThem_Click;

            btnThoat = new Button { Text = "Thoát", Location = new Point(190, 85), Size = new Size(85, 32) };
            btnThoat.Click += (s, e) => this.Close();

            this.Controls.Add(lblTenSP);
            this.Controls.Add(txtTenSP);
            this.Controls.Add(btnThem);
            this.Controls.Add(btnThoat);
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            string tenSP = txtTenSP.Text.Trim();
            if (string.IsNullOrEmpty(tenSP))
            {
                MessageBox.Show("Vui lòng nhập Tên sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSP.Focus();
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // 1. Thêm dòng mới vào bảng SANPHAM (MaSP tự động tăng)
                    string querySP = "INSERT INTO SANPHAM (TenSP) VALUES (@TenSP); SELECT SCOPE_IDENTITY();";
                    int newMaSP;
                    using (SqlCommand cmdSP = new SqlCommand(querySP, conn))
                    {
                        cmdSP.Parameters.AddWithValue("@TenSP", tenSP);
                        newMaSP = Convert.ToInt32(cmdSP.ExecuteScalar());
                    }

                    // 2. Thêm 1 dòng tin mới vào bảng Tồn kho với SLDau = 0, SLNhap = 0, SLBan = 0 theo ngày hiện tại
                    string queryTK = @"IF NOT EXISTS (SELECT 1 FROM TONKHO WHERE MaSP = @MaSP AND NgayTon = CAST(GETDATE() AS DATE))
                                       BEGIN
                                           INSERT INTO TONKHO (MaSP, NgayTon, SLDau, SLNhap, SLBan)
                                           VALUES (@MaSP, CAST(GETDATE() AS DATE), 0, 0, 0)
                                       END";
                    using (SqlCommand cmdTK = new SqlCommand(queryTK, conn))
                    {
                        cmdTK.Parameters.AddWithValue("@MaSP", newMaSP);
                        cmdTK.ExecuteNonQuery();
                    }

                    MessageBox.Show($"Thêm sản phẩm thành công!\nMã SP: {newMaSP}\nTên SP: {tenSP}\nĐã khởi tạo bản ghi tồn kho ban đầu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTenSP.Clear();
                    txtTenSP.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thêm sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}