namespace api.Features.Pizzas.Models
{
    public class PizzasTypeSearchResponseModel
    {
        public PizzasTypeSearchResponseModel(
            IEnumerable<PizzasTypeListingResponseModel> pizzas,
            int page,
            int totalPages)
        {
            this.Pizzas = pizzas;
            this.Page = page;
            this.TotalPages = totalPages;
        }

        public IEnumerable<PizzasTypeListingResponseModel> Pizzas { get; }

        public int Page { get; }

        public int TotalPages { get; }
    }
}
