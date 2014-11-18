using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        public IList<SystemsViewModel> GetSystemsViewModel(out int numberOfPages, int itemsPerPage, int currentPage)
        {
            var systems = this.Data.TestedSystems.All();

            var itemsCount = systems.Count();

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

            var result = systems.Project()
                .To<SystemsViewModel>()
                .OrderByDescending(t => t.IssuesCount)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToList();

            return result;
        }
    }
}