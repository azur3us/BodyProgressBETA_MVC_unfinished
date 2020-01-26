using BodyProgress.Models;
using Microsoft.AspNetCore.Identity;
using System;

namespace BodyProgress.Logic
{
    public interface ITrainingPlanService
    {
        void AddTrainingPlan(TrainingPlan traningPlan);
    }
}
