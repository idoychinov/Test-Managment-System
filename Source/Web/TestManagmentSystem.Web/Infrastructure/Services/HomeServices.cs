namespace TestManagmentSystem.Web.Infrastructure.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper.QueryableExtensions;

    using TestManagmentSystem.Data.UnitOfWork;
    using TestManagmentSystem.Web.Infrastructure.Services.Base;
    using TestManagmentSystem.Web.Infrastructure.Services.Contracts;
    using TestManagmentSystem.Web.ViewModels.Home;

    public class HomeServices : BaseServices, IHomeServices
    {
        public HomeServices(ITestManagmentSystemData data)
            :base(data)
        {
        }

        public IList<TestedSystemViewModel> GetIndexTestdSystemsViewModel(int numberOfSystems)
        {
            var testedSystemsViewModel = this.Data.
                TestedSystems
                .All()
                .Project()
                .To<TestedSystemViewModel>()
                .OrderByDescending(t => t.IssuesCount)
                .ThenByDescending(t => t.EnvorinmentsCount)
                .Take(numberOfSystems)
                .ToList();

            return testedSystemsViewModel;
        }

        public IList<IssuesViewModel> GetIndexIssuesViewModel(int numberOfIssues)
        {
            var issuesViewModel = this.Data.
                Issues
                .All()
                .Project()
                .To<IssuesViewModel>()
                .OrderByDescending(t => t.DateSubmitted)
                .ThenByDescending(t => t.Priority)
                .Take(numberOfIssues)
                .ToList();

            return issuesViewModel;
        }
    }
}
