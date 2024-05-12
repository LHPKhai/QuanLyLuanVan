using DataLibrary;
using QuanLyLuanAn.BUS;
using QuanLyLuanAn.Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyLuanAn
{
    public partial class FTBDuyet : Form
    {
        LuanVan luanVan;
        List<NguoiDung> ds;
        public EventHandler LoadLaiForm;
        public FTBDuyet(LuanVan luanVan)
        {
            InitializeComponent();
            this.luanVan = luanVan;
        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            PLyDo pLyDo = new PLyDo();
            FDSHuyDuyet f = new FDSHuyDuyet(pLyDo.TaoDanhSachLyDoHoTen(ds, luanVan.ID), luanVan);
            f.OkButtonClicked += LoadLaiForm;
            f.Show();
            this.Close();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            PNhom pNhom = new PNhom();
            PLuanVan pLuanVan = new PLuanVan();
            var dsthanhvien = pNhom.LayDanhSachNhomTheoLuanVanID(luanVan.ID);
            int soLuongThanhVien = 0;
            if (dsthanhvien != null)
            {
                soLuongThanhVien = dsthanhvien.Count();
            }
            if (Hotro.user.VaiTro == "GiangVien")
            {
                string ThongBao = "Giảng viên có chắc duyệt đề tài không?";
                int? lech = luanVan.SoLuongSinhVien - soLuongThanhVien;
                if (lech > 0)
                {
                    ThongBao = $"Thiếu {lech} sinh viên. " + ThongBao;
                }

                FThongBao fThongBao = new FThongBao(ThongBao);
                DialogResult result = fThongBao.ShowDialog();

                if (result == DialogResult.OK)
                {
                    luanVan.TinhTrang = "Đã duyệt";
                    pLuanVan.CapNhat(luanVan);
                    PThongBao pThongBao = new PThongBao();
                    foreach (var sv in dsthanhvien)
                    {
                        pThongBao.ThemThongBaoDuocDuyetLuanVan((int)sv.ThanhVienID, (int)sv.LuanVanID);
                    }
                    LoadLaiForm.Invoke(sender, e);
                }
            }
            this.Close();
        }
        private void FTBDuyet_Load(object sender, EventArgs e)
        {
            PNguoiDung pNguoiDung = new PNguoiDung();
            ds = pNguoiDung.LayDanhSachTheoLuanVan(luanVan.ID);
        }
    }
}
