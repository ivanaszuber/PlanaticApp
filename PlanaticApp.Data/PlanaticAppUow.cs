using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlanaticApp.Data.Contracts;
using PlanaticApp.Data.Helpers;
using PlanaticApp.Model;

namespace PlanaticApp.Data
{
    public class PlanaticAppUow 
    {
        private PlanaticDbContext DbContext { get; set; }
        private IRepositoryProvider _epositoryProvider { get; set; }

        public PlanaticAppUow(IRepositoryProvider repositoryProvider)
        {
            CreateDbContext();

            repositoryProvider.DbContext = DbContext;
            _epositoryProvider = repositoryProvider;
        }

        public IRepository<Task> Task { get { return GetStandardRepo<Task>(); } }

        public IPersonRepository Person { get { return GetRepo<IPersonRepository>(); } }
        public IGoalRepository Goal { get { return GetRepo<IGoalRepository>(); } }
        public ILifeCategoryRepository LifeCategory { get { return GetRepo<ILifeCategoryRepository>(); } }
        public IRelationsRepository Relation { get { return GetRepo<IRelationsRepository>(); } }
        public void Commit()
        {
            DbContext.SaveChanges();
        }

        protected void CreateDbContext()
        {
            DbContext = new PlanaticDbContext();

            DbContext.Configuration.ProxyCreationEnabled = false;

            DbContext.Configuration.LazyLoadingEnabled = false;

            DbContext.Configuration.ValidateOnSaveEnabled = false;
        }

        protected IRepositoryProvider RepositoryProvider { get; set; }

        private IRepository<T> GetStandardRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepositoryFoerEntityType<T>();
        }

        private T GetRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }
    }
}
