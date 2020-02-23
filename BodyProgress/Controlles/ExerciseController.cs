using BodyProgress.Logic;
using BodyProgress.Models;
using BodyProgress.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

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
        public IActionResult AddExercise(ExerciseViewModel model)
        {
            var exercise = new Exercise()
            {
                Name = model.Name
            };

            if (ModelState.IsValid)
            {
                _exerciseService.CreateExercise(exercise);
                return RedirectToAction("AddExercise");
            }

            return View();
        }

        [HttpPost]
        public IActionResult DeleteExercise(int Id)
        {
            var exercise = _exerciseService.TakeExerciseById(Id);
            _exerciseService.DeleteExercise(exercise);

            return RedirectToAction("ShowAllExercises", "Exercise");
        }

        [HttpGet]
        public IActionResult EditExercise(int Id)
        {

            var exercise = _exerciseService.TakeExerciseById(Id);

            var exerciseViewModel = new EditExerciseViewModel()
            {
                Id = exercise.Id,
                Name = exercise.Name
            };

            return View(exerciseViewModel);
        }

        [HttpPost]
        public IActionResult EditExercise(EditExerciseViewModel model)
        {
            var exercise = new Exercise()
            {
                Id = model.Id,
                Name = model.Name
            };
            _exerciseService.EditExercise(exercise);

            return RedirectToAction("ShowAllExercises", "Exercise");

        }

        [HttpGet]
        public IActionResult ShowAllExercises()
        {
            var exercises = _exerciseService.ReturnAllExercises();

            var exerciseViewModel = new ExerciseViewModel()
            {
                Exercises = exercises.ToList()
            };

            return View(exerciseViewModel);
        }
    }
}