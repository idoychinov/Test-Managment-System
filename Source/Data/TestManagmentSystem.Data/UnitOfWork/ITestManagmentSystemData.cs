namespace TestManagmentSystem.Data.UnitOfWork
{

    using TestManagmentSystem.Data.Common.Contracts;
    using TestManagmentSystem.Data.Models;
    using TestManagmentSystem.Data.UnitOfWork.Base;

    interface ITestManagmentSystemData : ITestManagmentSystemBaseData
    {
        IDeletableEntityRepository<TestedSystem> TestedSystems { get; }

        IDeletableEntityRepository<SystemEnvironment> Environments { get; }

        IDeletableEntityRepository<Project> Projects { get; }

        IRepository<ApplicationUser> Users { get; }
    }
}
