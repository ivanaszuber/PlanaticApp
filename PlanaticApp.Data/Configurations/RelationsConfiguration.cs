using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanaticApp.Model;

namespace PlanaticApp.Data.Configurations
{
    public class RelationsConfiguration : EntityTypeConfiguration<Relations>
    {
        public RelationsConfiguration()
        {
            HasKey(x => new {x.GoalId, x.PersonId});

            HasRequired(x => x.Person)
                .WithMany(x => x.RelationsList)
                .HasForeignKey(x => x.PersonId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Goal)
                .WithMany(x => x.RelationsList)
                .HasForeignKey(x => x.GoalId)
                .WillCascadeOnDelete(false);
        }
    }
}
