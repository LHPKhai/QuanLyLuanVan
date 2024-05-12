//using BUS_QuanLy;
//using DTO_QuanLy;
using QuanLyLuanAn.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;
using System.Windows.Forms;

namespace QuanLyLuanAn
{
    public partial class FDangNhap : Form
    {

        public FDangNhap()
        {
            InitializeComponent();
        }

        #region Phương thức
        private void ChuyenForm()
        {
            Form form;
            if (Hotro.user.VaiTro == "SinhVien" || Hotro.user.VaiTro == "NhomTruong")
            {
                form = new FSinhVien();
            }
            else if (Hotro.user.VaiTro == "GiangVien")
            {
                form = new FGiangVien();
            }
            else
                form = new Form();
            form.ShowDialog();
        }

        #endregion
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            var email = txtTenDangNhap.Text.Trim();
            var matKhau = txtMatKhau.Text.Trim();
            PNguoiDung thaotac = new PNguoiDung();
            Hotro.user = thaotac.Login(email, matKhau);
            if (Hotro.user != null)
            {
                ChuyenForm();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
