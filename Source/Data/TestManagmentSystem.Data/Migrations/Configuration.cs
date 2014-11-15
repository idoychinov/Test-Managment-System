namespace TestManagmentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TestManagmentSystemDbContext>
    {
        public Configuration()
        {            
            AutomaticMigrationsEnabled = true;
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
 
        private void SeadTestedSystems( TestManagmentSystemDbContext context)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }
    }
}
