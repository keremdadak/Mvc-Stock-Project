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
    public class ProductController : Controller
    {
        // GET: Product
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var degerler = db.tbl_Product.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult NewProduct()
        {
            List<SelectListItem> degerler = (from i in db.tbl_Category.ToList()
                                             select new SelectListItem { 
                                             Text=i.Category_Name,
                                             Value=i.Category_ID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult NewProduct(tbl_Product p1)
        {
            var ktg = db.tbl_Category.Where(m=>m.Category_ID==p1.tbl_Category.Category_ID).FirstOrDefault();
            p1.tbl_Category = ktg;
            db.tbl_Product.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteProduct(int id)
        {
            var product = db.tbl_Product.Find(id);
            db.tbl_Product.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ProductGet(int id)
        {
            var product = db.tbl_Product.Find(id);

            List<SelectListItem> degerler = (from i in db.tbl_Category.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Category_Name,
                                                 Value = i.Category_ID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("ProductGet", product);
        }
        public ActionResult ProductUpdate(tbl_Product p1)
        {
            var pupdt = db.tbl_Product.Find(p1.Product_ID);
            pupdt.Product_Name = p1.Product_Name;
            pupdt.Product_Brand = p1.Product_Brand;
            // pupdt.Product_Category = p1.Product_Category;
            var ktg = db.tbl_Category.Where(m => m.Category_ID == p1.tbl_Category.Category_ID).FirstOrDefault();
           pupdt.Product_Category = ktg.Category_ID;
            pupdt.Product_Price = p1.Product_Price;
            pupdt.Product_Stock = p1.Product_Stock;
            db.SaveChanges();


            return RedirectToAction("Index");

        }
    }
}