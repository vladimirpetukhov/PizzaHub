using api.Features.Pizzas.Models;
using api.Infrastructure.Common;
using api.Infrastructure.Services.Common;

namespace api.Features.Pizzas
{
    public interface IPizzasService: IService
    {
        Task<int> CreateAsync(PizzasTypeRequestModel request);

        Task<Result> UpdateAsync(int id, PizzasTypeRequestModel request);

        Task<PizzasTypeSearchResponseModel> SearchAsync(PizzasTypeSearchRequestModel request);

        Task<PizzasForSelectResponseModel> Select();

        Task<Result> DeleteAsync(int id);
    }
}
