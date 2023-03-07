using api.Data;
using api.Data.Models;
using api.Features.Pizzas.Models;
using api.Features.Pizzas.Specifications;
using api.Infrastructure.Common;
using api.Infrastructure.Services.Common;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api.Features.Pizzas
{
    public class PizzasService : DataService<PizzaType>, IPizzasService
    {

        private const int PizzasPerPage = 9;

        public PizzasService(PizzaDbContext data, IMapper mapper) : base(data, mapper)
        {
        }

        public async Task<int> CreateAsync(PizzasTypeRequestModel request)
        {
            var pizza = new PizzaType
            {
                Name = request.Name,
                Price = request.Price,
                Description = request.Description
            };

            await this.Data.AddAsync(pizza);
            await this.Data.SaveChangesAsync();

            return pizza.Id;
        }

        public async Task<Result> UpdateAsync(
           int id, PizzasTypeRequestModel request)
        {
            var pizza = await this.FindByIdAsync(id);

            if (pizza == null)
            {
                return false;
            }

            pizza.Name = request.Name;
            pizza.Price = request.Price;
            pizza.Description = request.Description;

            await this.Data.SaveChangesAsync();

            return true;
        }

        public async Task<Result> DeleteAsync(int id)
        {
            var pizza = await this.FindByIdAsync(id);

            if (pizza == null)
            {
                return false;
            }

            this.Data.Remove(pizza);

            await this.Data.SaveChangesAsync();

            return true;
        }

        public async Task<PizzasTypeSearchResponseModel> SearchAsync(
            PizzasTypeSearchRequestModel request)
        {
            var specification = this.GetPizzaSpecification(request);
            request.Page = request.Page <= 0 ? 1 : request.Page;
            var pizzas = await this.Mapper
                .ProjectTo<PizzasTypeListingResponseModel>(this
                    .AllAsNoTracking()
                    .Where(specification)
                    .Skip((request.Page - 1) * PizzasPerPage)
                    .Take(PizzasPerPage))
                .ToListAsync();

            var totalPages = await this.GetTotalPages(request);

            return new PizzasTypeSearchResponseModel(pizzas, request.Page, totalPages);
        }

        public async Task<PizzasForSelectResponseModel> Select()
        {
            var pizzas = await this.Mapper
                .ProjectTo<PizzassTypesSelectModel>(this
                    .AllAsNoTracking())
                .ToListAsync();

            return new PizzasForSelectResponseModel(pizzas);
        }
         

        private async Task<int> GetTotalPages(
            PizzasTypeSearchRequestModel request)
        {
            var specification = this.GetPizzaSpecification(request);

            var total = await this
                .AllAsNoTracking()
                .Where(specification)
                .CountAsync();

            return (int)Math.Ceiling((double)total / PizzasPerPage);
        }

        private async Task<PizzaType> FindByIdAsync(
            int id)
            => await this
                .All()
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

        private Specification<PizzaType> GetPizzaSpecification(
            PizzasTypeSearchRequestModel request)
            => new PizzaByTypeNameSpecification(request.Query);

    }
}
