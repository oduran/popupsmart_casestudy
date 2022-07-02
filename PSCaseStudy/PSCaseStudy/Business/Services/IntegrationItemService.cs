using AutoMapper;
using PSCaseStudy.Business.Interfaces;
using PSCaseStudy.Datas;
using PSCaseStudy.Datas.Dtos;
using PSCaseStudy.Datas.Entities;
using PSCaseStudy.Items;
using System.Threading.Tasks;

namespace PSCaseStudy.Business.Services
{
    public class IntegrationItemService : IIntegrationItemService
    {
        private readonly IMapper _mapper;

        public IntegrationItemService(IMapper mapper)
        {
            _mapper = mapper;
        }
    
        public async Task<ResultItem> AddItem(IntegrationItemsDto dto)
        {
            try
            {
                using var dbContext = new AppDbContext();
                var item = _mapper.Map<IntegrationItem>(dto);
                await dbContext.IntegrationItems.AddAsync(item);
                await dbContext.SaveChangesAsync();

                return new ResultItem { IsOk = true, Data = item, Message = "success", StatusCode = System.Net.HttpStatusCode.OK };
            }
            catch (System.Exception ex)
            {
                return new ResultItem { IsOk = false, Data = null, Message = ex.Message, StatusCode = System.Net.HttpStatusCode.InternalServerError };
            }
        }
    }
}
