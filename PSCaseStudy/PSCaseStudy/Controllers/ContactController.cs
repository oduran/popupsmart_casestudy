using Microsoft.AspNetCore.Mvc;
using PSCaseStudy.Business.Interfaces;
using PSCaseStudy.Controllers.Base;
using PSCaseStudy.Datas.Dtos;
using System.Threading.Tasks;

namespace PSCaseStudy.Controllers
{
    public class ContactController : ApiControllerBase
    {
        private readonly IContactService _cs;
        public ContactController(IContactService cs)
        {
            this._cs = cs;
        }


        [HttpPost("{integrationItemId}")]
        public async Task<IActionResult> AddActiveCampaignItem(int integrationItemId, ActiveCampaignItem dto)
        {
            var res = await _cs.AddActiveCampaignItem(integrationItemId,dto);
            return View("UserCodeConfirmation");
        }

    }
}
