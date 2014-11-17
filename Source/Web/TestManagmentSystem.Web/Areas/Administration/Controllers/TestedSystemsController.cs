namespace TestManagmentSystem.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Kendo.Mvc.UI;
    using TestManagmentSystem.Data.UnitOfWork;
    using TestManagmentSystem.Web.Areas.Administration.Controllers.Base;
    using Model = TestManagmentSystem.Data.Models.TestedSystem;
    using ViewModel = TestManagmentSystem.Web.Areas.Administration.ViewModels.TestedSystems.TestedSystemViewModel;

    public class TestedSystemsController : KendoGridAdministrationController
    {
        public TestedSystemsController(ITestManagmentSystemData data)
            :base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        protected override IEnumerable GetData()
        {
            return this.Data
                .TestedSystems
                .All()
                .Project()
                .To<ViewModel>();
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.TestedSystems.GetById(id) as T;
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            var dbModel = base.Create<Model>(model);
            if (dbModel != null) model.Id = dbModel.Id;
            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            base.Update<Model, ViewModel>(model, model.Id);
            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var testedSystem = this.Data.TestedSystems.GetById(model.Id.Value);

                var projects = this.Data
                        .Projects
                        .All()
                        .Where(p => p.TestedSystemId == testedSystem.Id)
                        .Select(c => c.Id)
                        .ToList();
                foreach(var project in projects)
                {
                    this.Data.Projects.Delete(project);
                }

                this.Data.SaveChanges();

                foreach (var environment in testedSystem.Environments.Select(t => t.Id).ToList())
                {
                    this.Data.Environments.Delete(environment);
                }

                this.Data.SaveChanges();

                this.Data.TestedSystems.Delete(testedSystem);
                this.Data.SaveChanges();
            }

            return this.GridOperation(model, request);
        }

    }
}