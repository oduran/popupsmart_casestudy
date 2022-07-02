using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationService.Items
{
    public class TimerConfigsItem
    {
        public const string Path = "TimerConfigs";
        public string TimerIntervalSecond { get; set; }
        public string TimerWaitSecond { get; set; }
    }
}
