using api.Data.Common;

namespace api.Data.Models
{
    public class PizzaType: Entity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}
