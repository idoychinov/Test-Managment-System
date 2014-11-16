namespace TestManagmentSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TestManagmentSystem.Data.Common.Base;

    public class TestedSystem : DeletableEntity
    {
        private ICollection<SystemEnvironment> environments;
        private ICollection<Project> projects;


        public TestedSystem()
        {
            this.environments = new HashSet<SystemEnvironment>();
            this.projects = new HashSet<Project>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100,MinimumLength=2,ErrorMessage="The system name must be between 2 and 100 characters long")]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public virtual ICollection<SystemEnvironment> Environments
        {
            get { return this.environments; }
            set { this.environments = value; }
        }

        public virtual ICollection<Project> Projects
        {
            get { return this.projects; }
            set { this.projects = value; }
        }

    }
}
