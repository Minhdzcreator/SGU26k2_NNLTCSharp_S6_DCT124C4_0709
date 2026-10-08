using System;
using System.Windows.Forms;
namespace WinFormsApp
{
    public partial class frmBai01TL : Form
    {
        public frmBai01TL()
        {
            InitializeComponent();
        }
        private void frmBai01TL_Load(object sender, EventArgs e)
        {
            rdoBacNhat.Checked = true;
            CapNhatTrangThaiUI();
        }
        private void rdoLoaiPT_CheckedChanged(object sender, EventArgs e)
        {
            CapNhatTrangThaiUI();
            KiemTraDieuKienGiai();
        }
        private void CapNhatTrangThaiUI()
        {
            if (rdoBacNhat.Checked)
            {
                txtC.Enabled = false;
                lblC.Enabled = false;
                txtC.Clear();
            }
            else
            {
                txtC.Enabled = true;
                lblC.Enabled = true;
            }
            txtKetQua.Clear();
            btnGiai.Enabled = false;
        }
        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            txtKetQua.Clear();
            KiemTraDieuKienGiai();
        }
        private void KiemTraDieuKienGiai()
        {
            bool hopLeA = double.TryParse(txtA.Text, out _);
            bool hopLeB = double.TryParse(txtB.Text, out _);
            bool hopLeC = double.TryParse(txtC.Text, out _);
            if (rdoBacNhat.Checked)
            {
                btnGiai.Enabled = hopLeA && hopLeB && !string.IsNullOrWhiteSpace(txtA.Text) && !string.IsNullOrWhiteSpace(txtB.Text);
            }
            else
            {
                btnGiai.Enabled = hopLeA && hopLeB && hopLeC &&
                                  !string.IsNullOrWhiteSpace(txtA.Text) &&
                                  !string.IsNullOrWhiteSpace(txtB.Text) &&
                                  !string.IsNullOrWhiteSpace(txtC.Text);
            }
        }
        private void btnGiai_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            double a = double.Parse(txtA.Text);
            double b = double.Parse(txtB.Text);
            if (rdoBacNhat.Checked)
            {
                PhuongTrinhBacHai pt = new PhuongTrinhBacHai(a, b);
                txtKetQua.Text = pt.GiaiBacNhat();
            }
            else
            {
                double c = double.Parse(txtC.Text);
                PhuongTrinhBacHai pt = new PhuongTrinhBacHai(a, b, c);
                txtKetQua.Text = pt.GiaiBacHai();
            }
            btnGiai.Enabled = false;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmBai01TL_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát chương trình?", "Thoát",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question,
                                             MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
