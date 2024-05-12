//using BUS_QuanLy;
//using DTO_QuanLy;
using DataLibrary;
using QuanLyLuanAn.BUS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace QuanLyLuanAn
{
    public partial class FLuanVan : Form
    {
        PLuanVan thaotac;
        List<LuanVan> ds;
        public EventHandler MoNhiemVu;
        public FLuanVan()
        {
            InitializeComponent();
            thaotac = new PLuanVan();
            ucThaoTacDeTai.DongUC += AnThaoTacLuanVan;
        }

        #region Phương thức
        private void ThemItemVaoCombobox<T>(IEnumerable<T> cot, ComboBox combo)
        {
            object firstItem = combo.Items.Count > 0 ? combo.Items[0] : null;
            combo.Items.Clear();
            if (firstItem != null)
            {
                combo.Items.Add(firstItem);
            }
            foreach (T item in cot)
            {
                combo.Items.Add(item);
            }
            combo.SelectedIndex = 0;
        }

        private void ThemVaoCombobox()
        {
            var cotTheLoai = thaotac.HienThiCotTheLoai(ds);
            var cotCongNghe = thaotac.HienThiCotCongNghe(ds);
            PNguoiDung bus = new PNguoiDung();
            var cotGiangVienID = bus.LayDanhSachGiangVien();
            foreach (var item in cotGiangVienID)
            {
                cbGiangVien.Items.Add(item.HoTen.ToString());
            }

            ThemItemVaoCombobox(cotTheLoai, cbTheLoai);
            ThemItemVaoCombobox(cotCongNghe, cbCongNghe);
        }

        private void HienThaoTacLuanVan(object sender, EventArgs e)
        {
            ucThaoTacDeTai.HienThi();
            guna2CustomGradientPanel1.Visible = false;
            flpDanhSachDeTai.Visible = false;
            ucThaoTacDeTai.Dock = DockStyle.Fill;
            ucThaoTacDeTai.Visible = true;
        }
        private void AnThaoTacLuanVan(object sender, EventArgs e)
        {
            ucThaoTacDeTai.Dock = DockStyle.None;
            ucThaoTacDeTai.Visible = false;
            guna2CustomGradientPanel1.Visible = true;
            flpDanhSachDeTai.Visible = true;
            FDanhSachDeTai_Load(sender, e);
        }

        private void LoadUCDeTai(List<LuanVan> danhSachLuanVan)
        {
            flpDanhSachDeTai.Controls.Clear();
            foreach (LuanVan deTai in danhSachLuanVan)
            {
                UCLuanVan uc = new UCLuanVan(deTai);
                uc.HienThiUCThaoTac += HienThaoTacLuanVan;
                uc.LoadLaiForm += FDanhSachDeTai_Load;
                uc.MoNhiemVu += MoNhiemVu;
                flpDanhSachDeTai.Controls.Add(uc);
            }
        }
        #endregion
        private void FDanhSachDeTai_Load(object sender, EventArgs e)
        {
            if (Hotro.user.VaiTro == "GiangVien")
            {
                ds = thaotac.LocDanhSach(Hotro.user.ID, null, null, -1);
                cbGiangVien.Visible = false;
            }
            else
            {
                ds = thaotac.Load();
                btnThem.Visible = false;
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

            if (Hotro.user.VaiTro == "GiangVien")
            {
                ds = thaotac.LocDanhSach(Hotro.user.ID, theLoai, congNghe, soLuongSinhVien);
            }
            else
                ds = thaotac.LocDanhSach(maGV2, theLoai, congNghe, soLuongSinhVien);
            LoadUCDeTai(ds);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            Hotro.thaotac = EThaotac.ThemMoi;
            HienThaoTacLuanVan(sender, e);
        }
    }
}
