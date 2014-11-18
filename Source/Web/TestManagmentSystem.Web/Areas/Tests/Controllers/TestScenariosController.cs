namespace TestManagmentSystem.Web.Areas.Tests.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using TestManagmentSystem.Data.Models;
    using TestManagmentSystem.Data.UnitOfWork;
    using TestManagmentSystem.Web.Areas.Tests.Infrastructure.Services.Contracts;
    using TestManagmentSystem.Web.Areas.Tests.InputModels;
    using TestManagmentSystem.Web.Areas.Tests.ViewModels;
    using TestManagmentSystem.Web.Controllers;
    using TestManagmentSystem.Web.Infrastructure;

    [Authorize]
    public class TestScenariosController : BaseController
    {
        private const int ItemsPerPage = 5;
        private readonly ITestScenarioServices testScenarioServices;
        private readonly ISanitizer sanitizer;

        public TestScenariosController(ITestManagmentSystemData data, ITestScenarioServices services, ISanitizer sanitizer)
            : base(data)
        {
            this.sanitizer = sanitizer;
            this.testScenarioServices = services;
        }

        public ActionResult Index(int id = 1)
        {
            return View(id);
        }

        [OutputCache(Duration = 5 * 1)]
        public ActionResult AllScenarios(int? page = 1, string searchPattern = "")
        {
            int numberOfPages = 1;
            var partial = PartialView("_TestScenariosPartial", this.testScenarioServices.GetTestScenarioViewModel(out numberOfPages, ItemsPerPage, page ?? 1));

            TempData["CurrentPage"] = page;
            TempData["ActionLink"] = "/Tests/TestScenarios/Index";
            TempData["NumberOfPages"] = numberOfPages;

            return partial;
        }

        public ActionResult Create ()
        {
            var model = new TestScenarioInputModel();
            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TestScenarioInputModel input)
        {
            if (ModelState.IsValid)
            {
                var scenario = new TestScenario
                    {
                        Name = sanitizer.Sanitize(input.Name),
                        Description = sanitizer.Sanitize(input.Description),
                        Type = input.Type,
                        ProjectId = input.Project,
                        SystemEnvironmentId = input.System
                    };

                this.Data.TestScenarios.Add(scenario);
                this.Data.SaveChanges();
                TempData["NotificationMessage"] = "Test Scenario successfully created";
                return this.RedirectToAction("AllScenarios");
            }

            return this.View(input);
        }
    }
}
