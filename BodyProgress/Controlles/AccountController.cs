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

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IBodyPartsSizeService bodyPartsSize)
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

        public IActionResult Register()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(LoginViewModel loginViewModel)
        {
            var user = new IdentityUser() { UserName = loginViewModel.UserName };
            var result = await _userManager.CreateAsync(user, loginViewModel.Password);

            List<BodyPartsSize> bodyParts = new List<BodyPartsSize>()
            {
                new BodyPartsSize()
                {
                    BodyPartName = "Klatka",
                    UserId = user.Id
                },

                 new BodyPartsSize()
                {
                    BodyPartName = "Plecy",
                    UserId = user.Id
                },

                  new BodyPartsSize()
                {
                    BodyPartName = "Nogi",
                    UserId = user.Id
                },

                   new BodyPartsSize()
                {
                    BodyPartName = "Biceps",
                    UserId = user.Id               },

                    new BodyPartsSize()
                {
                    BodyPartName = "Talia",
                    UserId = user.Id
                },

                     new BodyPartsSize()
                {
                    BodyPartName = "Łydka",
                    UserId = user.Id
                }
            };

            _bodyPartsSize.CreateBodyParts(bodyParts);
            

            if (result.Succeeded)
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult ShowUserBodyParts()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var bodyParts = _bodyPartsSize.ShowAllBodyParts(userId);

            var vm = new BodyPartsViewModel()
            {
                bodyPartsList = bodyParts
            };

            return View(vm);
        }

    }
}