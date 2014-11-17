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
            this.SeedTestScenarios(context);
            this.SeedIssues(context);
        }

        private void SeedIssues(TestManagmentSystemDbContext context)
        {
            if (context.Issues.Any())
            {
                return;
            }

            var users = context.Users.ToList();
            var environments = context.SystemEnvironments.ToList();
            var environmentsCount = environments.Count == 0 ? environments.Count : environments.Count - 1;

            for (var i = 0; i < random.RandomNumber(5, 50); i++)
            {
                var environment = environments[random.RandomNumber(0, environmentsCount)];
                
                var issue = new Issue()
                {
                    Name = random.RandomString(5, 15),
                    Description = random.RandomString(10, 30),
                    DateSubmited = new DateTime(random.RandomNumber(2010, 2015), random.RandomNumber(1, 12), random.RandomNumber(1, 28)),
                    Status = (IssueStatusType)random.RandomNumber(1, 5),
                    Priority = (IssuePriorityType)random.RandomNumber(1, 4),
                    User = users[random.RandomNumber(0, users.Count - 1)],
                    SystemEnvironment = environment,
                };

                if (random.RandomNumber(0, 10) > 3)
                {
                    var testCases = context.TestCases.Where(c => c.TestScenario.SystemEnvironmentId == environment.Id).ToList();
                    var testCasesCount = testCases.Count == 0 ? testCases.Count : testCases.Count - 1;
                    if (testCasesCount > 0)
                    {
                        var testCase = testCases[random.RandomNumber(0, testCasesCount)];
                        issue.TestCase = testCase;
                        issue.Project = testCase.TestScenario.Project;
                    }
                }

                context.Issues.Add(issue);
            }
            context.SaveChanges();
        }

        private void SeedTestScenarios(TestManagmentSystemDbContext context)
        {
            if (context.TestScenarios.Any())
            {
                return;
            }

            foreach (var envoriment in context.SystemEnvironments.ToList())
            {
                var scenarioCount = random.RandomNumber(0, 3);
                for (var i = 0; i < scenarioCount; i++)
                {
                    Project project = null;
                    if (random.RandomNumber(0, 1) == 0)
                    {
                        var projects = context.Projects.Where(p => p.TestedSystemId == envoriment.TestedSystemId).ToList();
                        if (projects.Count > 0)
                        {
                            project = projects[random.RandomNumber(0, projects.Count - 1)];
                        }
                    }

                    var scenario = new TestScenario()
                    {
                        Name = random.RandomString(5, 15),
                        Description = random.RandomString(10, 30),
                        Type = (TestScenarioType)random.RandomNumber(1, 3),
                        SystemEnvironment = envoriment,
                        Project = project
                    };

                    SeedTestCases(context, scenario);
                    context.TestScenarios.Add(scenario);
                }
            }

            context.SaveChanges();
        }

        private void SeedTestCases(TestManagmentSystemDbContext context, TestScenario scenario)
        {
            var caseCount = random.RandomNumber(0, 2);
            for (var i = 0; i < caseCount; i++)
            {

                var testCase = new TestCase()
                {
                    Name = random.RandomString(5, 15),
                    Description = random.RandomString(10, 30),
                    TestScenario = scenario,
                };

                SeedTestCaseSteps(context, testCase);
                SeedTestResults(context, testCase);
                context.TestCases.Add(testCase);
            }
        }

        private void SeedTestResults(TestManagmentSystemDbContext context, TestCase testCase)
        {
            var testResult = random.RandomNumber(0, 2);
            var users = context.Users.ToList();


            for (var i = 0; i < testResult; i++)
            {
                var user = users[random.RandomNumber(0, users.Count - 1)];
                var result = new TestResult()
                {
                    Description = random.RandomString(5, 15),
                    Date = new DateTime(random.RandomNumber(2010, 2015), random.RandomNumber(1, 12), random.RandomNumber(1, 28)),
                    TestStatus = (TestResultStatusType)random.RandomNumber(1, 3),
                    TestCase = testCase,
                    User = user
                };

                context.TestResults.Add(result);
            }
        }

        private void SeedTestCaseSteps(TestManagmentSystemDbContext context, TestCase testCase)
        {
            var stepCount = random.RandomNumber(1, 5);
            for (var i = 0; i < stepCount; i++)
            {

                var step = new TestCaseStep()
                {
                    Name = random.RandomString(5, 15),
                    Preconditions = random.RandomString(10, 50),
                    Actions = random.RandomString(10, 100),
                    PostConditions = random.RandomString(10, 50),
                    TestCase = testCase,
                };

                context.TestCaseSteps.Add(step);
            }
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
            if (context.TestedSystems.Any())
            {
                return;
            }

            var testedSystem = new TestedSystem
                {
                    Name = name,
                    Description = description,
                };

            SeadSystemEnvironments(testedSystem);
            SeadProjects(testedSystem);
            context.TestedSystems.AddOrUpdate(a => a.Name, testedSystem);
        }

        private void SeadProjects(TestedSystem testedSystem)
        {
            var projectsCount = random.RandomNumber(0, 5);
            for (var i = 0; i < projectsCount; i++)
            {
                var startDate = new DateTime(random.RandomNumber(2010, 2015), random.RandomNumber(1, 12), random.RandomNumber(1, 28));
                var endDate = startDate.AddDays(random.RandomNumber(60, 600));
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
            var environmentsCount = random.RandomNumber(1, 3);
            for (var i = 0; i < environmentsCount; i++)
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
