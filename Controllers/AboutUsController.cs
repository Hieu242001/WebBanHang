using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebThietBi.Models;
using WebThietBi.Data;

namespace WebThietBi.Controllers
{
    public class AboutUsController : ApiController
    {
        // GET: api/AboutUs
        ThietBiDataContext db = new ThietBiDataContext();
        public IEnumerable<ThongTinCuaHang> Get()
        {
            return db.ThongTinCuaHangs.ToList();
        }

        // GET: api/AboutUs/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/AboutUs
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/AboutUs/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/AboutUs/5
        public void Delete(int id)
        {
        }
    }
}