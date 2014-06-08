using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlanaticApp.Model;

namespace PlanaticApp.Data.Contracts
{
    public interface IGoalRepository: IRepository<Goal>
    {
        IQueryable<Relations> GetRelations();
        IQueryable<Task> GetTasks();

        IQueryable<GoalSummary> GetGoalSummary();
    }
}
