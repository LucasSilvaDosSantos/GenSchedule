using GenSchedule.Entities;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenSchedule.Helpers
{
    interface ICsvHelper
    {
        public List<Professor> GetProfessors(string path);
    }
}
