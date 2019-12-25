using Dvor.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dvor.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            return Ok();
        }
    }
}