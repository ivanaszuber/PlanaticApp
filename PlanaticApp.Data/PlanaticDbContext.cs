using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using PlanaticApp.Data.Configurations;
using PlanaticApp.Model;
using Task = System.Threading.Tasks.Task;

namespace PlanaticApp.Data
{
    public class PlanaticDbContext : DbContext
    {
        public PlanaticDbContext() : base(nameOrConnectionString: "Planatic") { }

        public DbSet<Goal> Goals { get; set; }

        public DbSet<GoalSummary> GoalSummaries { get; set; }
        public DbSet<Person> Peoples { get; set; }
        public DbSet<LifeCategory> LifeCategories { get; set; }
        public DbSet<Task> Tasks { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new GoalConfiguration());
            modelBuilder.Configurations.Add(new PersonConfiguration());
            modelBuilder.Configurations.Add(new RelationsConfiguration());
            modelBuilder.Configurations.Add(new TaskConfiguration());
        }
    }
}
