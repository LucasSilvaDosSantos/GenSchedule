using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenSchedule.Entities
{
    class Day
    {
        public DayOfWeek DayOfWeek { get; set; }
        public Day[] Days { get; private set; }
    }
}
