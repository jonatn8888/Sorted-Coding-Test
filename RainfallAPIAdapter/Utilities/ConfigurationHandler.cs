using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainfallAPIAdapter.Utilities
{
    public class ConfigurationHandler
    {
        public static string GetAppSettingsValue(string key)
        {
            try
            {
                string filePath1 = ConfigurationManager.AppSettings[key];

                string filePath = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).FilePath;
                if (!File.Exists(filePath))
                {
                    throw new ConfigurationErrorsException();
                }

                string text = ConfigurationManager.AppSettings[key];
                if (text != null)
                {
                    return text;
                }

                throw new ConfigurationErrorsException(key);

            }
            catch
            {
                throw;
            }
        }
    }
}
