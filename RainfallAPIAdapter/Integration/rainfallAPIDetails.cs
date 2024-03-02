using RainfallAPIAdapter.Integration.RainfallHttpClient;
using RainfallAPIAdapter.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainfallAPIAdapter.Integration
{
    public class rainfallAPIDetails
    {
        public rainfallAPIHttpClient GetRainfallHtppCLient()
        {

            var handler = new HttpClientHandler();
            var client = new HttpClient(handler);

            string baseUrl = ConfigurationHandler.GetAppSettingsValue("RAINFALL_API_BASE_URL");
            client.BaseAddress = new Uri(baseUrl);

            return new rainfallAPIHttpClient(client);
        }
    }
}
