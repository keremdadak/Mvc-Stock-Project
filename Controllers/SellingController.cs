using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class SellingController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities();
        // GET: Selling
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult NewSelling()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewSelling(tbl_Selling p)
        {
            db.tbl_Selling.Add(p);
            db.SaveChanges();
            return View("Index");
        }
        public ActionResult SellingTable()
        {
            var degerler = db.tbl_Selling.ToList();
            return View(degerler);
        }
        public ActionResult DeleteSelling(int id)
        {
            var selldelete = db.tbl_Selling.Find(id);
            db.tbl_Selling.Remove(selldelete);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}