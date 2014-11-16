namespace TestManagmentSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using TestManagmentSystem.Data.Common.Base;

    public class SystemEnvironment : DeletableEntity
    {
        [Key]
        public int Id { get; set; }

        
        [Required]
        [StringLength(100,MinimumLength=2,ErrorMessage="The Environment name must be between 2 and 100 characters long")]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        public EnvironmentType Type { get; set; }

        [StringLength(100)]
        public string Url { get; set; }

        public int TestedSystemId { get; set; }

        public virtual TestedSystem TestedSystem { get; set; }
    }
}
