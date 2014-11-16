using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestManagmentSystem.Data;
using TestManagmentSystem.Data.UnitOfWork;
using TestManagmentSystem.Web.Infrastructure.Services.Contracts;

namespace TestManagmentSystem.Web.Controllers
{
    public class HomeController : BaseController
    {
        private IHomeServices homeServices;

        public HomeController(ITestManagmentSystemData data, IHomeServices services)
            :base(data)
        {
            this.homeServices = services;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [ChildActionOnly]
        [OutputCache(Duration = 60 * 60)]
        public ActionResult TestedSystems()
        {
            return PartialView("_TestedSystemsPartial", this.homeServices.GetIndexViewModel(5));
        }
    }
}