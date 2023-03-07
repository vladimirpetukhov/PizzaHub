using api.Data.Models;
using api.Infrastructure.Mapping;

namespace api.Features.Customers.Models
{
    public class CustomerListingResponseModel: IMapFrom<Customer>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }
    }
}
