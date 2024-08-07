using HolidaySearchOTB.Services;

namespace HolidaySearchOTB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HolidaySearchService holiday = new HolidaySearchService("Manchester", "Malaga", "2023/07/01", 7);
        }
    }
}
