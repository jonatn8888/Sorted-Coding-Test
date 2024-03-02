using Microsoft.AspNetCore.Mvc;
using RainfallAPIAdapter.Model.RequestModel;
using RainfallAPIAdapter.Model.ResponseModel;
using RainfallAPIAdapter.Model.ResponseModel.Errors;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;


namespace Sorted_Coding_Test.Controllers
{

    [ApiController]
    [SwaggerTag("Operations relating to rainfall")]
    public class rainfallController : Controller
    {

        //Status Code Response and descriptions
        [SwaggerResponse(StatusCodes.Status200OK, "A list of rainfall readings successfully retrieved", typeof(rainfallReadingResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request", Type = typeof(errorResponse))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No readings found for the specified stationId", Type = typeof(errorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", Type = typeof(errorResponse))]

        [Produces("application/json")]
        [SwaggerOperation("Get rainfall readings by station Id", "Retrieve the latest readings for the specified stationId")]
        [HttpGet("/rainfall/id/{stationId}/readings", Name = nameof(getrainfall))]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IActionResult> getrainfall([FromQuery] rainfallReadingsRequest rainfallReadingsRequest)
        {
            return View();
        }
    }
}
