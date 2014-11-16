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
            this.random = new RandomGenerator();
        }

        protected override void Seed(TestManagmentSystemDbContext context)
        {
            this.userManager = new UserManager<User>(new UserStore<User>(context));
            this.SeedRoles(context);
            this.SeedUsers(context);
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

            for (int i = 1; i <= 5; i++)
            {
                var username = "user" + i + "@tms.com";
                var user = new User
                    {
                        Email = username,
                        UserName = username
                    };

                this.userManager.Create(user, "123456");
            }

            var adminUser = new User
            {
                Email = "admin@tms.com",
                UserName = "admin@tms.com"
            };

            this.userManager.Create(adminUser, "admin123");

            this.userManager.AddToRole(adminUser.Id, GlobalConstants.AdminRole);
            context.SaveChanges();
        }


        private void SeadTestedSystems(TestManagmentSystemDbContext context)
        {
            GeneratedTestedSystem(context, "Test Management System", "The product allows management of system and integration and UAT tests results");
            GeneratedTestedSystem(context, "Pew Pew", "Very addictive online game. The title says it all");
            GeneratedTestedSystem(context, "Our Intra-net", "The Company's intra-net site");

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
            var projectsCount = random.RandomNumber(0,5);
            for(var i=0; i< projectsCount; i++)
            {
                var startDate = new DateTime(random.RandomNumber(2010, 2015),random.RandomNumber(1,12), random.RandomNumber(1,28));
                var endDate = startDate.AddDays(random.RandomNumber( 60,600));
                var project = new Project()
                {
                    Name = random.RandomString(5, 15),
                    Description = random.RandomString(10, 30),
                    StartDate = startDate,
                    EndDate = endDate,
                    Status = (ProjectStatusType)random.RandomNumber(1, 7)
                };

                testedSystem.Projects.Add(project);
            }
        }

        private void SeadSystemEnvironments(TestedSystem testedSystem)
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

                testedSystem.Environments.Add(systemEnvironment);
            }
        }
    }
}
