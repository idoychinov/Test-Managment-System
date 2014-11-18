using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestManagmentSystem.Data.UnitOfWork;
using TestManagmentSystem.Web.Infrastructure.Services.Base;
using TestManagmentSystem.Web.Infrastructure.Services.Contracts;
using TestManagmentSystem.Web.ViewModels.Systems;
using AutoMapper.QueryableExtensions;



namespace TestManagmentSystem.Web.Infrastructure.Services
{
    public class SystemsServices : BaseServices, ISystemsServices
    {
        public SystemsServices(ITestManagmentSystemData data)
            : base(data)
        {
        }

        public IList<SystemsViewModel> GetSystemsViewModel()
        {
             var systems = this.Data.TestedSystems
                .All()
                .Project()
                .To<SystemsViewModel>()
                .OrderByDescending(t => t.IssuesCount)
                .ToList();

             return systems;
        }
    }
}