using Microsoft.AspNetCore.Identity;
using System.Net;

namespace api.Data.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public ICollection<Order> Orders { get; } = new HashSet<Order>();
    }
}
