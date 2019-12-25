using Microsoft.AspNetCore.Mvc;

namespace Dvor.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}