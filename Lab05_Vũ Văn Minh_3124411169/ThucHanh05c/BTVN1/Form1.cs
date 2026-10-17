#nullable disable
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace TuDienApp
{
    public partial class Form1 : Form
    {
        // Lớp đối tượng biểu diễn một từ vựng
        public class WordItem
        {
            public string Word { get; set; }
            public string Meaning { get; set; }
            public WordItem(string word, string meaning)
            {
                Word = word;
                Meaning = meaning;
            }
            public override string ToString()
            {
                return Word;
            }
        }
        // Yêu cầu 3: Danh sách các từ lưu sẵn vào List
        private List<WordItem> listAnhViet;
        private List<WordItem> listVietAnh;
        // Các thành phần giao diện
        private TabControl tabControlMain;
        private TabPage tabAnhViet, tabVietAnh;
        // Tab Anh - Việt
        private Label lblAnh, lblViet;
        private ComboBox cmbAnh;
        private ListBox lstAnh;
        private TextBox txtNghiaViet;
        // Tab Việt - Anh
        private Label lblVietTab2, lblAnhTab2;
        private ComboBox cmbViet;
        private ListBox lstViet;
        private TextBox txtNghiaAnh;
        private Button btnThoat;
        public Form1()
        {
            InitializeCustomComponent();
            InitData();
        }
        private void InitializeCustomComponent()
        {
            // Cấu hình Form
            this.Text = "TỪ ĐIỂN ANH VIỆT - VIỆT ANH";
            this.Size = new Size(580, 480);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            // 1. Tạo TabControl
            tabControlMain = new TabControl();
            tabControlMain.Location = new Point(15, 15);
            tabControlMain.Size = new Size(535, 370);
            // --- TAB 1: ANH - VIỆT ---
            tabAnhViet = new TabPage("ANH - VIỆT");
            lblAnh = new Label { Text = "Tiếng Anh", Location = new Point(15, 15), AutoSize = true };
            cmbAnh = new ComboBox { Location = new Point(15, 40), Size = new Size(180, 25) };
            lstAnh = new ListBox { Location = new Point(15, 70), Size = new Size(180, 230) };
            lblViet = new Label { Text = "Tiếng Việt", Location = new Point(220, 15), AutoSize = true };
            txtNghiaViet = new TextBox { Location = new Point(220, 40), Size = new Size(285, 260), Multiline = true, ReadOnly = true, ScrollBars = ScrollBars.Vertical };
            tabAnhViet.Controls.Add(lblAnh);
            tabAnhViet.Controls.Add(cmbAnh);
            tabAnhViet.Controls.Add(lstAnh);
            tabAnhViet.Controls.Add(lblViet);
            tabAnhViet.Controls.Add(txtNghiaViet);
            // --- TAB 2: VIỆT - ANH ---
            tabVietAnh = new TabPage("VIỆT - ANH");
            lblVietTab2 = new Label { Text = "Tiếng Việt", Location = new Point(15, 15), AutoSize = true };
            cmbViet = new ComboBox { Location = new Point(15, 40), Size = new Size(180, 25) };
            lstViet = new ListBox { Location = new Point(15, 70), Size = new Size(180, 230) };
            lblAnhTab2 = new Label { Text = "Tiếng Anh", Location = new Point(220, 15), AutoSize = true };
            txtNghiaAnh = new TextBox { Location = new Point(220, 40), Size = new Size(285, 260), Multiline = true, ReadOnly = true, ScrollBars = ScrollBars.Vertical };
            tabVietAnh.Controls.Add(lblVietTab2);
            tabVietAnh.Controls.Add(cmbViet);
            tabVietAnh.Controls.Add(lstViet);
            tabVietAnh.Controls.Add(lblAnhTab2);
            tabVietAnh.Controls.Add(txtNghiaAnh);
            // Thêm các tab vào TabControl
            tabControlMain.TabPages.Add(tabAnhViet);
            tabControlMain.TabPages.Add(tabVietAnh);
            this.Controls.Add(tabControlMain);
            // 2. Nút "Thoát"
            btnThoat = new Button { Text = "Thoát", Location = new Point(440, 395), Size = new Size(110, 32) };
            btnThoat.Click += BtnThoat_Click;
            this.Controls.Add(btnThoat);
            // Đăng ký sự kiện Tab Anh - Việt
            cmbAnh.TextChanged += CmbAnh_TextChanged;
            cmbAnh.KeyDown += CmbAnh_KeyDown;
            lstAnh.SelectedIndexChanged += LstAnh_SelectedIndexChanged;
            lstAnh.DoubleClick += LstAnh_DoubleClick;
            // Đăng ký sự kiện Tab Việt - Anh
            cmbViet.TextChanged += CmbViet_TextChanged;
            cmbViet.KeyDown += CmbViet_KeyDown;
            lstViet.SelectedIndexChanged += LstViet_SelectedIndexChanged;
            lstViet.DoubleClick += LstViet_DoubleClick;
            this.FormClosing += Form1_FormClosing;
        }
        // Yêu cầu 3: Khởi tạo dữ liệu sẵn vào List
        private void InitData()
        {
            // Danh sách Từ điển Anh - Việt
            listAnhViet = new List<WordItem>
            {
                new WordItem("student", "Sinh viên, học sinh"),
                new WordItem("teacher", "Giáo viên, thầy cô giáo"),
                new WordItem("worker", "Công nhân, người lao động"),
                new WordItem("hat", "Cái mũ, cái nón"),
                new WordItem("head", "Cái đầu"),
                new WordItem("mouse", "Con chuột"),
                new WordItem("cat", "Con mèo"),
                new WordItem("dog", "Con chó"),
                new WordItem("snake", "Con rắn"),
                new WordItem("lamb", "Con cừu con"),
                new WordItem("loan", "Khoản vay, tiền cho vay"),
                new WordItem("frog", "Con ếch"),
                new WordItem("sheep", "Con cừu")
            };
            // Sắp xếp danh sách Anh - Việt theo A-Z
            listAnhViet = listAnhViet.OrderBy(x => x.Word).ToList();
            lstAnh.Items.Clear();
            cmbAnh.Items.Clear();
            foreach (var item in listAnhViet)
            {
                lstAnh.Items.Add(item);
                cmbAnh.Items.Add(item.Word);
            }
            // Danh sách Từ điển Việt - Anh
            listVietAnh = new List<WordItem>
            {
                new WordItem("Cái đầu", "head"),
                new WordItem("Cái mũ", "hat"),
                new WordItem("Công nhân", "worker"),
                new WordItem("Con chó", "dog"),
                new WordItem("Con cừu", "sheep"),
                new WordItem("Con ếch", "frog"),
                new WordItem("Con mèo", "cat"),
                new WordItem("Con chuột", "mouse"),
                new WordItem("Con rắn", "snake"),
                new WordItem("Giáo viên", "teacher"),
                new WordItem("Sinh viên", "student")
            };
            // Sắp xếp danh sách Việt - Anh theo A-Z
            listVietAnh = listVietAnh.OrderBy(x => x.Word).ToList();
            lstViet.Items.Clear();
            cmbViet.Items.Clear();
            foreach (var item in listVietAnh)
            {
                lstViet.Items.Add(item);
                cmbViet.Items.Add(item.Word);
            }
        }
        // --- XỬ LÝ TAB ANH - VIỆT ---
        // Yêu cầu 1: Nhập vào combobox thì dò tìm đến chữ khớp gần nhất
        private void CmbAnh_TextChanged(object sender, EventArgs e)
        {
            string keyword = cmbAnh.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword)) return;
            for (int i = 0; i < lstAnh.Items.Count; i++)
            {
                WordItem item = (WordItem)lstAnh.Items[i];
                if (item.Word.ToLower().StartsWith(keyword))
                {
                    lstAnh.SelectedIndex = i;
                    break;
                }
            }
        }
        // Yêu cầu 2: Nhấn phím Enter để hiển thị nghĩa tương ứng
        private void CmbAnh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HienThiNghiaAnhViet();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void LstAnh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAnh.SelectedItem is WordItem item)
            {
                if (cmbAnh.Text != item.Word)
                {
                    cmbAnh.Text = item.Word;
                }
            }
        }
        // Yêu cầu 2: Double click vào từ cần tra để hiển thị nghĩa
        private void LstAnh_DoubleClick(object sender, EventArgs e)
        {
            HienThiNghiaAnhViet();
        }
        private void HienThiNghiaAnhViet()
        {
            if (lstAnh.SelectedItem is WordItem item)
            {
                txtNghiaViet.Text = item.Meaning;
            }
            else
            {
                string searchWord = cmbAnh.Text.Trim();
                var found = listAnhViet.FirstOrDefault(x => x.Word.Equals(searchWord, StringComparison.OrdinalIgnoreCase));
                if (found != null)
                {
                    txtNghiaViet.Text = found.Meaning;
                }
                else
                {
                    txtNghiaViet.Text = "Không tìm thấy từ này trong từ điển!";
                }
            }
        }
        // --- XỬ LÝ TAB VIỆT - ANH ---
        private void CmbViet_TextChanged(object sender, EventArgs e)
        {
            string keyword = cmbViet.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword)) return;
            for (int i = 0; i < lstViet.Items.Count; i++)
            {
                WordItem item = (WordItem)lstViet.Items[i];
                if (item.Word.ToLower().StartsWith(keyword))
                {
                    lstViet.SelectedIndex = i;
                    break;
                }
            }
        }
        private void CmbViet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HienThiNghiaVietAnh();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void LstViet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstViet.SelectedItem is WordItem item)
            {
                if (cmbViet.Text != item.Word)
                {
                    cmbViet.Text = item.Word;
                }
            }
        }
        private void LstViet_DoubleClick(object sender, EventArgs e)
        {
            HienThiNghiaVietAnh();
        }
        private void HienThiNghiaVietAnh()
        {
            if (lstViet.SelectedItem is WordItem item)
            {
                txtNghiaAnh.Text = item.Meaning;
            }
            else
            {
                string searchWord = cmbViet.Text.Trim();
                var found = listVietAnh.FirstOrDefault(x => x.Word.Equals(searchWord, StringComparison.OrdinalIgnoreCase));
                if (found != null)
                {
                    txtNghiaAnh.Text = found.Meaning;
                }
                else
                {
                    txtNghiaAnh.Text = "Không tìm thấy từ này trong từ điển!";
                }
            }
        }
        // --- NÚT THOÁT ---
        private void BtnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Bạn có chắc muốn thoát khỏi chương trình?", 
                "Xác nhận thoát", 
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
