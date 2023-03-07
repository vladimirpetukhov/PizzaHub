using api.Data.Models;
using api.Infrastructure.Mapping;

namespace api.Features.Pizzas.Models
{
    public class PizzassTypesSelectModel : IMapFrom<PizzaType>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
