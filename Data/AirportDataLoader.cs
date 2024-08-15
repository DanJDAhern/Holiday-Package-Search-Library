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
    public class AirportDataLoader : IDataLoader<Airport>
    {
        public virtual List<Airport> LoadData(string filePath)
        {
            return JsonLoader.LoadJsonData<Airport>(filePath);
        }
    }
}
