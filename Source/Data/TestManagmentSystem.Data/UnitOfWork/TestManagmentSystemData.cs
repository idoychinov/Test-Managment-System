namespace TestManagmentSystem.Data.UnitOfWork
{
    using TestManagmentSystem.Data.Common.Contracts;
    using TestManagmentSystem.Data.Models;
    using TestManagmentSystem.Data.UnitOfWork.Base;

    public class TestManagmentSystemData : TestManagmentSystemBaseData, ITestManagmentSystemData
    {
        public TestManagmentSystemData(ITestManagmentSystemDbContext context)
            :base(context)
        {
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public IDeletableEntityRepository<TestedSystem> TestedSystems
        {
            get { return this.GetDeletableEntityRepository<TestedSystem>(); }
        }

        public IDeletableEntityRepository<SystemEnvironment> Environments
        {
            get { return this.GetDeletableEntityRepository<SystemEnvironment>(); }
        }


        public IDeletableEntityRepository<Project> Projects
        {
            get { return this.GetDeletableEntityRepository<Project>(); }
        }
    }
}
