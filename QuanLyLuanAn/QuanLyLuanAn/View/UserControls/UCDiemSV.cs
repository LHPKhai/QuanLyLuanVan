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
    public partial class UCDiemSV : UserControl
    {
        public UCDiemSV(Nhom thanhvien)
        {
            InitializeComponent();
            lblID.Text = thanhvien.ThanhVienID.ToString();
            PNguoiDung pNguoiDung = new PNguoiDung();
            lblHoVaTen.Text = pNguoiDung.LayNguoiDungTheoID(thanhvien.ThanhVienID).HoTen;
            lblLuanVan.Text = thanhvien.LuanVanID.ToString();
            lblMucDoHoanThanh.Text = thanhvien.TiLeHoanThanh.ToString();
            lblDiem.Text = thanhvien.Diem.ToString();
        }
    }
}
