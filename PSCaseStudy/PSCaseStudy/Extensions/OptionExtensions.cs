using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PSCaseStudy.Datas;
using PSCaseStudy.Items;

namespace PSCaseStudy.Extensions
{
    public static class OptionExtensions
    {
        public static IServiceCollection ConfigureOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnectionStringsItem>(configuration.GetSection(ConnectionStringsItem.Path));
            return services;
        }
    }
}
