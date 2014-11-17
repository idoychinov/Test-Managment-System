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

        [ChildActionOnly]
        [OutputCache(Duration = 5 * 1)]
        public ActionResult TestedSystems()
        {
            return PartialView("_TestedSystemsPartial", this.homeServices.GetIndexViewModel(3));
        }
    }
}