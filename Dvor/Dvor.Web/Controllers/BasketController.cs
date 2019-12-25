using Dvor.Common.Entities.DTO;
using Dvor.Common.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dvor.Web.Controllers
{
    public class BasketController : Controller
    {
        private readonly IOrderService _orderService;

        public BasketController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            var currentOrder = _orderService.GetCurrentOrder();

            return View(currentOrder);
        }

        [HttpPost]
        public IActionResult Add(string dishId, short quantity)
        {
            var orderDetailsDto = new OrderDetailsDTO
            {
                DishId = dishId,
                Quantity = quantity
            };

            _orderService.AddDetails(orderDetailsDto);

            return RedirectToAction("Index");
        }

        public IActionResult RemoveDetails(string id)
        {
            _orderService.RemoveDetails(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ChangeCount(string id, short quantity)
        {
            _orderService.UpdateDetailsCount(id, quantity);

            return RedirectToAction("Index");
        }

        public IActionResult Submit()
        {
            //
            _orderService.Submit("");

            return RedirectToAction("Index", "Home");
        }
    }
}