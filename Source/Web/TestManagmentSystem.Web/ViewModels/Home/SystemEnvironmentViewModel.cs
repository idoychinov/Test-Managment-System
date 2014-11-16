namespace TestManagmentSystem.Web.ViewModels.Home
{
    
    using System;
    using System.Linq;
    using AutoMapper;

    using TestManagmentSystem.Data.Models;
    using TestManagmentSystem.Web.Infrastructure.Mapping;


    public class SystemEnvironmentViewModel : IMapFrom<SystemEnvironment>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public EnvironmentType Type { get; set; }
    }
}