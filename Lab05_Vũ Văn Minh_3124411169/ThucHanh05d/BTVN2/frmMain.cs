#nullable disable
using System;
using System.Drawing;
using System.Windows.Forms;
namespace BTVN_Tuan6App
{
    public partial class frmMain : Form
    {
        private MenuStrip menuStripMain;
        private ToolStripMenuItem tsmiBaiTap;
        private ToolStripMenuItem tsmiBai1;
        private ToolStripMenuItem tsmiBai2;
        private ToolStripMenuItem tsmiBaiNangCao;
        private ToolStripMenuItem tsmiBaiVeNha1;
        private ToolStripMenuItem tsmiThoat;
        public frmMain()
        {
            InitializeCustomComponent();
        }
        private void InitializeCustomComponent()
        {
            // 1. Cấu hình Form Main làm MDI Container
            this.Text = "BTVN_Tuan6 - Quản lý bài tập tuần 6";
            this.Size = new Size(1000, 750);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.IsMdiContainer = true; // Bật tính năng cửa sổ cha chứa Form con
            // 2. Khởi tạo MenuStrip
            menuStripMain = new MenuStrip();
            // Menu chính "Bài tập"
            tsmiBaiTap = new ToolStripMenuItem("Bài tập");
            tsmiBai1 = new ToolStripMenuItem("Bài 1 Tại lớp - Quản lý sinh viên (ListView)");
            tsmiBai1.Click += TsmiBai1_Click;
            tsmiBai2 = new ToolStripMenuItem("Bài 2 Tại lớp - Quản lý tài khoản ngân hàng");
            tsmiBai2.Click += TsmiBai2_Click;
            tsmiBaiNangCao = new ToolStripMenuItem("Bài Nâng cao - Quản lý học viên");
            tsmiBaiNangCao.Click += TsmiBaiNangCao_Click;
            tsmiBaiVeNha1 = new ToolStripMenuItem("Bài Về nhà 1 - Đồng hồ đếm ngược");
            tsmiBaiVeNha1.Click += TsmiBaiVeNha1_Click;
            tsmiBaiTap.DropDownItems.Add(tsmiBai1);
            tsmiBaiTap.DropDownItems.Add(tsmiBai2);
            tsmiBaiTap.DropDownItems.Add(new ToolStripSeparator());
            tsmiBaiTap.DropDownItems.Add(tsmiBaiNangCao);
            tsmiBaiTap.DropDownItems.Add(tsmiBaiVeNha1);
            // Nút "Thoát"
            tsmiThoat = new ToolStripMenuItem("Thoát");
            tsmiThoat.Click += TsmiThoat_Click;
            // Thêm các menu vào MenuStrip
            menuStripMain.Items.Add(tsmiBaiTap);
            menuStripMain.Items.Add(tsmiThoat);
            this.MainMenuStrip = menuStripMain;
            this.Controls.Add(menuStripMain);
            this.FormClosing += FrmMain_FormClosing;
        }
        // --- HÀM PHỤ: Mở Form con (Ngăn ngừa mở trùng lặp cửa sổ) ---
        private void ShowChildForm<T>() where T : Form, new()
        {
            foreach (Form child in this.MdiChildren)
            {
                if (child is T)
                {
                    child.Activate(); // Nếu đã mở thì kích hoạt mang lên trước
                    return;
                }
            }
            T newChild = new T();
            newChild.MdiParent = this;
            newChild.Show();
        }
        private void TsmiBai1_Click(object sender, EventArgs e)
        {
            ShowChildForm<frmBaiTap1>();
        }
        private void TsmiBai2_Click(object sender, EventArgs e)
        {
            ShowChildForm<frmBaiTap2>();
        }
        private void TsmiBaiNangCao_Click(object sender, EventArgs e)
        {
            ShowChildForm<frmBaiTapNangCao>();
        }
        private void TsmiBaiVeNha1_Click(object sender, EventArgs e)
        {
            ShowChildForm<frmBaiTapVeNha1>();
        }
        private void TsmiThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Bạn có chắc muốn đóng chương trình chính?",
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
