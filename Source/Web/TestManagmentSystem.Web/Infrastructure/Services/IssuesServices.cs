namespace TestManagmentSystem.Web.Infrastructure.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using TestManagmentSystem.Data.UnitOfWork;
    using TestManagmentSystem.Web.Infrastructure.Services.Base;
    using TestManagmentSystem.Web.Infrastructure.Services.Contracts;
    using TestManagmentSystem.Web.ViewModels.Issues;

    public class IssuesServices : BaseServices, IIssuesServices
    {
        public IssuesServices(ITestManagmentSystemData data)
            : base(data)
        {
        }

        public IList<IssueViewModel> GetIssuesViewModel(out int numberOfPages, string searchPattern, int itemsPerPage, int currentPage)
        {
            var issues = this.Data.Issues.All();

            if(searchPattern != null)
            {
                issues = issues.Where(i => i.Name.Contains(searchPattern));
            }

            var itemsCount = issues.Count();

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

            var result = issues.Project()
                .To<IssueViewModel>()
                .OrderByDescending(t => t.DateSubmitted)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToList();

            return result;
        }
    }
}