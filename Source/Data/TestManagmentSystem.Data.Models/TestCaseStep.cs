namespace TestManagmentSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using TestManagmentSystem.Data.Common.Base;

    public class TestCaseStep : DeletableEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100,MinimumLength=2,ErrorMessage="The Test case name must be between 2 and 100 characters long")]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Preconditions { get; set; }

        [Required]
        [StringLength(1000)]
        public string Actions { get; set; }

        [StringLength(1000)]
        public string PostConditions { get; set; }

        public int TestCaseId { get; set; }

        public virtual TestCase TestCase { get; set; }
    }
}
