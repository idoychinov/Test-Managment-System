namespace TestManagmentSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using TestManagmentSystem.Data.Models;

    public interface ITestManagmentSystemDbContext
    {
        IDbSet<ApplicationUser> Users { get; set; }

        IDbSet<TestedSystem> TestedSystems { get; set; }

        IDbSet<Environment> Environments { get; set; }

        IDbSet<Project> Projects { get; set; }

        DbContext DbContext { get; }

        int SaveChanges();

        void Dispose();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<T> Set<T>() where T : class;

    }
}
