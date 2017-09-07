using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace NebulaNS.Api.WinService
{
    static class Program
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += (object sender, UnhandledExceptionEventArgs e) =>
            {
                _logger.Error(e);
            };

#if (DEBUG)
            _logger.Info("Starting service in debug mode");
            var service = new NebulaService();
            var serviceTask = Task.Run(() => service.ConsoleStart());
            Task.WaitAll(serviceTask);
#else
              _logger.Info("Starting service in release mode");
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new NebulaService()
            };
            ServiceBase.Run(ServicesToRun);se
#endif
        }
    }
}