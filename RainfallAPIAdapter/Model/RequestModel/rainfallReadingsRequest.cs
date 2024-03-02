using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RainfallAPIAdapter.Integration.API;
using RainfallAPIAdapter.Integration.Results;
using RainfallAPIAdapter.Integration.Service;
using RainfallAPIAdapter.Model.ResponseModel;
using RainfallAPIAdapter.Model.ResponseModel.Errors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainfallAPIAdapter.Model.RequestModel
{
    public class rainfallReadingsRequest
    {
        /// <summary>
        /// The id of the reading station
        /// </summary>        
        /// <example>4163</example>
        [FromRoute]
        [DefaultValue("4163")]
        public string stationId { get; set; }

        /// <summary>
        /// The number of readings to return
        /// </summary>
        [FromQuery]
        [DefaultValue("10")]
        public int count { get; set; }

        //Initial Call process of External API
        public async Task<Object> Process(rainfallReadingsRequest rainfallReadingsRequest)
        {
            try
            {
                rainfallReadingResponse rainfallReadingResponse = new rainfallReadingResponse();
                errorsApi errorResponse = new errorsApi();

                if (rainfallReadingsRequest.count == 0)
                {
                    rainfallReadingsRequest.count = 10;
                }

                //Call Rainfall API Cliet
                rainfallAPIDetails rainfallAPIDetails = new rainfallAPIDetails();
                rainfallService rainfallService = new rainfallService(rainfallAPIDetails.GetRainfallHtppCLient());
                //API Results
                defaultFrontEndResponse<List<rainfallReadingsResult>> result = await rainfallService.GetRainfallReadings(rainfallReadingsRequest);
                List<rainfallReadingResponse.rainfallReading> selectedCollection = new List<rainfallReadingResponse.rainfallReading>();

                //Validate API Reponse if readings or error
                bool validateResponse = result.GetType() == typeof(StatusCodes);

                if (result.items == null || result.items.Count == 0)
                {
                    errorResponse.detail = result.detail;
                    errorResponse.message = result.message;
                    return errorResponse;
                }

                //Map Rainfall Readings to new API Response
                selectedCollection = GetAllRainFallReadings(result);
                rainfallReadingResponse.readings = selectedCollection;
                return rainfallReadingResponse;

            }
            catch (Exception)
            {
                throw;
            }
        }

        //Map Rainfall Readings to new reponse
        private List<rainfallReadingResponse.rainfallReading> GetAllRainFallReadings(defaultFrontEndResponse<List<rainfallReadingsResult>> result)
        {
            var listWithoutCol = result.items.Select(x => new rainfallReadingResponse.rainfallReading()
            {
                dateMeasured = x.dateTime,
                amountMeasured = x.value

            })
       .ToList();

            return listWithoutCol;
        }
    }


  
}
