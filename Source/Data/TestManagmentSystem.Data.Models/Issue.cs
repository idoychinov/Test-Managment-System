namespace TestManagmentSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using TestManagmentSystem.Data.Common.Base;

    public class Issue : DeletableEntity
    {
        private ICollection<File> files;
        private ICollection<TestResult> testResults;


        public Issue()
        {
            this.files = new HashSet<File>();
            this.testResults = new HashSet<TestResult>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "The Issue name must be between 2 and 100 characters long")]
        public string Name { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        public DateTime DateSubmitted { get; set; }

        [DefaultValue(IssueStatusType.New)]
        public IssueStatusType Status { get; set; }
        
        [DefaultValue(IssuePriorityType.Meduim)]
        public IssuePriorityType Priority { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }

        public int? ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public int? TestCaseId { get; set; }

        public virtual TestCase TestCase { get; set; }

        public int? SystemEnvironmentId { get; set; }

        public virtual SystemEnvironment SystemEnvironment { get; set; }

        public virtual ICollection<File> Files 
        {
            get { return this.files; }
            set { this.files = value; }
        }

        public virtual ICollection<TestResult> TestResults 
        {
            get { return this.testResults; }
            set { this.testResults= value; }
        }
    }
}
