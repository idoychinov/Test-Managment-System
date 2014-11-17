namespace TestManagmentSystem.Web.Controllers
{
    using System;
    using System.Web.Mvc;
    using TestManagmentSystem.Data.UnitOfWork;
    using TestManagmentSystem.Web.Infrastructure.Services.Contracts;

    public class HomeController : BaseController
    {
        private const int NumberOfSystems = 3;
        private const int NumberOfIssues = 3;
        private IHomeServices homeServices;

        public HomeController(ITestManagmentSystemData data, IHomeServices services)
            : base(data)
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
            return PartialView("_TestedSystemsPartial", this.homeServices.GetIndexTestdSystemsViewModel(NumberOfSystems));
        }

        [ChildActionOnly]
        [OutputCache(Duration = 5 * 1)]
        public ActionResult Issues()
        {
            return PartialView("_LatestIssuesPartial", this.homeServices.GetIndexIssuesViewModel(NumberOfIssues));
        }
    }
}