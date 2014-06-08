using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanaticApp.Model
{
    public class Goal: GoalSummary
    {
        public string Description { get; set; }
        public LifeCategory LifeCategory { get; set; }
        public virtual ICollection<Relations> RelationsList { get; set; } 
        public virtual ICollection<Task> TaskList { get; set; } 
    }
}
