using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationService.Helpers
{
    public class Singleton<T> where T : class, new()
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                if (instance == null)
                    instance = Activator.CreateInstance<T>(); // new T();

                return instance;
            }
        }
    }
}
