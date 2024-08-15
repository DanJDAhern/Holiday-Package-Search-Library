using HolidaySearchOTB.Models;
using HolidaySearchOTB.Services;
using HolidaySearchOTB.Data;
using Moq;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using HolidaySearchOTB.Interfaces;

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
            var searchService = new HolidaySearch("Any Airport", "Spain", "2024-08-01", 7);

            // Act
            var result = searchService.GetAllValidAirports("Any Airport");

            // Assert
            Assert.Equal(_airportData.Count, result.Count);
        }

        [Fact]
        public void GetAllValidAirports_Returns_Correct_Airports_For_Any_City_Input()
        {
            // Arrange
            var searchService = new HolidaySearch("Any London", "spain", "2024-08-01", 7);

            // Act
            var result = searchService.GetAllValidAirports("Any London");

            // Assert
            Assert.Equal(2, result.Count); // Heathrow and Gatwick
            Assert.Contains(result, a => a.Code == "LTN");
            Assert.Contains(result, a => a.Code == "LGW");
        }

        [Fact]
        public void GetAllValidAirports_Returns_Correct_Airport_For_Airport_Code()
        {
            // Arrange
            var searchService = new HolidaySearch("LGW", "AGP", "2024-08-01", 7);

            // Act
            var result = searchService.GetAllValidAirports("LGW");

            // Assert
            Assert.Single(result);
            Assert.Equal("LGW", result.First().Code);
        }

        [Fact]
        public void GetAllValidAirports_Returns_Empty_List_When_No_Match()
        {
            // Arrange
            var searchService = new HolidaySearch("Gallifrey Airport", "Hyrule International", "2024-08-01", 7);

            // Act
            var result = searchService.GetAllValidAirports("Gallifrey Airport");

            // Assert
            Assert.Empty(result);
        }
    }
}
