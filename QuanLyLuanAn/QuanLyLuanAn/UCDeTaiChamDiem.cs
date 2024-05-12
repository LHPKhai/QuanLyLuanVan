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
    public partial class UCDeTaiChamDiem : UserControl
    {
        public EventHandler LoadLaiForm;
        public EventHandler MoNhiemVu;
        LuanVan luanVan;
        PNguoiDung pNguoiDung;
        public UCDeTaiChamDiem(LuanVan luanVan)
        {
            InitializeComponent();
            this.luanVan = luanVan;
            pNguoiDung = new PNguoiDung();
        }
        #region Phương thức
        private void HienThi(LuanVan luanVan)
        {
            lblMoTa.Text = luanVan.MoTa;
            lblTenDeTai.Text = luanVan.TieuDe;
            lblSoTV.Text = luanVan.SoLuongSinhVien.ToString();
            lblTenCongNghe.Text = luanVan.CongNghe;
            lblTenTheLoai.Text = luanVan.TheLoai;
            lblTenCongNghe.Text = luanVan.CongNghe;
            lblTenTheLoai.Text = luanVan.TheLoai;

            if (luanVan.TinhTrang != "Đã duyệt")
            {
                btnChamDiem.Text = "Chưa có SV";
            }
            NguoiDung giangVien = pNguoiDung.LayNguoiDungTheoID((int)luanVan.GiangVienID);
            if (giangVien != null)
            {
                lblTenGV.Text = giangVien.HoTen.ToString();
            }
        }
        #endregion

        private void btnNhiemVu_Click(object sender, EventArgs e)
        {
            if (luanVan.TinhTrang == "Đã duyệt")
            {
                Hotro.hienThi = luanVan;
                MoNhiemVu(sender, EventArgs.Empty);
            }
            else
            {
                FThongBao f = new FThongBao("Chưa có sinh viên nào!");
                f.Show();
            }
        }

        private void btnChamDiem_Click(object sender, EventArgs e)
        {
            if (luanVan.TinhTrang == "Đã duyệt")
            {
                FHoiDongChamDiem f = new FHoiDongChamDiem(luanVan);
                f.ShowDialog();
            }
        }

        private void UCDeTaiChamDiem_Load(object sender, EventArgs e)
        {
            HienThi(luanVan);
        }
    }
}
