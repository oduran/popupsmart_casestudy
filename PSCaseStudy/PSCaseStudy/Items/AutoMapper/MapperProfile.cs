using AutoMapper;

namespace PSCaseStudy.Items.AutoMapper
{
    public class MapperProfile : Profile
    {
        public void CreateFullMap<TDto, TEntity, TModel>()
        {
            CreateMap<TDto, TEntity>();
            CreateMap<TEntity, TModel>();
        }
    }
}
