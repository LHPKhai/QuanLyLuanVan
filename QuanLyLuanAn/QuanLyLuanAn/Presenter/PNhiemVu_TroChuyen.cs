using DataLibrary;
using DataLibrary.Hotro;
using QuanLyLuanAn.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;

namespace QuanLyLuanAn.BUS
{
    public class PNhiemVu_TroChuyen
    {
        private DBConnect<NhiemVu_TroChuyen> _dbConnect;
        public NguoiDung nguoiDung;
        public NguoiDung nguoiNhan;
        public List<HoTro_Chat> lichSuTroChuyenCuaNhiemVu;
        int nhiemVuID;
        public PNhiemVu_TroChuyen(int nhiemVuID)
        {
            _dbConnect = new DBConnect<NhiemVu_TroChuyen>();
            this.nhiemVuID = nhiemVuID;
            PNhiemVu pNhiemVu = new PNhiemVu();
            nguoiDung = Hotro.user;
            if (Hotro.user.VaiTro == "SinhVien")
            {
                nguoiNhan = pNhiemVu.LayThongTinGiangVienTheoNhiemVu(nhiemVuID);
            }
            else
            {
                nguoiNhan = pNhiemVu.LayThongTinSinhVienTheoNhiemVu(nhiemVuID);
            }
            lichSuTroChuyenCuaNhiemVu = LichSuTroChuyenCuaNhiemVu();
        }
        #region CRUD
        public List<NhiemVu_TroChuyen> LayDanhSach()
        {
            return _dbConnect.LayDanhSach();
        }

        public NhiemVu_TroChuyen LayTheoID(int id)
        {
            return _dbConnect.LayTheoID(id);
        }

        public void GuiTinNhan(NhiemVu_TroChuyen nv)
        {
            _dbConnect.Them(nv);
        }

        public void Xoa(int id)
        {
            _dbConnect.Xoa(id);
        }

        public void CapNhatPNhiemVu_TroChuyen(NhiemVu_TroChuyen nv)
        {
            _dbConnect.CapNhat(nv);
        }
        #endregion
        #region thao tác

        public List<HoTro_Chat> LichSuTroChuyenCuaNhiemVu()
        {
            List<NhiemVu_TroChuyen> chats = _dbConnect.LayDanhSach();
            List<HoTro_Chat> lichSu = new List<HoTro_Chat>();         

            if (chats != null)
            {
                foreach (var chat in chats)
                {
                    if (chat.NhiemVuID == nhiemVuID)
                    {
                        HoTro_Chat hoTroChat = new HoTro_Chat
                        {
                            ID = chat.ID,
                            NoiDung = chat.NoiDung,
                            ThoiGian = chat.ThoiGian,
                            NhiemVuID = chat.NhiemVuID,
                            NguoiGiu = chat.NguoiGiu
                        };

                        if (nguoiNhan != null && nguoiNhan.ID == chat.NguoiGiu)
                        {
                            hoTroChat.TenNguoiGui = nguoiNhan.HoTen;
                            hoTroChat.TenNguoiNhan = nguoiDung.HoTen;
                            hoTroChat.NguoiNhanID = nguoiDung.ID;
                        }
                        else
                        {
                            hoTroChat.TenNguoiGui = nguoiDung.HoTen;
                            hoTroChat.TenNguoiNhan = nguoiNhan.HoTen;
                            hoTroChat.NguoiNhanID = nguoiNhan.ID;
                        }

                        lichSu.Add(hoTroChat);
                    }
                }
            }

            lichSu = lichSu.OrderBy(x => x.ThoiGian).ToList();

            return lichSu;
        }

        #endregion
    }
}
