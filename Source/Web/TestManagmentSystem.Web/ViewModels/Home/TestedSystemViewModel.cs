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

        public string Description { get; set; }

        public IList<SystemEnvironmentViewModel> Envoriments { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<TestedSystem, TestedSystemViewModel>()
                .ForMember(m => m.Envoriments, opt => opt.MapFrom(t => t.Environments.Select(e => new SystemEnvironmentViewModel() { Id = e.Id, Name = e.Name, Type = e.Type})))
                .ReverseMap();
        }
    }
}