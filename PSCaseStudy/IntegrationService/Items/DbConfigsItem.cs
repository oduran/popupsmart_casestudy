using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationService.Items
{
    public class DbConfigsItem
    {
        public const string Path = "ConnectionString";
        public string ConnectionString { get; set; }
    }
}
