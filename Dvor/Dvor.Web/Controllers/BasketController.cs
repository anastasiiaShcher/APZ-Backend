using Microsoft.AspNetCore.Mvc;

namespace Dvor.Web.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}