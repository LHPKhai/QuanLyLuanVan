using DataLibrary;
using QuanLyLuanAn.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyLuanAn
{
    public partial class UCDSNhiemVuSV : UserControl
    {
        public UCDSNhiemVuSV()
        {
            InitializeComponent();
        }
        #region Phương thức
        private void HienThiDoThi(List<NhiemVu> nhiemVus)
        {
            Chart chart1 = new Chart();
            chart1.Dock = DockStyle.Fill;
            Series series = new Series("Tasks");
            series.ChartType = SeriesChartType.Pie;
            int soNhiemVuHoanThanhTren80 = 0;
            int soNhiemVuHoanThanhTren50 = 0;
            int soNhiemVuHoanThanhDuoi50 = 0;
            int soNhiemVuChuaNopBai = 0;
            foreach (NhiemVu nhiemVu in nhiemVus)
            {
                if (nhiemVu.TiLePhanCham >= 80)
                {
                    soNhiemVuHoanThanhTren80++;
                }
                else if (nhiemVu.TiLePhanCham >= 50)
                {
                    soNhiemVuHoanThanhTren50++;
                }
                else if (nhiemVu.TiLePhanCham < 50 && nhiemVu.TiLePhanCham > 0)
                {
                    soNhiemVuHoanThanhDuoi50++;
                }
                else if (string.IsNullOrEmpty(nhiemVu.BaiNop))
                {
                    soNhiemVuChuaNopBai++;
                }
            }

            int tongSoNhiemVu = soNhiemVuChuaNopBai + soNhiemVuHoanThanhDuoi50 + soNhiemVuHoanThanhTren50 + soNhiemVuHoanThanhTren80;
            DataPoint point80 = series.Points.Add(soNhiemVuHoanThanhTren80);
            if (soNhiemVuHoanThanhTren80 > 0)
            {
                point80.Label = 100.0 * soNhiemVuHoanThanhTren80 / tongSoNhiemVu + "%";
            }
            point80.LegendText = "NV hoàn thành trên 80%";
            point80.Color = Color.ForestGreen;
            DataPoint point50 = series.Points.Add(soNhiemVuHoanThanhTren50);
            if (soNhiemVuHoanThanhTren50 > 0)
            {
                point50.Label = 100.0 * soNhiemVuHoanThanhTren50 / tongSoNhiemVu + "%";
            }
            point50.LegendText = "NV hoàn thành trên 50%";
            point50.Color = Color.YellowGreen;
            DataPoint pointDuoi50 = series.Points.Add(soNhiemVuHoanThanhDuoi50);
            if (soNhiemVuHoanThanhDuoi50 > 0)
            {
                pointDuoi50.Label = 100.0 * soNhiemVuHoanThanhDuoi50 / tongSoNhiemVu + "%";
            }
            pointDuoi50.LegendText = "NV hoàn thành dưới 50%";
            pointDuoi50.Color = Color.Orange;
            DataPoint pointChuaHoanThanh = series.Points.Add(soNhiemVuChuaNopBai);
            if (soNhiemVuChuaNopBai > 0)
            {
                pointChuaHoanThanh.Label = 100.0 * soNhiemVuChuaNopBai / tongSoNhiemVu + "%";
            }
            pointChuaHoanThanh.LegendText = "NV chưa nộp bài";
            pointChuaHoanThanh.Color = Color.Red;
            Legend legend = new Legend();
            legend.Font = new Font("Arial", 14);
            chart1.Legends.Add(legend);
            chart1.Series.Add(series);
            chart1.ChartAreas.Add(new ChartArea());
            Title chartTitle = new Title("Tiến độ nhiệm vụ");
            chartTitle.Font = new Font("Arial", 30, FontStyle.Bold);

            chart1.Titles.Add(chartTitle);
            pnThongKe.Controls.Add(chart1);
        }
        private void LoadUCNhiemVu(List<NhiemVu> dsNhiemVu, FlowLayoutPanel flpDachSach)
        {
            flpDachSach.Controls.Clear();
            foreach (NhiemVu nvs in dsNhiemVu)
            {
                UCHienThiNV uc = new UCHienThiNV(nvs);
                uc.LoadLaiForm += UCDSNhiemVu_Load;
                flpDachSach.Controls.Add(uc);
            }
        }
        #endregion
        private void UCDSNhiemVu_Load(object sender, EventArgs e)
        {
            List<NhiemVu> nhiemVus = new List<NhiemVu>();
            PNhiemVu pNhiemVu = new PNhiemVu();
            if (pNhiemVu.Load() != null)
            {
                nhiemVus = pNhiemVu.Load();
                List<NhiemVu> dsNhiemVuChuaDenHan = new List<NhiemVu>();
                List<NhiemVu> dsChuaDenHanDaNhan = new List<NhiemVu>();
                if (Hotro.hienThi != null)
                {
                    dsNhiemVuChuaDenHan = pNhiemVu.Load().Where(nv => nv.LuanVanID == Hotro.hienThi.ID && nv.ThoiGianDenHan >= DateTime.Now).ToList(); ;
                    dsChuaDenHanDaNhan = dsNhiemVuChuaDenHan.Where(nv => nv.NguoiDuocGiao == Hotro.user.ID).ToList();
                }
                List<NhiemVu> dsNhiemVuDaDenHan = new List<NhiemVu>();
                List<NhiemVu> dsDaDenHanDaNhan = new List<NhiemVu>();
                if (Hotro.hienThi != null)
                {
                    dsNhiemVuDaDenHan = pNhiemVu.Load().Where(nv => nv.LuanVanID == Hotro.hienThi.ID && nv.ThoiGianDenHan < DateTime.Now).ToList(); ;
                    dsDaDenHanDaNhan = dsNhiemVuDaDenHan.Where(nv => nv.NguoiDuocGiao == Hotro.user.ID).ToList();
                }
                LoadUCNhiemVu(dsNhiemVuChuaDenHan, flpDanhSachChuaDenHan);
                LoadUCNhiemVu(dsNhiemVuDaDenHan, flpDanhSachDaDenHan);
                LoadUCNhiemVu(dsChuaDenHanDaNhan, flpDanhSachChuaDenHanDaNhan);
                LoadUCNhiemVu(dsDaDenHanDaNhan, flpDSDaDenHanDaNhan);
            }
            HienThiDoThi(nhiemVus);
        }

        private void ThemNhiemVu_Click(object sender, EventArgs e)
        {
            FThaoTacNhiemVu f = new FThaoTacNhiemVu(Hotro.hienThi);
            f.LoadLaiForm += UCDSNhiemVu_Load;
            f.Show();
        }
    }
}
