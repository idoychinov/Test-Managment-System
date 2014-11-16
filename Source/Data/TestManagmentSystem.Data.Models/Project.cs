namespace TestManagmentSystem.Data.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using TestManagmentSystem.Data.Common.Base;

    public class Project : DeletableEntity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100,MinimumLength=2,ErrorMessage="The Project name must be between 2 and 100 characters long")]
        public string Name { get; set; }

        
        [StringLength(1000)]
        public string Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        [DefaultValue(ProjectStatusType.Planing)]
        public ProjectStatusType Status { get; set; }

    }
}
