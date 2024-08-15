using HolidaySearchOTB.Models;
using HolidaySearchOTB.Services;
using HolidaySearchOTB.Data;
using Moq;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace HolidaySearchTests
{
    public class HolidaySearchTests
    {
        private readonly Mock<AirportDataLoader> _mockAirportDataLoader;
        private readonly List<Airport> _airportData;

        public HolidaySearchTests()
        {
            // Setup mock airport data
            _airportData = new List<Airport>
            {
                new Airport { airportName = "Manchester", City = "Manchester", Country = "United Kingdom", Code = "MAN" },
                new Airport { airportName = "Tenerife South", City = "Tenerife", Country = "Spain", Code = "TFS" },
                new Airport { airportName = "Malaga-Costa del Sol", City = "Malaga", Country = "Spain", Code = "AGP" },
                new Airport { airportName = "Palma de Mallorca", City = "Mallorca", Country = "Spain", Code = "PMI" },
                new Airport { airportName = "London Luton", City = "London", Country = "UK", Code = "LTN" },
                new Airport { airportName = "London Gatwick", City = "London", Country = "UK", Code = "LGW" },
                new Airport { airportName = "Gran Canaria", City = "Gran Canaria", Country = "Spain", Code = "LPA" }
            };

            _mockAirportDataLoader = new Mock<AirportDataLoader>();
            _mockAirportDataLoader.Setup(loader => loader.LoadData(It.IsAny<string>())).Returns(_airportData);
        }

        [Fact]
        public void GetAllValidAirports_Returns_All_Airports_When_Any_Airport_Is_Input()
        {
            // Arrange
            var searchService = new HolidaySearch("any airport", "Spain", "2024-08-01", 7);

            // Act
            var result = searchService.GetAllValidAirports("any airport");

            // Assert
            Assert.Equal(_airportData.Count, result.Count);
        }

        
    }
}
