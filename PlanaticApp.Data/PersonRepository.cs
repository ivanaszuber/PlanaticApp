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
    public class PersonRepository : EFRepository<Person>, IPersonRepository 
    {
        public PersonRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<Goal> GetGoals()
        {
            return DbContext.Set<Relations>().Select(relation => relation.Goal)
                .Distinct().Select(x =>
                    new Goal
                    {
                        Id = x.Id,
                        LifeCategory = x.LifeCategory,
                        Description = x.Description,
                        EndDate = x.EndDate,
                        StartDate = x.StartDate,
                        Title = x.Title
                    });
        }
    }
}
