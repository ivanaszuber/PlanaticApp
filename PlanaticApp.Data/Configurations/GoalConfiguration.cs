using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanaticApp.Model;

namespace PlanaticApp.Data.Configurations
{
    public class GoalConfiguration : EntityTypeConfiguration<Goal>
    {
        public GoalConfiguration()
        {
            HasRequired(x => x.LifeCategory)
                .WithMany(x => x.GoalList)
                .HasForeignKey(x => x.CategoryId);

        }
    }
}
