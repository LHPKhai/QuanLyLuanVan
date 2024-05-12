//using DTO_QuanLy;
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
using System.Windows.Navigation;

namespace QuanLyLuanAn
{
    public partial class FSinhVien : Form
    {
        PLuanVan PLuanVan = new PLuanVan();
        public FSinhVien()
        {
            InitializeComponent();
            lblTen.Text = Hotro.user.HoTen;
        }
        #region Phương thức
        private void ChuyenTab(object _form)
        {
            if (guna2Panel_container.Controls.Count > 0) guna2Panel_container.Controls.Clear();
            Form fm = _form as Form;
            fm.TopLevel = false;
            fm.FormBorderStyle = FormBorderStyle.None;
            fm.Dock = DockStyle.Fill;
            guna2Panel_container.Controls.Add(fm);
            guna2Panel_container.Tag = fm;
            fm.Show();
        }

        private bool ThongBaoLuanVan()
        {
            LuanVan luanVanDaDangKy = PLuanVan.LayLuanVanDaDangKyTheoSinhVienID(Hotro.user);
            if (luanVanDaDangKy == null)
            {
                FThongBao f = new FThongBao("Bạn chưa đăng ký luận văn, vui lòng đăng ký luận văn và chờ giảng viên duyệt!");
                f.Show();
            }
            else
            {
                if (luanVanDaDangKy.TinhTrang == "Chờ duyệt")
                {
                    FThongBao f = new FThongBao("Yêu cầu đăng ký luận văn của bạn đang được xét duyệt, vui lòng đợi giảng viên duyệt, nếu có yêu cầu khác, hãy nói với giảng viên!");
                    f.Show();
                }
                else
                {
                    Hotro.hienThi = luanVanDaDangKy;
                    return true;
                }
            }
            return false;
        }
        #endregion

        private void btnDeTai_Click(object sender, EventArgs e)
        {
            ChuyenTab(new FLuanVan());
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            Hotro.form.Show();
            this.Close();
        }

        private void btnUCNhiemVu_Click(object sender, EventArgs e)
        {
            if (ThongBaoLuanVan())
            {
                guna2Panel_container.Controls.Clear();
                guna2Panel_container.Controls.Add(new UCDSNhiemVuSV());
            }
        }

        private void btnThongBao_Click(object sender, EventArgs e)
        {
            FDSThongBao f = new FDSThongBao();
            f.LoaiLaiForm += FSinhVien_Load;
            ChuyenTab(f);
        }

        private void btnLuanVan_Click(object sender, EventArgs e)
        {
            ChuyenTab(new FLuanVan());
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            Hotro.form.Show();
            this.Close();
        }

        private void FSinhVien_Load(object sender, EventArgs e)
        {
            PThongBao pThongBao = new PThongBao();
            lblSoLuongThongBao.Text = pThongBao.SoLuongThongBaoMoi(Hotro.user.ID).ToString();
        }

        private void btnDiem_Click(object sender, EventArgs e)
        {
            if (ThongBaoLuanVan())
            {
                FDiemSV fDiemSV = new FDiemSV();
                ChuyenTab(fDiemSV);
            }
        }

        private void btnThongTin_Click(object sender, EventArgs e)
        {
            FThongTinSV f = new FThongTinSV();
            ChuyenTab(f);
        }
    }
}
