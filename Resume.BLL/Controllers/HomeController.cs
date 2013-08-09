using System;
using System.Data.Objects;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Resume.Core.Interfaces;
using Resume.Core.Models;
using Resume.Infrastructure.ViewModel;
using Resume.Infrastructure.Repositories;
using Resume.Infrastructure.UnitOfWork;

namespace Resume.Infrastructure.Controllers
{
    public class HomeController : Controller
    {
        //private readonly CvDb _db = new CvDb();
        private IUnitOfWork _unitOfWork;
        private IRepository<Activity> _activityRepository;//= new Repository<Activity>(_db);
        private IRepository<Feedback> _feedbackRepository;// = new Repository<Feedback>(_db);

        public void InitUnitOfWork(IUnitOfWork unitOfWork)
        {
            if (_unitOfWork == null)
            {
                var container = new UnityContainer();
                container.RegisterType<IUnitOfWork, SimpleUnitOfWork>();
                //container.RegisterType<IRepository<T>, Repository<T>>();
                _unitOfWork = container.Resolve<IUnitOfWork>();
                _activityRepository = _unitOfWork.Activities;
                _feedbackRepository = _unitOfWork.Feedbacks;
            }
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
            InitUnitOfWork(new SimpleUnitOfWork());
            var model =
                _activityRepository.Find(
                    e => (e.ActivityType.ActivityTypeName == filter || filter == "none") && (e.ActivityName.Contains(search) || e.Description.Contains(search)));

            //var model = from r in _db.Activities
            //            where (filter == "none" ||
            //            (from t in _db.ActivityTypes where t.ActivityTypeId == r.ActivityType.ActivityTypeId select t.ActivityTypeName).ToString() == filter) &&
            //            (string.IsNullOrEmpty(search) || r.ActivityName.Contains(search) || r.Description.Contains(search))
            //            orderby r.Start descending
            //            select r;

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
            InitUnitOfWork(new SimpleUnitOfWork());
            //var model = (from x in _db.Feedbacks
            //             orderby x.Time descending
            //             select x)
            //                .Take(5);
            var model = _feedbackRepository.Find(e => true).Take(5);

            return View(model);
        }

        [HttpPost]
        public ActionResult Feedback(string feedback, string name)
        {
            if (ModelState.IsValid)
            {
                InitUnitOfWork(new SimpleUnitOfWork());
                _feedbackRepository.Add(new Feedback
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

        //protected override void Dispose(bool disposing)
        //{
        //    if (_db != null)
        //        _db.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}
