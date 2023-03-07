using api.Data.Models;
using api.Features.Customers.Models;
using api.Infrastructure.Services.Common;

namespace api.Features.Customers
{
    public interface ICustomerService: IService
    {
        Task<CustomerSearchResponseModel> SearchAsync(CustomerSearchRequestModel request);
    }
}
