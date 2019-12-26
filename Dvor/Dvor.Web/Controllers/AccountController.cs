using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CryptoHelper;
using Dvor.Common.Entities;
using Dvor.Common.Interfaces.Services;
using Dvor.Web.Infrastructure;
using Dvor.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dvor.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IDishService _dishService;

        public AccountController(IUserService userService, IDishService dishService)
        {
            _userService = userService;
            _dishService = dishService;
        }

        [Authorize]
        public IActionResult Index()
        {
            var allergies = _dishService.GetAllergies();
            var userViewModel = new UserViewModel { AllAllergies = allergies };

            return View(userViewModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Index(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.Get(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                user.Allergies = model.Allergies.Select(allergy => new UserAllergy { UserId = user.UserId, AllergyId = allergy }).ToList();
                user.Name = model.Name;
                _userService.Update(user);
            }

            var allergies = _dishService.GetAllergies();
            model.AllAllergies = allergies;

            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel credentials)
        {
            var user = _userService.GetByEmail(credentials.Email);

            if (user != null && Crypto.VerifyHashedPassword(user.PasswordHash, credentials.Password))
            {
                var claims = ClaimsOperator.GenerateClaims(user);
                var principal = ClaimsOperator.CreatePrincipal(claims);
                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(nameof(credentials.Password), "Invalid login or password");

            return View(credentials);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Email = model.Email,
                    Name = model.Name,
                    PasswordHash = model.Password
                };

                _userService.Create(user);
                var claims = ClaimsOperator.GenerateClaims(user);
                var principal = ClaimsOperator.CreatePrincipal(claims);
                await HttpContext.SignInAsync(principal);

                return RedirectToAction("EditAllergies");
            }

            return View(model);
        }

        public IActionResult EditAllergies()
        {
            var allergies = _dishService.GetAllergies();

            return View(allergies);
        }

        [HttpPost]
        [Authorize]
        public IActionResult EditAllergies(IList<string> allergies)
        {
            var user = _userService.Get(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            user.Allergies = allergies.Select(allergy => new UserAllergy {UserId = user.UserId, AllergyId = allergy}).ToList();
            _userService.Update(user);

            return RedirectToAction("Index", "Home");
        }
    }
}