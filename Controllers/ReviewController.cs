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
    public class ReviewController : ApiController
    {


        ThietBiDataContext db = new ThietBiDataContext();
        // GET api/<controller>/5
        public IEnumerable<Comment> Get(string id)
        {
            IEnumerable<Review> rv = db.Reviews.Where(n => n.ID_SanPham == id).OrderByDescending(n => n.Ngay_Review).ToList();
            List<Comment> lstCmt = new List<Comment>();

            foreach (var item in rv)
            {
                Comment cmt = new Comment();
                cmt.Id = item.ID_Review;
                cmt.TenKhach = db.TaiKhoanKhachHangs.Where(n => n.ID_KhachHang == item.ID_KhachHang).FirstOrDefault().HoTenKhachHang;
                cmt.NgayReview = (DateTime)item.Ngay_Review;
                cmt.Rate = (int)item.Rating;
                cmt.Cmt = item.comment;
                lstCmt.Add(cmt);
            }
            return lstCmt;
        }

        // POST api/<controller>
        [HttpPost]
        public bool addReview(Comment comment)
        {
            try
            {
                int value = int.Parse(db.Reviews.OrderByDescending(n => n.ID_Review)
                                     .Select(n => n.ID_Review).First().ToString());
                value++;
                string id = value.ToString();
                while (id.Length < 3)
                {
                    id = "0" + id;
                }
                comment.Id = id;
                comment.NgayReview = DateTime.Now;
               
                
                db.ExecuteCommand("Insert review values ('" +
                     comment.Id + "','" + comment.MaSanPham + "','" + comment.MaKhach + "'," +
                    comment.Rate + ",'" + comment.Cmt + "'," + "getdate()" + ")");
                return true;
            }
            catch
            {
                return false;
            }

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