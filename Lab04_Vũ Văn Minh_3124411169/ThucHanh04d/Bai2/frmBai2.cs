using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace WinFormsApp
{
    public partial class frmBai2 : Form
    {
        private MangSoNguyen mang;
        public frmBai2()
        {
            InitializeComponent();
            mang = new MangSoNguyen();
        }
        // --- NÚT THỰC HIỆN (SẮP XẾP) ---
        private void btnThucHien_Click(object sender, EventArgs e)
        {
            List<int> list = MangSoNguyen.ParseString(txtNhapMang.Text);
            if (list.Count == 0)
            {
                MessageBox.Show("Vui lòng nhập mảng số nguyên hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            mang = new MangSoNguyen(list);
            if (rdoSapXepTang.Checked)
                mang.SapXepTang();
            else if (rdoSapXepGiam.Checked)
                mang.SapXepGiam();
            txtKetQuaMang.Text = mang.InMang();
        }
        // --- TÌM KIẾM ---
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (rdoTimGiaTri.Checked)
            {
                if (int.TryParse(txtTimGiaTri.Text, out int val))
                {
                    int pos = mang.TimViTriDauTien(val);
                    txtSoTimDuoc.Text = pos != -1 ? pos.ToString() : "Không thấy";
                }
            }
            else if (rdoTimViTri.Checked)
            {
                if (int.TryParse(txtTimViTri.Text, out int pos))
                {
                    int val = mang.TimGiaTriTaiViTri(pos);
                    txtSoTimDuoc.Text = val != int.MinValue ? val.ToString() : "Không hợp lệ";
                }
            }
        }
        // --- XÓA ---
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (rdoXoaGiaTri.Checked)
            {
                if (int.TryParse(txtXoaGiaTri.Text, out int val) && mang.XoaTheoGiaTri(val))
                    txtKetQuaMang.Text = mang.InMang();
                else
                    MessageBox.Show("Không tìm thấy giá trị cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (rdoXoaViTri.Checked)
            {
                if (int.TryParse(txtXoaViTri.Text, out int pos) && mang.XoaTheoViTri(pos))
                    txtKetQuaMang.Text = mang.InMang();
                else
                    MessageBox.Show("Vị trí xóa không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // --- THÊM ---
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtGiaTriThem.Text, out int val) && int.TryParse(txtViTriThem.Text, out int pos))
            {
                if (mang.ThemTaiViTri(val, pos))
                    txtKetQuaMang.Text = mang.InMang();
                else
                    MessageBox.Show("Vị trí thêm không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // --- TÍNH TỔNG ---
        private void btnTong_Click(object sender, EventArgs e)
        {
            txtTongMang.Text = mang.TongMang().ToString();
            txtTongChan.Text = mang.TongChan().ToString();
            txtTongLe.Text = mang.TongLe().ToString();
        }
        // --- MAX - MIN ---
        private void btnTimMaxMin_Click(object sender, EventArgs e)
        {
            txtMax.Text = mang.TimMax().ToString();
            txtMin.Text = mang.TimMin().ToString();
        }
        // --- THAY THẾ ---
        private void btnThayThe_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtSoThayThe.Text, out int valMoi))
            {
                MessageBox.Show("Vui lòng nhập 'Số thay thế'!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (rdoThayTheGiaTri.Checked && int.TryParse(txtThayTheGiaTri.Text, out int valCu))
            {
                if (mang.ThayTheTheoGiaTri(valCu, valMoi))
                    txtKetQuaMang.Text = mang.InMang();
                else
                    MessageBox.Show("Không tìm thấy giá trị cần thay thế!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (rdoThayTheViTri.Checked && int.TryParse(txtThayTheViTri.Text, out int pos))
            {
                if (mang.ThayTheTheoViTri(pos, valMoi))
                    txtKetQuaMang.Text = mang.InMang();
                else
                    MessageBox.Show("Vị trí cần thay thế không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // --- RESET ---
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtNhapMang.Clear();
            txtKetQuaMang.Clear();
            txtTimGiaTri.Clear(); txtTimViTri.Clear(); txtSoTimDuoc.Clear();
            txtXoaGiaTri.Clear(); txtXoaViTri.Clear();
            txtGiaTriThem.Clear(); txtViTriThem.Clear();
            txtTongMang.Clear(); txtTongChan.Clear(); txtTongLe.Clear();
            txtMax.Clear(); txtMin.Clear();
            txtThayTheGiaTri.Clear(); txtThayTheViTri.Clear(); txtSoThayThe.Clear();
        }
        // --- THOÁT CÓ XÁC NHẬN ---
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmBai2_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát chương trình?", "Xác nhận",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);
            if (r == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
