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
    public partial class FDSHuyDuyet : Form
    {
        public event EventHandler OkButtonClicked;
        LuanVan luanVan;
        public FDSHuyDuyet(List<LyDo_HoTen> ds, LuanVan luanVan)
        {
            InitializeComponent();
            LoadHienThi(ds, luanVan);
            this.luanVan = luanVan;
        }

        #region Phương thức
        private void LoadHienThi(List<LyDo_HoTen> ds, LuanVan luanVan)
        {
            DataGridViewTextBoxColumn hoTenColumn = new DataGridViewTextBoxColumn();
            hoTenColumn.HeaderText = "Họ Tên";
            hoTenColumn.DataPropertyName = "HoTen";
            dgvDanhSach.Columns.Add(hoTenColumn);

            DataGridViewTextBoxColumn SinhVienIDTextColumn = new DataGridViewTextBoxColumn();
            SinhVienIDTextColumn.HeaderText = "Mã sinh viên";
            SinhVienIDTextColumn.DataPropertyName = "SinhVienID";
            dgvDanhSach.Columns.Add(SinhVienIDTextColumn);

            DataGridViewTextBoxColumn lyDoTextColumn = new DataGridViewTextBoxColumn();
            lyDoTextColumn.HeaderText = "Lý do";
            lyDoTextColumn.DataPropertyName = "LyDoText";
            dgvDanhSach.Columns.Add(lyDoTextColumn);

            foreach (var lyDo in ds)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewTextBoxCell lyDoTextCell = new DataGridViewTextBoxCell();
                lyDoTextCell.Value = lyDo.LyDoText;
                DataGridViewTextBoxCell hoTenCell = new DataGridViewTextBoxCell();
                hoTenCell.Value = lyDo.HoTen;
                DataGridViewTextBoxCell SinhVienIDCell = new DataGridViewTextBoxCell();
                SinhVienIDCell.Value = lyDo.SinhVienID;
                row.Cells.Add(hoTenCell);
                row.Cells.Add(SinhVienIDCell);
                row.Cells.Add(lyDoTextCell);
                dgvDanhSach.Rows.Add(row);
            }
        }
        #endregion

        private void btnOk_Click(object sender, EventArgs e)
        {
            PLyDo pLyDo = new PLyDo();
            PThongBao pThongBao = new PThongBao();
            foreach (DataGridViewRow row in dgvDanhSach.Rows)
            {
                if (!row.IsNewRow)
                {
                    string lyDoText = "";
                    if (row.Cells[2].Value != null)
                    {
                        lyDoText = row.Cells[2].Value.ToString();
                    }

                    int sinhVienID = Convert.ToInt32(row.Cells[1].Value);

                    LyDo lyDoHoTen = new LyDo
                    {
                        LyDoText = lyDoText,
                        SinhVienID = sinhVienID,
                        LuanVanID = luanVan.ID
                    };
                    if (lyDoText != "")
                    {
                        pLyDo.Them(lyDoHoTen);
                        pThongBao.ThemThongBaoKoDuyetLuanVan((int)lyDoHoTen.SinhVienID, (int)lyDoHoTen.LuanVanID, lyDoHoTen.LyDoText);
                    }
                }
            }
            PNhom pNhom = new PNhom();
            pNhom.XoaTheoLuanVanID(luanVan.ID);

            luanVan.TinhTrang = "Chưa đăng ký";
            PLuanVan pLuanVan = new PLuanVan();

            pLuanVan.CapNhat(luanVan);

            OkButtonClicked?.Invoke(this, EventArgs.Empty);
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
