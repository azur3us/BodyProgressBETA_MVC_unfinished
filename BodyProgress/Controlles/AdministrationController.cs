using BodyProgress.Logic;
using BodyProgress.Models;
using BodyProgress.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace BodyProgress.Controlles
{
    public class AdministrationController : Controller
    {
        private readonly IPartOfBodyService _partOfBodyService;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdministrationController(IPartOfBodyService partOfBodyService, RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _partOfBodyService = partOfBodyService;
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

        [HttpGet]
        public IActionResult AddPartOfBody()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPartOfBody(PartOfBodyViewModel model)
        {
            var partOfBody = new PartOfBody()
            {
                Name = model.Name
            };

            _partOfBodyService.AddParfOfBody(partOfBody);

            return RedirectToAction("AddPartOfBody");

        }

    }
}