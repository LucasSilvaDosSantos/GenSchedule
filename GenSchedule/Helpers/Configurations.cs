using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenSchedule.Helpers
{
    public class Configurations
    {
        public int LessonPerDay { get; private set; }
        private Configurations() { }

        private static Configurations _instance;

        public static Configurations GetInstance(int lessonPerDay = 4)
        {
            if (_instance == null)
            {
                _instance = new Configurations();
                _instance.LessonPerDay = lessonPerDay != 0 ? lessonPerDay : 4;
            }
            return _instance;
        }
    }
}
