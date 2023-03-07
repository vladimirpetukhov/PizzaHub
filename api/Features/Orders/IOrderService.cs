using api.Features.Orders.Models;
using api.Features.Pizzas.Models;
using api.Infrastructure.Services.Common;

namespace api.Features.Orders
{
    public interface IOrderService: IService
    {
        Task<int> CreateAsync(OrderRequestModel request);
    }
}
