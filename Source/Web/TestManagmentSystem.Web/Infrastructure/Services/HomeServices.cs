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

        public IList<TestedSystemViewModel> GetIndexViewModel(int numberOfSystems)
        {
            var indexViewModel = this.Data.
                TestedSystems.
                All()
                .OrderBy(t => t.Name)
                .Take(numberOfSystems)
                .Project()
                .To<TestedSystemViewModel>()
                .ToList();

            return indexViewModel;
        }
    }
}
