using DataLibrary;
using QuanLyLuanAn.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyLuanAn
{
    public partial class FDoiMatKhau : Form
    {
        public FDoiMatKhau()
        {
            InitializeComponent();
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            var mKCu = txtMKCu.Text.Trim();
            var mKMoi = txtMKMoi.Text.Trim();
            var nhapLai = txtNhapLai.Text.Trim();
            if (Hotro.user.MatKhau == mKCu)
            {
                if (mKMoi == nhapLai)
                {
                    PNguoiDung pNguoiDung = new PNguoiDung();
                    pNguoiDung.ChangePassword(Hotro.user.TenDangNhap, mKCu, mKMoi);
                }
            }
            this.Close();
            MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnhuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
