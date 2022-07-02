using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.ComponentModel;

namespace PSCaseStudy.IoC
{
    public static class ServiceTool
    {
        private static IServiceProvider ServiceProvider { get; set; }
        private static IContainer Container { get; set; }

        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }

        public static T GetService<T>() => ServiceProvider.GetService<T>();

        public static T GetRequiredService<T>() => ServiceProvider.GetRequiredService<T>();

        public static T GetOptions<T>() where T : class, new() => ServiceProvider.GetRequiredService<IOptions<T>>().Value;

    }
}
