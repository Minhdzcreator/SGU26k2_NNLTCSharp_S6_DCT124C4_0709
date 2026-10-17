#nullable disable
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace QuanLyListboxApp
{
    public partial class Form1 : Form
    {
        // Khai báo các thành phần giao diện
        private Label lblTitle;
        private GroupBox grpListbox, grpXuLy;
        private TextBox txtNhap;
        private Button btnNhap;
        private ListBox lstNumbers;
        // Các nút trong nhóm "Xử lý Listbox"
        private Button btnTong;
        private Button btnXoaDauCuoi;
        private Button btnXoaDangChon;
        private Button btnTang2;
        private Button btnBinhPhuong;
        private Button btnChonChan;
        private Button btnChonLe;
        // Nút Kết thúc
        private Button btnKetThuc;
        public Form1()
        {
            InitializeCustomComponent();
        }
        private void InitializeCustomComponent()
        {
            // Cấu hình Form cơ bản
            this.Text = "frmListbox";
            this.Size = new Size(520, 480);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            // 1. Tiêu đề "LISTBOX" màu cam/đỏ
            lblTitle = new Label();
            lblTitle.Text = "LISTBOX";
            lblTitle.Font = new Font("Arial", 16, FontStyle.Bold);
            lblTitle.ForeColor = Color.OrangeRed;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Size = new Size(470, 30);
            lblTitle.Location = new Point(15, 10);
            this.Controls.Add(lblTitle);
            // 2. GroupBox "Listbox" bên trái
            grpListbox = new GroupBox();
            grpListbox.Text = "Listbox";
            grpListbox.Location = new Point(15, 45);
            grpListbox.Size = new Size(220, 330);
            txtNhap = new TextBox();
            txtNhap.Location = new Point(15, 25);
            txtNhap.Size = new Size(190, 25);
            btnNhap = new Button();
            btnNhap.Text = "&Nhập"; // Alt + N
            btnNhap.Location = new Point(15, 60);
            btnNhap.Size = new Size(190, 30);
            btnNhap.Click += BtnNhap_Click;
            // Listbox cho phép chọn nhiều phần tử (MultiExtended)
            lstNumbers = new ListBox();
            lstNumbers.Location = new Point(15, 100);
            lstNumbers.Size = new Size(190, 215);
            lstNumbers.SelectionMode = SelectionMode.MultiExtended;
            grpListbox.Controls.Add(txtNhap);
            grpListbox.Controls.Add(btnNhap);
            grpListbox.Controls.Add(lstNumbers);
            this.Controls.Add(grpListbox);
            // 3. GroupBox "Xử lý Listbox" bên phải
            grpXuLy = new GroupBox();
            grpXuLy.Text = "Xử lý Listbox";
            grpXuLy.Location = new Point(255, 45);
            grpXuLy.Size = new Size(230, 330);
            int btnWidth = 200;
            int btnHeight = 32;
            int startX = 15;
            int startY = 25;
            int gapY = 42;
            btnTong = CreateButton("Tổng các phần tử trong List", startX, startY, btnWidth, btnHeight);
            btnTong.Click += BtnTong_Click;
            btnXoaDauCuoi = CreateButton("Xóa Phần tử đầu và cuối", startX, startY + gapY, btnWidth, btnHeight);
            btnXoaDauCuoi.Click += BtnXoaDauCuoi_Click;
            btnXoaDangChon = CreateButton("Xóa Phần tử đang chọn", startX, startY + gapY * 2, btnWidth, btnHeight);
            btnXoaDangChon.Click += BtnXoaDangChon_Click;
            btnTang2 = CreateButton("Tăng mỗi phần tử lên 2", startX, startY + gapY * 3, btnWidth, btnHeight);
            btnTang2.Click += BtnTang2_Click;
            btnBinhPhuong = CreateButton("Thay bằng bình phương", startX, startY + gapY * 4, btnWidth, btnHeight);
            btnBinhPhuong.Click += BtnBinhPhuong_Click;
            btnChonChan = CreateButton("Chọn số chẵn", startX, startY + gapY * 5, btnWidth, btnHeight);
            btnChonChan.Click += BtnChonChan_Click;
            btnChonLe = CreateButton("Chọn số lẻ", startX, startY + gapY * 6, btnWidth, btnHeight);
            btnChonLe.Click += BtnChonLe_Click;
            grpXuLy.Controls.Add(btnTong);
            grpXuLy.Controls.Add(btnXoaDauCuoi);
            grpXuLy.Controls.Add(btnXoaDangChon);
            grpXuLy.Controls.Add(btnTang2);
            grpXuLy.Controls.Add(btnBinhPhuong);
            grpXuLy.Controls.Add(btnChonChan);
            grpXuLy.Controls.Add(btnChonLe);
            this.Controls.Add(grpXuLy);
            // 4. Nút KẾT THÚC ở dưới cùng
            btnKetThuc = new Button();
            btnKetThuc.Text = "KẾT THÚC";
            btnKetThuc.Location = new Point(15, 385);
            btnKetThuc.Size = new Size(470, 35);
            btnKetThuc.Click += BtnKetThuc_Click;
            this.Controls.Add(btnKetThuc);
            // Thiết lập nút Nhập làm nút mặc định khi ấn Enter
            this.AcceptButton = btnNhap;
            this.FormClosing += Form1_FormClosing;
        }
        private Button CreateButton(string text, int x, int y, int width, int height)
        {
            Button btn = new Button();
            btn.Text = text;
            btn.Location = new Point(x, y);
            btn.Size = new Size(width, height);
            return btn;
        }
        // --- 1. Thêm số tự nhiên N vào ListBox ---
        private void BtnNhap_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtNhap.Text.Trim(), out int n) && n >= 0)
            {
                lstNumbers.Items.Add(n);
                txtNhap.Clear();
                txtNhap.Focus();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập một số tự nhiên hợp lệ (N >= 0)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNhap.SelectAll();
                txtNhap.Focus();
            }
        }
        // --- 2. Tính tổng các phần tử trong ListBox ---
        private void BtnTong_Click(object sender, EventArgs e)
        {
            if (lstNumbers.Items.Count == 0)
            {
                MessageBox.Show("Listbox đang trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int sum = lstNumbers.Items.Cast<int>().Sum();
            MessageBox.Show($"Tổng các phần tử trong List là: {sum}", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        // --- 3. Xóa phần tử đầu và cuối của ListBox ---
        private void BtnXoaDauCuoi_Click(object sender, EventArgs e)
        {
            if (lstNumbers.Items.Count == 0)
            {
                MessageBox.Show("Listbox đang trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (lstNumbers.Items.Count == 1)
            {
                lstNumbers.Items.RemoveAt(0);
            }
            else
            {
                // Xóa phần tử cuối trước để không thay đổi chỉ số của phần tử đầu
                lstNumbers.Items.RemoveAt(lstNumbers.Items.Count - 1);
                lstNumbers.Items.RemoveAt(0);
            }
        }
        // --- 4. Xóa các phần tử đang chọn trong ListBox ---
        private void BtnXoaDangChon_Click(object sender, EventArgs e)
        {
            while (lstNumbers.SelectedItems.Count > 0)
            {
                lstNumbers.Items.Remove(lstNumbers.SelectedItems[0]);
            }
        }
        // --- 5. Tăng giá trị mỗi phần tử lên 2 ---
        private void BtnTang2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstNumbers.Items.Count; i++)
            {
                int val = Convert.ToInt32(lstNumbers.Items[i]);
                lstNumbers.Items[i] = val + 2;
            }
        }
        // --- 6. Thay mỗi phần tử bằng bình phương của chính nó ---
        private void BtnBinhPhuong_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstNumbers.Items.Count; i++)
            {
                int val = Convert.ToInt32(lstNumbers.Items[i]);
                lstNumbers.Items[i] = val * val;
            }
        }
        // --- 7. Chọn các phần tử là số chẵn ---
        private void BtnChonChan_Click(object sender, EventArgs e)
        {
            lstNumbers.ClearSelected();
            for (int i = 0; i < lstNumbers.Items.Count; i++)
            {
                int val = Convert.ToInt32(lstNumbers.Items[i]);
                if (val % 2 == 0)
                {
                    lstNumbers.SetSelected(i, true);
                }
            }
        }
        // --- 8. Chọn các phần tử là số lẻ ---
        private void BtnChonLe_Click(object sender, EventArgs e)
        {
            lstNumbers.ClearSelected();
            for (int i = 0; i < lstNumbers.Items.Count; i++)
            {
                int val = Convert.ToInt32(lstNumbers.Items[i]);
                if (val % 2 != 0)
                {
                    lstNumbers.SetSelected(i, true);
                }
            }
        }
        // --- 9. Nút KẾT THÚC ---
        private void BtnKetThuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Bạn có muốn kết thúc chương trình?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (dr == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
