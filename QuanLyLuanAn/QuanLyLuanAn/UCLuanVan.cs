//using DTO_QuanLy;
using DataLibrary;
using QuanLyLuanAn.BUS;
using QuanLyLuanAn.DAL;
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
    public partial class UCLuanVan : UserControl
    {
        public EventHandler HienThiUCThaoTac;
        public EventHandler LoadLaiForm;
        public EventHandler MoNhiemVu;
        PLuanVan PLuanVan = new PLuanVan();
        PNguoiDung pNguoiDung = new PNguoiDung();
        LuanVan luanVanDaDangKy;
        LuanVan luanVan;
        public UCLuanVan(LuanVan luanVan)
        {
            InitializeComponent();
            this.luanVan = luanVan;
        }
        #region Phương thức

        private void HienThi(LuanVan luanVan)
        {
            lblMoTa.Text = luanVan.MoTa;
            lblTenDeTai.Text = luanVan.TieuDe;
            lblSoTV.Text = luanVan.SoLuongSinhVien.ToString();
            lblTenCongNghe.Text = luanVan.CongNghe;
            lblTenTheLoai.Text = luanVan.TheLoai;
            lblTenGV.Text = pNguoiDung.LayNguoiDungTheoID((int)luanVan.GiangVienID).HoTen.ToString();
            if (Hotro.user.VaiTro == "SinhVien")
            {
                btnSua.Visible = false;
                btnXoa.Visible = false;
                PNguoiDung nguoiDung = new PNguoiDung();
                luanVanDaDangKy = PLuanVan.LayLuanVanDaDangKyTheoSinhVienID(Hotro.user);
                PNhom pNhom = new PNhom();
                int soLuongSinhVien = pNhom.LayDanhSachNhomTheoLuanVanID(luanVan.ID).ToList().Count();
                if (luanVan.SoLuongSinhVien <= soLuongSinhVien)
                {
                    btnDangky.Text = "Đã đầy";
                }
                if (luanVanDaDangKy != null)
                {
                    if (luanVan.ID == luanVanDaDangKy.ID)
                    {
                        btnDangky.Text = "Hủy đăng ký";
                        btnDangky.FillColor = Color.Red;
                    }
                }
            }
            else
            {
                btnDangky.Visible = false;
            }
        }

        #endregion
        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            Hotro.thaotac = EThaotac.CapNhat;
            Hotro.hienThi = luanVan;
            HienThiUCThaoTac.Invoke(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa luận văn này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                PLuanVan thaotac = new PLuanVan();
                thaotac.Xoa(luanVan.ID);
                LoadLaiForm.Invoke(sender, e);
            }
        }

        private void btnDangky_Click(object sender, EventArgs e)
        {
            if (luanVanDaDangKy == null)
            {
                PNhom pNhom = new PNhom();
                int soLuongSinhVien = pNhom.LayDanhSachNhomTheoLuanVanID(luanVan.ID).ToList().Count();
                if (btnDangky.Text == "Đã đầy")
                {
                    MessageBox.Show("Luận văn này đã đầy", "Thông báo", MessageBoxButtons.YesNo);
                }
                else
                {
                    FDangKyLuanVan f = new FDangKyLuanVan(luanVan);
                    f.LoadLaiForm += LoadLaiForm;
                    f.Show();
                }
            }
            else
            {
                if (btnDangky.Text == "Hủy đăng ký")
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn hủy đăng ký luận văn này?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        luanVanDaDangKy = null;
                        PNhom pNhom = new PNhom();
                        pNhom.XoaTheoLuanVanID(luanVan.ID);
                        PLuanVan pLuanVan = new PLuanVan();
                        luanVan.TinhTrang = "Chưa đăng ký";
                        pLuanVan.CapNhat(luanVan);
                    }
                }
                else
                {
                    MessageBox.Show("Bạn đã đăng ký luận văn, vui lòng hủy đăng ký trước", "Thông báo", MessageBoxButtons.YesNo);
                }
            }
            LoadLaiForm.Invoke(sender, e);
        }

        private void btnNhiemVu_Click(object sender, EventArgs e)
        {
            Hotro.hienThi = luanVan;
            MoNhiemVu(sender, e);
        }

        private void UCLuanVan_Load(object sender, EventArgs e)
        {
            HienThi(luanVan);
        }
    }
}
