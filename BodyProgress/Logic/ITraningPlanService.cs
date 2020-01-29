﻿using BodyProgress.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace BodyProgress.Logic
{
    public interface ITrainingPlanService
    {
        void AddTrainingPlan(TrainingPlan traningPlan);
        List<SelectListItem> ShowAllExerciseInSelectList();
    }
}