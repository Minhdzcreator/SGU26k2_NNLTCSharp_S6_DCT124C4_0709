#nullable disable
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace BTVN_Tuan6App
{
    public partial class frmBaiTap1 : Form
    {
        // Khai báo các Control giao diện
        private Label lblHoTen, lblMaSV, lblGioiTinh, lblNgoaiNgu, lblDanToc;
        private TextBox txtHoTen, txtMaSV;
        private RadioButton rdoNam, rdoNu;
        private CheckBox chkAnh, chkPhap, chkHoa;
        private ComboBox cmbDanToc;
        private ListView lsvSinhVien;
        private Button btnThem, btnXoa, btnSua;
        private ContextMenuStrip cmsListView;
        private ToolStripMenuItem tsmiXoa;
        public frmBaiTap1()
        {
            InitializeCustomComponent();
        }
        private void InitializeCustomComponent()
        {
            // Cấu hình Form cơ bản
            this.Text = "frmBaitap1 - Quản lý sinh viên";
            this.Size = new Size(620, 580);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            int leftX = 140;
            int startY = 25;
            int rowGap = 35;
            // 1. Họ và Tên
            lblHoTen = new Label { Text = "Họ và Tên", Location = new Point(40, startY), AutoSize = true };
            txtHoTen = new TextBox { Location = new Point(leftX, startY - 3), Size = new Size(280, 25) };
            // 2. Mã sinh viên
            startY += rowGap;
            lblMaSV = new Label { Text = "Mã sinh viên", Location = new Point(40, startY), AutoSize = true };
            txtMaSV = new TextBox { Location = new Point(leftX, startY - 3), Size = new Size(280, 25) };
            // 3. Giới tính
            startY += rowGap;
            lblGioiTinh = new Label { Text = "Giới tính", Location = new Point(40, startY), AutoSize = true };
            rdoNam = new RadioButton { Text = "Nam", Location = new Point(leftX, startY - 3), AutoSize = true, Checked = true };
            rdoNu = new RadioButton { Text = "Nữ", Location = new Point(leftX + 80, startY - 3), AutoSize = true };
            // 4. Ngoại ngữ
            startY += rowGap;
            lblNgoaiNgu = new Label { Text = "Ngoại ngữ", Location = new Point(40, startY), AutoSize = true };
            chkAnh = new CheckBox { Text = "Anh", Location = new Point(leftX, startY - 3), AutoSize = true, Checked = true };
            chkPhap = new CheckBox { Text = "Pháp", Location = new Point(leftX + 70, startY - 3), AutoSize = true };
            chkHoa = new CheckBox { Text = "Hoa", Location = new Point(leftX + 140, startY - 3), AutoSize = true };
            // 5. Dân tộc
            startY += rowGap;
            lblDanToc = new Label { Text = "Dân tộc", Location = new Point(40, startY), AutoSize = true };
            cmbDanToc = new ComboBox { Location = new Point(leftX, startY - 3), Size = new Size(280, 25), DropDownStyle = ComboBoxStyle.DropDownList };
            // 6. ListView hiển thị sinh viên
            startY += 45;
            lsvSinhVien = new ListView();
            lsvSinhVien.Location = new Point(20, startY);
            lsvSinhVien.Size = new Size(565, 230);
            lsvSinhVien.View = View.Details;
            lsvSinhVien.FullRowSelect = true;
            lsvSinhVien.GridLines = true;
            // Tạo các cột trong ListView
            lsvSinhVien.Columns.Add("Họ tên", 140);
            lsvSinhVien.Columns.Add("Mã sinh viên", 100);
            lsvSinhVien.Columns.Add("Giới tính", 80);
            lsvSinhVien.Columns.Add("Ngoại ngữ", 120);
            lsvSinhVien.Columns.Add("Dân tộc", 100);
            // 7. ContextMenuStrip cho thao tác chuột phải trên ListView
            cmsListView = new ContextMenuStrip();
            tsmiXoa = new ToolStripMenuItem("Xóa");
            tsmiXoa.Click += BtnXoa_Click;
            cmsListView.Items.Add(tsmiXoa);
            lsvSinhVien.ContextMenuStrip = cmsListView;
            // 8. Các nút chức năng (Thêm, Xóa, Sửa)
            startY += 245;
            btnThem = new Button { Text = "Thêm", Location = new Point(120, startY), Size = new Size(100, 38) };
            btnThem.Click += BtnThem_Click;
            btnXoa = new Button { Text = "Xóa", Location = new Point(240, startY), Size = new Size(100, 38) };
            btnXoa.Click += BtnXoa_Click;
            btnSua = new Button { Text = "Sửa", Location = new Point(360, startY), Size = new Size(100, 38) };
            btnSua.Click += BtnSua_Click;
            // Thêm tất cả Controls vào Form
            this.Controls.Add(lblHoTen); this.Controls.Add(txtHoTen);
            this.Controls.Add(lblMaSV); this.Controls.Add(txtMaSV);
            this.Controls.Add(lblGioiTinh); this.Controls.Add(rdoNam); this.Controls.Add(rdoNu);
            this.Controls.Add(lblNgoaiNgu); this.Controls.Add(chkAnh); this.Controls.Add(chkPhap); this.Controls.Add(chkHoa);
            this.Controls.Add(lblDanToc); this.Controls.Add(cmbDanToc);
            this.Controls.Add(lsvSinhVien);
            this.Controls.Add(btnThem); this.Controls.Add(btnXoa); this.Controls.Add(btnSua);
            // Đăng ký sự kiện của Form & ListView
            this.Load += Form1_Load;
            lsvSinhVien.SelectedIndexChanged += LsvSinhVien_SelectedIndexChanged;
        }
        // Yêu cầu 1: Nạp dữ liệu vào ComboBox Dân tộc khi Load Form
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] danhSachDanToc = { "Kinh", "Tày", "Thái", "Mường", "Khơ-me", "H'Mông", "Nùng", "Hoa", "Khác" };
            cmbDanToc.Items.AddRange(danhSachDanToc);
            cmbDanToc.SelectedIndex = 0; // Chọn mặc định là "Kinh"
        }
        // Hàm hỗ trợ lấy danh sách Ngoại ngữ đã chọn
        private string GetNgoaiNgu()
        {
            List<string> listNN = new List<string>();
            if (chkAnh.Checked) listNN.Add("Anh");
            if (chkPhap.Checked) listNN.Add("Pháp");
            if (chkHoa.Checked) listNN.Add("Hoa");
            return string.Join(", ", listNN);
        }
        // Yêu cầu 2: Thêm sinh viên (Không cho trùng mã sinh viên)
        private void BtnThem_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text.Trim();
            string maSV = txtMaSV.Text.Trim();
            if (string.IsNullOrWhiteSpace(hoTen) || string.IsNullOrWhiteSpace(maSV))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Họ Tên và Mã Sinh Viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Kiểm tra trùng mã sinh viên
            foreach (ListViewItem item in lsvSinhVien.Items)
            {
                if (item.SubItems[1].Text.Equals(maSV, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Mã sinh viên này đã tồn tại trong danh sách!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaSV.Focus();
                    return;
                }
            }
            string gioiTinh = rdoNam.Checked ? "Nam" : "Nữ";
            string ngoaiNgu = GetNgoaiNgu();
            string danToc = cmbDanToc.SelectedItem?.ToString() ?? "";
            // Thêm dòng mới vào ListView
            ListViewItem lsvItem = new ListViewItem(hoTen);
            lsvItem.SubItems.Add(maSV);
            lsvItem.SubItems.Add(gioiTinh);
            lsvItem.SubItems.Add(ngoaiNgu);
            lsvItem.SubItems.Add(danToc);
            lsvSinhVien.Items.Add(lsvItem);
            // Reset ô nhập
            ResetInputFields();
        }
        // Yêu cầu 2 & 3: Xóa dòng đang chọn trên ListView (hỗ trợ cả nút bấm & ContextMenuStrip)
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (lsvSinhVien.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dòng sinh viên cần xóa trong ListView!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult dr = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa sinh viên đang chọn không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (dr == DialogResult.Yes)
            {
                foreach (ListViewItem item in lsvSinhVien.SelectedItems)
                {
                    lsvSinhVien.Items.Remove(item);
                }
                ResetInputFields();
            }
        }
        // Khi chọn 1 dòng trên ListView, đẩy thông tin lên các Control và khóa ô Mã SV
        private void LsvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvSinhVien.SelectedItems.Count > 0)
            {
                ListViewItem item = lsvSinhVien.SelectedItems[0];
                txtHoTen.Text = item.SubItems[0].Text;
                txtMaSV.Text = item.SubItems[1].Text;
                // Không cho phép sửa Mã sinh viên khi chọn dòng
                txtMaSV.ReadOnly = true;
                // Cập nhật Giới tính
                if (item.SubItems[2].Text == "Nam") rdoNam.Checked = true;
                else rdoNu.Checked = true;
                // Cập nhật Ngoại ngữ
                string ngoaiNgu = item.SubItems[3].Text;
                chkAnh.Checked = ngoaiNgu.Contains("Anh");
                chkPhap.Checked = ngoaiNgu.Contains("Pháp");
                chkHoa.Checked = ngoaiNgu.Contains("Hoa");
                // Cập nhật Dân tộc
                cmbDanToc.SelectedItem = item.SubItems[4].Text;
            }
            else
            {
                ResetInputFields();
            }
        }
        // Yêu cầu 2: Sửa thông tin sinh viên (Giữ nguyên Mã sinh viên)
        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (lsvSinhVien.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dòng sinh viên cần sửa trong ListView!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string hoTen = txtHoTen.Text.Trim();
            if (string.IsNullOrWhiteSpace(hoTen))
            {
                MessageBox.Show("Vui lòng nhập Họ Tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ListViewItem item = lsvSinhVien.SelectedItems[0];
            item.SubItems[0].Text = hoTen;
            // SubItems[1] là Mã sinh viên giữ nguyên theo yêu cầu không cho sửa
            item.SubItems[2].Text = rdoNam.Checked ? "Nam" : "Nữ";
            item.SubItems[3].Text = GetNgoaiNgu();
            item.SubItems[4].Text = cmbDanToc.SelectedItem?.ToString() ?? "";
            MessageBox.Show("Cập nhật thông tin sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ResetInputFields();
        }
        // Trả lại trạng thái ô nhập ban đầu
        private void ResetInputFields()
        {
            txtHoTen.Clear();
            txtMaSV.Clear();
            txtMaSV.ReadOnly = false; // Mở lại ô Mã sinh viên cho thao tác Thêm mới
            rdoNam.Checked = true;
            chkAnh.Checked = true;
            chkPhap.Checked = false;
            chkHoa.Checked = false;
            if (cmbDanToc.Items.Count > 0) cmbDanToc.SelectedIndex = 0;
        }
    }
}
