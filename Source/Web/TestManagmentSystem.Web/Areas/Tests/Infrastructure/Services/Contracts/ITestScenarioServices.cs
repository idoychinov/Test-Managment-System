using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestManagmentSystem.Web.Areas.Tests.ViewModels;

namespace TestManagmentSystem.Web.Areas.Tests.Infrastructure.Services.Contracts
{
    public interface ITestScenarioServices
    {
        
        IList<TestScenarioViewModel> GetTestScenarioViewModel(out int numberOfPages, int itemsPerPage, int currentPage);
    }
}