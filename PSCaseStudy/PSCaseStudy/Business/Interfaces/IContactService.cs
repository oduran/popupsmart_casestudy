using Microsoft.AspNetCore.Mvc;
using PSCaseStudy.Datas.Dtos;
using PSCaseStudy.Items;
using System.Threading.Tasks;

namespace PSCaseStudy.Business.Interfaces
{
    public interface IContactService
    {
        //TODO : Base Crud ekle
        Task<ResultItem> AddActiveCampaignItem(int integrationItemId, ActiveCampaignItem dto);
    }
}
