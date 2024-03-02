using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainfallAPIAdapter.Model.ResponseModel.Errors
{
    public class errorsApi
    {
        public string message { get; set; }
        public List<errorDetail> detail { get; set; }


        public class errorDetail
        {
            /// <summary>
            /// Details of invalid request property
            /// </summary>  
            public string propertyName { get; set; }

            public string message { get; set; }

        }


    }
}
