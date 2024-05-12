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
    public partial class UCHienThiNV : UserControl
    {
        NhiemVu nhiemVu;
        public EventHandler LoadLaiForm;
        public UCHienThiNV(NhiemVu nhiemVu)
        {
            InitializeComponent();
            this.nhiemVu = nhiemVu;
        }

        private void UCHienThiNV_Load(object sender, EventArgs e)
        {
            if (Hotro.user.VaiTro == "SinhVien" && nhiemVu.NguoiDuocGiao != Hotro.user.ID)
            {
                btnChiTiet.Visible = false;
            }
            lblTieuDe.Text = nhiemVu.TieuDe;
            txtDenHan.Text = nhiemVu.ThoiGianDenHan.ToString();
            if (nhiemVu.TiLePhanCham == null)
            {
                txtTienDo.Text = "0%";
            }
            else
            {
                txtTienDo.Text = nhiemVu.TiLePhanCham.ToString();
            }
            if (nhiemVu.NguoiDuocGiao == null)
            {
                txtNguoiThucHien.Text = "Chưa có ai nhận";
            }
            else
            {
                PNguoiDung pNguoiDung = new PNguoiDung();
                string hoten = pNguoiDung.LayNguoiDungTheoID((int)nhiemVu.NguoiDuocGiao).HoTen.ToString();
                txtNguoiThucHien.Text = hoten;
            }
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            FChiTietNVNhan f = new FChiTietNVNhan(nhiemVu);
            f.LoadLaiForm += LoadLaiForm;
            f.Show();
        }
    }
}
