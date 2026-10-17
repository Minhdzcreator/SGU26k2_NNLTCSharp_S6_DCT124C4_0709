#nullable disable
using System;
using System.Drawing;
using System.Windows.Forms;
namespace DanhBaApp
{
    public partial class Form1 : Form
    {
        // Khai báo các thành phần giao diện
        private TreeView trvDanhBa;
        private Panel pnlInput;
        private Label lblFirstName, lblLastName;
        private TextBox txtFirstName, txtLastName;
        private Button btnAdd, btnExit;
        public Form1()
        {
            InitializeCustomComponent();
            InitTreeViewAZ();
        }
        private void InitializeCustomComponent()
        {
            // Cấu hình Form cơ bản
            this.Text = "frmBTVN2";
            this.Size = new Size(580, 410);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            // 1. TreeView hiển thị danh bạ bên trái
            trvDanhBa = new TreeView();
            trvDanhBa.Location = new Point(15, 15);
            trvDanhBa.Size = new Size(220, 330);
            this.Controls.Add(trvDanhBa);
            // 2. Khung Panel nhập thông tin bên phải
            pnlInput = new Panel();
            pnlInput.BorderStyle = BorderStyle.FixedSingle;
            pnlInput.Location = new Point(250, 15);
            pnlInput.Size = new Size(300, 150);
            lblFirstName = new Label { Text = "First Name", Location = new Point(15, 20), AutoSize = true };
            txtFirstName = new TextBox { Location = new Point(100, 17), Size = new Size(180, 25) };
            lblLastName = new Label { Text = "Last Name", Location = new Point(15, 60), AutoSize = true };
            txtLastName = new TextBox { Location = new Point(100, 57), Size = new Size(180, 25) };
            btnAdd = new Button { Text = "Add", Location = new Point(190, 100), Size = new Size(90, 30) };
            btnAdd.Click += BtnAdd_Click;
            pnlInput.Controls.Add(lblFirstName);
            pnlInput.Controls.Add(txtFirstName);
            pnlInput.Controls.Add(lblLastName);
            pnlInput.Controls.Add(txtLastName);
            pnlInput.Controls.Add(btnAdd);
            this.Controls.Add(pnlInput);
            // 3. Nút Exit
            btnExit = new Button { Text = "Exit", Location = new Point(440, 230), Size = new Size(90, 30) };
            btnExit.Click += BtnExit_Click;
            this.Controls.Add(btnExit);
            this.AcceptButton = btnAdd;
            this.FormClosing += Form1_FormClosing;
        }
        // Yêu cầu 1: Khởi tạo TreeView chứa tất cả các ký tự từ A -> Z khi Form load
        private void InitTreeViewAZ()
        {
            trvDanhBa.Nodes.Clear();
            for (char c = 'A'; c <= 'Z'; c++)
            {
                trvDanhBa.Nodes.Add(new TreeNode(c.ToString()));
            }
        }
        // Yêu cầu 2: Thêm người mới vào TreeView theo chữ cái đầu của First Name
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            if (string.IsNullOrWhiteSpace(firstName))
            {
                MessageBox.Show("Vui lòng nhập First Name!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return;
            }
            // Lấy chữ cái đầu tiên của First Name và chuyển thành chữ HOA
            char firstChar = char.ToUpper(firstName[0]);
            // Tìm node gốc tương ứng (A -> Z) trong TreeView
            TreeNode targetNode = null;
            foreach (TreeNode node in trvDanhBa.Nodes)
            {
                if (node.Text.Equals(firstChar.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    targetNode = node;
                    break;
                }
            }
            if (targetNode != null)
            {
                // Định dạng chuỗi hiển thị: "First Name, Last Name"
                string displayName = string.IsNullOrWhiteSpace(lastName) 
                    ? firstName 
                    : $"{firstName}, {lastName}";
                targetNode.Nodes.Add(new TreeNode(displayName));
                targetNode.Expand(); // Mở rộng node chữ cái vừa thêm
                // Xóa dữ liệu ô nhập và đưa con trỏ về ô First Name
                txtFirstName.Clear();
                txtLastName.Clear();
                txtFirstName.Focus();
            }
            else
            {
                MessageBox.Show("First Name phải bắt đầu bằng chữ cái từ A đến Z!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Nút Exit thoát chương trình
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Bạn có chắc muốn thoát chương trình?", 
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
