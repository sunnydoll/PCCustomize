using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PCCustomize.Models;
using WebMatrix.WebData;
using PagedList;

namespace PCCustomize.Controllers
{
    [Authorize]
    public class ComputerController : Controller
    {
        CustomizeDB _db = new CustomizeDB();
        private IMessage _msg;
        //
        // GET: /Computer/

        public ComputerController(IMessage msg)
        {
            _msg = msg;
        }

        public ActionResult Index(int page = 1)
        {
            int id = WebSecurity.CurrentUserId;
            var model = (from r in _db.Computers
                         where r.IsDel == 0 && r.UserId == id
                         orderby r.LastUpdate descending
                         select new ComputerListViewModel
                         {
                             Id = r.Id,
                             Name = r.Name,
                             Price = r.Price,
                             LastUpdate = r.LastUpdate,
                             NumberOfTopics = r.Topics.Count()
                         }).ToPagedList(page, 10);

            return View(model);
        }

        //
        // GET: /Computer/Details/5

        public ActionResult Details(int id)
        {
            Computer computer = _db.Computers.Find(id);
            var topics = _db.Topics.Where(r => r.ComputerId == id).OrderBy(r => r.Created).ToList();
            computer.Topics = _msg.GetTopics(id).OrderBy(r => r.Created).Take(20).ToList();
            if (computer == null)
            {
                return HttpNotFound();
            }
            return View(computer);
        }

        //public ActionResult MsgDetails(int id)
        //{
        //    var topics = _msg.GetTopics(id).OrderByDescending(r => r.Created).Take(20).ToList();
        //    //if (topics == null)
        //    //{
        //    //    return HttpNotFound();
        //    //}
        //    return View(topics);
        //}

        //
        // GET: /Computer/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Computer/Create

        [HttpPost]
        public ActionResult Create(Computer computer)
        {
            if (ModelState.IsValid)
            {
                computer.LastUpdate = DateTime.UtcNow;
                computer.IsDel = 0;
                computer.UserId = WebSecurity.CurrentUserId;
                _db.Computers.Add(computer);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(computer);
        }

        //
        // GET: /Computer/Edit/5

        public ActionResult Edit(int id)
        {
            Computer restaurant = _db.Computers.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        //
        // POST: /Computer/Edit/5

        [HttpPost]
        public ActionResult Edit([Bind(Exclude="IsDel, UserId")] int id, Computer computer)
        {
            if (ModelState.IsValid)
            {
                computer.LastUpdate = DateTime.UtcNow; 
                computer.IsDel = 0;
                computer.UserId = WebSecurity.CurrentUserId;
                _db.Entry(computer).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(computer);
        }

        //
        // GET: /Computer/Delete/5

        public ActionResult Delete(int id)
        {
            Computer computer = _db.Computers.Find(id);
            if (computer == null)
            {
                return HttpNotFound();
            }
            return View(computer);
        }

        //
        // POST: /Computer/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Computer computer = _db.Computers.Find(id);
            computer.IsDel = 1;
            if (ModelState.IsValid)
            {
                _db.Entry(computer).State = EntityState.Modified;
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

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
