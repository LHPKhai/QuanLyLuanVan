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
    public partial class FDSChamDiemLuanVan : Form
    {

        PLuanVan pLuanVan;
        List<LuanVan> ds;
        public EventHandler MoNhiemVu;
        public FDSChamDiemLuanVan()
        {
            InitializeComponent();
            pLuanVan = new PLuanVan();
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
            var cotTheLoai = pLuanVan.HienThiCotTheLoai(ds);
            var cotCongNghe = pLuanVan.HienThiCotCongNghe(ds);
            PNguoiDung bus = new PNguoiDung();
            var cotGiangVienID = bus.LayDanhSachGiangVien();
            foreach (var item in cotGiangVienID)
            {
                cbGiangVien.Items.Add(item.HoTen.ToString());
            }

            ThemItemVaoCombobox(cotTheLoai, cbTheLoai);
            ThemItemVaoCombobox(cotCongNghe, cbCongNghe);
        }

        private void LoadUCDeTai(List<LuanVan> danhSachLuanVan)
        {
            flpDanhSachLuanVan.Controls.Clear();
            foreach (LuanVan deTai in danhSachLuanVan)
            {
                if (deTai.GiangVienID == Hotro.user.ID)
                {
                    UCDeTaiChamDiem uc = new UCDeTaiChamDiem(deTai);
                    uc.MoNhiemVu += MoNhiemVu;
                    uc.LoadLaiForm += FDanhSachDeTai_Load;
                    flpDanhSachLuanVan.Controls.Add(uc);
                }
                else
                {
                    PHoiDong pHoiDong = new PHoiDong();
                    List<HoiDongChamThi> list = pHoiDong.LayDanhSachTheoLuanVanID(deTai.ID);
                    foreach (var item in list)
                    {
                        if (item.GiangVienID == Hotro.user.ID)
                        {
                            UCDeTaiChamDiem uc = new UCDeTaiChamDiem(deTai);
                            uc.MoNhiemVu += MoNhiemVu;
                            uc.LoadLaiForm += FDanhSachDeTai_Load;
                            flpDanhSachLuanVan.Controls.Add(uc);
                        }

                    }
                }
            }
        }
        #endregion
        private void FDanhSachDeTai_Load(object sender, EventArgs e)
        {
            if (Hotro.user.VaiTro == "GiangVien")
            {
                ds = pLuanVan.LocDanhSach(null, null, null, -1);
            }
            else
            {
                ds = pLuanVan.Load();
            }
            ThemVaoCombobox();
            LoadUCDeTai(ds);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            PNguoiDung bus = new PNguoiDung();
            int? maGV2 = bus.TraIDGiangVienTheoTen(cbGiangVien.SelectedItem?.ToString());

            string theLoai = cbTheLoai.SelectedItem?.ToString();
            if (theLoai == "Thể loại") theLoai = null;

            string congNghe = cbCongNghe.SelectedItem?.ToString();
            if (congNghe == "Công nghệ") congNghe = null;

            string soLuongSinhVienStr = cbSLsv.SelectedItem?.ToString();
            int soLuongSinhVien = -1;
            if (int.TryParse(soLuongSinhVienStr, out soLuongSinhVien)) { }
            else
            {
                soLuongSinhVien = -1;
            }

            ds = pLuanVan.LocDanhSach(maGV2, theLoai, congNghe, soLuongSinhVien);
            LoadUCDeTai(ds);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Hotro.thaotac = EThaotac.ThemMoi;
        }

    }
}
