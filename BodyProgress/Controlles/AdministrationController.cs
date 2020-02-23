using BodyProgress.Logic;
using BodyProgress.Models;
using BodyProgress.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace BodyProgress.Controlles
{
    public class AdministrationController : Controller
    {
       
        private readonly IExerciseService _exerciseService;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager, IExerciseService exerciseService)
        {
            _roleManager = roleManager;
           
            _exerciseService = exerciseService;
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if(ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };

                IdentityResult result = await _roleManager.CreateAsync(identityRole);

                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Home"); 
                }

                foreach(IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
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