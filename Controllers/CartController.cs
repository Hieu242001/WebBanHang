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
    public class CartController : ApiController
    {
        List<ChiTietHoaDon> cthd = new List<ChiTietHoaDon>();
        // GET api/<controller>
        ThietBiDataContext db = new ThietBiDataContext();

        // GET api/<controller>/5
        public List<Product> Get(string id)
        {
            IEnumerable<HoaDonBan> hdb = db.HoaDonBans.Where(n => n.ID_KhachHang == id).Where(n => n.TrangThai == false);

            foreach (var item in hdb)
            {
                var id_HDB = item.ID_HDB;
                IEnumerable<ChiTietHoaDon> temp = db.ChiTietHoaDons.Where(n => n.ID_HDB == item.ID_HDB);
                foreach (ChiTietHoaDon ct in temp)
                {
                    cthd.Add(ct);
                }

            }
            var product = from p in cthd
                          join c in db.SanPhams.OrderBy(n => n.ID_SanPham) on p.ID_SanPham equals c.ID_SanPham
                          select new
                          {
                              id = c.ID_SanPham,
                              id_hd = p.ID_HDB,
                              tenSP = c.TenSanPham,
                              trongluong = c.TRONGLUONG,
                              namSX = c.NamSanXuat,
                              kichThuoc = c.KichThuoc,
                              id_LoaiSP = c.ID_LoaiSanPham,
                              mota = c.MoTaChiTiet,
                              gianhap = c.GIANHAP,
                              giaban = p.DonGia,
                              sl = p.SoLuong
                          };
            List<Product> lstSP = new List<Product>();
            foreach (var item in product)
            {
                Product sp = new Product();
                sp.Id = item.id;
                sp.Id_hd = item.id_hd;
                sp.TenSP = item.tenSP;
                sp.Mota = item.mota;
                var img = db.AnhSanPhams.Where(n => n.ID_SanPham == item.id).FirstOrDefault();
                sp.Image = img.TenAnh;
                sp.Gia = item.giaban;
                sp.Soluong = item.sl;

                lstSP.Add(sp);
            }
            return lstSP;
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public bool Delete(string id_hd, string id_sp)
        {
            try
            {
               
                while(id_hd.Length < 3)
                {
                    id_hd = "0" + id_hd;
                }
                while (id_sp.Length < 2)
                {
                    id_sp = "0" + id_sp;
                }
                ChiTietHoaDon cthd = db.ChiTietHoaDons.FirstOrDefault(n => n.ID_HDB == id_hd && n.ID_SanPham == id_sp);
                if (cthd == null)
                {
                    return false;
                }
               
                db.ExecuteCommand("Delete from ChiTietHoaDon where ID_HDB = " + id_hd + " AND ID_SAnPHam = " + id_sp);
                
                //if (db.ChiTietHoaDons.Where(n => n.ID_HDB == id_hd).Count() == 0)
                //{
                //    HoaDonBan hdb = db.HoaDonBans.Where(n => n.ID_HDB == id_hd).FirstOrDefault();
                //    if (hdb != null)
                //    {
                //        db.HoaDonBans.DeleteOnSubmit(hdb);
                //        db.SubmitChanges();
                //    }
                //}
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}