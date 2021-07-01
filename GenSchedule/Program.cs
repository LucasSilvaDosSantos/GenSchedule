﻿using GenSchedule.Entities;
using GenSchedule.Services;
using GenSchedule.Services.Interfaces;
using log4net;
using log4net.Config;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using GenSchedule.Helpers;

namespace GenSchedule
{
    class Program
    {
        private readonly ILog _log;
        private readonly ICsvService _csvHelper;
        private readonly IRandomService _randomHelper;
        private readonly IConfiguration _configuration;

        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.Services.GetRequiredService<Program>().Run(args);
        }

        public Program(ILog log, ICsvService csvHelper, IRandomService randomHelper, IConfiguration configuration)
        {
            _log = log;
            _csvHelper = csvHelper;
            _randomHelper = randomHelper;
            _configuration = configuration;
        }

        public void Run(string[] args)
        {
            var inputPorfessor = GetArg("--professor");
            var inputDisciplines = GetArg("--disciplines");

            var professors = _csvHelper.GetProfessors(inputPorfessor);
            var disciplines = _csvHelper.GetDisciplines(inputDisciplines, professors.ToList());

            var totalLessonsPerWeek = _configuration.GetValue<int>("totalLessonsPerWeek");
            var lessonPerDay = _configuration.GetValue<int>("lessonPerDay");

            var b = DisciplineHelper.MultipleDisciplinesiplines(disciplines.ToList());
            

            string GetArg(string argName)
                => args?.Where(_ => _.Contains(argName)).FirstOrDefault()?.Split('=').Last();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("Properties/log4net.config"));

            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddTransient<Program>();
                    services.AddScoped(factory => LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType));
                    services.AddScoped<ICsvService, CsvService>();
                    services.AddScoped<IRandomService, RandomService>();
                });
        }
    }
}
