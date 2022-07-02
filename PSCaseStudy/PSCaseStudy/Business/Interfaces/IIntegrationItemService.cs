using Microsoft.AspNetCore.Mvc;
using PSCaseStudy.Items;
using System.Threading.Tasks;

namespace PSCaseStudy.Business.Interfaces
{
    public interface IIntegrationItemService 
    {
        //TODO : Base Crud ekle
        Task<ResultItem> AddItem();
    }
}
