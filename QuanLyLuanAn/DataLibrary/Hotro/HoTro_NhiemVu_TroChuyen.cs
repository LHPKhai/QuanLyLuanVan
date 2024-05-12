using System;

namespace DataLibrary.Hotro
{
    public class HoTro_Chat : NhiemVu_TroChuyen
    {
        public string TenNguoiGui { get; set; }
        public string TenNguoiNhan { get; set; }
        public int NguoiNhanID { get; set; }

        public HoTro_Chat() : base() { }
        public HoTro_Chat(int id, string noiDung, DateTime? thoiGian, int? nhiemVuID, int nguoiGiu, string tenNguoiGui, string tenNguoiNhan, int nguoiNhanID)
            : base(id, noiDung, thoiGian, nhiemVuID, nguoiGiu)
        {
            TenNguoiGui = tenNguoiGui;
            TenNguoiNhan = tenNguoiNhan;
            NguoiNhanID = nguoiNhanID;
        }
    }
}
