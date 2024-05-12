//using BUS_QuanLy;
//using DTO_QuanLy;
using System;
using System.Windows.Forms;

namespace QuanLyLuanAn
{
    public partial class FTinNhan : Form
    {
    //    private readonly BUS_TinNhan _busTinNhan;
        //FGuiTinNhan f;

        public FTinNhan()
        {
            InitializeComponent();
          //  _busTinNhan = new BUS_TinNhan();
            //f = new FGuiTinNhan();
        }

        private void btnTinNhan_Click(object sender, EventArgs e)
        {
           // HoTro.chucNang = "Thêm";
            //f.ShowDialog();
        }

        private void FTinNhan_Load(object sender, EventArgs e)
        {
            //dgvTinNhanDaGui.DataSource = _busTinNhan.LayTinNhanTheoNguoiGui(HoTro.nguoiDung.Ma);
            //dgvTinNhanDen.DataSource = _busTinNhan.LayTinNhanTheoNguoiNhan(HoTro.nguoiDung.Ma);
        }

        private void dgvTinNhanDaGui_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    DataGridViewRow row = dgvTinNhanDaGui.Rows[e.RowIndex];
            //    HoTro.tinNhan = new TinNhan
            //    {
            //        MaNguoiNhan = row.Cells["MaNguoiNhan"].Value.ToString(),
            //        MaNguoiGui = row.Cells["MaNguoiGui"].Value.ToString(),
            //        NoiDung = row.Cells["NoiDung"].Value.ToString(),
            //        ThoiGian = Convert.ToDateTime(row.Cells["ThoiGian"].Value)
            //    };
            //    HoTro.chucNang = "Xem thông tin";
            //    //f.ShowDialog();
            //}
        }

        private void dgvTinNhanDen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    DataGridViewRow row = dgvTinNhanDen.Rows[e.RowIndex];
            //    HoTro.tinNhan = new TinNhan
            //    {
            //        MaNguoiNhan = row.Cells["MaNguoiNhan"].Value.ToString(),
            //        MaNguoiGui = row.Cells["MaNguoiGui"].Value.ToString(),
            //        NoiDung = row.Cells["NoiDung"].Value.ToString(),
            //        ThoiGian = Convert.ToDateTime(row.Cells["ThoiGian"].Value)
            //    };
            //    HoTro.chucNang = "Xem thông tin";
            //    //f.ShowDialog();
            //}
        }
    }
}
