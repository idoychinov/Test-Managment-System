namespace TestManagmentSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using TestManagmentSystem.Data.Common.Base;

    public class TestScenario : DeletableEntity
    {
        private ICollection<TestCase> testCases;

        public TestScenario()
        {
            this.testCases = new HashSet<TestCase>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "The Test Scenario name must be between 2 and 100 characters long")]
        public string Name { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        [DefaultValue(TestScenarioType.RegressionTest)]
        public TestScenarioType Type { get; set; }

        public int ProjectId { get; set; }

        public virtual Project Project {get; set;}

        public int SystemEnvironmentId { get; set; }

        public virtual SystemEnvironment SystemEnvironment { get; set; }

        public virtual ICollection<TestCase> TestCases
        {
            get { return this.testCases; }
            set { this.testCases = value; }
        }
    }
}
