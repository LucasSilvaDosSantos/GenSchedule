using GenSchedule.Entities;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenSchedule.Services.Interfaces
{
    interface ICsvService
    {
        public IEnumerable<Professor> GetProfessors(string path);
        public IEnumerable<Discipline> GetDisciplines(string path, List<Professor> professors);
    }
}
