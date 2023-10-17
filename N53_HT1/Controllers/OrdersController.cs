using Microsoft.AspNetCore.Mvc;
using N53_HT1.Models;
using N53_HT1.Services;

namespace N53_HT1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private OrderService _orderService;

        public OrdersController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _orderService.Get(x => true);
            return result.Any() ? Ok(result) : NotFound();
        }

        [HttpPost]
        public IActionResult CreateOrder(Order order)
        {
            var result = _orderService.CreateAsync(order);
            return Ok(result);
        }
    }
}
