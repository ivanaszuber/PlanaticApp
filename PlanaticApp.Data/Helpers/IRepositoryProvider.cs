using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanaticApp.Data.Contracts;

namespace PlanaticApp.Data.Helpers
{
    public interface IRepositoryProvider
    {
        IRepository<T> GetRepositoryFoerEntityType<T>() where T : class;

        T GetRepository<T>(Func<DbContext, object> factory = null) where T : class;

        void SetRepository<T>(T repositoty);

        DbContext DbContext { get; set; }

    }
}
