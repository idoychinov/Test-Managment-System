using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper.QueryableExtensions;
using TestManagmentSystem.Data.UnitOfWork;
using TestManagmentSystem.Web.Areas.Tests.Infrastructure.Services.Contracts;
using TestManagmentSystem.Web.Areas.Tests.ViewModels;
using TestManagmentSystem.Web.Infrastructure.Services.Base;

namespace TestManagmentSystem.Web.Areas.Tests.Infrastructure.Services
{
    public class TestScenarioServices : BaseServices, ITestScenarioServices
    {
        public TestScenarioServices(ITestManagmentSystemData data)
            : base(data)
        {
        }

        public IList<TestScenarioViewModel> GetTestScenarioViewModel(out int numberOfPages, int itemsPerPage, int currentPage)
        {
            var systems = this.Data.TestScenarios.All();

            var itemsCount = systems.Count();

            numberOfPages = 1 + ((itemsCount - 1) / itemsPerPage);
            var page = currentPage;

            if (page == 0)
            {
                page = 0;
            }
            else if (page > numberOfPages)
            {
                page = numberOfPages;
            }

            var result = systems.Project()
                .To<TestScenarioViewModel>()
                .OrderByDescending(t => t.Type)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToList();

            return result;
        }
    }
}