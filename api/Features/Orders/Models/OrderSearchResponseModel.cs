using api.Features.Pizzas.Models;

namespace api.Features.Orders.Models
{
    public class OrderSearchResponseModel
    {
        public OrderSearchResponseModel(
           IEnumerable<OrderListingResponseModel> orders,
           int page,
           int totalPages)
        {
            this.Orders = orders;
            this.Page = page;
            this.TotalPages = totalPages;
        }

        public IEnumerable<OrderListingResponseModel> Orders { get; }

        public int Page { get; }

        public int TotalPages { get; }
    }
}
