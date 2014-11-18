namespace TestManagmentSystem.Web.ViewModels.Issues
{
    using System;
    using System.Linq;
    using AutoMapper;
    using TestManagmentSystem.Data.Models;
    using TestManagmentSystem.Web.Infrastructure.Mapping;

    public class IssueViewModel : IMapFrom<Issue>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DateSubmitted { get; set; }

        public IssueStatusType Status { get; set; }

        public IssuePriorityType Priority { get; set; }

        public string User { get; set; }

        public string Project { get; set; }

        public string TestCase { get; set; }

        public string System { get; set; }

        public string Environment { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Issue, IssueViewModel>()
                .ForMember(m => m.User, opt => opt.MapFrom(t => t.User.UserName))
                .ForMember(m => m.Project, opt => opt.MapFrom(t => t.Project != null ? t.Project.Name : ""))
                .ForMember(m => m.TestCase, opt => opt.MapFrom(t => t.TestCase != null ? t.TestCase.Name : ""))
                .ForMember(m => m.System, opt => opt.MapFrom(t => t.SystemEnvironment != null ? t.SystemEnvironment.TestedSystem.Name : ""))
                .ForMember(m => m.Environment, opt => opt.MapFrom(t => t.SystemEnvironment != null ? t.SystemEnvironment.Name : ""))
                .ReverseMap();
        }
    }
}