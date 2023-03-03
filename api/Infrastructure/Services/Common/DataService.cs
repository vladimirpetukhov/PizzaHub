using api.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api.Infrastructure.Services.Common
{
    public abstract class DataService<TEntity>
        where TEntity : class
    {
        protected DataService(PizzaDbContext data, IMapper mapper)
        {
            this.Data = data;
            this.Mapper = mapper;
        }

        protected PizzaDbContext Data { get; }

        protected IMapper Mapper { get; }

        protected IQueryable<TEntity> All() => this.Data.Set<TEntity>();

        protected IQueryable<TEntity> AllAsNoTracking() => this.All().AsNoTracking();
    }
}
