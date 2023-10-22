using Shop.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new ProjectEntities();
            var data = db.tbl_Product.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tbl_Product d)
        {
            var db = new ProjectEntities();
            db.tbl_Product.Add(d);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new ProjectEntities();
            var data = db.tbl_Product.Find(id);
            
            return View(data);
        }
        public ActionResult Details(int id)
        {
            var db = new ProjectEntities();
            var dept = db.tbl_Product.Find(id);
         
            return View(dept);

        }
        [HttpPost]
        public ActionResult Edit(tbl_Product d)
        {
            var db = new ProjectEntities();
            var ex = db.tbl_Product.Find(d.Id);
            ex.P_Name = d.P_Name;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var db = new ProjectEntities();
            var ex = db.tbl_Product.Find(id);
            db.tbl_Product.Remove(ex);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
      

       
        
    }
}
    