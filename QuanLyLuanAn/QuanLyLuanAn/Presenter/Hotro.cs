using DataLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyLuanAn.BUS
{
    public class Hotro
    {
        public static NguoiDung user = new NguoiDung();
        public static Form form;
        public static EThaotac thaotac;
        public static LuanVan hienThi = new LuanVan();
        public static List<Nhom> nhoms = new List<Nhom>();
    }

    public enum EThaotac
    {
        ThemMoi,
        CapNhat,
        DangKy,
        Khong
    }
}
