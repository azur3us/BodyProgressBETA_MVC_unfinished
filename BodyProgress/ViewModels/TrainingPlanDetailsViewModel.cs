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
        public string TrainingPlanName { get; set; }
        public List<PlanItem> PlanItems { get; set; }
    }
}
