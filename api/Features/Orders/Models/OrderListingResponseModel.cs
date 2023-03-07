using api.Data.Models;
using api.Data.Models.Enums;
using api.Infrastructure.Mapping;
using AutoMapper;

namespace api.Features.Orders.Models
{
    public class OrderListingResponseModel: IMapFrom<Order>
    {
        public string OrderCode { get; set; }

        public int Quantity { get; set; }

        public string Status { get; set; }

        public Customer Customer { get; set; }

        public PizzaType? Pizza { get; set; }

    }
}
