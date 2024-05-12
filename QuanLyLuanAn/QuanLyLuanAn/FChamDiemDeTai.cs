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
    public partial class FChamDiemDeTai : Form
    {
        LuanVan luanVan;
        List<HoiDongChamThi> hoidong = new List<HoiDongChamThi>();
        PNguoiDung bus = new PNguoiDung();
        PHoiDong pHoiDong = new PHoiDong();
        public FChamDiemDeTai(LuanVan luanVan)
        {
            InitializeComponent();
            this.luanVan = luanVan;
            hoidong = pHoiDong.Load().Where(hd => hd.LuanVanID == luanVan.ID).ToList();
            if (hoidong.Find(hd => hd.GiangVienID == Hotro.user.ID) == null)
            {
                HoiDongChamThi nguoiCham = new HoiDongChamThi();
                nguoiCham.LuanVanID = luanVan.ID;
                nguoiCham.GiangVienID = Hotro.user.ID;
                pHoiDong.Them(nguoiCham);
            }    
        }

        private void LoadUCDeTai()
        {
            hoidong = pHoiDong.Load().Where(hd => hd.LuanVanID == luanVan.ID).ToList();
            flpDanhSachLuanVan.Controls.Clear();
            foreach (HoiDongChamThi nguoiCham in hoidong)
            {
                UCGVChamDiem1 uc = new UCGVChamDiem1(nguoiCham);
                flpDanhSachLuanVan.Controls.Add(uc);
            }
        }

        private void FChamDiemDeTai_Load(object sender, EventArgs e)
        {
            var cotGiangVienID = bus.LayDanhSachGiangVien();
            cbGiangVien.DataSource = cotGiangVienID;
            cbGiangVien.DisplayMember = "HoTen";
            cbGiangVien.ValueMember = "ID";
            LoadUCDeTai();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            hoidong = pHoiDong.Load().Where(hd => hd.LuanVanID == luanVan.ID).ToList();
            if (cbGiangVien.SelectedValue != null && hoidong.Find(hd => hd.GiangVienID.ToString() == cbGiangVien.SelectedValue.ToString()) != null)
            {
                FThongBao f = new FThongBao("Giảng viên này đã có trong danh sách chấm thi");
                f.Show();
            }
            else
            {
                HoiDongChamThi nguoiCham = new HoiDongChamThi();
                nguoiCham.LuanVanID = luanVan.ID;
                int id;
                if (int.TryParse(cbGiangVien.SelectedValue.ToString(), out id))
                {
                    nguoiCham.GiangVienID = id;
                }
                hoidong.Add(nguoiCham);
                pHoiDong.Them(nguoiCham);
                LoadUCDeTai();
            }
        }
    }
}
