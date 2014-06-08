using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanaticApp.Model;

namespace PlanaticApp.Data.Contracts
{
    public interface IPersonRepository: IRepository<Person>
    {
        IQueryable<Goal> GetGoals();
    }
}
