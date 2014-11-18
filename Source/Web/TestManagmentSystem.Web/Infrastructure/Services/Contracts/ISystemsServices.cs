namespace TestManagmentSystem.Web.Infrastructure.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TestManagmentSystem.Web.ViewModels.Systems;

    public interface ISystemsServices
    {
        IList<SystemsViewModel> GetSystemsViewModel(out int numberOfPages, int itemsPerPage, int currentPage);
    }
}