using HolidaySearchOTB.Services;

namespace HolidaySearchOTB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HolidaySearchService holiday = new HolidaySearchService("Any London", "Any Spain", "2023-06-15", 7);
        }
    }
}
