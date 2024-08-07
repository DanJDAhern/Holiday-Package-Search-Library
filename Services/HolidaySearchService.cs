using HolidaySearchOTB.Data;
using HolidaySearchOTB.Models;
using HolidaySearchOTB.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            var validFlights = GetAllMatchingFlights(departureAirports, arrivalAirports, departureDate);
            var matchingHotels = GetAllMatchingHotels(arrivalAirports, validFlights);
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

            // Try to parse the inputted departure date into a DateTime format

            DateTime parsedDepartureDate;
            if (!DateTime.TryParse(departureDate, out parsedDepartureDate))
            {
                throw new ArgumentException("Invalid departure date format. Please make sure you're inputting YYYY-MM-DD.");
            }

            var matchingFlights = new List<Flight>();

            foreach (var departureAirport in departureAirports)
            {
                var flightsFromAirport = _flights.Where(f => f.From == departureAirport.Code);

                foreach (var arrivalAirport in arrivalAirports)
                {
                    var flightsToAirport = flightsFromAirport .Where(f => f.To == arrivalAirport.Code 
                                                               && f.DepartureDate.Date == parsedDepartureDate.Date);

                    matchingFlights.AddRange(flightsToAirport);
                }
            }

            foreach (var flight in matchingFlights) {
                Console.WriteLine($"Flight option: {flight.Id}");
            }

            return matchingFlights;
        }

        public List<Hotel> GetAllMatchingHotels(List<Airport> arrivalAirports, List<Flight> arrivalFlights)
        {
            HotelDataLoader hotelDataLoader = new HotelDataLoader();
            var hotels = hotelDataLoader.LoadData(hotelDataPath);

            // Create a set of unique departure dates from the flights
            var flightDepartureDates = arrivalFlights.Select(f => f.DepartureDate.Date).Distinct().ToList();

            var matchingHotels = new List<Hotel>();


            foreach (var arrivalAirport in arrivalAirports)
            {
                var validHotels = hotels.Where(hotel =>
                    hotel.LocalAirports.Contains(arrivalAirport.Code) &&
                    flightDepartureDates.Contains(hotel.ArrivalDate.Date)
                ).ToList();

                matchingHotels.AddRange(validHotels);
            }

            foreach (var hotel in matchingHotels)
            {
                Console.WriteLine($"Hotel Name: {hotel.Name}, Code: {hotel.Id}");
            }

            return matchingHotels;
        }


    }
}
