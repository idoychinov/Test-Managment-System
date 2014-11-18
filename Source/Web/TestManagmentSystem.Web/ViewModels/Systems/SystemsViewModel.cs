using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AutoMapper;
using TestManagmentSystem.Data.Models;
using TestManagmentSystem.Web.Infrastructure.Mapping;

namespace TestManagmentSystem.Web.ViewModels.Systems
{
    public class SystemsViewModel : IMapFrom<TestedSystem>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int? IssuesCount { get; set; }

        [UIHint("EnvorinmentsInSystemViewModel")]
        public IList<SystemEnvironmentViewModel> Environments { get; set; }

        [UIHint("ProjectsInSystemViewModel")]
        public IList<ProjectsViewModel> Projects { get; set; }


        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<TestedSystem, SystemsViewModel>()
                .ForMember(m => m.IssuesCount, opt => opt.MapFrom(t => t.Environments.Sum(e=> e.Issues.Count)))
                .ForMember(m => m.Environments, opt => opt.MapFrom(t => t.Environments.Select(e => new SystemEnvironmentViewModel() { Id = e.Id, Name = e.Name, Type = e.Type, Issues = e.Issues.Count()})))
                .ForMember(m => m.Projects, opt => opt.MapFrom(t => t.Projects.Select(p => new ProjectsViewModel() { Id = p.Id, Name = p.Name, Status = p.Status, Issues = p.Issues.Count()})))
                .ReverseMap();
        }
    }
}