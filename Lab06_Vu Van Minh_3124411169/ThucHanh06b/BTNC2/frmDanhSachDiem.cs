#nullable disable
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace ThucHanh06b_BTNC2
{
    public class frmDanhSachDiem : Form
    {
        private string connectionString = @"Data Source=.;Initial Catalog=QLSinhVien;Integrated Security=True;TrustServerCertificate=True";

        private Label lblMonHoc, lblTongDiem;
        private ComboBox cboMonHoc;
        private Button btnLoc;
        private ListView lvwDiem;
        private TextBox txtTongDiem;

        public frmDanhSachDiem()
        {
            InitializeCustomComponent();
        }

        private void InitializeCustomComponent()
        {
            this.Text = "Danh sách sinh viên";
            this.Size = new Size(680, 480);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            lblMonHoc = new Label { Text = "Môn học", Location = new Point(30, 25), AutoSize = true };
            cboMonHoc = new ComboBox
            {
                Location = new Point(100, 22),
                Size = new Size(200, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            btnLoc = new Button
            {
                Text = "Lọc dữ liệu",
                Location = new Point(320, 20),
                Size = new Size(110, 28)
            };
            btnLoc.Click += BtnLoc_Click;

            lvwDiem = new ListView
            {
                Location = new Point(30, 65),
                Size = new Size(605, 310),
                View = View.Details,
                FullRowSelect = true,
                GridLines = true
            };
            lvwDiem.Columns.Add("STT", 50, HorizontalAlignment.Center);
            lvwDiem.Columns.Add("Tên SV", 160, HorizontalAlignment.Left);
            lvwDiem.Columns.Add("Ngày sinh", 140, HorizontalAlignment.Center);
            lvwDiem.Columns.Add("Tên môn học", 160, HorizontalAlignment.Left);
            lvwDiem.Columns.Add("Điểm", 70, HorizontalAlignment.Center);

            lblTongDiem = new Label { Text = "Tổng điểm", Location = new Point(400, 395), AutoSize = true };
            txtTongDiem = new TextBox
            {
                Location = new Point(480, 392),
                Size = new Size(80, 25),
                ReadOnly = true,
                TextAlign = HorizontalAlignment.Center,
                Font = new Font(this.Font, FontStyle.Bold)
            };

            this.Controls.Add(lblMonHoc);
            this.Controls.Add(cboMonHoc);
            this.Controls.Add(btnLoc);
            this.Controls.Add(lvwDiem);
            this.Controls.Add(lblTongDiem);
            this.Controls.Add(txtTongDiem);

            this.Load += FrmDanhSachDiem_Load;
        }

        private void FrmDanhSachDiem_Load(object sender, EventArgs e)
        {
            LoadMonHoc_ComboBox();
            LoadData(string.Empty);
        }

        // 1. Hiển thị mã môn học trong bảng MonHoc lên combobox Môn học, thêm 1 item khoảng trắng
        private void LoadMonHoc_ComboBox()
        {
            cboMonHoc.Items.Clear();
            cboMonHoc.Items.Add(" "); // Khoảng trắng biểu thị cho tất cả môn học

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT MaMH FROM MonHoc ORDER BY MaMH";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            cboMonHoc.Items.Add(rd["MaMH"].ToString());
                        }
                    }
                    cboMonHoc.SelectedIndex = 0; // Mặc định chọn khoảng trắng (tất cả)
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải danh sách môn học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 2. Load dữ liệu lên ListView và tính Tổng điểm
        private void LoadData(string maMH)
        {
            lvwDiem.Items.Clear();
            double tongDiem = 0.0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    if (string.IsNullOrWhiteSpace(maMH))
                    {
                        // Hiển thị tất cả
                        query = @"SELECT sv.HoTen, sv.NgaySinh, mh.TenMH, d.Diem 
                                  FROM Diem d 
                                  JOIN SinhVien sv ON d.MaSV = sv.MaSinhVien 
                                  JOIN MonHoc mh ON d.MaMH = mh.MaMH
                                  ORDER BY sv.HoTen, mh.TenMH";
                    }
                    else
                    {
                        // Lọc theo mã môn học cụ thể
                        query = @"SELECT sv.HoTen, sv.NgaySinh, mh.TenMH, d.Diem 
                                  FROM Diem d 
                                  JOIN SinhVien sv ON d.MaSV = sv.MaSinhVien 
                                  JOIN MonHoc mh ON d.MaMH = mh.MaMH
                                  WHERE d.MaMH = @MaMH
                                  ORDER BY sv.HoTen";
                        cmd.Parameters.AddWithValue("@MaMH", maMH);
                    }

                    cmd.CommandText = query;

                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        int stt = 1;
                        while (rd.Read())
                        {
                            ListViewItem item = new ListViewItem(stt.ToString());

                            // Tên SV
                            item.SubItems.Add(rd["HoTen"].ToString());

                            // Ngày sinh định dạng dd/MM/yyyy HH:mm:ss hoặc dd/MM/yyyy
                            string ngaySinhStr = string.Empty;
                            if (rd["NgaySinh"] != DBNull.Value)
                            {
                                DateTime dt = Convert.ToDateTime(rd["NgaySinh"]);
                                ngaySinhStr = dt.ToString("M/d/yyyy 12:00:00 AM", CultureInfo.InvariantCulture);
                            }
                            item.SubItems.Add(ngaySinhStr);

                            // Tên môn học
                            item.SubItems.Add(rd["TenMH"].ToString());

                            // Điểm
                            double diem = 0;
                            if (rd["Diem"] != DBNull.Value)
                            {
                                diem = Convert.ToDouble(rd["Diem"]);
                            }
                            item.SubItems.Add(diem.ToString());
                            tongDiem += diem;

                            lvwDiem.Items.Add(item);
                            stt++;
                        }
                    }

                    // Gán tổng điểm vào txtTongDiem
                    txtTongDiem.Text = tongDiem.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải dữ liệu điểm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 3. Sự kiện bấm nút Lọc dữ liệu
        private void BtnLoc_Click(object sender, EventArgs e)
        {
            string selectedMH = cboMonHoc.SelectedItem?.ToString() ?? string.Empty;
            // Nếu chọn khoảng trắng hoặc chuỗi rỗng -> hiển thị tất cả, ngược lại lọc theo mã môn học
            LoadData(selectedMH.Trim());
        }
    }
}