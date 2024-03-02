using RainfallAPIAdapter.Integration.RainfallHttpClient;
using RainfallAPIAdapter.Integration.Results;
using RainfallAPIAdapter.Model.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainfallAPIAdapter.Integration.Service
{
    public class rainfallService
    {
        private readonly rainfallAPIHttpClient _client;

        public rainfallService(rainfallAPIHttpClient client)
        {
            _client = client;
        }

        public async Task<defaultFrontEndResponse<List<rainfallReadingsResult>>> GetRainfallReadings(rainfallReadingsRequest rainfallReadingsRequest)
        {
            //https://environment.data.gov.uk/flood-monitoring/id/stations/52203/readings?_sorted&_limit=100
            string uri = "/flood-monitoring/id/stations/" + rainfallReadingsRequest.stationId + "/readings?_sorted&_limit=" + rainfallReadingsRequest.count;
            return await _client.HttpGetAsync<List<rainfallReadingsResult>>(uri);
        }
    }
}
