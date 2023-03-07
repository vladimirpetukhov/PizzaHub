namespace api.Features.Orders.Models
{
    public class OrderSearchRequestModel
    {
        public string? Query { get; set; }

        public int Page { get; set; } = 1;
    }
}
