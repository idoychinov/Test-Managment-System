namespace TestManagmentSystem.Data.UnitOfWork.Base
{
    using TestManagmentSystem.Data;

    public interface ITestManagmentSystemBaseData
    {
        ITestManagmentSystemDbContext Context { get; }
        
        int SaveChanges();
    }
}
