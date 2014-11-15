using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestManagmentSystem.Data;
using TestManagmentSystem.Data.UnitOfWork;

namespace TestManagmentSystem.Web.Controllers
{
    public class HomeController : BaseController
    {
        // Poor man's DI
        /*
        public HomeController()
            :this(new TestManagmentSystemData(new TestManagmentSystemDbContext()))
        {
        }
        */

        public HomeController(ITestManagmentSystemData data)
            :base(data)
        {
        }

        public ActionResult Index()
        {
            ViewBag.TestedSystems = this.Data.TestedSystems.All().FirstOrDefault();
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
    }
}