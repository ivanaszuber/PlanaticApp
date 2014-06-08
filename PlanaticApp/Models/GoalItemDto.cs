using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewPlanner.Models
{
    public class GoalItemDto
    {
        public GoalItemDto() { }

        public GoalItemDto(GoalItem item)
        {
            GoalItemId = item.GoalItemId;
            Title = item.Title;
            IsDone = item.IsDone;
            GoalListId = item.GoalListId;
        }

        [Key]
        public int GoalItemId { get; set; }

        [Required]
        public string Title { get; set; }

        public bool IsDone { get; set; }

        public int GoalListId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }

        public GoalItem ToEntity()
        {
            return new GoalItem
            {
                GoalItemId = GoalItemId,
                Title = Title,
                IsDone = IsDone,
                GoalListId = GoalListId,
                StartDate = StartDate,
                EndDate = EndDate,
                Description = Description,
                Category = Category
            };
        }
    }
}