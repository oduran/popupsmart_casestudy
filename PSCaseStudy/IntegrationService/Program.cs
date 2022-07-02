using IntegrationService.Data;
using IntegrationService.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using PSCaseStudy.Extensions;
using PSCaseStudy.Items;
using System;

namespace IntegrationService
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new HostBuilder();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var configSettings = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json")
              .Build();

            var asd = ConfigurationHelper.GetDbConfigs().ConnectionString;
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddServiceTool();
                    services.AddDbContext<AppDbContext>(options =>
                    options.UseNpgsql(asd));
                    services.AddHostedService<Worker>();
                }).ConfigureAppConfiguration(config =>
                {
                    config.AddConfiguration(configSettings);
                });
        }
    }
}
