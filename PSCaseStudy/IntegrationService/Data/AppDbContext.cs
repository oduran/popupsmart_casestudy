using IntegrationService.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PSCaseStudy.Datas.Entities;
using PSCaseStudy.Items;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Text;

namespace IntegrationService.Data
{
    public class AppDbContext : PSCaseStudy.Datas.AppDbContext
    {
        public AppDbContext() { }

        public AppDbContext(DbContextOptions<PSCaseStudy.Datas.AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

                var connectionStrings = ConfigurationHelper.GetDbConfigs().ConnectionString;
                optionsBuilder.UseNpgsql(connectionStrings);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
