using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PCCustomize.Models;
using PCCustomize.Services;
using PagedList;

namespace PCCustomize.Controllers
{
    public class HomeController : Controller
    {
        CustomizeDB _db = new CustomizeDB();

        private IMailService _mail;
        private IMessage _msg;


        public HomeController(IMailService mail, IMessage msg)
        {
            _mail = mail;
            _msg = msg;
        }

        public ActionResult Autocomplete(string term)
        {
            var model =
                _db.Computers
                   .Where(r => r.Name.Contains(term) && r.IsDel == 0)
                   .Take(5)
                   .Select(r => new
                   {
                       label = r.Name
                   });

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index(string searchTerm = null, int page = 1)
        {
            //var model = _db.Computers.Where(r => r.IsDel == 0).OrderByDescending(r => r.LastUpdate).ToList();
            ViewBag.PadTitle = "List of Customized PC";
            ViewBag.Title = "HomePage";
            var model = (from r in _db.Computers
                        where r.IsDel == 0 && (searchTerm == null || r.Name.Contains(searchTerm))
                        orderby r.LastUpdate descending
                        select new ComputerListViewModel
                        {
                            Id = r.Id,
                            Name = r.Name,
                            Price = r.Price,
                            LastUpdate = r.LastUpdate,
                            NumberOfTopics = r.Topics.Count()
                        }).ToPagedList(page, 5);

            if (Request.IsAjaxRequest()) 
            {
                return PartialView("_PCList", model);
            }

            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }

            base.Dispose(disposing);
        }

        [HttpPost]
        public ActionResult Contact(Contact model)
        {
            var msg = string.Format("Comment from: {1}{0}Email: {2}{0}Website: {3}{0}Comment{4}",
                Environment.NewLine,
                model.Name,
                model.Email,
                model.Website,
                model.Comment);
            if(_mail.SendMail("zc77@drexel.edu", "zc77@drexel.edu", "Website Contact", msg))
            {
                ViewBag.MailSent = true;
            }
            return View();
        }

    }
}
