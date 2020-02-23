using BodyProgress.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BodyProgress.ViewModels
{
    public class CreateTrainingPlanViewModel
    {
        public Guid TraningPlanId { get; set; }
        public DateTime CratedDate { get; set; }
        public string TrainingPlanName { get; set; }
        public string CreatorId { get; set; }
        public string UserName { get; set; }

        public List<SelectListItem> ExercisesSelectList { get; set; }

        public List<PlanItemModel> PlanItems { get; set; }
    }

    public class PlanItemModel
    {
        public int ExerciseId { get; set; }
        public decimal Weight { get; set; }
        public int Reps { get; set; }
    }
}
