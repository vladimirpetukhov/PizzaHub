using api.Data;
using api.Data.Models;
using api.Features.Customers.Models;
using api.Features.Customers.Specifications;
using api.Features.Pizzas.Models;
using api.Features.Pizzas.Specifications;
using api.Infrastructure.Common;
using api.Infrastructure.Services.Common;
using AutoMapper;
using System.Data.Entity;

namespace api.Features.Customers
{
    public class CustomerService : DataService<Customer>, ICustomerService
    {
        public CustomerService(PizzaDbContext data, IMapper mapper) : base(data, mapper)
        {
        }

        public async Task<CustomerSearchResponseModel> SearchAsync(CustomerSearchRequestModel request)
        {
            var specification = this.GetCustomerSpecification(request);
            var customers =  this.Mapper
                .ProjectTo<CustomerListingResponseModel>(this
                    .AllAsNoTracking()
                    .Where(specification));

            return new CustomerSearchResponseModel(customers);
        }

        private Specification<Customer> GetCustomerSpecification(
            CustomerSearchRequestModel request)
            => new CustomerByIdOrPhoneSpecification(request.Query);
    }
}
