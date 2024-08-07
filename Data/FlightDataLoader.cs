using HolidaySearchOTB.Interfaces;
using HolidaySearchOTB.Models;
using HolidaySearchOTB.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearchOTB.Data
{
    public class FlightDataLoader : IDataLoader<Flight>
    {
        public List<Flight> LoadData(string filePath)
        {
            return JsonLoader.LoadJsonData<Flight>(filePath);
        }
    }
}
