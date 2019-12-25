using Dvor.Common.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dvor.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDishService _dishService;

        public HomeController(IDishService dishService)
        {
            _dishService = dishService;
        }

        public IActionResult Index()
        {
            var categories = _dishService.GetCategories();

            return View(categories);
        }
    }
}