using Microsoft.AspNetCore.Mvc;

namespace Dvor.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}