using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenSchedule.Entities
{
    class Week
    {
        public int Semester { get; private set; }
        public Day[] Days { get; private set; }
    }
}
