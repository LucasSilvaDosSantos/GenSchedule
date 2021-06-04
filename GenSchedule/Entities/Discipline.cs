using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenSchedule.Entities
{
    class Discipline
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SessonsPerWeek { get; set; }
        public int Period { get; set; }
        public Professor Professor { get; set; }
    }
}
