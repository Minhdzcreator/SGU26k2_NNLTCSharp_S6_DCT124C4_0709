#nullable disable
using System;
using System.Drawing;
using System.Windows.Forms;
namespace QuanLySinhVienApp
{
    public partial class Form1 : Form
    {
        // Khai báo các Control giao diện
        private TreeView trvDanhSach;
        private Label lblChonLop, lblMaSV, lblHoTen, lblDiaChi, lblTenLop;
        private ComboBox cmbChonLop;
        private GroupBox grpSV, grpLop;
        private TextBox txtMaSV, txtHoTen, txtDiaChi, txtTenLop;
        private Button btnCapNhat, btnXoa, btnThemLop;
        private CheckBox chkThemLop;
        public Form1()
        {
            InitializeCustomComponent();
            InitData();
        }
        private void InitializeCustomComponent()
        {
            // Cấu hình Form
            this.Text = "Quản lý sinh viên";
            this.Size = new Size(680, 520);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            // 1. TreeView bên trái hiển thị Danh sách lớp
            trvDanhSach = new TreeView();
            trvDanhSach.Location = new Point(15, 15);
            trvDanhSach.Size = new Size(250, 440);
            trvDanhSach.AfterSelect += trvDanhSach_AfterSelect;
            this.Controls.Add(trvDanhSach);
            int rightX = 280;
            // 2. ComboBox Chọn Lớp
            lblChonLop = new Label();
            lblChonLop.Text = "Chọn Lớp";
            lblChonLop.Location = new Point(rightX, 20);
            lblChonLop.AutoSize = true;
            this.Controls.Add(lblChonLop);
            cmbChonLop = new ComboBox();
            cmbChonLop.Location = new Point(360, 17);
            cmbChonLop.Size = new Size(270, 25);
            cmbChonLop.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(cmbChonLop);
            // 3. GroupBox Thông tin sinh viên
            grpSV = new GroupBox();
            grpSV.Text = "Thông tin sinh viên";
            grpSV.Location = new Point(rightX, 55);
            grpSV.Size = new Size(350, 210);
            lblMaSV = new Label { Text = "Mã SV:", Location = new Point(20, 30), AutoSize = true };
            txtMaSV = new TextBox { Location = new Point(90, 27), Size = new Size(230, 25) };
            lblHoTen = new Label { Text = "Họ Tên:", Location = new Point(20, 70), AutoSize = true };
            txtHoTen = new TextBox { Location = new Point(90, 67), Size = new Size(230, 25) };
            lblDiaChi = new Label { Text = "Địa Chỉ:", Location = new Point(20, 110), AutoSize = true };
            txtDiaChi = new TextBox { Location = new Point(90, 107), Size = new Size(230, 25) };
            btnCapNhat = new Button { Text = "Cập Nhật", Location = new Point(90, 150), Size = new Size(100, 35) };
            btnCapNhat.Click += BtnCapNhat_Click;
            btnXoa = new Button { Text = "Xóa", Location = new Point(220, 150), Size = new Size(100, 35) };
            btnXoa.Click += BtnXoa_Click;
            grpSV.Controls.Add(lblMaSV);
            grpSV.Controls.Add(txtMaSV);
            grpSV.Controls.Add(lblHoTen);
            grpSV.Controls.Add(txtHoTen);
            grpSV.Controls.Add(lblDiaChi);
            grpSV.Controls.Add(txtDiaChi);
            grpSV.Controls.Add(btnCapNhat);
            grpSV.Controls.Add(btnXoa);
            this.Controls.Add(grpSV);
            // 4. CheckBox Thêm lớp
            chkThemLop = new CheckBox();
            chkThemLop.Text = "Thêm lớp";
            chkThemLop.Location = new Point(rightX, 280);
            chkThemLop.AutoSize = true;
            chkThemLop.Checked = false;
            chkThemLop.CheckedChanged += ChkThemLop_CheckedChanged;
            this.Controls.Add(chkThemLop);
            // 5. GroupBox Thông tin lớp
            grpLop = new GroupBox();
            grpLop.Text = "Thông tin lớp";
            grpLop.Location = new Point(rightX, 310);
            grpLop.Size = new Size(350, 80);
            grpLop.Visible = false;
            lblTenLop = new Label { Text = "Tên lớp", Location = new Point(20, 30), AutoSize = true };
            txtTenLop = new TextBox { Location = new Point(90, 27), Size = new Size(140, 25) };
            btnThemLop = new Button { Text = "Thêm lớp", Location = new Point(240, 25), Size = new Size(90, 30) };
            btnThemLop.Click += BtnThemLop_Click;
            grpLop.Controls.Add(lblTenLop);
            grpLop.Controls.Add(txtTenLop);
            grpLop.Controls.Add(btnThemLop);
            this.Controls.Add(grpLop);
        }
        private void InitData()
        {
            TreeNode rootNode = new TreeNode("Danh sách lớp");
            string[] danhSachLop = { "05DHTH1", "05DHTH2", "05DHTH3", "05DHTH4" };
            foreach (string tenLop in danhSachLop)
            {
                rootNode.Nodes.Add(new TreeNode(tenLop));
                cmbChonLop.Items.Add(tenLop);
            }
            trvDanhSach.Nodes.Add(rootNode);
            rootNode.Expand();
            if (cmbChonLop.Items.Count > 0)
            {
                cmbChonLop.SelectedIndex = 0;
            }
        }
        private void ChkThemLop_CheckedChanged(object sender, EventArgs e)
        {
            grpLop.Visible = chkThemLop.Checked;
        }
        private void BtnThemLop_Click(object sender, EventArgs e)
        {
            string tenLopMoi = txtTenLop.Text.Trim();
            if (string.IsNullOrWhiteSpace(tenLopMoi))
            {
                MessageBox.Show("Vui lòng nhập tên lớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLop.Focus();
                return;
            }
            if (cmbChonLop.Items.Contains(tenLopMoi))
            {
                MessageBox.Show("Tên lớp này đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLop.SelectAll();
                txtTenLop.Focus();
                return;
            }
            TreeNode root = trvDanhSach.Nodes[0];
            root.Nodes.Add(new TreeNode(tenLopMoi));
            root.Expand();
            cmbChonLop.Items.Add(tenLopMoi);
            cmbChonLop.SelectedItem = tenLopMoi;
            txtTenLop.Clear();
            MessageBox.Show("Thêm lớp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void BtnCapNhat_Click(object sender, EventArgs e)
        {
            if (cmbChonLop.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn lớp!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string maSV = txtMaSV.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            if (string.IsNullOrWhiteSpace(maSV) || string.IsNullOrWhiteSpace(hoTen) || string.IsNullOrWhiteSpace(diaChi))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã SV, Họ Tên và Địa Chỉ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTraTrungMaSV(trvDanhSach.Nodes[0], maSV))
            {
                MessageBox.Show("Mã sinh viên này đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaSV.Focus();
                return;
            }
            string tenLop = cmbChonLop.SelectedItem.ToString();
            TreeNode nodeLopTarget = null;
            foreach (TreeNode nodeLop in trvDanhSach.Nodes[0].Nodes)
            {
                if (nodeLop.Text == tenLop)
                {
                    nodeLopTarget = nodeLop;
                    break;
                }
            }
            if (nodeLopTarget != null)
            {
                TreeNode nodeSV = new TreeNode($"{maSV}, {hoTen}");
                nodeSV.Tag = new StudentInfo { MaSV = maSV, HoTen = hoTen, DiaChi = diaChi };
                TreeNode nodeDC = new TreeNode(diaChi);
                nodeSV.Nodes.Add(nodeDC);
                nodeLopTarget.Nodes.Add(nodeSV);
                nodeLopTarget.Expand();
                nodeSV.Expand();
                txtMaSV.Clear();
                txtHoTen.Clear();
                txtDiaChi.Clear();
                txtMaSV.Focus();
            }
        }
        private bool KiemTraTrungMaSV(TreeNode parentNode, string maSV)
        {
            foreach (TreeNode node in parentNode.Nodes)
            {
                if (node.Tag is StudentInfo info && info.MaSV.Equals(maSV, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
                if (KiemTraTrungMaSV(node, maSV))
                {
                    return true;
                }
            }
            return false;
        }
        private void trvDanhSach_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = e.Node;
            if (selectedNode == null) return;
            if (selectedNode.Tag is StudentInfo info)
            {
                txtMaSV.Text = info.MaSV;
                txtHoTen.Text = info.HoTen;
                txtDiaChi.Text = info.DiaChi;
                if (selectedNode.Parent != null && cmbChonLop.Items.Contains(selectedNode.Parent.Text))
                {
                    cmbChonLop.SelectedItem = selectedNode.Parent.Text;
                }
            }
            else if (selectedNode.Parent != null && selectedNode.Parent.Tag is StudentInfo parentInfo)
            {
                txtMaSV.Text = parentInfo.MaSV;
                txtHoTen.Text = parentInfo.HoTen;
                txtDiaChi.Text = parentInfo.DiaChi;
                if (selectedNode.Parent.Parent != null && cmbChonLop.Items.Contains(selectedNode.Parent.Parent.Text))
                {
                    cmbChonLop.SelectedItem = selectedNode.Parent.Parent.Text;
                }
            }
        }
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = trvDanhSach.SelectedNode;
            TreeNode svNodeToDelete = null;
            if (selectedNode != null)
            {
                if (selectedNode.Tag is StudentInfo)
                {
                    svNodeToDelete = selectedNode;
                }
                else if (selectedNode.Parent != null && selectedNode.Parent.Tag is StudentInfo)
                {
                    svNodeToDelete = selectedNode.Parent;
                }
            }
            if (svNodeToDelete == null)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa trong TreeView!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            StudentInfo info = (StudentInfo)svNodeToDelete.Tag;
            DialogResult dr = MessageBox.Show(
                $"Bạn có chắc muốn xóa sinh viên: {info.HoTen} ({info.MaSV}) không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (dr == DialogResult.Yes)
            {
                svNodeToDelete.Remove();
                txtMaSV.Clear();
                txtHoTen.Clear();
                txtDiaChi.Clear();
                MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
    public class StudentInfo
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
    }
}
