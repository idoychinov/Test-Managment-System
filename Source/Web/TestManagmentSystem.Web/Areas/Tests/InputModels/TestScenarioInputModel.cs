using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AutoMapper;
using TestManagmentSystem.Data.Models;
using TestManagmentSystem.Web.Infrastructure.Mapping;

namespace TestManagmentSystem.Web.Areas.Tests.InputModels
{
    public class TestScenarioInputModel
    {
        [Required]
        
        public string Name { get; set; }

        [Required]
        [UIHint("MultiLineText")]
        public string Description { get; set; }

        public TestScenarioType Type { get; set; }

        public int Project {get; set;}

        public int System { get; set; }
    }
}