using api.Data.Models;
using api.Infrastructure.Mapping;

namespace api.Features.Pizzas.Models
{
    public class PizzasTypeListingResponseModel : IMapFrom<PizzaType>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}
