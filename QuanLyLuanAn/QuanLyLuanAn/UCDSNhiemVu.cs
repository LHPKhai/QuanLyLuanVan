using DataLibrary;
using Guna.UI2.WinForms;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyLuanAn
{
    public partial class UCDSNhiemVu : UserControl
    {
        LuanVan luanVan;
        public UCDSNhiemVu(LuanVan luanVan)
        {
            InitializeComponent();
            this.luanVan = luanVan;
        }



        private void HienThiDoThi()
        {
            // Khởi tạo biểu đồ
            Chart chart1 = new Chart();
            chart1.Size = new System.Drawing.Size(800, 400);

            // Khởi tạo loạt dữ liệu
            Series series = new Series("Tasks");
            series.ChartType = SeriesChartType.Column;


            PNhiemVu pNhiemVu = new PNhiemVu();
            List<NhiemVu> danhSachNhiemVu = pNhiemVu.LayDanhSachNhiemVu();

            // Khởi tạo các biến để thống kê
            int soNhiemVuHoanThanhTren80 = 0;
            int soNhiemVuHoanThanhTren50 = 0;
            int soNhiemVuHoanThanhDuoi50 = 0;
            int soNhiemVuChuaNopBai = 0;

            // Thống kê số lượng nhiệm vụ theo điều kiện
            foreach (NhiemVu nhiemVu in danhSachNhiemVu)
            {
                if (nhiemVu.HoanThanh == true && nhiemVu.TiLePhanCham >= 80)
                {
                    soNhiemVuHoanThanhTren80++;
                }
                else if (nhiemVu.HoanThanh == true && nhiemVu.TiLePhanCham >= 50)
                {
                    soNhiemVuHoanThanhTren50++;
                }
                else if (nhiemVu.HoanThanh == true && nhiemVu.TiLePhanCham < 50)
                {
                    soNhiemVuHoanThanhDuoi50++;
                }
                else if (string.IsNullOrEmpty(nhiemVu.BaiNop))
                {
                    soNhiemVuChuaNopBai++;
                }
            }
            // Thêm dữ liệu vào loạt dữ liệu
            series.Points.AddXY("Số lượng nhiệm vụ > 80%", soNhiemVuHoanThanhTren80);
            series.Points.AddXY("Số lượng nhiệm vụ > 50%", soNhiemVuHoanThanhTren50);
            series.Points.AddXY("Số lượng nhiệm vụ < 50%", soNhiemVuHoanThanhDuoi50);
            series.Points.AddXY("Nhiệm vụ chưa hoàn thành", soNhiemVuChuaNopBai);


            // Thêm loạt dữ liệu vào biểu đồ
            chart1.Series.Add(series);

            // Kiểm tra nếu biểu đồ không có ChartArea, thì tạo mới một ChartArea
            if (chart1.ChartAreas.Count == 0)
            {
                chart1.ChartAreas.Add(new ChartArea());
            }

            // Thiết lập tiêu đề cho trục Y
            chart1.ChartAreas[0].AxisY.Title = "Số lượng nhiệm vụ";
            chart1.ChartAreas[0].AxisX.Title = "Danh mục";
            chart1.BackColor = Color.LightGray;
            panel1.Controls.Add(chart1);

        }

        private void LoadUCNhiemVu(List<NhiemVu> dsNhiemVu, FlowLayoutPanel flpDachSach)
        {
            flpDachSach.Controls.Clear();
            foreach (NhiemVu nvs in dsNhiemVu)
            {
                UCHienThiNV uc  = new UCHienThiNV(nvs);
                uc.LoadLaiForm += UCDSNhiemVu_Load;
                flpDachSach.Controls.Add(uc);
            }
        }

        private void ThemNhiemVu_Click(object sender, EventArgs e)
        {
            FThaoTacNhiemVu f = new FThaoTacNhiemVu(luanVan);
            f.LoadLaiForm += UCDSNhiemVu_Load;
            f.Show();
        }

        //private void guna2TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    PNguoiDung pNguoiDung = new PNguoiDung();
        //    if (dgvPhanCong.SelectedRows.Count > 0)
        //    {
        //        DataGridViewRow selectedRow = dgvPhanCong.SelectedRows[0];
        //        txtManhom.Text = selectedRow.Cells[0].Value.ToString();
        //        txtMadetai.Text = selectedRow.Cells[5].Value.ToString();
        //        if (selectedRow.Cells[6].Value != null)
        //        {
        //            string sinhVienID = selectedRow.Cells[6].Value.ToString();
        //            int sinhVienID1 = 0;
        //            if (int.TryParse(sinhVienID, out sinhVienID1)) { }
        //            if (sinhVienID1 != 0)
        //            {
        //                cbSinhVien.Text = sinhVienID1.ToString();
        //                txtHoTen.Text = pNguoiDung.LayNguoiDungTheoID(sinhVienID1).HoTen.ToString();
        //            }
        //        }                
        //    }
        //}

        private void UCDSNhiemVu_Load(object sender, EventArgs e)
        {
            List<NhiemVu> nhiemVus = new List<NhiemVu>();   
            PNhiemVu pNhiemVu = new PNhiemVu();
            //dgvPhanCong.DataSource = pNhiemVu.LayDanhSachNhiemVu();
            if (pNhiemVu.LayDanhSachNhiemVu() != null)
            {
                List<NhiemVu> dsNhiemVuChuaDenHan = new List<NhiemVu>();
                if (Hotro.hienThi != null)
                {
                    dsNhiemVuChuaDenHan = pNhiemVu.LayDanhSachNhiemVu().Where(nv => nv.LuanVanID == Hotro.hienThi.ID && nv.ThoiGianDenHan.HasValue && nv.ThoiGianDenHan >= DateTime.Now).ToList(); ;
                }
                List<NhiemVu> dsNhiemVuDaDenHan = new List<NhiemVu>();
                if (Hotro.hienThi != null)
                {
                    dsNhiemVuDaDenHan = pNhiemVu.LayDanhSachNhiemVu().Where(nv => nv.LuanVanID == Hotro.hienThi.ID && nv.ThoiGianDenHan.HasValue && nv.ThoiGianDenHan < DateTime.Now).ToList(); ;
                }
                LoadUCNhiemVu(dsNhiemVuChuaDenHan, flpDanhSachChuaDenHan);
                LoadUCNhiemVu(dsNhiemVuDaDenHan, flpDanhSachDaDenHan);
            }
            HienThiDoThi();
        }

        private void guna2GradientPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

     
        private void lblHocki_Click(object sender, EventArgs e)
        {

        }

        private void btnThemPhanCong_Click(object sender, EventArgs e)
        { 
            
        }
        
        private void btnHuyPhanCong_Click(object sender, EventArgs e)
        {

        }

        private void dgvPhanCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
