using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanaticApp.Model;

namespace PlanaticApp.Data.Contracts
{
    public interface IRelationsRepository: IRepository<Relations>
    {
        IQueryable<Relations> GetByGoalId(int id);
        IQueryable<Relations> GetByPersonId(int id);
        Relations GetByIds(int personId, int goalId);
        void Delete(int personId, int goalId);
    }
}
