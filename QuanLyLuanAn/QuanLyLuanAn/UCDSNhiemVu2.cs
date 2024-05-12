using DataLibrary;
using QuanLyLuanAn.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyLuanAn
{
    public partial class UCDSNhiemVu2 : UserControl
    {
        public UCDSNhiemVu2()
        {
            InitializeComponent();
        }

        private void LoadUCNhiemVu(List<NhiemVu> dsNhiemVu, FlowLayoutPanel flpDachSach)
        {
            flpDachSach.Controls.Clear();
            foreach (NhiemVu nvs in dsNhiemVu)
            {
                UCHienThiNV uc = new UCHienThiNV(nvs);
                flpDachSach.Controls.Add(uc);
            }
        }

        private void UCDSNhiemVu2_Load(object sender, EventArgs e)
        {
            List<NhiemVu> nhiemVus = new List<NhiemVu>();
            PNhiemVu pNhiemVu = new PNhiemVu();
            //dgvPhanCong.DataSource = pNhiemVu.LayDanhSachNhiemVu();
            if (pNhiemVu.LayDanhSachNhiemVu() != null)
            {
                List<NhiemVu> dsNhiemVuChuaDenHan = new List<NhiemVu>();
                List<NhiemVu> dsChuaDenHanDaNhan = new List<NhiemVu>();
                if (Hotro.hienThi != null)
                {
                    dsNhiemVuChuaDenHan = pNhiemVu.LayDanhSachNhiemVu().Where(nv => nv.LuanVanID == Hotro.hienThi.ID && nv.ThoiGianDenHan.HasValue && nv.ThoiGianDenHan >= DateTime.Now).ToList(); ;
                    dsChuaDenHanDaNhan = dsNhiemVuChuaDenHan.Where(nv => nv.NguoiDuocGiao == Hotro.user.ID).ToList();
                }
                List<NhiemVu> dsNhiemVuDaDenHan = new List<NhiemVu>();
                List<NhiemVu> dsDaDenHanDaNhan = new List<NhiemVu>();
                if (Hotro.hienThi != null)
                {
                    dsNhiemVuDaDenHan = pNhiemVu.LayDanhSachNhiemVu().Where(nv => nv.LuanVanID == Hotro.hienThi.ID && nv.ThoiGianDenHan.HasValue && nv.ThoiGianDenHan < DateTime.Now).ToList(); ;
                    dsDaDenHanDaNhan = dsNhiemVuDaDenHan.Where(nv => nv.NguoiDuocGiao == Hotro.user.ID).ToList();
                }
                LoadUCNhiemVu(dsNhiemVuChuaDenHan, flpDanhSachChuaDenHan);
                LoadUCNhiemVu(dsNhiemVuDaDenHan, flpDanhSachDaDenHan);
                LoadUCNhiemVu(dsChuaDenHanDaNhan, flpDanhSachChuaDenHanDaNhan);
                LoadUCNhiemVu(dsDaDenHanDaNhan, flpDSDaDenHanDaNhan);
            }
        }

        private void ThemNhiemVu_Click(object sender, EventArgs e)
        {
            FThaoTacNhiemVu f = new FThaoTacNhiemVu(Hotro.hienThi);
            f.LoadLaiForm += UCDSNhiemVu2_Load;
            f.Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
