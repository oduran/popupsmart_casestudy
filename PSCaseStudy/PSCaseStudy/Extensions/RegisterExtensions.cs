using Microsoft.Extensions.DependencyInjection;
using PSCaseStudy.Business.Interfaces;
using PSCaseStudy.Business.Services;

namespace PSCaseStudy.Extensions
{
    public static class RegisterExtensions
    {
        public static IServiceCollection RegisterBusiness(this IServiceCollection services)
        {
            // business
            services.AddTransient<IIntegrationItemService, IntegrationItemService>();
            services.AddTransient<IContactService, ContactService>();

            return services;
        }
    }
}
