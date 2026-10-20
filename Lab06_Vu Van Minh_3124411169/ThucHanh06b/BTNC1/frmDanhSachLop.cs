#nullable disable
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace ThucHanh06b_BTNC1
{
    public class frmDanhSachLop : Form
    {
        private string connectionString = @"Data Source=.;Initial Catalog=QLSinhVien;Integrated Security=True;TrustServerCertificate=True";

        private Button btnHienThi, btnThoat;
        private ListView lvwLop;

        public frmDanhSachLop()
        {
            InitializeCustomComponent();
        }

        private void InitializeCustomComponent()
        {
            this.Text = "Danh sách Lớp";
            this.Size = new Size(620, 420);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            btnHienThi = new Button
            {
                Text = "Hiển thị dữ liệu",
                Location = new Point(25, 20),
                Size = new Size(130, 32)
            };
            btnHienThi.Click += BtnHienThi_Click;

            lvwLop = new ListView
            {
                Location = new Point(25, 65),
                Size = new Size(555, 250),
                View = View.Details,
                FullRowSelect = true,
                GridLines = true
            };
            lvwLop.Columns.Add("STT", 60, HorizontalAlignment.Center);
            lvwLop.Columns.Add("Mã lớp", 110, HorizontalAlignment.Left);
            lvwLop.Columns.Add("Tên lớp", 260, HorizontalAlignment.Left);
            lvwLop.Columns.Add("Mã khoa", 100, HorizontalAlignment.Center);

            btnThoat = new Button
            {
                Text = "Thoát",
                Location = new Point(480, 330),
                Size = new Size(100, 32)
            };
            btnThoat.Click += (s, e) => this.Close();

            this.Controls.Add(btnHienThi);
            this.Controls.Add(lvwLop);
            this.Controls.Add(btnThoat);
        }

        private void BtnHienThi_Click(object sender, EventArgs e)
        {
            lvwLop.Items.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT MaLop, TenLop, MaKhoa FROM Lop ORDER BY MaLop";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        int stt = 1;
                        while (rd.Read())
                        {
                            ListViewItem item = new ListViewItem(stt.ToString());
                            item.SubItems.Add(rd["MaLop"].ToString());
                            item.SubItems.Add(rd["TenLop"].ToString());
                            item.SubItems.Add(rd["MaKhoa"].ToString());

                            lvwLop.Items.Add(item);
                            stt++;
                        }
                    }

                    if (lvwLop.Items.Count == 0)
                    {
                        MessageBox.Show("Bảng Lớp hiện chưa có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi hiển thị dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}