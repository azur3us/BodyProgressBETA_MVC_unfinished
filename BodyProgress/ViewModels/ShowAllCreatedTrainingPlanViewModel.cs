using BodyProgress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BodyProgress.ViewModels
{
    public class ShowAllCreatedTrainingPlanViewModel
    {
        public Guid PlanId { get; set; }
        public List<TrainingPlan> TrainingPlans;
        public int Counter { get; set; } = 1;
    }
}
