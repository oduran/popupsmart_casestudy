using PSCaseStudy.Datas.Enums;

namespace PSCaseStudy.Datas.Entities
{
    public class Link : BaseEntity
    {
        public string BounceLogs { get; set; }
        public string ContactAutomations { get; set; }
        public string ContactData { get; set; }
        public string ContactGoals { get; set; }
        public string ContactLists { get; set; }
        public string ContactTags { get; set; }
        public string FieldValues { get; set; }
        public int ContactId { get; set; }

    }
}
