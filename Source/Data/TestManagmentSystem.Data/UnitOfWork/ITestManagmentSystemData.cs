namespace TestManagmentSystem.Data.UnitOfWork
{

    using TestManagmentSystem.Data.Common.Contracts;
    using TestManagmentSystem.Data.Models;
    using TestManagmentSystem.Data.UnitOfWork.Base;

    public interface ITestManagmentSystemData : ITestManagmentSystemBaseData
    {
        IRepository<User> Users { get; }

        IDeletableEntityRepository<TestedSystem> TestedSystems { get; }

        IDeletableEntityRepository<SystemEnvironment> Environments { get; }

        IDeletableEntityRepository<Project> Projects { get; }

        IDeletableEntityRepository<File> Files { get; }

        IDeletableEntityRepository<Issue> Issues { get; }

        IDeletableEntityRepository<TestCase> TestCases { get; }

        IDeletableEntityRepository<TestScenario> TestScenarios { get; }

        IDeletableEntityRepository<TestCaseStep> TestCaseStep { get; }

        IDeletableEntityRepository<TestResult> TestResults { get; }
    }
}
