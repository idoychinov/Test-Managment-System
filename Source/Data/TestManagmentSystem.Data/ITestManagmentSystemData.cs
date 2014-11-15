namespace TestManagmentSystem.Data
{
    using TestManagmentSystem.Data.Common.Contracts;
    using TestManagmentSystem.Data.Models;

    public interface ITestManagmentSystemData
    {
        ITestManagmentSystemDbContext Context { get; }

        IDeletableEntityRepository<TestedSystem> TestedSystems { get; }

        IDeletableEntityRepository<Project> Projects { get; }

        IDeletableEntityRepository<Envoriment> Envoriments { get; }

        IRepository<ApplicationUser> Users { get; }

        int SaveChanges();
    }
}
