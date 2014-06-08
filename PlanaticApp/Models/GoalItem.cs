using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewPlanner.Models
{
    public class GoalItem
    {
        public int GoalItemId { get; set; }

        [Required]
        public string Title { get; set; }
        public bool IsDone { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [ForeignKey("GoalList")]
        public int GoalListId { get; set; }
        public virtual GoalList GoalList { get; set; }
    }
}