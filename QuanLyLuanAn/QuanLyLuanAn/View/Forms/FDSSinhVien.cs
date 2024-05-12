using DataLibrary;
using QuanLyLuanAn.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyLuanAn
{
    public partial class FDSSinhVien : Form
    {
        PLuanVan pLuanVan;
        PNguoiDung PNguoiDung;
        PNhom pNhom;
        public EventHandler LoadUCNhiemVu;
        List<NguoiDung> nguoiDungs;
        List<LuanVan> luanVans;
        List<UserControl> userControls;
        public FDSSinhVien()
        {
            InitializeComponent();
            pLuanVan = new PLuanVan();
            PNguoiDung = new PNguoiDung();
            pNhom = new PNhom();
            nguoiDungs = PNguoiDung.LayDanhSach();
            luanVans = pLuanVan.Load().Where(lv => lv.GiangVienID == Hotro.user.ID).ToList();
            userControls = new List<UserControl>();
        }

        #region Phương thức
        private void ThemItemVaoCombobox<T>(IEnumerable<T> cot, ComboBox combo)
        {
            foreach (T item in cot)
            {
                combo.Items.Add(item);
            }
        }

        private void ThemVaoCombobox()
        {
            PLuanVan thaotac = new PLuanVan();
            List<LuanVan> ds = thaotac.LocDanhSach(Hotro.user.ID, null, null, -1);
            var cotMaLuanVan = thaotac.HienThiCotMaLuanVan(ds);
            PNguoiDung bus = new PNguoiDung();
            ThemItemVaoCombobox(cotMaLuanVan, cbMaLuanVan);
        }

        private void HienThiSinhVienDaDuocChapNhan()
        {
            List<LuanVan> ds = luanVans.Where(lv => lv.GiangVienID == Hotro.user.ID).ToList();
            flpDanhSachSV.Controls.Clear();

            foreach (LuanVan luanVan in ds)
            {
                List<Nhom> danhSachNhom = pNhom.LayDanhSachNhomTheoLuanVanID(luanVan.ID);
                foreach (Nhom nhom in danhSachNhom)
                {
                    NguoiDung nguoiDung = nguoiDungs.Find(nd => nd.ID == nhom.ThanhVienID);
                    if (nguoiDung != null && luanVan.TinhTrang == "Đã duyệt")
                    {
                        UCDSSinhVien uc = new UCDSSinhVien(nguoiDung, luanVan, nhom);
                        uc.LoadUCNhiemVu += LoadUCNhiemVu;
                        flpDanhSachSV.Controls.Add(uc);
                        userControls.Add(uc);
                    }
                }
            }
        }
        #endregion
        private void FDSSinhVien_Load(object sender, EventArgs e)
        {
            HienThiSinhVienDaDuocChapNhan();
            ThemVaoCombobox();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            flpDanhSachSV.Controls.Clear();
            string gioiTinh = cbGioiTinh.SelectedItem.ToString();
            string diem = cbDiem.Text;
            string maLuanVan = cbMaLuanVan.Text;
            foreach (UCDSSinhVien uc in userControls)
            {
                if (uc.gioiTinh == gioiTinh || gioiTinh == "Giới tính")
                {
                    if (uc.luanVan.ID.ToString() == maLuanVan || maLuanVan == "Mã Luận Văn")
                    {
                        if (uc.nhom.Diem.ToString() == diem || diem == "Điểm")
                        {
                            flpDanhSachSV.Controls.Add(uc);
                        }
                    }
                }
            }
        }
    }
}
