namespace TestManagmentSystem.Web.Controllers
{
    using System;
    using System.Web.Mvc;
    using TestManagmentSystem.Data.Models;
    using TestManagmentSystem.Data.UnitOfWork;

    public abstract class BaseController : Controller
    {
        public BaseController(ITestManagmentSystemData data)
        {
            this.Data = data;
        }

        protected ITestManagmentSystemData Data { get; set; }

        protected ApplicationUser CurrentUser { get; set; }
    }
}