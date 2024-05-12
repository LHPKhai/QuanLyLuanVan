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
    public partial class FThaoTacNhiemVu : Form
    {
        EThaotac thaotac;
        NhiemVu nhiemVu;
        public EventHandler LoadLaiForm;
        public FThaoTacNhiemVu(LuanVan luanVan)
        {
            InitializeComponent();
            nhiemVu = new NhiemVu();
            nhiemVu.HoanThanh = false;
            nhiemVu.LuanVanID = luanVan.ID;
            EThaotac thaotac = EThaotac.ThemMoi;
        }

        public FThaoTacNhiemVu(NhiemVu nhiemVu)
        {
            InitializeComponent();
            this.nhiemVu = nhiemVu;
            txtTieude.Text = nhiemVu.TieuDe;
            txtNoiDung.Text = nhiemVu.MoTa;
            EThaotac thaotac = EThaotac.CapNhat;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            nhiemVu.ThoiGianDenHan = dptThoiGian.Value;
            nhiemVu.MoTa = txtNoiDung.Text;
            nhiemVu.TieuDe = txtTieude.Text;
            nhiemVu.TiLePhanCham = 0;
            nhiemVu.HoanThanh = false;
            if (int.TryParse(cmbPhanCong.SelectedValue.ToString(), out int nguoiDuocGiao))
            {
                nhiemVu.NguoiDuocGiao = nguoiDuocGiao;
            }
            nhiemVu.TacGiaID = Hotro.user.ID;
            PNhiemVu pNhiemVu = new PNhiemVu();
            PThongBao pThongBao = new PThongBao();
            if (thaotac == EThaotac.ThemMoi)
            {
                int nhiemVuID = pNhiemVu.ThemNhiemVu(nhiemVu);
                nhiemVu.ID = nhiemVuID;
                pThongBao.ThemThongBaoPhanCongNhiemVu((int)nhiemVu.NguoiDuocGiao, nhiemVu);

            }
            else
            {
                pThongBao.ThemThongBaoDoiPhanCongNhiemVu((int)nhiemVu.NguoiDuocGiao, nhiemVu);
                pNhiemVu.CapNhatNhiemVu(nhiemVu);
            }
            LoadLaiForm(sender, e);
            this.Close();
        }

        private void FThaoTacNhiemVu_Load(object sender, EventArgs e)
        {
            PNhom pNhom = new PNhom();
            cmbPhanCong.DataSource = pNhom.LayThongTinThanhVienNhomTheoLuanVanID((int)nhiemVu.LuanVanID);
            cmbPhanCong.DisplayMember = "HoTen";
            cmbPhanCong.ValueMember = "ID";
        }
    }
}
