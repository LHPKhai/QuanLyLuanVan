using DataLibrary;
using Guna.UI2.WinForms;
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
    public partial class FChiTietNVNhan : Form
    {

        NhiemVu nhiemVu;
        PNhiemVu pNhiemVu;
        PNhiemVu_TroChuyen pChat;
        public EventHandler LoadLaiForm;

        public FChiTietNVNhan(NhiemVu nhiemVu)
        {
            InitializeComponent();
            this.nhiemVu = nhiemVu;
            pNhiemVu = new PNhiemVu();
            pChat = new PNhiemVu_TroChuyen(nhiemVu.ID);
        }
        #region Phương thức
        private void HienThiTrenForm()
        {
            nhiemVu = pNhiemVu.LayNhiemVuTheoID(nhiemVu.ID);
            lblTenNhiemVu.Text = nhiemVu.TieuDe;
            txtNoiDung.Text = nhiemVu.MoTa;
            guna2TrackBar1.Text = nhiemVu.TiLePhanCham.ToString();
            dptThoiGian.Value = nhiemVu.ThoiGianDenHan;
            var baiNop = nhiemVu.BaiNop;
            txtBaiNop.Text = baiNop != null ? baiNop.ToString() : "";
            txtTienDo.Text = nhiemVu.TiLePhanCham.ToString();
            if (Hotro.user.VaiTro == "SinhVien")
            {
                dptThoiGian.Enabled = false;
            }
            if (nhiemVu.NguoiDuocGiao != null)
            {
                PNguoiDung pNguoiDung = new PNguoiDung();
                lblTenSinhVien.Text = pNguoiDung.LayNguoiDungTheoID((int)nhiemVu.NguoiDuocGiao).HoTen.ToString();
            }
            else
            {
                lblTenSinhVien.Text = "Chưa ai nhận";
            }
            if (pChat.nguoiNhan.HoTen != null)
            {
                lblTenNguoiNhan.Text = pChat.nguoiNhan.HoTen.ToString();
            }
            else
            {
                lblTenNguoiNhan.Text = "Không có người nhận";
            }
        }

        private void HienThiChat()
        {
            panel1.Controls.Clear();
            foreach (var tinNhan in pChat.lichSuTroChuyenCuaNhiemVu)
            {
                UserControl uc;
                if (tinNhan.NguoiNhanID == pChat.nguoiNhan.ID)
                {
                    uc = new UCTNGui(tinNhan.NoiDung);
                }
                else
                {
                    uc = new UCTNNhan(tinNhan.NoiDung);
                }
                uc.Dock = DockStyle.Bottom;
                panel1.Controls.Add(uc);
            }
        }
        private void GuiTinNhan()
        {
            if (txtGui.Text != "")
            {
                PThongBao pThongBao = new PThongBao();
                if (pChat.nguoiNhan.ID == null)
                {
                    MessageBox.Show("Không có người nhận. Vui lòng chọn người nhận trước khi gửi tin nhắn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    string content = txtGui.Text;
                    NhiemVu_TroChuyen tinNhan = new NhiemVu_TroChuyen(0, content, DateTime.Now, nhiemVu.ID, pChat.nguoiDung.ID);
                    pChat.GuiTinNhan(tinNhan);
                    pThongBao.ThemThongBaoTinNhanDen(pChat.nguoiDung, tinNhan, pChat.nguoiNhan);
                    UCTNGui newUC = new UCTNGui(content);
                    newUC.Dock = DockStyle.Bottom;
                    panel1.Controls.Add(newUC);
                    txtGui.Text = "";
                }
            }
        }
        #endregion

        private void txtGui_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GuiTinNhan();
            }
        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            GuiTinNhan();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtTienDo.Text, out int tienDo))
            {
                if (Hotro.user.VaiTro == "SinhVien")
                {

                }
                nhiemVu.TiLePhanCham = tienDo;
            }
            nhiemVu.BaiNop = txtBaiNop.Text;
            pNhiemVu.CapNhatNhiemVu(nhiemVu);
            LoadLaiForm.Invoke(sender, e);
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FChiTietNVNhan_Load(object sender, EventArgs e)
        {
            HienThiTrenForm();
            HienThiChat();
        }

        private void ThanhTruot_Scroll(object sender, ScrollEventArgs e)
        {
            txtTienDo.Text = guna2TrackBar1.Value.ToString();
        }

        private void txtPhanCham_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtTienDo.Text, out int value))
            {
                value = Math.Min(guna2TrackBar1.Maximum, Math.Max(guna2TrackBar1.Minimum, value));
                guna2TrackBar1.Value = value;
            }
        }

        private void txtTienDo_TextChanged(object sender, EventArgs e)
        {
            txtTienDo.Text = this.guna2TrackBar1.Text;
        }

        private void btnSuaNhiemVu_Click(object sender, EventArgs e)
        {
            FThaoTacNhiemVu f = new FThaoTacNhiemVu(nhiemVu);
            f.LoadLaiForm += FChiTietNVNhan_Load;
            f.Show();
        }
    }
}
