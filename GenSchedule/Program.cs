using GenSchedule.Helpers;
using log4net;
using log4net.Config;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;

namespace GenSchedule
{
    class Program
    {
        private readonly ILog _log;
        private readonly ICsvHelper _csvHelper;
        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.Services.GetRequiredService<Program>().Run(args);
        }

        public Program(ILog log, ICsvHelper csvHelper)
        {
            _log = log;
            _csvHelper = csvHelper;
        }

        public void Run(string[] args)
        {
            var inputPorfessor = GetArg("--professor");
            var professors = _csvHelper.GetProfessors(inputPorfessor);

            int.TryParse(GetArg("--lesson-per-day"), out var lessonPerDay);
            

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
                    services.AddScoped<ICsvHelper, CsvHelper>();
                });
        }
    }
}
