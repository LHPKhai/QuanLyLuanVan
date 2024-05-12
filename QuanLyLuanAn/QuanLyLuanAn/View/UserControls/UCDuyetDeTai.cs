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
    public partial class UCDuyetDeTai : UserControl
    {
        LuanVan luanVan;
        public EventHandler LoadLaiForm;
        PNguoiDung pNguoiDung;
        public UCDuyetDeTai(LuanVan luanVan)
        {
            InitializeComponent();
            pNguoiDung = new PNguoiDung();
            this.luanVan = luanVan;
        }

        private void btnChitiet_Click(object sender, EventArgs e)
        {
            FDangKyLuanVan f = new FDangKyLuanVan(luanVan);
            f.LoadLaiForm += this.LoadLaiForm;
            f.ShowDialog();
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            if (btnDuyet.Text == "Chờ duyệt")
            {
                FTBDuyet f = new FTBDuyet(luanVan);
                f.LoadLaiForm += LoadLaiForm;
                f.ShowDialog();
            }
            else
            {
                FThongBao f = new FThongBao("Luận văn chưa được đăng ký");
            }
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

        private void UCDuyetDeTai_Load(object sender, EventArgs e)
        {
            lblTenLuanVan.Text = luanVan.TieuDe;
            lblMoTa.Text = luanVan.MoTa;
            lblSoTV.Text = luanVan.SoLuongSinhVien.ToString();
            lblTenCongNghe.Text = luanVan.CongNghe;
            lblTenTheLoai.Text = luanVan.TheLoai;
            lblTenGV.Text = pNguoiDung.LayNguoiDungTheoID((int)luanVan.GiangVienID).HoTen.ToString();
            btnDuyet.Text = luanVan.TinhTrang;
            if (btnDuyet.Text == "Chờ duyệt")
                btnDuyet.FillColor = Color.Yellow;
            if (btnDuyet.Text == "Chưa đăng ký")
                btnDuyet.FillColor = Color.Red;
            if (btnDuyet.Text == "Đã duyệt")
                btnDuyet.FillColor = Color.LightGreen;
        }
    }
}
