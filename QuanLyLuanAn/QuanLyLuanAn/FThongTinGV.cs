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
    public partial class FThongTinGV : Form
    {
        public FThongTinGV()
        {
            InitializeComponent();
        }

        private void FThongTinGV_Load(object sender, EventArgs e)
        {
            lblID.Text = Hotro.user.ID.ToString();
            lblHoTen.Text = Hotro.user.HoTen;
            lblNgaySinh.Text = Hotro.user.NgaySinh.Value.ToString("dd/MM/yyyy");
            lblGioiTinh.Text = Hotro.user.GioiTinh;
            lblSdt.Text = Hotro.user.SoDienThoai;
            lblEmail.Text = Hotro.user.Email;
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            FDoiMatKhau f = new FDoiMatKhau();
            f.ShowDialog();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            FCapNhatThongTInGV f = new FCapNhatThongTInGV(Hotro.user);
            f.Show();
        }
    }
}
