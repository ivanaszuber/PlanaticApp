using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace PlanaticApp.Model
{
    public class Person
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int CategoryId { get; set; }
        public LifeCategory LifeCategory { get; set; }

        public virtual ICollection<Relations> RelationsList { get; set; } 

        
    }
}
