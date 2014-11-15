namespace TestManagmentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TestManagmentSystem.Data.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TestManagmentSystemDbContext>
    {
        public Configuration()
        {            
            AutomaticMigrationsEnabled = true;
            
            // TODO: Remove in production
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TestManagmentSystemDbContext context)
        {
            if(context.TestedSystems.Any())
            {
                return;
            }

            this.SeadTestedSystems(context);
        }
 
        private void SeadTestedSystems(TestManagmentSystemDbContext context)
        {
            context.TestedSystems.AddOrUpdate(a => a.Id,
                new TestedSystem
                {
                    Name = "This System"
                });
        }
    }
}
