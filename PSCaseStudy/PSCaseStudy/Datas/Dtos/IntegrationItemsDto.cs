using PSCaseStudy.Datas.Enums;

namespace PSCaseStudy.Datas.Dtos
{
    public class IntegrationItemsDto
    {
        public string ApiUrl { get; set; }
        public string ApiKey { get; set; }
        public IntegrationApplicationEnum IntegrationApplication { get; set; }
    }
}
