using Newtonsoft.Json;
using RainfallAPIAdapter.Model.ResponseModel.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainfallAPIAdapter.Integration.Results 
{
    public class rainfallReadingsResult : errorsApi
    {
        public List<Item> items { get; set; }

        public string ReturnCode { get; set; }

        public string ReturnMsg { get; set; }

        public class Item
        {
            [JsonProperty("@id")]
            public string id { get; set; }
            public DateTime dateTime { get; set; }
            public string measure { get; set; }
            public double value { get; set; }
        }

        public class Meta
        {
            public string publisher { get; set; }
            public string licence { get; set; }
            public string documentation { get; set; }
            public string version { get; set; }
            public string comment { get; set; }
            public List<string> hasFormat { get; set; }
            public int limit { get; set; }
        }

        public class Root
        {
            [JsonProperty("@context")]
            public string context { get; set; }
            public Meta meta { get; set; }
            public List<Item> items { get; set; }
        }

    }
}
