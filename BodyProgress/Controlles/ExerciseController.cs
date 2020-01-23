using BodyProgress.Logic;
using BodyProgress.Models;
using BodyProgress.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
            var myVM = new ExerciseViewModel();
            myVM.PartOfBodies = _exerciseService.ShowPartOfBodyToSelect();
            return View(myVM);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddExercise(ExerciseViewModel model)
        {
            var exercise = new Exercise()
            {
                Name = model.Name,
                PartOfBodyId = model.PartOfBodyId
            };

            if (ModelState.IsValid)
            {
                _exerciseService.CreateExercise(exercise);
                return RedirectToAction("AddExercise");
            }

            return View();
        }

        [HttpGet]
        public IActionResult DeleteExercise(Guid Id)
        {
            var exercise = _exerciseService.TakeExerciseById(Id);
            if (exercise == null)
            {
                return NotFound();
            }

            var exerciseViewModel = new DeleteExerciseViewModel()
            {
                Id = exercise.Id,
                Name = exercise.Name
            };

            return View(exerciseViewModel);
        }

        [HttpPost, ActionName("DeleteExercise")]
        public IActionResult DeleteConfirmed(Guid Id)
        {
            var exercise = _exerciseService.TakeExerciseById(Id);
            _exerciseService.DeleteExercise(exercise);

            return RedirectToAction("ShowAllExercises", "Exercise");
        }

        [HttpGet]
        public IActionResult EditExercise(Guid Id)
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
            var exercises = _exerciseService.ReturnAllExercises().OrderBy(x => x.PartOfBody.Name);

            var exerciseViewModel = new ExerciseViewModel()
            {
                Exercises = exercises.ToList()
            };

            return View(exerciseViewModel);
        }
    }
}