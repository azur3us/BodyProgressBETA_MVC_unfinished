using BodyProgress.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace BodyProgress.Logic
{
    public class TrainingPlanService : ITrainingPlanService
    {

        private readonly BodyProgressDbContext _context;

        public TrainingPlanService(BodyProgressDbContext context)
        {
            _context = context;
        }

        public List<SelectListItem> ShowAllExerciseInSelectList()
        {
            return _context.Exercises
                .Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.Name })
                .OrderBy(x => x.Text)
                .ToList();
        }

        public List<TrainingPlan> ReturnAllCreatedTrainingPlans(string creatorId)
        {
            return _context.TrainingPlans
                .Where(x => x.UserId == creatorId)
                .OrderByDescending(x => x.CreatedDate)
                .ToList();
        }

        public TrainingPlan TakeTrainingPlanById(Guid Id)
        {
            return _context.TrainingPlans.FirstOrDefault(x => x.Id == Id);
        }

        public List<PlanItem> ShowPlanItemsBelongingToTrainingPlan(Guid PlanId)
        {
            return _context.PlanItems
                .Include(x => x.Exercise)
                .Where(x => x.TrainingPlanId == PlanId)
                .ToList();
        }

        public void AddTrainingPlan(TrainingPlan traningPlan, List<PlanItem> planItems)
        {
            _context.TrainingPlans.Add(traningPlan);
            _context.AddRange(planItems);
            _context.SaveChanges();
        }

        public void RemoveTrainingPlan(TrainingPlan trainingPlan)
        {
            var planItems = _context.PlanItems.Where(x => x.TrainingPlanId == trainingPlan.Id);
            _context.Remove(trainingPlan);
            _context.RemoveRange(planItems);
            _context.SaveChanges();
        }
        
        
    }
}
