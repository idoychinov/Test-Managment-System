namespace TestManagmentSystem.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using TestManagmentSystem.Data.UnitOfWork;
    using TestManagmentSystem.Web.Areas.Administration.Controllers.Base;

    public class TestedSystemsController : AdminController
    {
        public TestedSystemsController(ITestManagmentSystemData data)
            :base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}