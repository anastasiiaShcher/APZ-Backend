using Microsoft.AspNetCore.Mvc;

namespace Dvor.Web.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index(string id)
        {

            return View();
        }
    }
}