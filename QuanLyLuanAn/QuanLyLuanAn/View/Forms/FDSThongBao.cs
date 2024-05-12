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
    public partial class FDSThongBao : Form
    {
        PThongBao pThongBao;
        public EventHandler LoaiLaiForm;
        public FDSThongBao()
        {
            InitializeComponent();
            pThongBao = new PThongBao();
        }

        #region Phương thức
        private void LoadUC(List<ThongBao> ds, FlowLayoutPanel nen)
        {
            nen.Controls.Clear();
            if (ds.Count == 0)
            {
                Label labelEmptyList = new Label();
                labelEmptyList.Text = "Danh sách trống";
                labelEmptyList.Font = new Font(labelEmptyList.Font.FontFamily, 20f);
                nen.Controls.Add(labelEmptyList);
                labelEmptyList.TextAlign = ContentAlignment.MiddleCenter;
                labelEmptyList.AutoSize = true;
                labelEmptyList.ForeColor = Color.Purple;
            }
            else
            {
                foreach (ThongBao t in ds)
                {
                    UCThongBao uCThongBao = new UCThongBao(t);
                    uCThongBao.LoadLaiForm += FDSThongBao_Load;
                    nen.Controls.Add(uCThongBao);
                }
            }
        }

        private void LoadThongBao()
        {
            int idNguoiDung = Hotro.user.ID;
            LoadUC(pThongBao.LayDanhSachThongBaoDaXem(idNguoiDung), flpDaXem);
            LoadUC(pThongBao.LayDanhSachThongBaoChuaXem(idNguoiDung), flpChuaXem);
            List<int> sl = pThongBao.SoLuongThongBao(idNguoiDung);
            lblSlNhiemVu.Text = sl[0].ToString();
            lblSlChat.Text = sl[1].ToString();
            lblSlLuanVan.Text = sl[2].ToString();
        }
        #endregion
        private void FDSThongBao_Load(object sender, EventArgs e)
        {
            LoadThongBao();
            LoaiLaiForm.Invoke(sender, e);
        }
    }
}
