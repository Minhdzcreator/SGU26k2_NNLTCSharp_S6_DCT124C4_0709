#nullable disable
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace ThucHanh06b_BTVN
{
    public class frmBanHang : Form
    {
        private string connectionString = @"Data Source=.;Initial Catalog=QLCuaHang;Integrated Security=True;TrustServerCertificate=True";

        private Button btnTaoHD;
        private GroupBox grpChiTietHD;
        private Label lblMaHD, lblMaSP, lblSoLuong, lblTonKhoInfo;
        private TextBox txtMaHD, txtSoLuong;
        private ComboBox cboSanPham;
        private Button btnThem, btnHuy, btnThanhToan;
        private ListView lvwChiTiet;

        private int currentMaHD = -1;

        public frmBanHang()
        {
            InitializeCustomComponent();
            SetControlsState(false);
        }

        private void InitializeCustomComponent()
        {
            this.Text = "BanHang";
            this.Size = new Size(540, 520);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            btnTaoHD = new Button
            {
                Text = "Tạo hóa đơn mới",
                Location = new Point(330, 20),
                Size = new Size(160, 32),
                Font = new Font(this.Font, FontStyle.Bold)
            };
            btnTaoHD.Click += BtnTaoHD_Click;

            grpChiTietHD = new GroupBox
            {
                Text = "Chi tiết hóa đơn",
                Location = new Point(25, 65),
                Size = new Size(475, 400)
            };

            lblMaHD = new Label { Text = "Mã hóa đơn", Location = new Point(25, 30), AutoSize = true };
            txtMaHD = new TextBox { Location = new Point(130, 27), Size = new Size(180, 25), ReadOnly = true, BackColor = Color.WhiteSmoke };

            lblMaSP = new Label { Text = "Mã sản phẩm", Location = new Point(25, 70), AutoSize = true };
            cboSanPham = new ComboBox { Location = new Point(130, 67), Size = new Size(180, 25), DropDownStyle = ComboBoxStyle.DropDownList };
            cboSanPham.SelectedIndexChanged += CboSanPham_SelectedIndexChanged;

            lblTonKhoInfo = new Label { Text = "Tồn: 0", Location = new Point(325, 70), AutoSize = true, ForeColor = Color.DarkBlue };

            lblSoLuong = new Label { Text = "Số lượng", Location = new Point(25, 110), AutoSize = true };
            txtSoLuong = new TextBox { Location = new Point(130, 107), Size = new Size(180, 25) };

            btnThem = new Button { Text = "Thêm", Location = new Point(130, 150), Size = new Size(80, 30) };
            btnThem.Click += BtnThem_Click;

            btnHuy = new Button { Text = "Hủy", Location = new Point(230, 150), Size = new Size(80, 30) };
            btnHuy.Click += BtnHuy_Click;

            btnThanhToan = new Button { Text = "Thanh toán", Location = new Point(330, 150), Size = new Size(110, 30) };
            btnThanhToan.Click += BtnThanhToan_Click;

            lvwChiTiet = new ListView
            {
                Location = new Point(25, 195),
                Size = new Size(425, 185),
                View = View.Details,
                FullRowSelect = true,
                GridLines = true
            };
            lvwChiTiet.Columns.Add("Mã SP", 80, HorizontalAlignment.Center);
            lvwChiTiet.Columns.Add("Tên SP", 220, HorizontalAlignment.Left);
            lvwChiTiet.Columns.Add("Số lượng", 100, HorizontalAlignment.Right);

            grpChiTietHD.Controls.Add(lblMaHD);
            grpChiTietHD.Controls.Add(txtMaHD);
            grpChiTietHD.Controls.Add(lblMaSP);
            grpChiTietHD.Controls.Add(cboSanPham);
            grpChiTietHD.Controls.Add(lblTonKhoInfo);
            grpChiTietHD.Controls.Add(lblSoLuong);
            grpChiTietHD.Controls.Add(txtSoLuong);
            grpChiTietHD.Controls.Add(btnThem);
            grpChiTietHD.Controls.Add(btnHuy);
            grpChiTietHD.Controls.Add(btnThanhToan);
            grpChiTietHD.Controls.Add(lvwChiTiet);

            this.Controls.Add(btnTaoHD);
            this.Controls.Add(grpChiTietHD);
        }

        // Đặt trạng thái Enabled / Disabled (mờ) cho các control
        private void SetControlsState(bool enabled)
        {
            txtMaHD.Enabled = enabled;
            cboSanPham.Enabled = enabled;
            txtSoLuong.Enabled = enabled;
            btnThem.Enabled = enabled;
            btnHuy.Enabled = enabled;
            btnThanhToan.Enabled = enabled;
            lvwChiTiet.Enabled = enabled;
        }

        // Tải danh sách sản phẩm lên ComboBox
        private void LoadSanPham_ComboBox()
        {
            cboSanPham.Items.Clear();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT MaSP, TenSP FROM SANPHAM ORDER BY MaSP";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            cboSanPham.Items.Add(new SanPhamItem
                            {
                                MaSP = Convert.ToInt32(rd["MaSP"]),
                                TenSP = rd["TenSP"].ToString()
                            });
                        }
                    }
                    if (cboSanPham.Items.Count > 0)
                        cboSanPham.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Lấy số tồn khả dụng của sản phẩm trong ngày hôm nay: SLDau + SLNhap - SLBan
        private int GetTonKhaDung(int maSP)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Đảm bảo có dòng tồn kho cho ngày hôm nay
                    string checkQuery = @"SELECT ISNULL((SLDau + SLNhap - SLBan), 0) 
                                          FROM TONKHO 
                                          WHERE MaSP = @MaSP AND NgayTon = CAST(GETDATE() AS DATE)";
                    using (SqlCommand cmd = new SqlCommand(checkQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSP", maSP);
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            return Convert.ToInt32(result);
                        }
                    }

                    // Nếu hôm nay chưa có dòng tồn kho, tự động tạo từ tồn của ngày trước
                    string createQuery = @"
                        DECLARE @SlTruoc INT = 0;
                        SELECT TOP 1 @SlTruoc = (SLDau + SLNhap - SLBan)
                        FROM TONKHO
                        WHERE MaSP = @MaSP AND NgayTon < CAST(GETDATE() AS DATE)
                        ORDER BY NgayTon DESC;

                        IF @SlTruoc IS NULL SET @SlTruoc = 0;

                        INSERT INTO TONKHO (MaSP, NgayTon, SLDau, SLNhap, SLBan)
                        VALUES (@MaSP, CAST(GETDATE() AS DATE), @SlTruoc, 0, 0);

                        SELECT @SlTruoc;";
                    using (SqlCommand cmd2 = new SqlCommand(createQuery, conn))
                    {
                        cmd2.Parameters.AddWithValue("@MaSP", maSP);
                        return Convert.ToInt32(cmd2.ExecuteScalar());
                    }
                }
                catch
                {
                    return 0;
                }
            }
        }

        private void CboSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSanPham.SelectedItem is SanPhamItem item)
            {
                int ton = GetTonKhaDung(item.MaSP);
                lblTonKhoInfo.Text = $"Tồn khả dụng: {ton}";
                lblTonKhoInfo.ForeColor = ton > 0 ? Color.DarkGreen : Color.Red;
            }
        }

        // 1. TẠO HÓA ĐƠN MỚI
        private void BtnTaoHD_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Thêm 1 hóa đơn mới vào bảng HOADON với mã tự động tăng, ngày tạo hiện tại, TinhTrangThanhToan = 0
                    string query = @"INSERT INTO HOADON (NgayTao, TinhTrangThanhToan) 
                                     VALUES (GETDATE(), 0); 
                                     SELECT SCOPE_IDENTITY();";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        currentMaHD = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    txtMaHD.Text = currentMaHD.ToString();
                    txtSoLuong.Clear();
                    lvwChiTiet.Items.Clear();

                    // Hiển thị/Enable các control
                    SetControlsState(true);
                    LoadSanPham_ComboBox();

                    MessageBox.Show($"Đã tạo hóa đơn mới thành công! Mã HĐ: {currentMaHD}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tạo hóa đơn mới: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 2. THÊM CHI TIẾT HÓA ĐƠN
        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (currentMaHD <= 0)
            {
                MessageBox.Show("Vui lòng nhấn 'Tạo hóa đơn mới' trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!(cboSanPham.SelectedItem is SanPhamItem sp))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtSoLuong.Text.Trim(), out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng bán phải là số nguyên lớn hơn 0!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
                return;
            }

            // Kiểm tra số lượng bán phải <= số lượng tồn trong bảng tồn kho
            int tonKhaDung = GetTonKhaDung(sp.MaSP);
            if (soLuong > tonKhaDung)
            {
                MessageBox.Show($"Số lượng bán ({soLuong}) vượt quá số lượng tồn kho khả dụng ({tonKhaDung})!", "Hết hàng trong kho", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Kiểm tra khóa chính trong bảng CHITIET_HOADON (MaHD, MaSP)
                    string checkExists = "SELECT 1 FROM CHITIET_HOADON WHERE MaHD = @MaHD AND MaSP = @MaSP";
                    using (SqlCommand cmdCheck = new SqlCommand(checkExists, conn))
                    {
                        cmdCheck.Parameters.AddWithValue("@MaHD", currentMaHD);
                        cmdCheck.Parameters.AddWithValue("@MaSP", sp.MaSP);
                        using (SqlDataReader rd = cmdCheck.ExecuteReader())
                        {
                            if (rd.HasRows)
                            {
                                MessageBox.Show($"Sản phẩm '{sp.TenSP}' đã có trong chi tiết hóa đơn này!", "Trùng sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }

                    // 1. Thêm một dòng tin vào bảng CHITIET_HOADON
                    string insertCT = "INSERT INTO CHITIET_HOADON (MaHD, MaSP, SoLuong) VALUES (@MaHD, @MaSP, @SoLuong)";
                    using (SqlCommand cmdInsert = new SqlCommand(insertCT, conn))
                    {
                        cmdInsert.Parameters.AddWithValue("@MaHD", currentMaHD);
                        cmdInsert.Parameters.AddWithValue("@MaSP", sp.MaSP);
                        cmdInsert.Parameters.AddWithValue("@SoLuong", soLuong);
                        cmdInsert.ExecuteNonQuery();
                    }

                    // 2. Cập nhật lại tổng số lượng bán trong bảng tồn kho: Tổng SLBan = Tổng SLBan + số lượng
                    string updateTonKho = @"UPDATE TONKHO 
                                            SET SLBan = SLBan + @SoLuong 
                                            WHERE MaSP = @MaSP AND NgayTon = CAST(GETDATE() AS DATE)";
                    using (SqlCommand cmdUpdate = new SqlCommand(updateTonKho, conn))
                    {
                        cmdUpdate.Parameters.AddWithValue("@SoLuong", soLuong);
                        cmdUpdate.Parameters.AddWithValue("@MaSP", sp.MaSP);
                        cmdUpdate.ExecuteNonQuery();
                    }

                    // 3. Hiển thị lên ListView
                    ListViewItem item = new ListViewItem(sp.MaSP.ToString());
                    item.SubItems.Add(sp.TenSP);
                    item.SubItems.Add(soLuong.ToString());
                    lvwChiTiet.Items.Add(item);

                    MessageBox.Show($"Đã thêm sản phẩm '{sp.TenSP}' (SL: {soLuong}) vào hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSoLuong.Clear();

                    // Cập nhật lại nhãn tồn kho
                    CboSanPham_SelectedIndexChanged(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thêm chi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 3. THANH TOÁN HÓA ĐƠN
        private void BtnThanhToan_Click(object sender, EventArgs e)
        {
            if (currentMaHD <= 0) return;

            if (lvwChiTiet.Items.Count == 0)
            {
                MessageBox.Show("Hóa đơn chưa có sản phẩm nào để thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE HOADON SET TinhTrangThanhToan = 1 WHERE MaHD = @MaHD";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaHD", currentMaHD);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show($"Thanh toán hóa đơn #{currentMaHD} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 4. HỦY HÓA ĐƠN VÀ HOÀN LẠI TỒN KHO
        private void BtnHuy_Click(object sender, EventArgs e)
        {
            if (currentMaHD <= 0) return;

            DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn hủy hóa đơn #{currentMaHD}?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // 1. Hoàn lại số lượng bán trong tồn kho ngày hôm nay
                    string queryHoanTon = @"
                        UPDATE tk
                        SET tk.SLBan = tk.SLBan - ct.SoLuong
                        FROM TONKHO tk
                        JOIN CHITIET_HOADON ct ON tk.MaSP = ct.MaSP
                        WHERE ct.MaHD = @MaHD AND tk.NgayTon = CAST(GETDATE() AS DATE)";
                    using (SqlCommand cmdHoan = new SqlCommand(queryHoanTon, conn))
                    {
                        cmdHoan.Parameters.AddWithValue("@MaHD", currentMaHD);
                        cmdHoan.ExecuteNonQuery();
                    }

                    // 2. Xóa chi tiết hóa đơn
                    string queryDelCT = "DELETE FROM CHITIET_HOADON WHERE MaHD = @MaHD";
                    using (SqlCommand cmdDelCT = new SqlCommand(queryDelCT, conn))
                    {
                        cmdDelCT.Parameters.AddWithValue("@MaHD", currentMaHD);
                        cmdDelCT.ExecuteNonQuery();
                    }

                    // 3. Xóa hóa đơn
                    string queryDelHD = "DELETE FROM HOADON WHERE MaHD = @MaHD";
                    using (SqlCommand cmdDelHD = new SqlCommand(queryDelHD, conn))
                    {
                        cmdDelHD.Parameters.AddWithValue("@MaHD", currentMaHD);
                        cmdDelHD.ExecuteNonQuery();
                    }

                    MessageBox.Show($"Đã hủy hóa đơn #{currentMaHD} và hoàn lại tồn kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi hủy hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ResetForm()
        {
            currentMaHD = -1;
            txtMaHD.Clear();
            txtSoLuong.Clear();
            lvwChiTiet.Items.Clear();
            lblTonKhoInfo.Text = "Tồn: 0";
            SetControlsState(false);
        }

        private class SanPhamItem
        {
            public int MaSP { get; set; }
            public string TenSP { get; set; }
            public override string ToString()
            {
                return $"{MaSP} - {TenSP}";
            }
        }
    }
}