using GenSchedule.Entities;
using GenSchedule.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GenSchedule.Services
{
    class RandomService : IRandomHelper
    {
        public IEnumerable<T> RandomList<T>(List<T> list)
        {
            var random = new Random(DateTime.Now.ToString().GetHashCode());
            var listOut = new List<T>();
            while (list.Any())
            {
                int index = random.Next(0, list.Count);
                listOut.Add(list.ElementAt(index));
                list.RemoveAt(index);
            }
            return listOut;
        }
    }
}
