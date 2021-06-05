using GenSchedule.Entities;
using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GenSchedule.Helpers
{
    class CsvHelper : ICsvHelper
    {
        private ILog _log { get; set; }
        public CsvHelper(ILog log)
        {
            _log = log;
        }

        public List<Professor> GetProfessors(string path)
        {
            var professores = new List<Professor>();

            try{
                _log.Info("Getting professors.csv");
                var lines = File.ReadAllLines(path).Select(_ => _.Split(';'));
                foreach (var line in lines)
                {
                    professores.Add(new Professor(line[0], line[1]));
                }
                return professores;
            }
            catch(Exception e)
            {
                _log.Error(e);
                throw;
            }
        }
    }
}
