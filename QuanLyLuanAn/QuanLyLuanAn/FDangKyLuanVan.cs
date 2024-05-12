using DataLibrary;
using QuanLyLuanAn.BUS;
using QuanLyLuanAn.DAL;
using QuanLyLuanAn.Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace QuanLyLuanAn
{
    public partial class FDangKyLuanVan : Form
    {
        PLuanVan pLuanVan;
        LuanVan luanVan;
        PNguoiDung pNguoiDung;
        PNhom pNhom;
        int soLuongThanhVien;
        public EventHandler LoadLaiForm;

        public FDangKyLuanVan()
        {
            InitializeComponent();
        }

        public FDangKyLuanVan(LuanVan luanVan)
        {
            InitializeComponent();
            this.luanVan = luanVan;
            pLuanVan = new PLuanVan();
            pNguoiDung = new PNguoiDung();
            pNhom = new PNhom();
        }
        #region Phương thức
        private void LoadSinhVienDauTien()
        {
            Nhom thanhVienMoi = new Nhom(0, luanVan.ID, Hotro.user.ID, 0, 0);
            List<Nhom> ds = new List<Nhom>();
            ds = pNhom.LayDanhSachNhomTheoLuanVanID(luanVan.ID);
            if (Hotro.user.VaiTro == "SinhVien")
            {
                Hotro.nhoms = pNhom.ThemThanhVienVaoList(ds, thanhVienMoi);
            }
            else
            {
                btnDangKy.Visible = false;
            }
        }
        private void HienThiLuanVan(LuanVan luanVan)
        {
            txtMoTa.Text = luanVan.MoTa;
            txtYeuCau.Text = luanVan.YeuCau;
            txtChucNang.Text = luanVan.ChucNang;
            txtCongNghe.Text = luanVan.CongNghe;
            txtTheLoai.Text = luanVan.TheLoai;
            lblTieude.Text = luanVan.TieuDe;
            lblGioiHan.Text = luanVan.SoLuongSinhVien.ToString();
            lblGV.Text = pNguoiDung.LayNguoiDungTheoID((int)luanVan.GiangVienID).HoTen.ToString();
        }

        private void LoadUCThanhVien(List<Nhom> ds)
        {
            soLuongThanhVien = 0;
            flpDanhSach.Controls.Clear();
            foreach (var u in ds)
            {
                soLuongThanhVien++;
                UCMSSV uc = new UCMSSV(u);
                flpDanhSach.Controls.Add(uc);
            }
            lbThamGia.Text = soLuongThanhVien.ToString();
        }

        private void TruyenDuLieu()
        {
            cbMaSV.DataSource = pNguoiDung.LayDanhSach().Where(nd => nd.VaiTro == "SinhVien").ToList();
            cbMaSV.DisplayMember = "ID";
            cbMaSV.ValueMember = "HoTen";
            txtHoten.Text = "";
        }

        private void LayDuLieu()
        {
            Hotro.hienThi.MoTa = txtMoTa.Text;
            Hotro.hienThi.YeuCau = txtYeuCau.Text;
            Hotro.hienThi.ChucNang = txtChucNang.Text;
            Hotro.hienThi.CongNghe = txtCongNghe.Text;
            Hotro.hienThi.TheLoai = txtTheLoai.Text;
        }

        private void DongForm(object sender, EventArgs e)
        {
            LoadLaiForm(sender, e);
            this.Close();
        }
        #endregion

        private void btnTaoLai_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dữ liệu?", "Xác nhận xóa", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Thành công!");
                FDKDeTai_Load(sender, e);
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (Hotro.user.VaiTro == "SinhVien")
            {
                PThongBao pThongBao = new PThongBao();
                foreach (var d in Hotro.nhoms)
                {
                    pNhom.CapNhatHoacThemNhom(d);
                    pThongBao.ThemThongBaoDangKyLuanVan(d.ThanhVienID, luanVan);
                }
            }

            luanVan.TinhTrang = "Chờ duyệt";
            pLuanVan.CapNhat(luanVan);
            MessageBox.Show("Thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadLaiForm.Invoke(sender, e);
            this.Close();
        }

        private void FDKDeTai_Load(object sender, EventArgs e)
        {
            Hotro.nhoms = pNhom.LayDanhSachNhomTheoLuanVanID(luanVan.ID);
            TruyenDuLieu();
            HienThiLuanVan(luanVan);
            LoadSinhVienDauTien();
            LoadUCThanhVien(Hotro.nhoms);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            LayDuLieu();
            if (Hotro.thaotac == EThaotac.CapNhat)
            {
                pLuanVan.CapNhat(Hotro.hienThi);
            }
            else
            {
                pLuanVan.Them(Hotro.hienThi);
            }
            DongForm(this, new EventArgs());
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (Hotro.user.VaiTro == "SinhVien")
            {
                if (soLuongThanhVien + 1 <= luanVan.SoLuongSinhVien)
                {
                    if (cbMaSV.SelectedItem != null)
                    {
                        NguoiDung sv = (NguoiDung)cbMaSV.SelectedItem;
                        if (int.TryParse(sv.ID.ToString(), out int selectedMaSV))
                        {
                            Nhom thanhVienMoi = new Nhom(selectedMaSV, luanVan.ID, selectedMaSV, 0, 0);
                            Hotro.nhoms = pNhom.ThemThanhVienVaoList(Hotro.nhoms, thanhVienMoi);
                        }
                        else
                        {
                            MessageBox.Show("Giá trị không hợp lệ.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn một sinh viên.");
                    }
                }
                else
                {
                    MessageBox.Show("Không thể đăng ký do đã đủ thành viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            LoadUCThanhVien(Hotro.nhoms);
        }

        private void cbMaSV_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtHoten.Text = cbMaSV.SelectedValue.ToString();
        }
    }
}
