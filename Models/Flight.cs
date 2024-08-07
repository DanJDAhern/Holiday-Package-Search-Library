using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearchOTB.Models
{
    public class Flight
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("airline")]
        public string Airline { get; set; }
        [JsonProperty("from")]
        public string From { get; set; }
        [JsonProperty("to")]
        public string To { get; set; }
        [JsonProperty("price")]
        public decimal Price { get; set; }
        [JsonProperty("departure_date")]
        public DateTime DepartureDate { get; set; }
    }
}
