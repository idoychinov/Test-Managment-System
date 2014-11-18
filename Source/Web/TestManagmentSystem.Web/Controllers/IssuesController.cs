namespace TestManagmentSystem.Web.Controllers
{
    
    using System;
    using System.Web.Mvc;
    using TestManagmentSystem.Data.UnitOfWork;
    using TestManagmentSystem.Web.Infrastructure.Services.Contracts;

    public class IssuesController: BaseController
    {
        private const int ItemsPerPage = 5;
        private readonly IIssuesServices issuesServices;

        public IssuesController(ITestManagmentSystemData data, IIssuesServices services)
            : base(data)
        {
            this.issuesServices = services;
        }

        public ActionResult Index(int id = 1)
        {
            return View(id);
        }

        [OutputCache(Duration = 5 * 1)]
        public ActionResult ActiveIssues(int? page = 1, string searchPattern="")
        {
            int numberOfPages=1;
            var partial = PartialView("_ActiveIssuesPartial", this.issuesServices.GetIssuesViewModel(out numberOfPages, searchPattern, ItemsPerPage, page??1));
            
            TempData["CurrentPage"] = page;
            TempData["ActionLink"] = "/Issues/Index";
            TempData["NumberOfPages"] = numberOfPages;

            return partial;
        }

    }
}