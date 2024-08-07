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
    public class HotelDataLoader : IDataLoader<Hotel>
    {
        public List<Hotel> LoadData(string filePath)
        {
            return JsonLoader.LoadJsonData<Hotel>(filePath);
        }
    }
}
