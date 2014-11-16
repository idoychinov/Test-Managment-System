namespace TestManagmentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using TestManagmentSystem.Common;
    using TestManagmentSystem.Data.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TestManagmentSystemDbContext>
    {
        private UserManager<User> userManager;
        private IRandomGenerator random;


        public Configuration()
        {
            AutomaticMigrationsEnabled = true;

            // TODO: Remove in production
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TestManagmentSystemDbContext context)
        {
            this.userManager = new UserManager<User>(new UserStore<User>(context));
            this.SeedRoles(context);
            this.SeadTestedSystems(context);
        }


        
        private void SeedRoles(TestManagmentSystemDbContext context)
        {
            context.Roles.AddOrUpdate(x => x.Name, new IdentityRole(GlobalConstants.AdminRole));
            context.SaveChanges();
        }

        private void SeedUsers(TestManagmentSystemDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            for (int i = 0; i < 10; i++)
            {
                var user = new User
                    {
                        Email = string.Format("{0}@{1}.com", this.random.RandomString(6, 16), this.random.RandomString(6, 16)),
                        UserName = this.random.RandomString(6, 16)
                    };

                this.userManager.Create(user, "123456");
            }

            var adminUser = new User
            {
                Email = "admin@mysite.com",
                UserName = "Administrator"
            };

            this.userManager.Create(adminUser, "admin123456");

            this.userManager.AddToRole(adminUser.Id, GlobalConstants.AdminRole);
        }


        private void SeadTestedSystems(TestManagmentSystemDbContext context)
        {
            GeneratedTestedSystem(context, "Test Management System", "The product allows management of system and integration and UAT tests results");
            context.SaveChanges();
        }

        private void GeneratedTestedSystem(TestManagmentSystemDbContext context, string name, string description)
        {
            if(context.TestedSystems.Any())
            {
                return;
            }

            var testedSystem  = new TestedSystem
                {
                    Name = name,
                    Description = description,
                };

            SeadSystemEnvironments(testedSystem);
            SeadProjects(testedSystem);
            context.TestedSystems.AddOrUpdate(a => a.Name,testedSystem);
        }
 
        private void SeadProjects(TestedSystem testedSystem)
        {
            
        }

        private void SeadSystemEnvironments(TestedSystem system)
        {
            var environmentsCount = random.RandomNumber(1,3);
            for(var i=0; i< environmentsCount; i++)
            {
                var systemEnvironment = new SystemEnvironment()
                {
                    Name = random.RandomString(5, 15),
                    Description = random.RandomString(10, 30),
                    Type = (EnvironmentType)random.RandomNumber(1, 3),
                    Url = random.RandomString(10, 20)
                };

                system.Environments.Add(systemEnvironment);
            }
        }
    }
}
