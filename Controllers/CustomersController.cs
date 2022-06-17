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
    
    public class CustomersController : ApiController
    {
        // GET api/<controller>
        ThietBiDataContext db = new ThietBiDataContext();
        public IEnumerable<TaiKhoanKhachHang> Get()
        {
            return db.TaiKhoanKhachHangs.ToList();
        }

        // GET api/<controller>/5
        [HttpGet]
        public TaiKhoanKhachHang Get(string id)
        {
            TaiKhoanKhachHang customer = db.TaiKhoanKhachHangs.FirstOrDefault(n => n.SDT_KhachHang == id);
            if(customer == null)
            {
                return null;
            }
            Customer.id = customer.ID_KhachHang;
            return customer;
        }

        // POST api/<controller>
        [HttpPost]
       public bool AddCustomer(string fullName,string phone,string address,string pass)
        {
            try
            {
                IEnumerable<TaiKhoanKhachHang> lstCus = db.TaiKhoanKhachHangs.ToList();
                foreach(var item in lstCus)
                {
                    if(phone.ToString().Trim() == item.SDT_KhachHang.ToString().Trim())
                    {
                        return false;
                    }
                }
                int value = int.Parse(db.TaiKhoanKhachHangs.OrderByDescending(n => n.ID_KhachHang)
                                     .Select(n => n.ID_KhachHang).First().ToString());
                value++;
                string id_Customer = "";
                if (value < 10) id_Customer += "0";
                id_Customer += value;
                TaiKhoanKhachHang customer = new TaiKhoanKhachHang();
                customer.ID_KhachHang = id_Customer;
                customer.HoTenKhachHang = fullName;
                customer.SDT_KhachHang = phone;
                customer.DiaChi = address;
                customer.MatKhau = pass;

                db.TaiKhoanKhachHangs.InsertOnSubmit(customer);
                db.SubmitChanges();
                return true;
            }catch(Exception e)
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