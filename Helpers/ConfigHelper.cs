using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public class ConfigHelper
    {
        public static string GetConfigurationFile(string key)
        {
            string configValue = ConfigurationManager.AppSettings[key].ToString();
            return configValue;
        }
    }
}
