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
    public partial class FDuyetLuanVan : Form
    {

        PLuanVan thaotac;
        List<LuanVan> ds;
        public FDuyetLuanVan()
        {
            InitializeComponent();
            thaotac = new PLuanVan();

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
            var cotTheLoai = thaotac.HienThiCotTheLoai(ds);
            var cotCongNghe = thaotac.HienThiCotCongNghe(ds);
            PNguoiDung bus = new PNguoiDung();

            ThemItemVaoCombobox(cotTheLoai, cbTheLoai);
            ThemItemVaoCombobox(cotCongNghe, cbCongNghe);
        }

        private void LoadUCDeTai(List<LuanVan> danhSachLuanVan)
        {
            flpDanhSachDeTai.Controls.Clear();
            foreach (LuanVan deTai in danhSachLuanVan)
            {
                UCDuyetDeTai uc = new UCDuyetDeTai(deTai);
                uc.LoadLaiForm += FDanhSachDeTai_Load;
                flpDanhSachDeTai.Controls.Add(uc);
            }
        }
        #endregion



        private void FDanhSachDeTai_Load(object sender, EventArgs e)
        {
            if (Hotro.user.VaiTro == "GiangVien")
            {
                ds = thaotac.LocDanhSach(Hotro.user.ID, null, null, -1);
            }
            else
            {
                ds = thaotac.Load();
            }
            ThemVaoCombobox();
            LoadUCDeTai(ds);
        }


        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            PNguoiDung bus = new PNguoiDung();

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

            if (Hotro.user.VaiTro == "GiangVien")
            {
                ds = thaotac.LocDanhSach(Hotro.user.ID, theLoai, congNghe, soLuongSinhVien);
            }
            else
                ds = thaotac.LocDanhSach(Hotro.user.ID, theLoai, congNghe, soLuongSinhVien);
            string trangThai = cbTrangThai.SelectedItem.ToString();
            if (trangThai != "Trạng thái")
            {
                ds = ds.Where(lv => lv.TinhTrang == trangThai).ToList();
            }
            LoadUCDeTai(ds);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Hotro.thaotac = EThaotac.ThemMoi;
        }

    }
}
