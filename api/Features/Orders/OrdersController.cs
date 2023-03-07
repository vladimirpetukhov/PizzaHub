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

        [HttpGet]
        /// <summary>
        /// Searches for pizza types based on the provided search criteria.
        /// </summary>
        /// <param name="request">The search criteria.</param>
        /// <returns>A collection of matching pizza types.</returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderSearchResponseModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OrderSearchResponseModel>> Search(
            [FromQuery] OrderSearchRequestModel request)
            => await this.orders.SearchAsync(request);

        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> Create(
           [FromBody] OrderRequestModel request)
        {
            var result = await this.orders.CreateAsync(request);

            return result;
        }
    }
}
