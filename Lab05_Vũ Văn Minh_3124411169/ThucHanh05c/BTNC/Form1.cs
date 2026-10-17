#nullable disable
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
namespace XuLyChuoiApp
{
    public partial class Form1 : Form
    {
        // Danh sách mảng chuỗi mẫu theo đề bài
        private readonly string[] HO = { "Lê", "Nguyễn", "Lý", "Trần", "Lâm", "Hồ", "Lai", "Huỳnh", "La" };
        private readonly string[] TENLOT = { "Quang", "Thành", "Ngọc", "Anh", "Xuân", "Bảo", "Cẩm", "Thị", "Kim", "Thái", "Hồng" };
        private readonly string[] TEN = { "Hà", "Danh", "Sơn", "Mai", "Thắng", "Kỳ", "Thành", "Lâm", "Tâm", "Phụng", "Thắm" };
        private Button btnNgauNhien;
        private ListBox lstTen;
        private Button btnXoaDangChon;
        private Button btnXoaTenSon;
        private Button btnXoaHoLe;
        private Button btnHoaDangChon;
        private Button btnThuongDangChon;
        private Button btnHoaDauDangChon;
        private Button btnXoaTatCa;
        public Form1()
        {
            InitializeCustomComponent();
        }
        private void InitializeCustomComponent()
        {
            // Cấu hình Form
            this.Text = "frmChuoi";
            this.Size = new Size(550, 430);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            // 1. Nút "Nhập tên ngẫu nhiên"
            btnNgauNhien = new Button();
            btnNgauNhien.Text = "Nhập tên ngẫu nhiên";
            btnNgauNhien.Location = new Point(20, 20);
            btnNgauNhien.Size = new Size(220, 35);
            btnNgauNhien.Click += BtnNgauNhien_Click;
            this.Controls.Add(btnNgauNhien);
            // 2. ListBox hiển thị danh sách tên (Cho phép chọn nhiều dòng)
            lstTen = new ListBox();
            lstTen.Location = new Point(20, 65);
            lstTen.Size = new Size(220, 310);
            lstTen.SelectionMode = SelectionMode.MultiExtended;
            lstTen.DoubleClick += LstTen_DoubleClick;
            this.Controls.Add(lstTen);
            // Cấu hình vị trí các nút chức năng bên phải
            int rightX = 260;
            int btnWidth = 250;
            int btnHeight = 35;
            int startY = 65;
            int gapY = 40;
            // Nút "Xóa Phần tử đang chọn"
            btnXoaDangChon = CreateButton("Xóa Phần tử đang chọn", rightX, startY, btnWidth, btnHeight);
            btnXoaDangChon.Click += BtnXoaDangChon_Click;
            // Nút "Xóa phần tử có tên là Sơn"
            btnXoaTenSon = CreateButton("Xóa phần tử có tên là Sơn", rightX, startY + gapY, btnWidth, btnHeight);
            btnXoaTenSon.Click += BtnXoaTenSon_Click;
            // Nút "Xóa Phần tử có họ là Lê"
            btnXoaHoLe = CreateButton("Xóa Phần tử có họ là Lê", rightX, startY + gapY * 2, btnWidth, btnHeight);
            btnXoaHoLe.Click += BtnXoaHoLe_Click;
            // Nút "Chuyển PT đang chọn thành chữ HOA"
            btnHoaDangChon = CreateButton("Chuyển PT đang chọn thành chữ HOA", rightX, startY + gapY * 3, btnWidth, btnHeight);
            btnHoaDangChon.Click += BtnHoaDangChon_Click;
            // Nút "Chuyển PT đang chọn thành chữ thường"
            btnThuongDangChon = CreateButton("Chuyển PT đang chọn thành chữ thường", rightX, startY + gapY * 4, btnWidth, btnHeight);
            btnThuongDangChon.Click += BtnThuongDangChon_Click;
            // Nút "Chuyển PT đang chọn thành viết Hoa đầu mỗi từ"
            btnHoaDauDangChon = CreateButton("Chuyển PT đang chọn thành viết Hoa\nđầu mỗi từ", rightX, startY + gapY * 5, btnWidth, btnHeight);
            btnHoaDauDangChon.Click += BtnHoaDauDangChon_Click;
            // Nút "Xóa tất cả các Phần tử"
            btnXoaTatCa = CreateButton("Xóa tất cả các Phần tử", rightX, startY + gapY * 6, btnWidth, btnHeight);
            btnXoaTatCa.Click += BtnXoaTatCa_Click;
        }
        private Button CreateButton(string text, int x, int y, int width, int height)
        {
            Button btn = new Button();
            btn.Text = text;
            btn.Location = new Point(x, y);
            btn.Size = new Size(width, height);
            this.Controls.Add(btn);
            return btn;
        }
        // Yêu cầu 1: Thêm 50 tên ngẫu nhiên kết hợp từ HO, TENLOT, TEN
        private void BtnNgauNhien_Click(object sender, EventArgs e)
        {
            lstTen.Items.Clear();
            Random rand = new Random();
            for (int i = 0; i < 50; i++)
            {
                string ho = HO[rand.Next(HO.Length)];
                string tenLot = TENLOT[rand.Next(TENLOT.Length)];
                string ten = TEN[rand.Next(TEN.Length)];
                string hoTenFull = $"{ho} {tenLot} {ten}";
                lstTen.Items.Add(hoTenFull);
            }
        }
        // Yêu cầu 2.1: Xóa phần tử đang chọn
        private void BtnXoaDangChon_Click(object sender, EventArgs e)
        {
            while (lstTen.SelectedItems.Count > 0)
            {
                lstTen.Items.Remove(lstTen.SelectedItems[0]);
            }
        }
        // Yêu cầu 2.2: Xóa các phần tử có tên là "Sơn"
        private void BtnXoaTenSon_Click(object sender, EventArgs e)
        {
            for (int i = lstTen.Items.Count - 1; i >= 0; i--)
            {
                string item = lstTen.Items[i].ToString().Trim();
                string[] parts = item.Split(' ');
                // Lấy từ cuối cùng làm Tên
                if (parts.Length > 0 && parts.Last().Equals("Sơn", StringComparison.OrdinalIgnoreCase))
                {
                    lstTen.Items.RemoveAt(i);
                }
            }
        }
        // Yêu cầu 2.3: Xóa các phần tử có họ là "Lê"
        private void BtnXoaHoLe_Click(object sender, EventArgs e)
        {
            for (int i = lstTen.Items.Count - 1; i >= 0; i--)
            {
                string item = lstTen.Items[i].ToString().Trim();
                string[] parts = item.Split(' ');
                // Lấy từ đầu tiên làm Họ
                if (parts.Length > 0 && parts.First().Equals("Lê", StringComparison.OrdinalIgnoreCase))
                {
                    lstTen.Items.RemoveAt(i);
                }
            }
        }
        // Yêu cầu 2.4: Chuyển các PT đang chọn thành chữ HOA
        private void BtnHoaDangChon_Click(object sender, EventArgs e)
        {
            List<int> selectedIndices = lstTen.SelectedIndices.Cast<int>().ToList();
            foreach (int index in selectedIndices)
            {
                lstTen.Items[index] = lstTen.Items[index].ToString().ToUpper();
            }
        }
        // Yêu cầu 2.5: Chuyển các PT đang chọn thành chữ thường
        private void BtnThuongDangChon_Click(object sender, EventArgs e)
        {
            List<int> selectedIndices = lstTen.SelectedIndices.Cast<int>().ToList();
            foreach (int index in selectedIndices)
            {
                lstTen.Items[index] = lstTen.Items[index].ToString().ToLower();
            }
        }
        // Yêu cầu 2.6: Chuyển các PT đang chọn thành viết Hoa đầu mỗi từ
        private void BtnHoaDauDangChon_Click(object sender, EventArgs e)
        {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            List<int> selectedIndices = lstTen.SelectedIndices.Cast<int>().ToList();
            foreach (int index in selectedIndices)
            {
                string str = lstTen.Items[index].ToString().ToLower();
                lstTen.Items[index] = textInfo.ToTitleCase(str);
            }
        }
        // Yêu cầu 2.7: Xóa tất cả các phần tử
        private void BtnXoaTatCa_Click(object sender, EventArgs e)
        {
            lstTen.Items.Clear();
        }
        // Yêu cầu 3: Double click vào tên đang chọn thì mở InputBox cho phép thay đổi tên
        private void LstTen_DoubleClick(object sender, EventArgs e)
        {
            if (lstTen.SelectedIndex != -1)
            {
                int index = lstTen.SelectedIndex;
                string oldName = lstTen.Items[index].ToString();
                // Hiển thị InputBox tùy chỉnh
                string newName = CustomInputBox.Show("Nhập tên mới:", "Sửa tên", oldName);
                if (!string.IsNullOrWhiteSpace(newName))
                {
                    lstTen.Items[index] = newName.Trim();
                }
            }
        }
    }
    // Lớp hỗ trợ tạo Hộp thoại InputBox đơn giản bằng C#
    public static class CustomInputBox
    {
        public static string Show(string promptText, string title, string defaultValue = "")
        {
            Form form = new Form
            {
                Width = 360,
                Height = 170,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = title,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false
            };
            Label label = new Label { Left = 20, Top = 15, Text = promptText, AutoSize = true };
            TextBox textBox = new TextBox { Left = 20, Top = 40, Width = 300, Text = defaultValue };
            Button buttonOk = new Button { Text = "OK", Left = 130, Width = 90, Top = 80, DialogResult = DialogResult.OK };
            Button buttonCancel = new Button { Text = "Hủy", Left = 230, Width = 90, Top = 80, DialogResult = DialogResult.Cancel };
            form.Controls.Add(label);
            form.Controls.Add(textBox);
            form.Controls.Add(buttonOk);
            form.Controls.Add(buttonCancel);
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;
            return form.ShowDialog() == DialogResult.OK ? textBox.Text : string.Empty;
        }
    }
}
