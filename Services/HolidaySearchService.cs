using HolidaySearchOTB.Data;
using HolidaySearchOTB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearchOTB.Services
{
    public class HolidaySearchService
    {
        // Load in flight and hotel data
        private readonly List<Flight> _flights;
        private readonly List<Hotel> _hotels;
        private readonly List<Airport> _airports;

        private readonly string airportDataPath = "Data\\Json\\Airports.json";
        private readonly string flightDataPath = "Data\\Json\\Flights.json";
        private readonly string hotelDataPath = "Data\\Json\\Hotels.json";
        public HolidaySearchService(string departingFrom, string travellingTo, string departureDate, int Duration)
        {
            var departureAirports = GetAllValidAirports(departingFrom);
            var arrivalAirports = GetAllValidAirports(travellingTo);

            GetAllMatchingFlights(departureAirports, arrivalAirports);
        }
        // Parse user query
        // 1. Find user's departure airport from list of possible airports
        // 2. For every possible airport, run a search to find all flights going to destination on specified date
        // 3. From there, find all local hotels from list of possible local hotels that have the right amount of nights
        // 4. Then, return these so they're accessible under the .Results operator

        public List<Airport> GetAllValidAirports(string inputAirport)
        {
            AirportDataLoader airportDataLoader = new AirportDataLoader();
            var _airports = airportDataLoader.LoadData(airportDataPath);

            

            var matchingAirports = _airports.Where(a => (a.airportName == inputAirport)
                                                  || inputAirport.Contains(a.airportName)
                                                  || inputAirport.Contains(a.City)
                                                  || inputAirport.Contains(a.Country)
                                                  || inputAirport.Contains(a.Code)
                                                  ).ToList();

            foreach (Airport a in matchingAirports)
            {
                Console.WriteLine($"Airport Name: {a.airportName} Airport Code:{a.Code}");
            }

            return matchingAirports;
           // return _airports.ToList();
        }

        public List<Flight> GetAllMatchingFlights(List<Airport> departureAirports, List<Airport> arrivalAirports, string departureDate)
        {
            FlightDataLoader flightDataLoader = new FlightDataLoader();
            var _flights = flightDataLoader.LoadData(flightDataPath);

            var matchingFlights = new List<Flight>();

            foreach (var departureAirport in departureAirports)
            {
                var flightsFromAirport = _flights.Where(f => f.From == departureAirport.Code.ToString());
                foreach (var arrivalAirport in arrivalAirports)
                {
                    var flightsToAirport = flightsFromAirport.Where(f => f.To == arrivalAirport.Code.ToString());
                    matchingFlights.AddRange(flightsToAirport);
                }
            }

            foreach (var flight in matchingFlights) {
                Console.WriteLine($"Flight option: {flight.Id}");
            }

            return matchingFlights;
        }
    }
}
