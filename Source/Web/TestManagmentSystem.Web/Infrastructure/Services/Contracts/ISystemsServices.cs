using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestManagmentSystem.Web.ViewModels.Systems;

namespace TestManagmentSystem.Web.Infrastructure.Services.Contracts
{
    public interface ISystemsServices
    {
        IList<SystemsViewModel> GetSystemsViewModel(out int numberOfPages, int itemsPerPage, int currentPage);

    }
}