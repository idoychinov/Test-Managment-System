namespace TestManagmentSystem.Web.Controllers
{
    using System;
    using System.Web.Mvc;
    using TestManagmentSystem.Data.UnitOfWork;
    using TestManagmentSystem.Web.Infrastructure.Services.Contracts;

    public class SystemsController : BaseController
    {
        private readonly ISystemsServices systemServices;

        public SystemsController(ITestManagmentSystemData data, ISystemsServices services)
            : base(data)
        {
            this.systemServices = services;
        }

        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        [OutputCache(Duration = 5 * 1)]
        public ActionResult TestedSystems()
        {
            return PartialView("_TestedSystemsPartial", this.systemServices.GetSystemsViewModel());
        }

        [OutputCache(Duration = 5 * 1)]
        public ActionResult View(int id)
        {
            return View();
        }
    }
}