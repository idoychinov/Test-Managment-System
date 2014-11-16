namespace TestManagmentSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using TestManagmentSystem.Data.Common.Base;

    public class Project : DeletableEntity
    {
        private ICollection<Issue> issues;

        public Project()
        {
            this.issues = new HashSet<Issue>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100,MinimumLength=2,ErrorMessage="The Project name must be between 2 and 100 characters long")]
        public string Name { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        [DefaultValue(ProjectStatusType.Planing)]
        public ProjectStatusType Status { get; set; }

        public int TestedSystemId { get; set; }

        public virtual TestedSystem TestedSystem { get; set; }

        public virtual ICollection<Issue> Issues 
        {
            get { return this.issues; }
            set { this.issues= value; }
        }
    }
}
