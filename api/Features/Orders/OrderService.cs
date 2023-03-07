using api.Data;
using api.Data.Models;
using api.Data.Models.Enums;
using api.Features.Orders.Models;
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
    }
}
