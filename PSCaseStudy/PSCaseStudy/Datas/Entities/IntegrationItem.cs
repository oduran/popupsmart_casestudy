using PSCaseStudy.Datas.Enums;

namespace PSCaseStudy.Datas.Entities
{
    public class IntegrationItem : BaseEntity
    {
        public string ApiUrl{ get; set; }
        public string ApiKey{ get; set; }
        public IntegrationStatusEnum Status { get; set; }

        public IntegrationApplicationEnum IntegrationApplication{ get; set; }
    }
}
