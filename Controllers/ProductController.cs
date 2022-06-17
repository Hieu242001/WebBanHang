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
    public class ProductController : ApiController
    {
        // GET api/<controller>
        ThietBiDataContext db = new ThietBiDataContext();
        public IEnumerable<Product> Get()
        {
            IEnumerable<SanPham> lstSP =  db.SanPhams.ToList();
            List<Product> sps = new List<Product>();
            foreach(var item in lstSP)
            {
                try
                {
                    Product sp = new Product();
                    sp.Id = item.ID_SanPham;
                    sp.TenSP = item.TenSanPham;
                    sp.Mota = item.MoTaChiTiet;
                    var img = db.AnhSanPhams.Where(n => n.ID_SanPham == item.ID_SanPham).First();
                    sp.Image = img.TenAnh;
                    sp.Gia = item.GIABAN;
                    sp.Soluong = item.SoLuongKho;
                    sps.Add(sp);
                }
                catch (Exception e)
                {
                    
                }
                

                
            }
            return sps;
           

        }

        // GET api/<controller>/5
        public Product Get(string id)
        {
            SanPham sp = db.SanPhams.FirstOrDefault(n => n.ID_SanPham == id);
            if(sp == null)
            {
                return null;
            }
            Product product = new Product();
            product.Id = sp.ID_SanPham;
            product.TenSP = sp.TenSanPham;
            product.Mota = sp.MoTaChiTiet;
            var img = db.AnhSanPhams.Where(n => n.ID_SanPham == sp.ID_SanPham).First();
            product.Image = img.TenAnh;
            product.Gia = sp.GIABAN;
            product.Soluong = sp.SoLuongKho;
            return product;
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
        public void Delete(int id)
        {
        }
    }
}