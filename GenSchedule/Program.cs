using GenSchedule.Helpers;
using System;
using System.Linq;

namespace GenSchedule
{
    class Program
    {
        static void Main(string[] args)
        {
            int.TryParse(GetArg("--lesson-per-day"), out var lessonPerDay);

            string GetArg(string argName)
                => args?.Where(_ => _.Contains(argName)).FirstOrDefault()?.Split('=').Last();
        }
    }
}
