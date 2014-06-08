using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanaticApp.Data.Contracts;

namespace PlanaticApp.Data.Helpers
{
    public class RepositoryProvider: IRepositoryProvider
    {
        private RepositoryFactories _repositoryFactories ;
        RepositoryProvider(RepositoryFactories repositoryFactories)
        {
            _repositoryFactories = repositoryFactories;
            Repositories = new Dictionary<Type, object>();
        }

        public DbContext DbContext { get; set; }

        public IRepository<T> GetRepositoryFoerEntityType<T>() where T : class
        {
            return GetRepository<IRepository<T>>(_repositoryFactories.GetRepositoryFactoryForEntityType<T>());
        }

        public virtual T GetRepository<T>(Func<DbContext, object> factory = null) where T : class
        {
            object repoObj;
            Repositories.TryGetValue(typeof (T), out repoObj);
            if (repoObj !=null)
            {
                return (T) repoObj;
            }

            return MakeRepository<T>(factory, DbContext);
        }

        protected Dictionary<Type, object> Repositories { get; private set; }

        protected virtual T MakeRepository<T>(Func<DbContext, object> factory, DbContext dbContext)
        {
            var f = factory ?? _repositoryFactories.GetRepositoryFactory<T>();
            if (f==null)
            {
                throw  new NotImplementedException("No factory for repostory type");
            }

            var repo = (T) f(dbContext);
            Repositories[typeof (T)] = repo;
            return repo;
        }

        public void SetRepository<T>(T repositoty)
        {
            Repositories[typeof (T)] = repositoty;
        }
    }


}
