using System;
using System.Linq;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

using TestManagmentSystem.Data.Common.CodeFirstConvention;
using TestManagmentSystem.Data.Common.Contracts;
using TestManagmentSystem.Data.Migrations;
using TestManagmentSystem.Data.Models;

namespace TestManagmentSystem.Data
{
    public class TestManagmentSystemDbContext : IdentityDbContext<ApplicationUser>, ITestManagmentSystemDbContext
    {
        public TestManagmentSystemDbContext()
            : this("DefaultConnection")
        {
        }

        public TestManagmentSystemDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TestManagmentSystemDbContext, Configuration>());

        }

        public static TestManagmentSystemDbContext Create()
        {
            return new TestManagmentSystemDbContext();
        }

        public virtual IDbSet<TestedSystem> TestedSystems { get; set; }

        public virtual IDbSet<SystemEnvironment> SystemEnvironments { get; set; }

        public virtual IDbSet<Project> Projects { get; set; }

        public DbContext DbContext
        {
            get
            {
                return this;
            }
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            this.ApplyDeletableEntityRules();
            return base.SaveChanges();
        }

        public new IDbSet<T> Set<T>() where T : class
        {
           return base.Set<T>();
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new IsUnicodeAttributeConvention());

            base.OnModelCreating(modelBuilder); // Without this call EntityFramework won't be able to configure the identity model
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }

        private void ApplyDeletableEntityRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (
                var entry in
                    this.ChangeTracker.Entries()
                        .Where(e => e.Entity is IDeletableEntity && (e.State == EntityState.Deleted)))
            {
                var entity = (IDeletableEntity)entry.Entity;

                entity.DeletedOn = DateTime.Now;
                entity.IsDeleted = true;
                entry.State = EntityState.Modified;
            }
        }
    }
}
