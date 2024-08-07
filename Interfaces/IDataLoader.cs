using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearchOTB.Interfaces
{
    public interface IDataLoader<T>
    {
        List<T> LoadData(string filePath);
    }
}
