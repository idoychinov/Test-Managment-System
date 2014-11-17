using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestManagmentSystem.Web.Areas.Administration.ViewModels.TestedSystems
{

    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using TestManagmentSystem.Data.Models;
    using TestManagmentSystem.Web.Infrastructure.Mapping;

    public class TestedSystemViewModel : IMapFrom<TestedSystem>
    {
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        [Required]
        [UIHint("String")]
        public string Name { get; set; }

        [UIHint("MultiLineText")]
        public string Description { get; set; }
    }
}