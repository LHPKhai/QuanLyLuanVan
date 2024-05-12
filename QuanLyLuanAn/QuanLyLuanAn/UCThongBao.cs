using DataLibrary;
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
    public partial class UCThongBao : UserControl
    {
        ThongBao thongBao;
        public EventHandler LoadLaiForm;
        PThongBao pThongBao = new PThongBao();
        public UCThongBao(ThongBao thongBao)
        {
            InitializeComponent();
            this.thongBao = thongBao;
        }
        #region Phương thức
        private void ThayDoiMauTheoLoai(string theLoai)
        {
            switch (theLoai)
            {
                case "Chat      ":
                    nen.FillColor = System.Drawing.Color.FromArgb(255, 128, 128);
                    break;
                case "LuanVan   ":
                    nen.FillColor = System.Drawing.Color.FromArgb(255, 128, 128);
                    break;
                case "NhiemVu   ":
                    nen.FillColor = System.Drawing.Color.FromArgb(255, 128, 128);
                    break;
                default:
                    nen.FillColor = System.Drawing.Color.White;
                    break;
            }
        }
        #endregion
        private void btnTrangThai_Click(object sender, EventArgs e)
        {
            if (btnTrangThai.Text == "Chưa xem")
            {
                pThongBao.DanhDauThongBaoDaDoc(thongBao.ID);
            }
            LoadLaiForm.Invoke(sender, new EventArgs());
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            pThongBao.XoaThongBao(thongBao.ID);
            LoadLaiForm.Invoke(sender, new EventArgs());
        }

        private void UCThongBao_Load(object sender, EventArgs e)
        {
            lblTieuDe.Text = thongBao.TieuDe;
            lblNoiDung.Text = thongBao.NoiDung;
            if (thongBao.DaDoc == false)
            {
                btnTrangThai.Text = "Chưa xem";
            }
            else
            {
                btnTrangThai.Text = "Đã xem";
            }
            ThayDoiMauTheoLoai(thongBao.TheLoai);
        }
    }
}

