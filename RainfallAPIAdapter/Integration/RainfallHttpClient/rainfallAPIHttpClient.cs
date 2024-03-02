using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainfallAPIAdapter.Integration.RainfallHttpClient
{
    public class rainfallAPIHttpClient
    {

        private readonly HttpClient _client;

        public rainfallAPIHttpClient(HttpClient client)
        {
            _client = client;
        }
    }
}
