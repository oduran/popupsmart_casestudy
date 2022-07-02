using PSCaseStudy.Datas.Entities;

namespace PSCaseStudy.Datas.BuiltinDatas
{
    public class ApplicationBuiltinDatas
    {
        public static Application[] Apps => new[]
        {
            new Application
            {
                Id = 1,
                ApplicationName = "Active Campaign",
            },
            new Application
            {
                Id = 2,
                ApplicationName = "Email Octopus",
            }
        };
    }
}
