using DataLibrary;
using QuanLyLuanAn.BUS;
using QuanLyLuanAn.Presenter;
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
    public partial class UCMSSV : UserControl
    {
        Nhom u;
        PNguoiDung pNguoiDung;
        public UCMSSV()
        {
            InitializeComponent();
        }

        public UCMSSV(Nhom u)
        {
            InitializeComponent();
            this.u = u;
            pNguoiDung = new PNguoiDung();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (Hotro.user.VaiTro == "GiangVien")
            {
                DialogResult result = MessageBox.Show($"Giảng viên có chắc muốn xóa Sinh viên {u.ThanhVienID} khỏi luận văn không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    Hotro.nhoms.Remove(u);
                    FThongBao fThongBao = new FThongBao("Mời giảng viên nhập lý do xóa sinh viên", true);
                    fThongBao.Show();
                    result = fThongBao.ShowDialog();
                    if (result == DialogResult.Yes)
                    {
                        PNhom pNhom = new PNhom();
                        pNhom.XoaNhomTheoThanhVienID(u.ThanhVienID);
                        PThongBao pThongBao = new PThongBao();
                        pThongBao.ThemThongBaoXoaSinhVienKhoiLuanVan(u.ThanhVienID, u.LuanVanID, fThongBao.Return());
                    }
                    this.Hide();
                }
            }
        }

        private void UCMSSV_Load(object sender, EventArgs e)
        {
            NguoiDung nguoiDung = pNguoiDung.LayNguoiDungTheoID(u.ThanhVienID);
            lblMSSV.Text = nguoiDung.ID.ToString();
            lblHoTen.Text = nguoiDung.HoTen.ToString();
            if (nguoiDung.ID == Hotro.user.ID)
            {
                btnXoa.Visible = false;
            }
        }
    }
}
