namespace TestManagmentSystem.Web.Controllers
{
    using System;
    using System.Web.Mvc;
    using TestManagmentSystem.Data.UnitOfWork;
    using TestManagmentSystem.Web.Infrastructure.Services.Contracts;

    public class SystemsController : BaseController
    {
        private const int ItemsPerPage = 3;
        private readonly ISystemsServices systemServices;

        public SystemsController(ITestManagmentSystemData data, ISystemsServices services)
            : base(data)
        {
            this.systemServices = services;
        }

        public ActionResult Index(int id = 1)
        {
            return View(id);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 5 * 1)]
        public ActionResult TestedSystems(int? page = 1)
        {
            int numberOfPages=1;
            var partial = PartialView("_TestedSystemsPartial", this.systemServices.GetSystemsViewModel(out numberOfPages, ItemsPerPage, page??1));
            
            TempData["CurrentPage"] = page;
            TempData["ActionLink"] = "/Systems/Index";
            TempData["NumberOfPages"] = numberOfPages;

            return partial;
        }

    }
}