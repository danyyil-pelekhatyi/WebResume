using System;
using System.Linq;
using System.Web.Mvc;
using Ninject;
using Resume.Core.Interfaces;
using Resume.Core.Models;
using Resume.Web.App_Start;
using Resume.Web.ViewModel;


namespace Resume.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

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


        public JsonResult GetCvItems(string filter = "none", string search = "")
        {
            ViewBag.Filter = filter;
            var model =
                _unitOfWork.Activities.Find(
                    e => (e.ActivityType.ActivityTypeName == filter || filter == "none") && (e.ActivityName.Contains(search) || e.Description.Contains(search)));
            var viewModel = model.Select(x => new ActivityViewModel
            {
                Activity = x
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
            var model = _unitOfWork.Feedbacks.Find(e => true).Take(5);

            return View(model);
        }

        [HttpPost]
        public ActionResult Feedback(string feedback, string name)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Feedbacks.Add(new Feedback
                    {
                        Name = name,
                        Time = DateTime.Now,
                        Comment = feedback
                    });
                _unitOfWork.Commit();
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
    }
}
