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
    public partial class FGiangVien : Form
    {
        public FGiangVien()
        {
            InitializeComponent();
            lblTen.Text = Hotro.user.HoTen;
        }
        #region Phương thức
        private void HienThiForm(object _form)
        {
            if (pnHienThi.Controls.Count > 0) pnHienThi.Controls.Clear();
            Form fm = _form as Form;
            fm.TopLevel = false;
            fm.FormBorderStyle = FormBorderStyle.None;
            fm.Dock = DockStyle.Fill;
            pnHienThi.Controls.Add(fm);
            pnHienThi.Tag = fm;
            fm.Show();
        }

        private void HienUCNhiemVu(object sender, EventArgs e)
        {
            PLuanVan pLuanVan = new PLuanVan();
            pnHienThi.Controls.Clear();
            pnHienThi.Controls.Add(new UCDSNhiemVuGV(Hotro.hienThi));
        }
        #endregion
        private void btnTroLai_Click(object sender, EventArgs e)
        {
            Hotro.form.Show();
            this.Close();
        }

        private void btnChamDiem(object sender, EventArgs e)
        {
            FDSChamDiemLuanVan f = new FDSChamDiemLuanVan();
            f.MoNhiemVu += HienUCNhiemVu;
            HienThiForm(f);
        }

        private void btnSinhVien_Click(object sender, EventArgs e)
        {
            FDSSinhVien f = new FDSSinhVien();
            f.LoadUCNhiemVu = HienUCNhiemVu;
            HienThiForm(f);
        }

        private void FGiangVien_Load(object sender, EventArgs e)
        {
            PThongBao pThongBao = new PThongBao();
            lblSoLuongThongBao.Text = pThongBao.SoLuongThongBaoMoi(Hotro.user.ID).ToString();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            Hotro.form.Show();
            this.Close();
        }

        private void btnDuyetLuanVan_Click(object sender, EventArgs e)
        {
            HienThiForm(new FDuyetLuanVan());
        }

        private void btnLuanVan_Click(object sender, EventArgs e)
        {
            FLuanVan f = new FLuanVan();
            f.MoNhiemVu = HienUCNhiemVu;
            HienThiForm(f);
        }

        private void btnThongBao_Click(object sender, EventArgs e)
        {
            FDSThongBao f = new FDSThongBao();
            f.LoaiLaiForm += FGiangVien_Load;
            HienThiForm(f);
        }

        private void btnThongTin_Click(object sender, EventArgs e)
        {
            FThongTinGV f = new FThongTinGV();
            HienThiForm(f);
        }
    }
}
