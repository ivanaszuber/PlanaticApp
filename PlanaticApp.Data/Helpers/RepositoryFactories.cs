using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanaticApp.Data.Helpers
{
    public class RepositoryFactories
    {
        private IDictionary<Type, Func<DbContext, object>> _repositoryFactories;

        public Func<DbContext, object> GetRepositoryFactory<T>()
        {
            Func<DbContext, object> factory;
            _repositoryFactories.TryGetValue(typeof (T), out factory);
            return factory;
        }

        public DbContext DbContext { get; set; }

        public Func<DbContext, object> GetRepositoryFactoryForEntityType<T>() where T : class
        {
            return GetRepositoryFactory<T>() ?? DefaultEntityRepositoryFactory<T>();
        }

        protected  virtual Func<DbContext, object> DefaultEntityRepositoryFactory<T>() where T:class 
        {
            return dbContext => new EFRepository<T>(dbContext);
        }
    }
}
