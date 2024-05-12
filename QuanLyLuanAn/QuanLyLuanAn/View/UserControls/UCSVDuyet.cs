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
    public partial class UCSVDuyet : UserControl
    {
        NguoiDung nguoiDung;
        LuanVan luanVan;
        Nhom nhom;
        public EventHandler LoadUCNhiemVu;
        public UCSVDuyet(NguoiDung nguoiDung, LuanVan luanVan, Nhom nhom)
        {
            InitializeComponent();
            this.nguoiDung = nguoiDung;
            this.luanVan = luanVan;
            this.nhom = nhom;
        }

        private void UCSVDuyet_Load(object sender, EventArgs e)
        {
            lblTenDeTai.Text = luanVan.TieuDe.ToString();
            lblD.Text = nguoiDung.ID.ToString();
            lblTenSV.Text = nguoiDung.HoTen.ToString();
            if (luanVan.TinhTrang == "Chưa duyệt")
            {
                btnChiTiet.Text = "Chi tiết";
            }
            if (luanVan.TinhTrang == "Chờ duyệt")
            {
                btnChiTiet.Visible = false;
            }
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            if (btnChiTiet.Text == "Chi tiết")
            {
                FDangKyLuanVan f = new FDangKyLuanVan(luanVan);
                f.Show();
            }
            else
            {
                Hotro.hienThi = luanVan;
                LoadUCNhiemVu(sender, e);
            }
        }
    }
}