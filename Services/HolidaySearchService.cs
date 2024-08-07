﻿using HolidaySearchOTB.Data;
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

        public HolidaySearchService(string departingFrom, string travellingTo, string departureDate, int Duration)
        {
            GetAllValidAirports(departingFrom);
        }
        // Parse user query
        // 1. Find user's departure airport from list of possible airports
        // 2. For every possible airport, run a search to find all flights going to destination on specified date
        // 3. From there, find all local hotels from list of possible local hotels that have the right amount of nights
        // 4. Then, return these so they're accessible under the .Results operator

        public void GetAllValidAirports(string airport)
        {
            AirportDataLoader airportDataLoader = new AirportDataLoader();
            var _airports = airportDataLoader.LoadData(airportDataPath);

            foreach (Airport a in _airports)
            {
                Console.WriteLine($"Airport Name: {a.airportName} Airport Code:{a.Code}");
            }
           // return _airports.ToList();
        }
    }
}
