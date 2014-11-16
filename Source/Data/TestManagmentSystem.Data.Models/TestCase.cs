namespace TestManagmentSystem.Data.Models
{
    
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TestManagmentSystem.Data.Common.Base;

    public class TestCase : DeletableEntity
    {
        private ICollection<TestCaseStep> testCaseSteps;
        private ICollection<TestResult> testResults;

        public TestCase()
        {
            this.testResults = new HashSet<TestResult>();
            this.testCaseSteps = new HashSet<TestCaseStep>();
        }

        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(100,MinimumLength=2,ErrorMessage="The Test Case name must be between 2 and 100 characters long")]
        public string Name { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        public int? TestScenarioId { get; set; }

        public virtual TestScenario TestScenario { get; set; }

        public virtual ICollection<TestCaseStep> TestCaseSteps
        {
            get { return this.testCaseSteps; }
            set { this.testCaseSteps = value; }
        }

        public virtual ICollection<TestResult> TestResults
        {
            get { return this.testResults; }
            set { this.testResults = value; }
        }

    }
}
