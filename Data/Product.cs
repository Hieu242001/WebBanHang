using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebThietBi.Data
{
    public class Product
    {
        private string id;
        private string id_hd;
        private string tenSP;
        private string mota;
        private string image;
        private double gia;
        private int soluong;
        
        public string Id { get => id; set => id = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public string Mota { get => mota; set => mota = value; }
        public string Image { get => image; set => image = value; }
        public double Gia { get => gia; set => gia = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        public string Id_hd { get => id_hd; set => id_hd = value; }
    }
}