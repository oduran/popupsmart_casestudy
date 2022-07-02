using PSCaseStudy.Datas.Enums;

namespace PSCaseStudy.Datas.Models
{
    public class IntegrationItemsModel : BaseModel
    {
        public string ApiUrl { get; set; }
        public string ApiKey { get; set; }
        public IntegrationApplicationEnum IntegrationApplication { get; set; }
    }
}
