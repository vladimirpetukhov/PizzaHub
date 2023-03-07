using api.Features.Customers.Models;
using api.Features.Pizzas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Features.Customers
{
    public class CustomerController : ApiController
    {
        private readonly ICustomerService customers;

        public CustomerController(ICustomerService customerService)
            => customers = customerService;

        [HttpGet]
        /// <summary>
        /// Searches for pizza types based on the provided search criteria.
        /// </summary>
        /// <param name="request">The search criteria.</param>
        /// <returns>A collection of matching pizza types.</returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerSearchRequestModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CustomerSearchResponseModel>> Search(
            [FromQuery] CustomerSearchRequestModel request)
            => await this.customers.SearchAsync(request);
    }
}
