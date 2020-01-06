using System;
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
        public IActionResult AddExercise(Exercise exercise)
        {           
            if(ModelState.IsValid)
            { 
            _exerciseService.CreateExercise(exercise);
            return RedirectToAction("AddExercise");
            }

            return View();

        }
    }
}