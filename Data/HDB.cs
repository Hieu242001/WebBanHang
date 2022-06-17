using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebThietBi.Data
{
    public class HDB
    {
        private string id_HDB;
        private DateTime ngayLapHDB;
        private string id_KhachHang;
        private string id_SanPham;
        private string tenSanPham;
        private int soluong;
        private int donGia;


        public string Id_HDB { get => id_HDB; set => id_HDB = value; }
        public DateTime NgayLapHDB { get => ngayLapHDB; set => ngayLapHDB = value; }
        public string Id_KhachHang { get => id_KhachHang; set => id_KhachHang = value; }

        public string Id_SanPham { get => id_SanPham; set => id_SanPham = value; }
        public string TenSanPham { get => tenSanPham; set => tenSanPham = value; }
        public int Soluong { get => soluong; set => soluong = value; }

        public int DonGia { get => donGia; set => donGia = value; }

    }
}