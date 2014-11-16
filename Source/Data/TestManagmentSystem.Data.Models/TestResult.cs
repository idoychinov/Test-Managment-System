namespace TestManagmentSystem.Data.Models
{
    
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using TestManagmentSystem.Data.Common.Base;

    public class TestResult : DeletableEntity
    {

        [Key]
        public int Id { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        [DefaultValue(TestResultStatusType.Passed)]
        public TestResultStatusType TestStatus {get; set;}

        [Required]
        public DataType Date {get; set;}

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int? TestCaseId {get; set;}

        public virtual TestCase TestCase {get; set;}

        public int? RelatedIssueId { get; set; }

        public virtual Issue RelatedIssue { get; set; }
    }
}
