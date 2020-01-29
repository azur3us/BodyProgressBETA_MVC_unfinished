using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BodyProgress.Models
{
    public class PlanItemExercise
    {
        public Guid ExerciseId { get; set; }
        public Exercise Exercise { get; set; }

        public Guid PlanItemId { get; set; }
        public PlanItem PlanItem { get; set; }
    }
}
