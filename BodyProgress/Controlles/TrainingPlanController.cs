﻿using BodyProgress.Logic;
using BodyProgress.Models;
using BodyProgress.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;

namespace BodyProgress.Controlles
{
    public class TrainingPlanController : Controller
    {
        private readonly ITrainingPlanService _trainingPlanService;

        public TrainingPlanController(ITrainingPlanService trainingPlanService)
        {
            _trainingPlanService = trainingPlanService;
        }

        [HttpGet]
        public IActionResult CreateTrainingPlan()
        {

            if (User.FindFirstValue(ClaimTypes.NameIdentifier) == null)
            {
                throw new Exception("UserId is null");
            }

            var createTrainingPlanViewMode = new CreateTrainingPlanViewModel()
            {
                ExercisesSelectList = _trainingPlanService.ShowAllExerciseInSelectList(),
                CreatorId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                UserName = User.FindFirstValue(ClaimTypes.Name),
            };

            return View(createTrainingPlanViewMode);
        }

        [HttpPost]
        public IActionResult CreateTrainingPlan(CreateTrainingPlanViewModel model)
        {
            var newTrainingPlan = new TrainingPlan()
            {
                UserId = model.CreatorId,
                CreatedDate = DateTime.Now,
                TrainingPlanName = model.TrainingPlanName,
                PlanItems = model.PlanItems.Select(x => new PlanItem()
                {
                    ExerciseId = x.ExerciseId,
                    Reps = x.Reps,
                    Weight = x.Weight
                }).ToList()
            }; 

            _trainingPlanService.AddTrainingPlan(newTrainingPlan, newTrainingPlan.PlanItems);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult ShowAllCreatedTrainingPlan()
        {
            var trainingPlans = _trainingPlanService.ReturnAllCreatedTrainingPlans(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var showAllCreatedTrainingPlanViewModel = new ShowAllCreatedTrainingPlanViewModel()
            {
                TrainingPlans = trainingPlans,
            };
          
            return View(showAllCreatedTrainingPlanViewModel);
        }

        [HttpGet]
        public IActionResult TrainingPlanDetails(Guid trainingPlanId)
        {
            var trainingId = _trainingPlanService.TakeTrainingPlanById(trainingPlanId);
            var planItemList = _trainingPlanService.ShowPlanItemsBelongingToTrainingPlan(trainingPlanId);

            var trainingPlanDetailsViewModel = new TrainingPlanDetailsViewModel()
            {
                PlanId = trainingId.Id,
                TrainingPlanName = trainingId.TrainingPlanName,
                PlanItems = planItemList                
            };

            return View(trainingPlanDetailsViewModel);
        }

        [HttpPost]
        public IActionResult DeleteTrainingPlan(Guid Id)
        {
            var trainingPlan = _trainingPlanService.TakeTrainingPlanById(Id);
            _trainingPlanService.RemoveTrainingPlan(trainingPlan);

            return RedirectToAction("ShowAllCreatedTrainingPlan","TrainingPlan");
        }
    }
}