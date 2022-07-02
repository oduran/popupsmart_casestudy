using PSCaseStudy.Datas.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSCaseStudy.Datas.Dtos
{
    public class ActiveCampaignItem
    {
        public List<ContactDto> contacts { get; set; }
        public int IntegrationItemId { get; set; }
    }
}
