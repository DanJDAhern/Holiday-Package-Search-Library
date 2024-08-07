using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace HolidaySearchOTB.Utilities
{
    public class JsonLoader
    {
        public static List<T> LoadJsonData<T>(string filePath)
        {
            // Read in Json text and then return it deserialised
            var jsonData = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<T>>(jsonData);
        }
    }
}
