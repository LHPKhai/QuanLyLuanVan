using DataLibrary;
using QuanLyLuanAn.BUS;
using QuanLyLuanAn.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Navigation;

namespace QuanLyLuanAn
{
    public partial class FCapNhatThongTinSV : Form
    {
        public FCapNhatThongTinSV()
        {
            InitializeComponent();
        }
        #region Phương thức
        private void TruyenDuLieu()
        {
            txtHoTen.Text = Hotro.user.HoTen;
            dtpTime.Value = Hotro.user.NgaySinh.Value;
            txtGioiTinh.Text = Hotro.user.GioiTinh;
            txtSdt.Text = Hotro.user.SoDienThoai;
            txtEmail.Text = Hotro.user.Email;
        }

        private void LayDuLieu()
        {
            Hotro.user.NgaySinh = dtpTime.Value;
            Hotro.user.GioiTinh = txtGioiTinh.Text;
            Hotro.user.SoDienThoai = txtSdt.Text;
            Hotro.user.Email = txtEmail.Text;
        }
        #endregion
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            LayDuLieu();
            PNguoiDung pNguoiDung = new PNguoiDung();
            pNguoiDung.CapNhat(Hotro.user);
            this.Close();
        }

        private void FCapNhatThongTinSV_Load(object sender, EventArgs e)
        {
            TruyenDuLieu();
        }
    }
}