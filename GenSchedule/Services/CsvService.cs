using GenSchedule.Entities;
using GenSchedule.Services.Interfaces;
using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GenSchedule.Services
{
    class CsvService : ICsvService
    {
        private ILog _log { get; set; }
        public CsvService(ILog log)
        {
            _log = log;
        }

        public IEnumerable<Professor> GetProfessors(string path)
        {
            var professores = new List<Professor>();

            try
            {
                _log.Info("Getting professors.csv");
                var lines = File.ReadAllLines(path).Select(_ => _.Split(';'));
                foreach (var line in lines)
                {
                    professores.Add(new Professor(line[0].Trim(), line[1].Trim()));
                    _log.Info($"Professor: {professores.Last().Nome}, Id: {professores.Last().Id}");
                }
                return professores;
            }
            catch (Exception e)
            {
                _log.Error(e);
                throw;
            }
        }

        public IEnumerable<Discipline> GetDisciplines(string path, List<Professor> professors)
        {
            var disciplines = new List<Discipline>();
            {
                try
                {
                    _log.Info("Getting disciplines.csv");
                    var lines = File.ReadAllLines(path).Select(_ => _.Split(';'));
                    foreach (var line in lines)
                    {
                        disciplines.Add(new Discipline(
                            line[0].Trim(), 
                            line[1].Trim(), 
                            int.Parse(line[2]), 
                            int.Parse(line[3]), 
                            professors.First(_ => _.Id.Equals(line[4].Trim()))));
                        _log.Info($"Discipline add, Id:{disciplines.Last().Id}, Name:{disciplines.Last().Name}, Professor:{disciplines.Last().Professor.Nome}");
                    }
                    return disciplines;
                }
                catch(Exception e)
                {
                    _log.Error(e);
                    throw;
                }
            }
        }
    }
}
