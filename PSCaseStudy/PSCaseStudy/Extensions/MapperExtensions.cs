using Microsoft.Extensions.DependencyInjection;
using PSCaseStudy.Items.AutoMapper;

namespace PSCaseStudy.Extensions
{
    public static class MapperExtensions
    {
        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            return services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
