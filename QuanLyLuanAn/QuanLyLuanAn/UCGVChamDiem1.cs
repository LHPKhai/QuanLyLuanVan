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
    public partial class UCGVChamDiem1 : UserControl
    {
        HoiDongChamThi nguoiCham;
        PHoiDong pHoiDong = new PHoiDong();
        public UCGVChamDiem1(HoiDongChamThi nguoiCham)
        {
            InitializeComponent();
            //txtID.Text = GiangVienID.ToString();
            this.nguoiCham = nguoiCham;
            if(nguoiCham.GiangVienID == Hotro.user.ID)
            {
                txtDiem.ReadOnly = false;
                btnXoa.Visible = false;
            }    
            PLuanVan pLuanVan =  new PLuanVan();
            PNguoiDung pNguoiDung = new PNguoiDung();
            txtTen.Text = pNguoiDung.LayNguoiDungTheoID(nguoiCham.GiangVienID).HoTen.ToString();
            if(nguoiCham.Diem != null)
            {
                txtDiem.Text = nguoiCham.Diem.ToString();
            }    
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            pHoiDong.Xoa(nguoiCham.ID);
            this.Hide();
        }

        private void txtDiem_TextChanged(object sender, EventArgs e)
        {
            int diem;
            if (int.TryParse(txtDiem.Text, out diem))
            {
                nguoiCham.Diem = diem;
            }
            pHoiDong.CapNhat(nguoiCham);
        }
    }
}
