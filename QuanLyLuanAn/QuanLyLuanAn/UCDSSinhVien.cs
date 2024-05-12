using DataLibrary;
using QuanLyLuanAn.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyLuanAn
{
    public partial class UCDSSinhVien : UserControl
    {
        public NguoiDung nguoiDung;
        public LuanVan luanVan;
        public Nhom nhom;
        public string gioiTinh;
        public EventHandler LoadUCNhiemVu;
        public UCDSSinhVien(NguoiDung nguoiDung, LuanVan luanVan, Nhom nhom)
        {
            InitializeComponent();
            this.nguoiDung = nguoiDung;
            this.luanVan = luanVan;
            this.nhom = nhom;
        }

        private void UCSVDuyet_Load(object sender, EventArgs e)
        {
            lblNgaySinh.Text = nguoiDung.NgaySinh.ToString();
            lblID.Text = nguoiDung.ID.ToString();
            lblTenSV.Text = nguoiDung.HoTen.ToString();
            lblSdt.Text = nguoiDung.SoDienThoai.ToString();
            lblGioiTinh.Text = nguoiDung.GioiTinh.ToString();
            if (lblGioiTinh.Text == "Nam")
            {
                gioiTinh = lblGioiTinh.Text;
            }
            else
            {
                gioiTinh = "Nữ";
            }
            lblEmail.Text = nguoiDung.Email.ToString();
            lblLuanVan.Text = luanVan.ID.ToString();
            if (nhom.Diem <= 10 && nhom.Diem >= 0)
            {
                lblDiem.Text = nhom.Diem.ToString();
            }
        }

    }
}