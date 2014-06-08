using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using PlanaticApp.Model;

namespace PlanaticApp.Data.Configurations
{
    public class TaskConfiguration : EntityTypeConfiguration<Task>
    {
        public TaskConfiguration()
        {
            HasRequired(x => x.Goal)
                .WithMany(x => x.TaskList)
                .HasForeignKey(x => x.GoalId);
        }
    }
}
