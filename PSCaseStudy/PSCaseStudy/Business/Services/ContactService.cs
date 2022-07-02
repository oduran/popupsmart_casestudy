using AutoMapper;
using PSCaseStudy.Business.Interfaces;
using PSCaseStudy.Datas;
using PSCaseStudy.Datas.Dtos;
using PSCaseStudy.Datas.Entities;
using PSCaseStudy.Items;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PSCaseStudy.Business.Services
{
    public class ContactService : IContactService
    {
        private readonly IMapper _mapper;

        public ContactService(IMapper mapper)
        {
            _mapper = mapper;
        }
    
        public async Task<ResultItem> AddActiveCampaignItem(int integrationItemId, ActiveCampaignItem dto)
        {
            try
            {
                List<Contact> cList = _mapper.Map<List<Contact>>(dto.contacts);
                cList.ForEach(x => x.IntegrationItemId = integrationItemId);
                List<Link> lList = new List<Link>();
                foreach (var item in dto.contacts)
                {
                    Link link = _mapper.Map<Link>(item.links);
                    link.ContactId = Int32.Parse(item.id);
                    lList.Add(link);
                }
                using var dbContext = new AppDbContext();
                await dbContext.Contacts.AddRangeAsync(cList);
                await dbContext.Links.AddRangeAsync(lList);
                await dbContext.SaveChangesAsync();

                return new ResultItem { IsOk = true, Data = dto, Message = "success", StatusCode = System.Net.HttpStatusCode.OK };
            }
            catch (System.Exception ex)
            {
                return new ResultItem { IsOk = false, Data = null, Message = ex.Message, StatusCode = System.Net.HttpStatusCode.InternalServerError };
            }
        }
    }
}
