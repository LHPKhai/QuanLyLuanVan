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
    public partial class FDiemSV : Form
    {
        public PLuanVan pLuanVan;
        PThongBao pThongBao;
        LuanVan luanVan;
        public FDiemSV()
        {
            InitializeComponent();
            pLuanVan = new PLuanVan();
            pThongBao = new PThongBao();
            luanVan = pLuanVan.LayLuanVanDaDangKyTheoSinhVienID(Hotro.user);
        }
        #region Phương thức
        private void LoadUCSinhVien()
        {
            PNhom pNhom = new PNhom();
            lblTenLuanVan.Text = luanVan.TieuDe;
            txtDiem.Text = luanVan.Diem.ToString();
            flpSinhVien.Controls.Clear();
            foreach (Nhom n in pNhom.LayDanhSachNhomTheoLuanVanID(luanVan.ID))
            {
                UCDiemSV uc = new UCDiemSV(n);
                flpSinhVien.Controls.Add(uc);
            }
        }

        private void LoadUCGiangVien()
        {
            PNguoiDung pNguoiDung = new PNguoiDung();
            lblTenGVHD.Text = pNguoiDung.LayNguoiDungTheoID(luanVan.GiangVienID).HoTen;
            PHoiDong pHoiDong = new PHoiDong();
            List<HoiDongChamThi> hoidong = pHoiDong.Load().Where(hd => hd.LuanVanID == luanVan.ID).ToList();
            flpGiangVien.Controls.Clear();
            foreach (HoiDongChamThi nguoiCham in hoidong)
            {
                UCGVChamDiem uc = new UCGVChamDiem(nguoiCham);
                flpGiangVien.Controls.Add(uc);
            }
        }
        #endregion
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xác nhận điểm luận văn này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                pThongBao.ThemThongBaoXacNhanDiemLuanVan(Hotro.user.ID, luanVan.ID);
                MessageBox.Show("Đã xác nhận điểm luận văn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPhucKhao_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn gửi yêu cầu phúc khảo điểm luận văn này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                pThongBao.ThemThongBaoPhucKhaoDiemLuanVan(Hotro.user.ID, luanVan.ID);
                MessageBox.Show("Đã gửi yêu cầu phúc khảo điểm luận văn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void FDiemSV_Load(object sender, EventArgs e)
        {
            LoadUCSinhVien();
            LoadUCGiangVien();
        }
    }
}
