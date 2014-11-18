using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using TestManagmentSystem.Data.Models;
using TestManagmentSystem.Web.Infrastructure.Mapping;

namespace TestManagmentSystem.Web.Areas.Tests.ViewModels
{
    public class TestScenarioViewModel : IMapFrom<TestScenario>, IHaveCustomMappings
    {
        public int Id { get; set; }
 
        public string Name { get; set; }

        public string Description { get; set; }

        public TestScenarioType Type { get; set; }

        public string Project {get; set;}

        public string System { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<TestScenario, TestScenarioViewModel>()
                .ForMember(m => m.Project, opt => opt.MapFrom(t => t.Project != null ? t.Project.Name : ""))
                .ForMember(m => m.Project, opt => opt.MapFrom(t => t.SystemEnvironment != null ? t.SystemEnvironment.TestedSystem.Name + " ("+ t.SystemEnvironment.Name +")": ""));
        }
    }
}