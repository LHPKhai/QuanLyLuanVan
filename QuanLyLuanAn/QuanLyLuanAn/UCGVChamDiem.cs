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
    public partial class UCGVChamDiem : UserControl
    {
        HoiDongChamThi nguoiCham;
        public UCGVChamDiem(HoiDongChamThi nguoiCham)
        {
            InitializeComponent();
            this.nguoiCham = nguoiCham;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            PHoiDong pHoiDong = new PHoiDong();
            pHoiDong.Xoa(nguoiCham.ID);
            this.Hide();
        }

        private void UCGVChamDiem_Load(object sender, EventArgs e)
        {
            PNguoiDung pNguoiDung = new PNguoiDung();

            lblTenGiangVien.Text = pNguoiDung.LayNguoiDungTheoID(nguoiCham.GiangVienID).HoTen.ToString();
            lblDiem.Text = nguoiCham.Diem.ToString();
            if (Hotro.user.VaiTro != "GiangVien")
            {
                btnThoat.Visible = false;
            }
        }
    }
}
