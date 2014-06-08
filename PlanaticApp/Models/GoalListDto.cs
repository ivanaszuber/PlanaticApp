using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewPlanner.Models
{
    public class GoalListDto
    {
        public GoalListDto() { }

        public GoalListDto(GoalList GoalList)
        {
            GoalListId = GoalList.GoalListId;
            UserId = GoalList.UserId;
            Title = GoalList.Title;
            Goals = new List<GoalItemDto>();
            foreach (GoalItem item in GoalList.Goals)
            {
                Goals.Add(new GoalItemDto(item));
            }
        }

        [Key]
        public int GoalListId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string Title { get; set; }

        public virtual List<GoalItemDto> Goals { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }

        public GoalList ToEntity()
        {
            GoalList Goal = new GoalList
            {
                Title = Title,
                GoalListId = GoalListId,
                UserId = UserId,
                StartDate = StartDate,
                EndDate = EndDate,
                Description = Description,
                Category = Category,
                Goals = new List<GoalItem>()
            };
            foreach (GoalItemDto item in Goals)
            {
                Goal.Goals.Add(item.ToEntity());
            }

            return Goal;
        }
    }
}