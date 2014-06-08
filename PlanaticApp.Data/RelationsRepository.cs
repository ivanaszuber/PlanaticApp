using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanaticApp.Data.Contracts;
using PlanaticApp.Model;

namespace PlanaticApp.Data
{
    public class RelationsRepository:EFRepository<Relations>, IRelationsRepository
    {
        public RelationsRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override Relations GetById(int id)
        {
            throw new InvalidOperationException("Cannot return a single Relation");
        }

        public IQueryable<Relations> GetByGoalId(int id)
        {
            return DbSet.Where(x => x.GoalId == id);
        }

        public IQueryable<Relations> GetByPersonId(int id)
        {
            return DbSet.Where(x => x.PersonId == id);
        }

        public Relations GetByIds(int personId, int goalId)
        {
            return DbSet.FirstOrDefault(x => x.PersonId == personId && x.GoalId==goalId);
        }

        public override void Delete(Relations entity)
        {
            throw new InvalidOperationException("Cannot delete a single Relation");
        }

        public void Delete(int personId, int goalId)
        {
            var relation = DbSet.FirstOrDefault(x => x.PersonId == personId && x.GoalId == goalId);
            DbSet.Remove(relation);
        }
    }
}
