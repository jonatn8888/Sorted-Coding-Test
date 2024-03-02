using Microsoft.AspNetCore.Mvc;
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
    }
}
