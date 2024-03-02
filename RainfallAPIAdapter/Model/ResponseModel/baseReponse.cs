using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RainfallAPIAdapter.Model.ResponseModel.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainfallAPIAdapter.Model.ResponseModel
{
    public class baseReponse
    {
        public static object CreateBaseRespone(ObjectResult objectResult, errorsApi errorResponse, string message)
        {

            List<errorsApi.errorDetail> apierrors = new List<errorsApi.errorDetail>();
            errorsApi.errorDetail errorDetail = new errorsApi.errorDetail();

            bool validateResponse = objectResult.GetType() == typeof(StatusCodes);

            if (validateResponse)
            {


            }

            errorDetail.propertyName = constantsVariables.API_ERROR_SERVER_CODE;
            errorDetail.message = constantsVariables.API_ERROR_SERVER_MESSAGE;
            errorResponse.message = message;

            apierrors.Add(errorDetail);
            errorResponse.detail = apierrors;


            //// if (IsMicroLogActivated) Utilities.FileLogging("     : ExecuteGenericApiCall > " + responseType.ToString() + "  >  Response: " + JsonConvert.SerializeObject(returnObject));
            return objectResult;


        }
    }
}
