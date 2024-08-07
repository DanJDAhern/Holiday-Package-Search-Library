using HolidaySearchOTB.Services;

namespace HolidaySearchOTB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HolidaySearchService holiday = new HolidaySearchService("London", "Test", "23/23/2333", 7);
        }
    }
}
