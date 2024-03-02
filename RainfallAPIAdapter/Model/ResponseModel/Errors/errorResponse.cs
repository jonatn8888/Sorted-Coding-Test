using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainfallAPIAdapter.Model.ResponseModel.Errors
{
    /// <summary>
    /// An error object returned for failed requests
    /// </summary>  
    public class errorResponse
    {
        public errorsApi error { get; set; }

        public errorResponse()
        { }

    }
}
