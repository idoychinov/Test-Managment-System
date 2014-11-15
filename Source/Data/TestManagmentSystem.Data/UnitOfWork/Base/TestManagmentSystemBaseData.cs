namespace TestManagmentSystem.Data.UnitOfWork.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TestManagmentSystem.Data.Common.Contracts;
    using TestManagmentSystem.Data.Repositories.Base;

    public class TestManagmentSystemBaseData : ITestManagmentSystemBaseData
    {
        private readonly ITestManagmentSystemDbContext context;

        protected readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public TestManagmentSystemBaseData(ITestManagmentSystemDbContext context)
        {
            this.context = context;
        }

        public ITestManagmentSystemDbContext Context
        {
            get
            {
                return this.context;
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.context != null)
                {
                    this.context.Dispose();
                }
            }
        }

        protected IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }

        protected IDeletableEntityRepository<T> GetDeletableEntityRepository<T>() where T : class, IDeletableEntity
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(DeletableEntityRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IDeletableEntityRepository<T>)this.repositories[typeof(T)];
        }


    }
}
