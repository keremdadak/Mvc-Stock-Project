using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index(string p)
        {
            var degerler = from d in db.tbl_Customers select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.Customer_Name.Contains(p));
            }
            return View(degerler.ToList());
            //var degerler = db.tbl_Customers.ToList();
            //return View(degerler);
        }
        [HttpGet]
        public ActionResult NewCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewCustomer(tbl_Customers p1)
        {
            if (!ModelState.IsValid) {
                return View("NewCustomer");
                    }
            db.tbl_Customers.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
           
        }
        public ActionResult DeleteCustomer(int id)
        {
            var customer = db.tbl_Customers.Find(id);
            db.tbl_Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CustomerGet(int id)
        {
            var custmr = db.tbl_Customers.Find(id);
            return View("CustomerGet",custmr);
        }
        public ActionResult CustomerUpdate(tbl_Customers p1)
        {
            var cstmr = db.tbl_Customers.Find(p1.Customer_ID);
            cstmr.Customer_Name = p1.Customer_Name;
            cstmr.Customer_Surname = p1.Customer_Surname;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}