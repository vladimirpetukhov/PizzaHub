using api.Data;
using api.Data.Models;
using api.Data.Models.Enums;
using api.Features.Orders.Models;
using api.Features.Orders.Specifications;
using api.Features.Pizzas.Models;
using api.Features.Pizzas.Specifications;
using api.Infrastructure.Common;
using api.Infrastructure.Services.Common;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api.Features.Orders
{
    public class OrderService : DataService<Order>, IOrderService
    {
        private const int OrdersPerPage = 9;

        public OrderService(PizzaDbContext data, IMapper mapper) : base(data, mapper)
        {
        }

        //TODO: refactor this method now he makes multiple things!!!
        public async Task<int> CreateAsync(OrderRequestModel request)
        {

            var customer = await Data.Customers.FindAsync(request.Customer.Id);
            if (customer is null)
            {
                // create new customer if it does not exist
                customer = new Customer
                {
                    Name = request.Customer.Name,
                    Address = request.Customer.Address,
                    Phone = request.Customer.Phone,
                };
                // add customer to database
                customer = Data.Customers.Add(customer).Entity;
                await Data.SaveChangesAsync();
            }

            var pizzaType = await Data.PizzaTypes.FindAsync(request.PizzaType);

            if (pizzaType == null)
            {
                throw new ArgumentException($"Pizza type with ID {request.PizzaType} does not exist.");
            }

            // create new order
            var order = new Order
            {
                Quantity = request.Quantity,
                CustomerId = customer.Id,
                Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), request.Status, true)
            };

            var orderPizza = new OrderPizza
            {
                Order = order,
                Pizza = new Pizza { PizzaTypeId = pizzaType.Id},
                Quantity = request.Quantity
            };

            Data.Orders.Add(order);
            Data.OrderPizzas.Add(orderPizza);

            return await Data.SaveChangesAsync();

        }

        public async Task<OrderSearchResponseModel> SearchAsync(OrderSearchRequestModel request)
        {
            var specification = this.GetOrderSpecification(request);
            request.Page = request.Page <= 0 ? 1 : request.Page;
            var orders = await this.Mapper
                .ProjectTo<OrderListingResponseModel>(this
                    .AllAsNoTracking()
                    .Where(specification)
                    .OrderByDescending(x => x.CreatedOn)
                    .Skip((request.Page - 1) * OrdersPerPage)
                    .Take(OrdersPerPage)
                    .Select(x => new OrderListingResponseModel
                    {
                        OrderCode = x.OrderCode.ToString(),
                        Quantity = x.Quantity,
                        Status = x.Status.ToString(),
                        Customer = x.Customer,
                        Pizza = x.Pizzas.Any() ? x.Pizzas.First(o => o.OrderId == x.Id).Pizza.PizzaType: null //Little Tricky
                    }))
                .ToListAsync();

            var totalPages = await this.GetTotalPages(request);

            return new OrderSearchResponseModel(orders, request.Page, totalPages);
        }

        public Task<int> UpdateAsync(OrderRequestModel request)
        {
            throw new NotImplementedException();
        }

        private async Task<int> GetTotalPages(
            OrderSearchRequestModel request)
        {
            var specification = this.GetOrderSpecification(request);

            var total = await this
                .AllAsNoTracking()
                .Where(specification)
                .CountAsync();

            return (int)Math.Ceiling((double)total / OrdersPerPage);
        }

        private Specification<Order> GetOrderSpecification(
            OrderSearchRequestModel request)
            => new OrderByCodeSearchSpecification(request.Query);
    }
}
