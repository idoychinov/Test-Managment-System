namespace TestManagmentSystem.Web.ViewModels.Home
{
    using System;
    using System.Linq;
    using AutoMapper;
    using TestManagmentSystem.Data.Models;
    using TestManagmentSystem.Web.Infrastructure.Mapping;

    public class IssuesViewModel : IMapFrom<Issue>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateSubmitted { get; set; }

        public IssueStatusType Status { get; set; }

        public IssuePriorityType Priority { get; set; }

        public string FoundIn { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {

            configuration.CreateMap<Issue, IssuesViewModel>()
                .ForMember(m => m.FoundIn, opt => opt.MapFrom(t =>"System:" + t.SystemEnvironment.TestedSystem.Name +" / Environment:"+ t.SystemEnvironment.Name ))
                .ReverseMap();
        }
    }
}