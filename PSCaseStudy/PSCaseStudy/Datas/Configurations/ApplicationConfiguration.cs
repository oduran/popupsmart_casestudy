using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSCaseStudy.Datas.BuiltinDatas;
using PSCaseStudy.Datas.Entities;

namespace PSCaseStudy.Datas.Configurations
{
    public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.HasData(ApplicationBuiltinDatas.Apps);
        }
    }
}
