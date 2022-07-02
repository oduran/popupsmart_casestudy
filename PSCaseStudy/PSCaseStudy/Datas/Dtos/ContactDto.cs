using PSCaseStudy.Datas.Entities;
using PSCaseStudy.Datas.Enums;

namespace PSCaseStudy.Datas.Dtos
{
    public class ContactDto
    {
        public string id { get; set; }
        public string email { get; set; }
        public string firstname { get; set; }
        public string lastName { get; set; }
        public string? deleted { get; set; }
        public string? cdate { get; set; }
        public string? updated_timestamp { get; set; }
        public LinkDto links { get; set; }
    }
}
