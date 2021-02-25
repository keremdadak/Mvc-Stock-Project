using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcStok.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index(int sayfa = 1)
        {
            // var degerler = db.tbl_Category.ToList();
            var degerler = db.tbl_Category.ToList().ToPagedList(sayfa,10);
           


            return View(degerler);
        }
        [HttpGet]
        public ActionResult NewCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewCategory(tbl_Category p1)
        {
            if (!ModelState.IsValid) {
                return View("NewCategory");
            }
            db.tbl_Category.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
            
           
            
        }
        public ActionResult DeleteCategory(int id)
        {
            var kategori = db.tbl_Category.Find(id);
            db.tbl_Category.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CategoryGet(int id)
        {
            var ctgr = db.tbl_Category.Find(id);
            return View("CategoryGet",ctgr);
        }
        public ActionResult CategoryUpdate(tbl_Category p1)
        {
            var ctgr = db.tbl_Category.Find(p1.Category_ID);
            ctgr.Category_Name = p1.Category_Name;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}