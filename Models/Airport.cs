using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HolidaySearchOTB.Models
{
    public class Airport
    {
        [JsonProperty("Code")]
        public string Code { get; set; }
        [JsonProperty("airport_name")]
        public string airportName { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
    }
}
