using BodyProgress.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace BodyProgress.Logic
{
    public interface ITrainingPlanService
    {
        List<SelectListItem> ShowAllExerciseInSelectList();
        List<TrainingPlan> ReturnAllCreatedTrainingPlans(string creatorId);
        TrainingPlan TakeTrainingPlanById(Guid Id);
        List<PlanItem> ShowPlanItemsBelongingToTrainingPlan(Guid PlanId);
        void AddTrainingPlan(TrainingPlan traningPlan, List<PlanItem> planItems);
        void RemoveTrainingPlan(TrainingPlan trainingPlan);
    }
}
