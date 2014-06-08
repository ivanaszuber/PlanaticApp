using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanaticApp.Model
{
    public class GoalSummary
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }     
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
