using BodyProgress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BodyProgress.ViewModels
{
    public class TrainingPlanDetailsViewModel
    {
        public Guid PlanId { get; set; }
        //public string ExerciseName { get; set; }
        //public decimal Weight { get; set; }
        //public int Reps { get; set; }
        public List<PlanItem> PlanItems { get; set; }
    }
}
