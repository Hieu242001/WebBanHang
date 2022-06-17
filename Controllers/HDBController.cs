using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebThietBi.Models;
using WebThietBi.Data;

namespace WebThietBi.Controllers
{
    public class HDBController : ApiController
    {
        ThietBiDataContext db = new ThietBiDataContext();
        List<HoaDonBan> HDB = new List<HoaDonBan>();
        public List<HDB> Get(string id)
        {
            IEnumerable<HoaDonBan> hdb = db.HoaDonBans.Where(n => n.ID_KhachHang == id && n.TrangThai == true);

            foreach (var item in hdb)
            {
                var id_HDB = item.ID_HDB;
                IEnumerable<HoaDonBan> temp = db.HoaDonBans.Where(n => n.ID_HDB == item.ID_HDB);
                foreach (HoaDonBan ct in temp)
                {
                    HDB.Add(ct);
                }

            }
            var hoadonban = from p in HDB
                            join c in db.ChiTietHoaDons.OrderBy(n => n.ID_HDB) on p.ID_HDB equals c.ID_HDB
                            join c2 in db.SanPhams.OrderBy(n => n.ID_SanPham) on c.ID_SanPham equals c2.ID_SanPham
                            select new
                            {
                                id_HDB = p.ID_HDB,
                                ngayLapHDB = p.NgayLapHDB,
                                id_KhachHang = p.ID_KhachHang,
                                id_SanPham = c.ID_SanPham,
                                tenSanPham = c2.TenSanPham,
                                soluong = c.SoLuong,
                                dongia = c.DonGia,


                            };
            List<HDB> lstHDB = new List<HDB>();
            foreach (var item in hoadonban)
            {
                HDB hd = new HDB();
                hd.Id_HDB = item.id_HDB;
                hd.NgayLapHDB = item.ngayLapHDB;
                hd.Id_KhachHang = item.id_KhachHang;
                hd.TenSanPham = item.tenSanPham;
                hd.Soluong = item.soluong;
                hd.DonGia = item.dongia;

                lstHDB.Add(hd);
            }
            return lstHDB;
        }

    }
}