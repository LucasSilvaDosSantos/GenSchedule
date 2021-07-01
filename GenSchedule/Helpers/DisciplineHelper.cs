using GenSchedule.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenSchedule.Helpers
{
    public static class DisciplineHelper
    {
        public static IEnumerable<Discipline> MultipleDisciplinesiplines(List<Discipline> disciplines)
        {
            var outList = new List<Discipline>();
            foreach(var discipline in disciplines)
            {
                var aux = 1;
                while(discipline.LessonsPerWeek >= aux)
                {
                    outList.Add(discipline);
                    aux++;
                }
            }

            return outList;
        }
    }
}
