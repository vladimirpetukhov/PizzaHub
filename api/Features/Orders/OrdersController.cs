using api.Features.Orders.Models;
using api.Features.Pizzas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Features.Orders
{
    public class OrdersController : ApiController
    {
        private readonly IOrderService orders;

        public OrdersController(IOrderService orderService)
            => orders = orderService;

        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> Create(
            OrderRequestModel request)
        {
            var result = await this.orders.CreateAsync(request);

            return result;
        }
    }
}
