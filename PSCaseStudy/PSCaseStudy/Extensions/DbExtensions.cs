using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PSCaseStudy.Datas;
using PSCaseStudy.Items;

namespace PSCaseStudy.Extensions
{
    public static class DbExtensions
    {
        public static IServiceCollection AddPostgreDbContext(this IServiceCollection services)
        {
            var builder = services.BuildServiceProvider();
            var connectionStrings = builder.GetRequiredService<IOptions<ConnectionStringsItem>>().Value;

            return services.AddDbContext<AppDbContext>(options =>
                    options.UseNpgsql(connectionStrings.PostgreDbContext), ServiceLifetime.Transient
            );
        }
    }
}
