using Newtonsoft.Json;
using RainfallAPIAdapter.Integration.Results;
using RainfallAPIAdapter.Model.ResponseModel.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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


        internal async Task<defaultFrontEndResponse<T>> HttpGetAsync<T>(string uri)
        {
            HttpResponseMessage httpResponseMessage = await _client.GetAsync(uri ?? "");
            defaultFrontEndResponse<T> defaultFrontEndResponse = new defaultFrontEndResponse<T>();
            List<errorsApi.errorDetail> apierrors = new List<errorsApi.errorDetail>();
            errorsApi.errorDetail errorDetail = new errorsApi.errorDetail();
            errorDetail.propertyName = httpResponseMessage.StatusCode.ToString();

            if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
            {
                rainfallReadingsResult RainfallReadingsResult = JsonConvert.DeserializeObject<rainfallReadingsResult>(await httpResponseMessage.Content.ReadAsStringAsync());
               
                defaultFrontEndResponse.items = RainfallReadingsResult.items;

                if (defaultFrontEndResponse.items.Count == 0)
                {
                    errorDetail.propertyName = "404";
                    errorDetail.message = "No readings found for the specified stationId";
                    defaultFrontEndResponse.message = "Not Found.";
                }

            }
            else if (httpResponseMessage.StatusCode == HttpStatusCode.Unauthorized)
            {
                errorDetail.propertyName = "002";
                errorDetail.message = "Unauthorized";
                defaultFrontEndResponse.message = "Unauthorized.";
            }
            else if (httpResponseMessage.StatusCode == HttpStatusCode.NotFound)
            {
                errorDetail.propertyName = "404";
                errorDetail.message = "No readings found for the specified stationId";
                defaultFrontEndResponse.message = "Not Found.";
            }
            else if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
            {
                errorDetail.propertyName = "400";
                errorDetail.message = "Invalid request.";
                defaultFrontEndResponse.message = "Bad Request.";
            }
            else
            {
                errorDetail.propertyName = "500";
                errorDetail.message = "Internal server error";
                defaultFrontEndResponse.message = "Internal server error: " + (int)httpResponseMessage.StatusCode + "-" + httpResponseMessage.StatusCode;
            }

            if (defaultFrontEndResponse.message != null)
            {
                apierrors.Add(errorDetail);
                defaultFrontEndResponse.detail = apierrors;
            }

            return defaultFrontEndResponse;
        }


    }
}
