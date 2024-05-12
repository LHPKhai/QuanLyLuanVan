using DataLibrary;
using QuanLyLuanAn.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuanAn.BUS
{
    public class PLyDo
    {
        #region CRUD
        public void Them(LyDo lyDo)
        {
            using (var context = new DBConnect<LyDo>())
            {
                context.Them(lyDo);
            }
        }

        public void CapNhat(LyDo lyDo)
        {
            using (var context = new DBConnect<LyDo>())
            {
                context.CapNhat(lyDo);
            }
        }

        public void Xoa(int lyDoID)
        {
            using (var context = new DBConnect<LyDo>())
            {
                context.Xoa(lyDoID);
            }
        }

        public List<LyDo> LayDanhSach()
        {
            using (var context = new DBConnect<LyDo>())
            {
                return context.LayDanhSach();   
            }
        }
        #endregion
        #region Thao tác khác
        public List<Nhom> LayDanhSachNhomTheoLuanVanID(int luanVanID)
        {
            using (var dbConnect = new DAL.DBConnect<Nhom>())
            {
                var nhomList = dbConnect.LayDanhSach();
                return nhomList.Where(n => n.LuanVanID == luanVanID).ToList();
            }
        }

        public List<LyDo_HoTen> TaoDanhSachLyDoHoTen(List<NguoiDung> danhSachNguoiDung, int luanVanID)
        {
            List<LyDo_HoTen> danhSachLyDo = new List<LyDo_HoTen>();
            foreach (var nguoiDung in danhSachNguoiDung)
            {
                int? sinhVienID = nguoiDung?.ID;
                danhSachLyDo.Add(new LyDo_HoTen
                {
                    LuanVanID = luanVanID,
                    SinhVienID = sinhVienID,
                    LyDoText = null,
                    HoTen = nguoiDung.HoTen
                });
            }
            return danhSachLyDo;
        }
        #endregion
    }
}
