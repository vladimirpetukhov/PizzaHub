using api.Features.Pizzas.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Features.Pizzas
{
    
    public class PizzasController : ApiController
    {
        private readonly IPizzasService pizzas;

        public PizzasController(IPizzasService pizzas)
            => this.pizzas = pizzas;

        [HttpGet]
        /// <summary>
        /// Return all pizzass type.
        /// </summary>
        /// <param name="request">All.</param>
        /// <returns>A collection of all pizzas with Id and Name</returns>
        [Route("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PizzasForSelectResponseModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PizzasForSelectResponseModel>> All()
            => await this.pizzas.Select();

        [HttpGet]
        /// <summary>
        /// Searches for pizza types based on the provided search criteria.
        /// </summary>
        /// <param name="request">The search criteria.</param>
        /// <returns>A collection of matching pizza types.</returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PizzasTypeSearchResponseModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PizzasTypeSearchResponseModel>> Search(
            [FromQuery] PizzasTypeSearchRequestModel request)
            => await this.pizzas.SearchAsync(request);

        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> Create(
            PizzasTypeRequestModel request)
        {
            var result = await this.pizzas.CreateAsync(request);

            return result;
        }

        [HttpPut(Id)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update(
            int id, PizzasTypeRequestModel request)
            => await this.pizzas.UpdateAsync(id, request);

        [HttpDelete(Id)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(
            int id)
            => await this.pizzas.DeleteAsync(id);
    }
}
