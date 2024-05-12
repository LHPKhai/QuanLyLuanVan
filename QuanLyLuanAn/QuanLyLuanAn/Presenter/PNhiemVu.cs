using DataLibrary;
using QuanLyLuanAn.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace QuanLyLuanAn.BUS
{
       public class PNhiemVu
       {
            private DBConnect<NhiemVu> _dbConnect;
            public PNhiemVu()
            {
                _dbConnect = new DBConnect<NhiemVu>();
            }
       #region CRUD
            public List<NhiemVu> Load()
            {
                return _dbConnect.LayDanhSach();
            }

            public NhiemVu LayNhiemVuTheoID(int id)
            {
                return _dbConnect.LayTheoID(id);
            }

            public int ThemNhiemVu(NhiemVu nhiemVu)
            {
                return _dbConnect.Them(nhiemVu);
            }

            public void XoaNhiemVu(int id)
            {
                _dbConnect.Xoa(id);
            }

            public void CapNhatNhiemVu(NhiemVu nhiemVu)
            {
                _dbConnect.CapNhat(nhiemVu);
            }
       #endregion
       #region thao tác khác
            public NguoiDung LayThongTinGiangVienTheoNhiemVu(int nhiemVuID)
            {
                PNguoiDung pNguoiDung = new PNguoiDung();
                PLuanVan pLuanVan = new PLuanVan();
                return pNguoiDung.LayNguoiDungTheoID((int)pLuanVan.LayLuanVanTheoID((int)LayNhiemVuTheoID(nhiemVuID).LuanVanID).GiangVienID);
            }

            public NguoiDung LayThongTinSinhVienTheoNhiemVu(int nhiemVuID)
            {
                NguoiDung nguoiDung = new NguoiDung();
                PNguoiDung pNguoiDung = new PNguoiDung();
                NhiemVu nv = LayNhiemVuTheoID(nhiemVuID);
                if(nv.NguoiDuocGiao != null)
                {
                    nguoiDung = pNguoiDung.LayNguoiDungTheoID(nv.NguoiDuocGiao.Value);
                }
                return nguoiDung;
            }
       #endregion
    }
}
