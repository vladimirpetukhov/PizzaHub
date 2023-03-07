namespace api.Features.Pizzas.Models
{
    public class PizzasForSelectResponseModel
    {
        public PizzasForSelectResponseModel(IEnumerable<PizzassTypesSelectModel> pizzas)
        {
            Pizzas = pizzas;
        }

        public IEnumerable<PizzassTypesSelectModel> Pizzas { get; }
    }
}
