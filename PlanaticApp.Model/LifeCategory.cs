using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanaticApp.Model
{
    public class LifeCategory
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        [Range (0,5)]
        public int Priority { get; set; }

        public virtual ICollection<Goal> GoalList { get; set; }

        public virtual ICollection<Person> PersonList { get; set; } 
    }
}
