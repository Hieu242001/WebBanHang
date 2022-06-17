using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using WebThietBi.Models;
namespace WebThietBi.Controllers
{
    public class BillController : ApiController
    {
        ThietBiDataContext db = new ThietBiDataContext();

        // GET api/<controller>
        public int Get()
        {
            
            return 1;
        }

        // GET api/<controller>/5
        [HttpGet]
        public HoaDonBan Get(string id_KH)
        {
          

                int value = int.Parse(db.HoaDonBans.OrderByDescending(n => n.ID_HDB)
                                     .Select(n => n.ID_HDB).First().ToString());
                value++;
                string id = value.ToString();

                while (id.Length < 3)
                {
                    id = "0" + id;
                }
                HoaDonBan hdb = new HoaDonBan();
                hdb.ID_HDB = id;
                hdb.ID_KhachHang = id_KH;
                hdb.NgayLapHDB = DateTime.Now;
                hdb.TrangThai = false;
                hdb.ThanhTien = 0;
                return hdb;
           
        }

        // POST api/<controller>
        public bool Post(string id_hdb,string id_sp,string id_KH,int soLuong,int donGia)
        {
            try
            {
                HoaDonBan hdb = db.HoaDonBans.FirstOrDefault(n => n.ID_HDB == id_hdb);
                if(hdb == null)
                {
                    hdb = new HoaDonBan();
                    hdb.ID_HDB = id_hdb;
                    hdb.ID_KhachHang = id_KH;
                    hdb.NgayLapHDB = DateTime.Now;
                    hdb.TrangThai = false;
                    hdb.ThanhTien = 0;
                    db.HoaDonBans.InsertOnSubmit(hdb);
                    db.SubmitChanges();
                }
                ChiTietHoaDon cthd = new ChiTietHoaDon();
                cthd.ID_HDB = id_hdb;
                cthd.ID_SanPham = id_sp;
                cthd.SoLuong = soLuong;
                cthd.DonGia = donGia;
                db.ExecuteCommand("Insert ChiTietHoaDon values('" + id_hdb + "','" + id_sp + "'," + soLuong + "," + donGia + ")");
                return true;
            }
            catch
            {
                return false;
            }

        }

        // PUT api/<controller>/5
        public bool Put(string id)
        {
            try
            {
                IEnumerable<HoaDonBan> bills = db.HoaDonBans.Where(n => n.ID_KhachHang == id).ToList();
                foreach(var item in bills)
                {
                    item.TrangThai = true;
                    db.SubmitChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}