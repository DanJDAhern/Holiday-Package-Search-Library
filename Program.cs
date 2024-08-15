using HolidaySearchOTB.Services;

namespace HolidaySearchOTB
{
    public class Program
    {
        static void Main(string[] args)
        {
            var holidaySearch = new HolidaySearch("Any Airport", "Gran Canaria", "2022/11/10", 14);

            Console.WriteLine($"Total Price: £{holidaySearch.Results.First().TotalPrice} \n" +
                              $"Best Flight ID: {holidaySearch.Results.First().Flight.Id} \n" +
                              $"Flight Departing From: {holidaySearch.Results.First().Flight.From}\n" +
                              $"Flight Going To: {holidaySearch.Results.First().Flight.To}\n" +
                              $"Flight Price: {holidaySearch.Results.First().Flight.Price}\n" +
                              $"Hotel ID: {holidaySearch.Results.First().Hotel.Id}\n" +
                              $"Hotel Name: {holidaySearch.Results.First().Hotel.Name}\n" +
                              $"Hotel Price: {holidaySearch.Results.First().Hotel.PricePerNight}");
        }
    }
}
