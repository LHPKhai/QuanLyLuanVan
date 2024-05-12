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
    public partial class FHoiDongChamDiem : Form
    {
        LuanVan luanVan;
        List<HoiDongChamThi> hoidong;
        PNguoiDung pNguoiDung;
        PHoiDong pHoiDong;
        NguoiDung giangVienCham;
        public FHoiDongChamDiem(LuanVan luanVan)
        {
            InitializeComponent();
            this.luanVan = luanVan;
            hoidong = new List<HoiDongChamThi>();
            pNguoiDung = new PNguoiDung();
            pHoiDong = new PHoiDong();
            giangVienCham = pNguoiDung.LayNguoiDungTheoID((int)luanVan.GiangVienID);
        }
        #region Phương thức
        private void ThemGiangVienVaoCombobox()
        {
            var cotGiangVienID = pNguoiDung.LayDanhSachGiangVien();
            cbGiangVien.DataSource = cotGiangVienID;
            cbGiangVien.DisplayMember = "HoTen";
            cbGiangVien.ValueMember = "ID";
        }

        private void LoadUCSinhVien()
        {
            PNhom pNhom = new PNhom();

            flpSinhVien.Controls.Clear();
            foreach (Nhom n in pNhom.LayDanhSachNhomTheoLuanVanID(luanVan.ID))
            {
                UCDiemSV uc = new UCDiemSV(n);
                flpSinhVien.Controls.Add(uc);
            }
        }

        private void LoadUCGiangVien()
        {
            hoidong = pHoiDong.Load().Where(hd => hd.LuanVanID == luanVan.ID).ToList();
            flpGiangVien.Controls.Clear();
            foreach (HoiDongChamThi nguoiCham in hoidong)
            {
                UCGVChamDiem uc = new UCGVChamDiem(nguoiCham);
                flpGiangVien.Controls.Add(uc);
            }
        }

        private void HienThiDuLieu()
        {
            lblTenGVHD.Text = Hotro.user.HoTen;
            lblTenGVHD2.Text = giangVienCham.HoTen;
            lblTenLuanVan.Text = luanVan.TieuDe;
            lblTenLuanVan2.Text = luanVan.TieuDe;
            txtDiemHoiDong.Text = luanVan.Diem.ToString();
            if (Hotro.user.ID != giangVienCham.ID)
            {
                tabGVHD.Visible = false;
            }
        }
        #endregion

        private void FHoiDongChamDiem_Load(object sender, EventArgs e)
        {
            HienThiDuLieu();
            hoidong = pHoiDong.Load().Where(hd => hd.LuanVanID == luanVan.ID).ToList();
            if (hoidong.Find(hd => hd.GiangVienID == Hotro.user.ID) == null)
            {
                HoiDongChamThi nguoiCham = new HoiDongChamThi();
                nguoiCham.LuanVanID = luanVan.ID;
                nguoiCham.GiangVienID = Hotro.user.ID;
                pHoiDong.Them(nguoiCham);
            }

            PLuanVan pLuanVan = new PLuanVan();
            luanVan = pLuanVan.LayLuanVanTheoID(luanVan.ID);


            HoiDongChamThi giangVienHuongDan = pHoiDong.LayTheoID(Hotro.user.ID, luanVan.ID);
            if (giangVienHuongDan.Diem != null)
            {
                txtDiem.Text = giangVienHuongDan.Diem.ToString();
            }
            if (giangVienHuongDan.NhanXet != null)
            {
                txtNhanXet.Text = giangVienHuongDan.NhanXet.ToString();
            }
            LoadUCSinhVien();
            ThemGiangVienVaoCombobox();
            LoadUCGiangVien();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            hoidong = pHoiDong.Load().Where(hd => hd.LuanVanID == luanVan.ID).ToList();
            if (cbGiangVien.SelectedValue != null && hoidong.Find(hd => hd.GiangVienID.ToString() == cbGiangVien.SelectedValue.ToString()) != null)
            {
                FThongBao f = new FThongBao("Giảng viên này đã có trong danh sách chấm thi");
                f.Show();
            }
            else
            {
                HoiDongChamThi nguoiCham = new HoiDongChamThi();
                nguoiCham.LuanVanID = luanVan.ID;
                int nguoi;
                if (int.TryParse(cbGiangVien.SelectedValue.ToString(), out int nguoiDuocGiao))
                {
                    nguoiCham.GiangVienID = nguoiDuocGiao;
                }
                hoidong.Add(nguoiCham);
                pHoiDong.Them(nguoiCham);
                LoadUCGiangVien();
            }
        }

        private void txtDiem_TextChanged(object sender, EventArgs e)
        {
            int diem = 0;
            HoiDongChamThi giangVienHuongDan = pHoiDong.LayTheoID(Hotro.user.ID, luanVan.ID);
            if (int.TryParse(txtDiem.Text, out diem))
            {
                giangVienHuongDan.Diem = diem;
            }
            pHoiDong.CapNhat(giangVienHuongDan);
            FHoiDongChamDiem_Load(sender, e);
        }

        private void txtNhanXet_TextChanged(object sender, EventArgs e)
        {
            HoiDongChamThi giangVienHuongDan = pHoiDong.LayTheoID(Hotro.user.ID, luanVan.ID);
            giangVienHuongDan.NhanXet = txtNhanXet.Text;
            pHoiDong.CapNhat(giangVienHuongDan);
            FHoiDongChamDiem_Load(sender, e);
        }

        private void btnGuiDiem_Click(object sender, EventArgs e)
        {
            PThongBao pThongBao = new PThongBao();
            PNhom pNhom = new PNhom();

            flpSinhVien.Controls.Clear();
            foreach (Nhom n in pNhom.LayDanhSachNhomTheoLuanVanID(luanVan.ID))
            {
                pThongBao.ThemThongBaoDiemLuanVan(n.ThanhVienID, n.LuanVanID, (int)n.Diem);
            }
        }
    }
}
