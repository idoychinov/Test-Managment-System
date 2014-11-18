using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestManagmentSystem.Web.ViewModels.Systems;

namespace TestManagmentSystem.Web.Infrastructure.Services.Contracts
{
    public interface ISystemsServices
    {
        IList<SystemsViewModel> GetSystemsViewModel();

    }
}