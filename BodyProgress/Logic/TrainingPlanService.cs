using BodyProgress.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace BodyProgress.Logic
{
    public class TrainingPlanService : ITrainingPlanService
    {

        private readonly BodyProgressDbContext _context;

        public TrainingPlanService(BodyProgressDbContext context)
        {
            _context = context;
        }

        public void AddTrainingPlan(TrainingPlan traningPlan)
        {
            _context.TrainingPlans.Add(traningPlan);
            _context.SaveChanges();
        }

        public List<SelectListItem> ShowAllExerciseInSelectList()
        {
            return _context.Exercises.Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.Name }).ToList();
        }
    }
}
