#nullable disable
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace QuanLyHocVienApp
{
    // ==========================================
    // 1. FORM CHÍNH: QUẢN LÝ HỌC VIÊN
    // ==========================================
    public partial class Form1 : Form
    {
        // Khai báo Menu
        private MenuStrip menuStripMain;
        private ToolStripMenuItem tsmiCapNhat;
        private ToolStripMenuItem tsmiNhapMoi;
        private ToolStripMenuItem tsmiChuyenB;
        private ToolStripMenuItem tsmiChuyenA;
        private ToolStripMenuItem tsmiXoa;
        private ToolStripMenuItem tsmiKetThuc;
        // Khai báo giao diện ListBox
        private GroupBox grpLopA, grpLopB;
        private ListBox lstLopA, lstLopB;
        public Form1()
        {
            InitializeCustomComponent();
            InitData();
        }
        private void InitializeCustomComponent()
        {
            // Cấu hình Form
            this.Text = "Quản lý học viên";
            this.Size = new Size(500, 360);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            // Tạo MenuStrip
            menuStripMain = new MenuStrip();
            tsmiCapNhat = new ToolStripMenuItem("Cập nhật");
            tsmiKetThuc = new ToolStripMenuItem("Kết thúc");
            tsmiNhapMoi = new ToolStripMenuItem("Nhập học viên mới");
            tsmiChuyenB = new ToolStripMenuItem("Chuyển sang lớp B");
            tsmiChuyenA = new ToolStripMenuItem("Chuyển sang lớp A");
            tsmiXoa = new ToolStripMenuItem("Xóa học viên");
            // Đăng ký sự kiện Menu
            tsmiNhapMoi.Click += TsmiNhapMoi_Click;
            tsmiChuyenB.Click += TsmiChuyenB_Click;
            tsmiChuyenA.Click += TsmiChuyenA_Click;
            tsmiXoa.Click += TsmiXoa_Click;
            tsmiKetThuc.Click += TsmiKetThuc_Click;
            tsmiCapNhat.DropDownItems.Add(tsmiNhapMoi);
            tsmiCapNhat.DropDownItems.Add(tsmiChuyenB);
            tsmiCapNhat.DropDownItems.Add(tsmiChuyenA);
            tsmiCapNhat.DropDownItems.Add(tsmiXoa);
            menuStripMain.Items.Add(tsmiCapNhat);
            menuStripMain.Items.Add(tsmiKetThuc);
            this.MainMenuStrip = menuStripMain;
            this.Controls.Add(menuStripMain);
            // GroupBox & ListBox Lớp A
            grpLopA = new GroupBox { Text = "Lớp A", Location = new Point(20, 40), Size = new Size(210, 250) };
            lstLopA = new ListBox
            {
                Location = new Point(10, 25),
                Size = new Size(190, 210),
                SelectionMode = SelectionMode.MultiExtended
            };
            grpLopA.Controls.Add(lstLopA);
            // GroupBox & ListBox Lớp B
            grpLopB = new GroupBox { Text = "Lớp B", Location = new Point(250, 40), Size = new Size(210, 250) };
            lstLopB = new ListBox
            {
                Location = new Point(10, 25),
                Size = new Size(190, 210),
                SelectionMode = SelectionMode.MultiExtended
            };
            grpLopB.Controls.Add(lstLopB);
            this.Controls.Add(grpLopA);
            this.Controls.Add(grpLopB);
            this.FormClosing += Form1_FormClosing;
        }
        private void InitData()
        {
            lstLopA.Items.AddRange(new string[] { "Trần Hùng", "Nguyễn Hưng", "Lâm Tử" });
            lstLopB.Items.AddRange(new string[] { "Tuấn Hưng", "Hồng Ngọc", "Anh Minh", "Bảo Lâm" });
        }
        // Hàm thêm học viên từ Form nhập
        public void ThemHocVien(string hoTen, string tenLop)
        {
            if (tenLop == "Lớp A")
            {
                lstLopA.Items.Add(hoTen);
            }
            else if (tenLop == "Lớp B")
            {
                lstLopB.Items.Add(hoTen);
            }
        }
        private void TsmiNhapMoi_Click(object sender, EventArgs e)
        {
            frmNhapHocVien frm = new frmNhapHocVien(this);
            frm.ShowDialog();
        }
        private void TsmiChuyenB_Click(object sender, EventArgs e)
        {
            if (lstLopA.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn học viên trong Lớp A trước khi chuyển!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var selectedItems = lstLopA.SelectedItems.Cast<object>().ToList();
            foreach (var item in selectedItems)
            {
                lstLopB.Items.Add(item);
                lstLopA.Items.Remove(item);
            }
        }
        private void TsmiChuyenA_Click(object sender, EventArgs e)
        {
            if (lstLopB.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn học viên trong Lớp B trước khi chuyển!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var selectedItems = lstLopB.SelectedItems.Cast<object>().ToList();
            foreach (var item in selectedItems)
            {
                lstLopA.Items.Add(item);
                lstLopB.Items.Remove(item);
            }
        }
        private void TsmiXoa_Click(object sender, EventArgs e)
        {
            if (lstLopA.SelectedItems.Count == 0 && lstLopB.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn học viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var selectedA = lstLopA.SelectedItems.Cast<object>().ToList();
            foreach (var item in selectedA)
            {
                lstLopA.Items.Remove(item);
            }
            var selectedB = lstLopB.SelectedItems.Cast<object>().ToList();
            foreach (var item in selectedB)
            {
                lstLopB.Items.Remove(item);
            }
        }
        private void TsmiKetThuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Bạn có chắc chắn muốn dừng chương trình?",
                "Xác nhận kết thúc",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (dr == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
    // ==========================================
    // 2. FORM PHỤ: NHẬP HỌC VIÊN MỚI
    // ==========================================
    public partial class frmNhapHocVien : Form
    {
        private Form1 mainForm;
        private Label lblHoTen, lblLop;
        private TextBox txtHoTen;
        private ComboBox cmbLop;
        private Button btnCapNhat, btnTroVe;
        public frmNhapHocVien(Form1 form)
        {
            mainForm = form;
            InitializeCustomComponent();
        }
        private void InitializeCustomComponent()
        {
            this.Text = "Nhập học viên mới";
            this.Size = new Size(380, 200);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            lblHoTen = new Label { Text = "Họ và Tên", Location = new Point(30, 25), AutoSize = true };
            txtHoTen = new TextBox { Location = new Point(110, 22), Size = new Size(220, 25) };
            lblLop = new Label { Text = "Lớp", Location = new Point(30, 65), AutoSize = true };
            cmbLop = new ComboBox
            {
                Location = new Point(110, 62),
                Size = new Size(220, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbLop.Items.AddRange(new string[] { "Lớp A", "Lớp B" });
            cmbLop.SelectedIndex = 0;
            btnCapNhat = new Button { Text = "Cập nhật", Location = new Point(110, 105), Size = new Size(100, 32) };
            btnCapNhat.Click += BtnCapNhat_Click;
            btnTroVe = new Button { Text = "Trở về", Location = new Point(230, 105), Size = new Size(100, 32) };
            btnTroVe.Click += BtnTroVe_Click;
            this.Controls.Add(lblHoTen); this.Controls.Add(txtHoTen);
            this.Controls.Add(lblLop); this.Controls.Add(cmbLop);
            this.Controls.Add(btnCapNhat); this.Controls.Add(btnTroVe);
            this.AcceptButton = btnCapNhat;
        }
        private void BtnCapNhat_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text.Trim();
            if (string.IsNullOrWhiteSpace(hoTen))
            {
                MessageBox.Show("Vui lòng nhập họ và tên học viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }
            string tenLop = cmbLop.SelectedItem.ToString();
            mainForm.ThemHocVien(hoTen, tenLop);
            txtHoTen.Clear();
            txtHoTen.Focus();
        }
        private void BtnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
