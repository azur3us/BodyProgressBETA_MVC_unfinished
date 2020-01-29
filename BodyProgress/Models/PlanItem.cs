using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BodyProgress.Models
{
    public class PlanItem
    {
        public Guid Id { get; set; }
        public decimal Weight { get; set; }
        public int Reps { get; set; }

        public Guid TrainingPlanId { get; set; }
        public TrainingPlan TrainingPlan { get; set; }

        public Guid ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
    }
}
