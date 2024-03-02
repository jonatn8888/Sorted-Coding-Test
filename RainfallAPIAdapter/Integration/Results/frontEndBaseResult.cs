using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainfallAPIAdapter.Integration.Results
{
    public class frontEndBaseResult : rainfallReadingsResult
    {
        public string ReturnCode { get; set; }

        public string ReturnMsg { get; set; }
    }
}
