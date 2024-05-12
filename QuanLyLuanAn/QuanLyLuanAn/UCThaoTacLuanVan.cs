//using BUS_QuanLy;
//using DTO_QuanLy;
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
    public partial class UCThaoTacLuanVan : UserControl
    {
        public EventHandler DongUC;
        PLuanVan thaotac = new PLuanVan();
        public UCThaoTacLuanVan()
        {
            InitializeComponent();
        }
        #region Phương thức
        private void LamMoi()
        {
            txtMota.Text = string.Empty;
            txtYeucau.Text = string.Empty;
            txtChucnang.Text = string.Empty;
            cbSoluongSV.Text = string.Empty;
            txtCongnghe.Text = string.Empty;
            txtTheLoai.Text = string.Empty;
            txtTieude.Text = string.Empty;
        }

        public void HienThi()
        {
            if (Hotro.thaotac == EThaotac.CapNhat)
            {
                txtMota.Text = Hotro.hienThi.MoTa;
                txtYeucau.Text = Hotro.hienThi.YeuCau;
                txtChucnang.Text = Hotro.hienThi.ChucNang;
                cbSoluongSV.Text = Hotro.hienThi.SoLuongSinhVien.ToString();
                txtCongnghe.Text = Hotro.hienThi.CongNghe;
                txtTheLoai.Text = Hotro.hienThi.TheLoai;
                txtTieude.Text = Hotro.hienThi.TieuDe;
            }
            else
            {
                LamMoi();
            }
        }

        private void LayDuLieu()
        {
            Hotro.hienThi.MoTa = txtMota.Text;
            Hotro.hienThi.YeuCau = txtYeucau.Text;
            Hotro.hienThi.ChucNang = txtChucnang.Text;
            Hotro.hienThi.SoLuongSinhVien = int.Parse(cbSoluongSV.Text);
            Hotro.hienThi.CongNghe = txtCongnghe.Text;
            Hotro.hienThi.TheLoai = txtTheLoai.Text;
            Hotro.hienThi.TieuDe = txtTieude.Text;
            Hotro.hienThi.GiangVienID = Hotro.user.ID;
        }
        #endregion

        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            LayDuLieu();
            if (Hotro.thaotac == EThaotac.CapNhat)
            {
                thaotac.CapNhat(Hotro.hienThi);
            }
            else
            {
                thaotac.Them(Hotro.hienThi);
            }
            DongUC.Invoke(this, new EventArgs());

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            DongUC.Invoke(this, new EventArgs());
        }

        public void UCThaoTacDeTai_Load(object sender, EventArgs e)
        {
            HienThi();
        }
    }
}
