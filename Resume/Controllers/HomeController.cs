using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Resume.Models;
using Resume.ViewModel;

namespace Resume.Controllers
{
    public class HomeController : Controller
    {
        CvDb _db = new CvDb();

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome";

            return View();
        }

        public ActionResult Skills()
        {
            ViewBag.Message = "Here's couple things that I think I'm not bad at";

            return View();
        }

        public ActionResult Cv()
        {
            ViewBag.Message = "My name is Daniel";

            return View();
        }


        public JsonResult GetCvItems(string filter = "", string search = "")
        {
            ViewBag.Filter = filter;
            var model = from r in _db.CvParts
                        where (filter == "none" || r.flag == filter) &&
                        (search == null || search == "" || r.Activity.Contains(search)
                        || r.Description.Contains(search))
                        orderby r.Start descending
                        select r;

            var viewModel = model.Select(x => new CvViewModel()
            {
                Cv = x
            });

            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }




        public ActionResult Chat()
        {
            ViewBag.Message = "Try it out";

            return View();
        }

        [HttpGet]
        public ActionResult Feedback()
        {
            ViewBag.Message = "I apreciate every comment on my work";
            var model = (from x in _db.Feedbacks
                         orderby x.Time descending
                         select x)
                            .Take(5);
            return View(model);
        }

        [HttpPost]
        public ActionResult Feedback(string feedback, string name)
        {
            if (ModelState.IsValid)
            {
                _db.Feedbacks.Add(new Feedback
                    {
                        Name = name,
                        Time = DateTime.Now,
                        Comment = feedback
                    });
                _db.SaveChanges();
                return RedirectToAction("Feedback");
            }
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Web resume is unique way to represent yourself";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "My contact page";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
                _db.Dispose();
            base.Dispose(disposing);
        }
    }
}
