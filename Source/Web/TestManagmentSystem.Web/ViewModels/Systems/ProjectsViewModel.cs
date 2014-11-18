﻿namespace TestManagmentSystem.Web.ViewModels.Systems
{
        
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using AutoMapper;
    using TestManagmentSystem.Data.Models;
    using TestManagmentSystem.Web.Infrastructure.Mapping;

    public class ProjectsViewModel : IMapFrom<Project>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ProjectStatusType Status { get; set; }

        public int? Issues { get; set; }
    }
}