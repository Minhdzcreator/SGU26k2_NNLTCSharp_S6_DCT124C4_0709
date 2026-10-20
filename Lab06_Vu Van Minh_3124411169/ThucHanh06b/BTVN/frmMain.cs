#nullable disable
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace ThucHanh06b_BTVN
{
    public class frmMain : Form
    {
        private string connectionString = @"Data Source=.;Initial Catalog=QLCuaHang;Integrated Security=True;TrustServerCertificate=True";

        private MenuStrip menuStrip;
        private ToolStripMenuItem menuTonKho, menuSanPham, menuBanHang, menuThoat;
        private ToolStripMenuItem itemTaoTonKho, itemXemTonKho, itemThemSP, itemBanHang;

        private Label lblTitle, lblSubTitle;
        private Button btnTaoTonKhoQuick, btnThemSPQuick, btnBanHangQuick, btnXemTonKhoQuick;
        private DataGridView dgvTonKho;

        public frmMain()
        {
            InitializeCustomComponent();
        }

        private void InitializeCustomComponent()
        {
            this.Text = "Hệ Thống Quản Lý Cửa Hàng - Lab 06 BTVN";
            this.Size = new Size(800, 560);
            this.StartPosition = FormStartPosition.CenterScreen;

            // MenuStrip
            menuStrip = new MenuStrip();

            menuTonKho = new ToolStripMenuItem("Tồn kho");
            itemTaoTonKho = new ToolStripMenuItem("Tạo tồn kho (1 lần mỗi ngày)", null, (s, e) => TaoTonKhoHomNay());
            itemXemTonKho = new ToolStripMenuItem("Xem bảng tồn kho", null, (s, e) => LoadTonKhoGrid());
            menuTonKho.DropDownItems.Add(itemTaoTonKho);
            menuTonKho.DropDownItems.Add(itemXemTonKho);

            menuSanPham = new ToolStripMenuItem("Sản phẩm");
            itemThemSP = new ToolStripMenuItem("Thêm sản phẩm mới", null, (s, e) => OpenFormSanPham());
            menuSanPham.DropDownItems.Add(itemThemSP);

            menuBanHang = new ToolStripMenuItem("Bán hàng");
            itemBanHang = new ToolStripMenuItem("Màn hình bán hàng", null, (s, e) => OpenFormBanHang());
            menuBanHang.DropDownItems.Add(itemBanHang);

            menuThoat = new ToolStripMenuItem("Thoát", null, (s, e) => Application.Exit());

            menuStrip.Items.Add(menuTonKho);
            menuStrip.Items.Add(menuSanPham);
            menuStrip.Items.Add(menuBanHang);
            menuStrip.Items.Add(menuThoat);
            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);

            // Controls trang trí giao diện Dashboard
            lblTitle = new Label
            {
                Text = "QUẢN LÝ CỬA HÀNG - VŨ VĂN MINH (3124411169)",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.DarkSlateBlue,
                Location = new Point(30, 45),
                AutoSize = true
            };

            lblSubTitle = new Label
            {
                Text = "Chọn chức năng trên thanh Menu hoặc nhấn các nút thao tác nhanh bên dưới:",
                Font = new Font("Segoe UI", 10),
                Location = new Point(32, 80),
                AutoSize = true
            };

            btnTaoTonKhoQuick = new Button
            {
                Text = "1. Tạo Tồn Kho Hôm Nay",
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                Location = new Point(35, 115),
                Size = new Size(170, 45),
                BackColor = Color.LightSkyBlue
            };
            btnTaoTonKhoQuick.Click += (s, e) => TaoTonKhoHomNay();

            btnThemSPQuick = new Button
            {
                Text = "2. Thêm Sản Phẩm Mới",
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                Location = new Point(220, 115),
                Size = new Size(170, 45),
                BackColor = Color.LightGreen
            };
            btnThemSPQuick.Click += (s, e) => OpenFormSanPham();

            btnBanHangQuick = new Button
            {
                Text = "3. Bán Hàng (Hóa Đơn)",
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                Location = new Point(405, 115),
                Size = new Size(170, 45),
                BackColor = Color.Orange
            };
            btnBanHangQuick.Click += (s, e) => OpenFormBanHang();

            btnXemTonKhoQuick = new Button
            {
                Text = "Tải Lại Bảng Tồn Kho",
                Font = new Font("Segoe UI", 9.5f),
                Location = new Point(590, 115),
                Size = new Size(160, 45)
            };
            btnXemTonKhoQuick.Click += (s, e) => LoadTonKhoGrid();

            // Bảng dữ liệu tồn kho hiển thị trực tiếp
            dgvTonKho = new DataGridView
            {
                Location = new Point(35, 180),
                Size = new Size(715, 310),
                ReadOnly = true,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BackgroundColor = Color.White
            };

            this.Controls.Add(lblTitle);
            this.Controls.Add(lblSubTitle);
            this.Controls.Add(btnTaoTonKhoQuick);
            this.Controls.Add(btnThemSPQuick);
            this.Controls.Add(btnBanHangQuick);
            this.Controls.Add(btnXemTonKhoQuick);
            this.Controls.Add(dgvTonKho);

            this.Load += (s, e) => LoadTonKhoGrid();
        }

        private void OpenFormSanPham()
        {
            frmSanPham frm = new frmSanPham();
            frm.FormClosed += (s, e) => LoadTonKhoGrid();
            frm.ShowDialog();
        }

        private void OpenFormBanHang()
        {
            frmBanHang frm = new frmBanHang();
            frm.FormClosed += (s, e) => LoadTonKhoGrid();
            frm.ShowDialog();
        }

        // CHỨC NĂNG TỒN KHO:
        // Tạo dữ liệu cho bảng tồn kho cho tất cả sản phẩm theo ngày hiện tại:
        // SLTon = SLTon (ngày trước) + Tổng SL nhập (ngày trước) - Tổng SL xuất (ngày trước)
        // Tổng số lượng nhập = 0
        // Tổng số lượng xuất = 0
        private void TaoTonKhoHomNay()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // 1. Lấy danh sách tất cả sản phẩm
                    DataTable dtSP = new DataTable();
                    using (SqlCommand cmdSP = new SqlCommand("SELECT MaSP, TenSP FROM SANPHAM", conn))
                    using (SqlDataAdapter da = new SqlDataAdapter(cmdSP))
                    {
                        da.Fill(dtSP);
                    }

                    int countCreated = 0;
                    int countExisted = 0;

                    foreach (DataRow row in dtSP.Rows)
                    {
                        int maSP = Convert.ToInt32(row["MaSP"]);

                        // Kiểm tra sản phẩm đã có bản ghi tồn kho cho ngày hôm nay chưa
                        string checkQuery = "SELECT 1 FROM TONKHO WHERE MaSP = @MaSP AND NgayTon = CAST(GETDATE() AS DATE)";
                        bool existed = false;
                        using (SqlCommand cmdCheck = new SqlCommand(checkQuery, conn))
                        {
                            cmdCheck.Parameters.AddWithValue("@MaSP", maSP);
                            using (SqlDataReader rd = cmdCheck.ExecuteReader())
                            {
                                existed = rd.HasRows;
                            }
                        }

                        if (existed)
                        {
                            countExisted++;
                            continue;
                        }

                        // Lấy tồn kho của ngày gần nhất trước ngày hôm nay
                        string queryTruoc = @"
                            SELECT TOP 1 (SLDau + SLNhap - SLBan) AS SLTon
                            FROM TONKHO
                            WHERE MaSP = @MaSP AND NgayTon < CAST(GETDATE() AS DATE)
                            ORDER BY NgayTon DESC";
                        int slTonNgayTruoc = 0;
                        using (SqlCommand cmdTruoc = new SqlCommand(queryTruoc, conn))
                        {
                            cmdTruoc.Parameters.AddWithValue("@MaSP", maSP);
                            object res = cmdTruoc.ExecuteScalar();
                            if (res != null && res != DBNull.Value)
                            {
                                slTonNgayTruoc = Convert.ToInt32(res);
                            }
                        }

                        // Tạo dòng tồn kho ngày hôm nay: SLDau = SLTon ngày trước, SLNhap = 0, SLBan = 0
                        string insertTK = @"
                            INSERT INTO TONKHO (MaSP, NgayTon, SLDau, SLNhap, SLBan)
                            VALUES (@MaSP, CAST(GETDATE() AS DATE), @SLDau, 0, 0)";
                        using (SqlCommand cmdIns = new SqlCommand(insertTK, conn))
                        {
                            cmdIns.Parameters.AddWithValue("@MaSP", maSP);
                            cmdIns.Parameters.AddWithValue("@SLDau", slTonNgayTruoc);
                            cmdIns.ExecuteNonQuery();
                        }
                        countCreated++;
                    }

                    LoadTonKhoGrid();

                    if (countCreated > 0)
                    {
                        MessageBox.Show($"Đã tạo tồn kho hôm nay thành công cho {countCreated} sản phẩm!\n({countExisted} sản phẩm đã có tồn kho trước đó).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Hôm nay tất cả sản phẩm ({countExisted}) đã có bản ghi tồn kho rồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tạo tồn kho: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadTonKhoGrid()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT tk.NgayTon AS [Ngày tồn], 
                               tk.MaSP AS [Mã SP], 
                               sp.TenSP AS [Tên sản phẩm], 
                               tk.SLDau AS [SL Đầu], 
                               tk.SLNhap AS [SL Nhập], 
                               tk.SLBan AS [SL Bán], 
                               (tk.SLDau + tk.SLNhap - tk.SLBan) AS [Tồn khả dụng]
                        FROM TONKHO tk
                        JOIN SANPHAM sp ON tk.MaSP = sp.MaSP
                        ORDER BY tk.NgayTon DESC, tk.MaSP ASC";
                    using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvTonKho.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải bảng tồn kho: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}