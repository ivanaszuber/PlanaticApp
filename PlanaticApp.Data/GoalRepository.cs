using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanaticApp.Data.Contracts;
using PlanaticApp.Model;
using Task = PlanaticApp.Model.Task;

namespace PlanaticApp.Data
{
    public class GoalRepository: EFRepository<Goal>, IGoalRepository
    {
        public GoalRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<Relations> GetRelations()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Task> GetTasks()
        {
            throw new NotImplementedException();
        }

        public IQueryable<GoalSummary> GetGoalSummary()
        {
            return DbSet.Select(s => new GoalSummary
            {
                Id = s.Id,
                EndDate = s.EndDate,
                StartDate = s.StartDate,
                Title = s.Title,
                CategoryId = s.CategoryId
            });
        }
    }
}
