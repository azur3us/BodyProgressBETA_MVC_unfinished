﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BodyProgress.Logic;
using BodyProgress.Models;
using BodyProgress.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BodyProgress.Controlles
{
    public class ExerciseController : Controller
    {
        private readonly IExerciseService _exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpGet]
        public IActionResult AddExercise()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public IActionResult AddExercise(ExerciseViewModel model)
        {

            var exerciseViewModel = new Exercise()
            {
                Name = model.Name
            };

            if (ModelState.IsValid)
            {
                _exerciseService.CreateExercise(exerciseViewModel);
                return RedirectToAction("AddExercise");
            }


            return View();
        }

        [HttpGet]
        public IActionResult ShowAllExercises()
        {
            var exercises = _exerciseService.ReturnAllExercises().OrderBy(x => x.Name);

            var exerciseViewModel = new ExerciseViewModel()
            {
                Exercises = exercises.ToList()
            };

            return View(exerciseViewModel);
        }
    }
}