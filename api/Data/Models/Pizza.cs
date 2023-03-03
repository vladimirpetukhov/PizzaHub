using api.Data.Common;

namespace api.Data.Models
{
    public class Pizza : Entity
    {
        public int Id { get; set; }
        
        public int PizzaTypeId { get; set; }
        public PizzaType PizzaType { get; set; }

        public ICollection<OrderPizza> Orders { get; } = new HashSet<OrderPizza>();
    }
}
