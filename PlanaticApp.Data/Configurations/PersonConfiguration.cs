using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanaticApp.Model;

namespace PlanaticApp.Data.Configurations
{
    public class PersonConfiguration : EntityTypeConfiguration<Person>
    {
        public PersonConfiguration()
        {           
            HasRequired(x => x.LifeCategory)      
                .WithMany(x=>x.PersonList)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
