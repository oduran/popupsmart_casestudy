using System;
using System.Collections.Generic;

namespace PSCaseStudy.Datas.Entities
{
    public class Contact : BaseEntity
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IntegrationItemId{ get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
