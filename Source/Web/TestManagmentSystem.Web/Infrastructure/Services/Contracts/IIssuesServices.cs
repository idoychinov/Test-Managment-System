namespace TestManagmentSystem.Web.Infrastructure.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TestManagmentSystem.Web.ViewModels.Issues;

    public interface IIssuesServices
    {
        IList<IssueViewModel> GetIssuesViewModel(out int numberOfPages, string searchPattern, int itemsPerPage, int currentPage);
    }
}