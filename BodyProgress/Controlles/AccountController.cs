using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BodyProgress.Logic;
using BodyProgress.Models;
using BodyProgress.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BodyProgress.Controlles
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IBodyPartsSizeService _bodyPartsSize;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager,
            IBodyPartsSizeService bodyPartsSize)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _bodyPartsSize = bodyPartsSize;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            var user = await _userManager.FindByNameAsync(loginViewModel.UserName);

            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(LoginViewModel loginViewModel)
        {
            var user = new IdentityUser() {UserName = loginViewModel.UserName};
            var result = await _userManager.CreateAsync(user, loginViewModel.Password);

            loginViewModel.BodyParts = _bodyPartsSize.GetAllBodyParts();

            var userBody = new UserBody()
            {
                UserId = user.Id,
                BodyPartSizes = loginViewModel.BodyParts.Select(x => new BodyPartSize()
                {
                    BodyPartId = x.Id
                }).ToList()
            };

            if (result.Succeeded)
            {
                _bodyPartsSize.CreateUserBody(userBody, userBody.BodyPartSizes);
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult UpdateBodySize()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var bodyParts = _bodyPartsSize.ShowUserBodyParts(userId);

            var vm = new BodyPartsViewModel()
            {
                bodyPartsList = bodyParts,
                Result = new decimal?[bodyParts.Count]
            };

            for (int i = 0; i < bodyParts.Count; i++)
            {
                vm.Result[i] = vm.bodyPartsList[i].CurrentSize - vm.bodyPartsList[i].LastSize;
            }

            return View(vm);
        }

        [HttpPost]
        public IActionResult UpdateBodySize(BodyPartsViewModel model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var bodyParts = _bodyPartsSize.ShowUserBodyParts(userId);
            for (int i = 0; i < bodyParts.Count; i++)
            {
                bodyParts[i].LastSize = model.bodyPartsList[i].LastSize;
                bodyParts[i].CurrentSize = model.bodyPartsList[i].CurrentSize;
            }

            _bodyPartsSize.UpdateUserBody(bodyParts);

            return RedirectToAction("UpdateBodySize", "Account");
        }
    }
}