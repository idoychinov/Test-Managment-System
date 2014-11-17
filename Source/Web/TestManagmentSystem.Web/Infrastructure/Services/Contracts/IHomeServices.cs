namespace TestManagmentSystem.Web.Infrastructure.Services.Contracts
{
    using System.Collections.Generic;
    using TestManagmentSystem.Web.ViewModels.Home;

    public interface IHomeServices
    {
        IList<TestedSystemViewModel> GetIndexTestdSystemsViewModel(int numberOfSystems);

        IList<IssuesViewModel> GetIndexIssuesViewModel(int numberOfIssues);

    }
}
