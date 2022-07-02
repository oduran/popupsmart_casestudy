using Microsoft.EntityFrameworkCore;
using PSCaseStudy.Datas.Configurations;
using PSCaseStudy.Datas.Entities;
using PSCaseStudy.IoC;
using PSCaseStudy.Items;

namespace PSCaseStudy.Datas
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        public DbSet<IntegrationItem> IntegrationItems { get; set; }
        public DbSet<Application> Applications{ get; set; }
        public DbSet<Link> Links{ get; set; }
        public DbSet<Contact> Contacts{ get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionStrings = ServiceTool.GetOptions<ConnectionStringsItem>();
                optionsBuilder.UseNpgsql(connectionStrings.PostgreDbContext);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApplicationConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
