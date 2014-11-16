namespace TestManagmentSystem.Data.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using TestManagmentSystem.Data.Common.Base;

    public class Issue : DeletableEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "The Issue name must be between 2 and 100 characters long")]
        public string Name { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        public DateTime DateSubmited { get; set; }

        [DefaultValue(IssueStatusType.New)]
        public IssueStatusType Status { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; }

        public int TestCaseId { get; set; }
        public TestCase TestCase { get; set; }

        [Required]
        public int SystemEnvironmentId { get; set; }

        [Required]
        public virtual SystemEnvironment SystemEnvironment { get; set; }
    }
}
