using Dvor.Common.Entities;
using Dvor.Common.Interfaces.Services;
using Dvor.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dvor.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IDishService _dishService;

        public CategoryController(IDishService dishService)
        {
            _dishService = dishService;
        }

        public IActionResult Get(DishSorting parameters)
        {
            var items = _dishService.GetSorted(parameters);

            var dishesListViewModel = new DishesListViewModel
            {
                Filter = parameters,
                Dishes = items
            };

            return View(dishesListViewModel);
        }
    }
}