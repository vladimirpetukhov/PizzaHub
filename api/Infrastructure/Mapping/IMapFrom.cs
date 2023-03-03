using AutoMapper;

namespace api.Infrastructure.Mapping
{
    public interface IMapFrom<TModel>
        where TModel : class
    {
        void Mapping(Profile mapper) => mapper.CreateMap(typeof(TModel), this.GetType());
    }
}
