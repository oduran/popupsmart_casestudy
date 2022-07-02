using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Text;

namespace IntegrationService.Extensions
{
    public static class MappingExtensions
    {
        public static T ToMap<T>(this T value)
        {
            Type myType = value.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            foreach (PropertyInfo prop in props)
            {
                var propValue = prop.GetValue(value, null);

                prop.SetValue(value, Convert.ChangeType(propValue, prop.PropertyType), null);
            }

            string json = JsonConvert.SerializeObject(value);
            var textMessage = JsonConvert.DeserializeObject<T>(json);

            return (T)textMessage;
        }
    }
}
