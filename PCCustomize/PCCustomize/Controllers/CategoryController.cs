using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PCCustomize.Models;

namespace PCCustomize.Controllers
{
    [Authorize(Users = "admin")]
    public class CategoryController : Controller
    {
        CustomizeDB _db = new CustomizeDB();
        //
        // GET: /Category/

        public ActionResult Index()
        {
            var model = _db.Cates.Where(r => r.IsDel == 0).ToList();
            ViewBag.PadTitle = "List of Customized PC";
            ViewBag.Title = "HomePage";

            return View(model);
        }

        //
        // GET: /Category/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Category/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Category/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Category/Edit/5

        public ActionResult Edit(int id)
        {

            return View();
        }

        //
        // POST: /Category/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {

            return View();
        }

        //
        // GET: /Category/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Category/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //static List<Category> _cates = new List<Category> 
        //{
        //    new Category{
        //        Id = 100,
        //        Name = "Test",
        //        IsDel = 0
        //    }        
        //};

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }

            base.Dispose(disposing);
        }

    }
}
