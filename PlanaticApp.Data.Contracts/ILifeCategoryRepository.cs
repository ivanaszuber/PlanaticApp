using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanaticApp.Model;

namespace PlanaticApp.Data.Contracts
{
    public interface ILifeCategoryRepository: IRepository<LifeCategory>
    {
        IQueryable<Goal> GetGoals();

        IQueryable<Person> GetPeople();
    }
}
