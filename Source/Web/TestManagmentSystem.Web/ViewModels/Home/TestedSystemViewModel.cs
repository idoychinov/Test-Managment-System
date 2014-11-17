namespace TestManagmentSystem.Web.ViewModels.Home
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;

    using TestManagmentSystem.Data.Models;
    using TestManagmentSystem.Web.Infrastructure.Mapping;

    public class TestedSystemViewModel : IMapFrom<TestedSystem>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int EnvorinmentsCount { get; set; }

        public int IssuesCount { get; set; }

        //public IList<SystemEnvironmentViewModel> Envoriments { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            //configuration.CreateMap<TestedSystem, TestedSystemViewModel>()
            //    .ForMember(m => m.Envoriments, opt => opt.MapFrom(t => t.Environments.Select(e => new SystemEnvironmentViewModel() { Id = e.Id, Name = e.Name, Type = e.Type})))
            //    .ReverseMap();

            configuration.CreateMap<TestedSystem, TestedSystemViewModel>()
                .ForMember(m => m.EnvorinmentsCount, opt => opt.MapFrom(t => t.Environments.Count()))
                .ForMember(m => m.IssuesCount, opt => opt.MapFrom(t => t.Environments.Sum(e=> e.Issues.Count)))
                .ReverseMap();
        }
    }
}