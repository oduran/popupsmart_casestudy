using IntegrationService.Items;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace IntegrationService.Helpers
{
    public class ConfigurationHelper
    {

        private readonly IOptions<DbConfigsItem> config;
        public ConfigurationHelper(IOptions<DbConfigsItem> config)
        {
            this.config = config;
        }

        // appsettings deki db ile alakalı config bilgileri alır 
        public static DbConfigsItem GetDbConfigs()
        {
            AppSettingsItem asi = GetAppSettingsItem("appsettings.json");
            return asi.DbConfigsItem;
        }

        // appsettings deki timer ile alakalı config bilgileri alır 
        public static TimerConfigsItem GetTimerConfigs()
        {

            AppSettingsItem asi = GetAppSettingsItem("appsettings.json");
            return asi.TimerConfigsItem;
        }
        public static ServerConfigsItem GetServerConfigs()
        {

            AppSettingsItem asi = GetAppSettingsItem("appsettings.json");
            return asi.ServerConfigsItem;
        }

        private static AppSettingsItem GetAppSettingsItem(string fileName)
        {
            string jsonString = File.ReadAllText($@"{AppDomain.CurrentDomain.BaseDirectory}\{fileName}");
            return JsonSerializer.Deserialize<AppSettingsItem>(jsonString);
        }
    }
}
