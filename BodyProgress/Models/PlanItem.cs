using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BodyProgress.Models
{
    public class PlanItem
    {
        public Guid Id { get; set; }
        public decimal Weight { get; set; }
        public int Reps { get; set; }

        public TrainingPlan TrainingPlan { get; set; }

        public List<PlanItemExercise> PlanItemExercises { get; set; }
    }
}
