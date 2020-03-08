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
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };

                IdentityResult result = await _roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult AddExercise()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddExercise(ExerciseViewModel model)
        {
            var exercise = new Exercise()
            {
                Name = model.Name
            };

            if (ModelState.IsValid)
            {
                await _exerciseService.CreateExercise(exercise);
                return RedirectToAction("AddExercise");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteExercise(int id)
        {
            await _exerciseService.DeleteExercise(id);

            return RedirectToAction("ShowAllExercises", "Administration");
        }

        [HttpGet]
        public async Task<IActionResult> EditExercise(int id)
        {
            var exercise = await _exerciseService.TakeExerciseById(id);

            var exerciseViewModel = new EditExerciseViewModel()
            {
                Name = exercise.Name
            };

            return View(exerciseViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditExercise(EditExerciseViewModel model)
        {
            var exercise = new Exercise()
            {
                Id = model.Id
            };

            exercise.Name = model.Name;

            await _exerciseService.EditExercise(exercise);

            return RedirectToAction("ShowAllExercises", "Administration");
        }

        [HttpGet]
        public IActionResult ShowAllExercises()
        {
            var exercises = _exerciseService.ReturnAllExercises();

            var exerciseViewModel = new ExerciseViewModel()
            {
                Exercises = exercises
            };

            return View(exerciseViewModel);
        }
    }
}