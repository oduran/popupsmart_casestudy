using PSCaseStudy.Datas.Dtos;
using PSCaseStudy.Datas.Entities;

namespace PSCaseStudy.Items.AutoMapper
{
    public class MappingProfile : MapperProfile
    {
        public MappingProfile()
        {
            CreateMap<IntegrationItemsDto, IntegrationItem>();
            CreateMap<ContactDto, Contact>();
            CreateMap<LinkDto, Link>();
        }
    }
}