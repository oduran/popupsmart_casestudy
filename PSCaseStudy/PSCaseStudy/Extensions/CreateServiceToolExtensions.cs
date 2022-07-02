using Microsoft.Extensions.DependencyInjection;
using PSCaseStudy.IoC;

namespace PSCaseStudy.Extensions
{
    public static class CreateServicesExtensions
    {
        public static IServiceCollection AddServiceTool(this IServiceCollection services)
        {
            return ServiceTool.Create(services);
        }
    }
}
