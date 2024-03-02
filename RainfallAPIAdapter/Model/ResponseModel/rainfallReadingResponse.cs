using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainfallAPIAdapter.Model.ResponseModel
{
    public class rainfallReadingResponse
    {
        public List<rainfallReading> readings { get; set; }

        /// <summary>
        /// Details of a rainfall reading
        /// </summary> 
        public class rainfallReading
        {
            public DateTime dateMeasured { get; set; }

            public double amountMeasured { get; set; }
        }

    }
}
