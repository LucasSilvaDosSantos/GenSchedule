using GenSchedule.Entities;
using System.Collections.Generic;

namespace GenSchedule.Services.Interfaces
{
    interface IRandomHelper
    {
        public IEnumerable<T> RandomList<T>(List<T> list);
    }
}
