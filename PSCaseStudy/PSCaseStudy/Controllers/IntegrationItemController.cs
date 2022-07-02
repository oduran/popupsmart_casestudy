using Microsoft.AspNetCore.Mvc;
using PSCaseStudy.Business.Interfaces;
using PSCaseStudy.Controllers.Base;
using PSCaseStudy.Datas.Dtos;
using System.Threading.Tasks;

namespace PSCaseStudy.Controllers
{
    public class IntegrationItemController : ApiControllerBase
    {
        private readonly IIntegrationItemService iis;
        public IntegrationItemController(IIntegrationItemService iis)
        {
            this.iis = iis; 
        }


        [HttpPost]
        public async Task<IActionResult> AddItem([FromForm] IntegrationItemsDto dto)
        {
            var res = await iis.AddItem(dto);
            return View("UserCodeConfirmation");
        }

    }
}
