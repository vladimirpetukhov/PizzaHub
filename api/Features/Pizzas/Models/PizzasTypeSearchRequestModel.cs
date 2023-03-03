namespace api.Features.Pizzas.Models
{
    public class PizzasTypeSearchRequestModel
    {
        public string? Query { get; set; }

        public int Page { get; set; } = 1;
    }
}
