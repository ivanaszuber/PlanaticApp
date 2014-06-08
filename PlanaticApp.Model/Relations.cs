using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanaticApp.Model
{
    public class Relations
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }
        
        public int GoalId{ get; set; }
        public Goal Goal { get; set; }

        public string Description { get; set; }
    }
}
