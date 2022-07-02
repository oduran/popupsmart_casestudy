namespace PSCaseStudy.Items
{
    public class ConnectionStringsItem
    {
        public const string Path = "ConnectionStrings";
        public string PostgreDbContext { get; set; }
        public string IntegrationDbContext { get; set; }
        public string LogDbContext { get; set; }
    }
}
