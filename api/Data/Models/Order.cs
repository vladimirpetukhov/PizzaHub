using api.Data.Common;
using api.Data.Models.Enums;
using System.Net;

namespace api.Data.Models
{
    public class Order : Entity
    {
        public int Id { get; set; }

        public Guid OrderCode { get; set; } = Guid.NewGuid();

        public int Quantity { get; set; }

        public OrderStatus Status { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public ICollection<OrderPizza> Pizzas { get; } = new HashSet<OrderPizza>();
    }
}
