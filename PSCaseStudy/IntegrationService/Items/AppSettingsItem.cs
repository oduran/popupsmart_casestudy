using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationService.Items
{
    public class AppSettingsItem
    {
        public DbConfigsItem DbConfigsItem { get; set; }
        public TimerConfigsItem TimerConfigsItem { get; set; }
        public ServerConfigsItem ServerConfigsItem { get; set; }
    }
}
