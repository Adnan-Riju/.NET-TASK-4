using Shop.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Category_Index()
        {
            var db = new ProjectEntities();
            var data = db.tbl_Category.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create_Category()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create_Category(tbl_Category c )
        {
            var db = new ProjectEntities();
            db.tbl_Category.Add(c);
            db.SaveChanges();

            return RedirectToAction("Category_Index");
        }
        [HttpGet]
        public ActionResult Edit_Category(int CatId)
        {
            var db = new ProjectEntities();
            var data = db.tbl_Category.Find(CatId);

            return View(data);
        }
        public ActionResult Category_Details(int id)
        {
            var db = new ProjectEntities();
            var dept = db.tbl_Category.Find(id);

            return View(dept);

        }
        [HttpPost]
        public ActionResult Edit_Category(tbl_Category d)
        {
            var db = new ProjectEntities();
            var ex = db.tbl_Category.Find(d.Category);
            ex.Category = d.Category;
            db.SaveChanges();
            return RedirectToAction("Category_Index,Category");
        }
        public ActionResult Delete(int CatId)
        {

            var db = new ProjectEntities();
            var exdata = db.tbl_Category.Find(CatId);
            db.tbl_Category.Remove(exdata);
            db.SaveChanges();
            return RedirectToAction("Category_Index,Category");
        }
    }
}