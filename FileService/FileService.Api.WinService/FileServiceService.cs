using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.ServiceProcess;
using System.Threading;
using Codenesium.DataConversionExtensions;
using FluentMigrator;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Initialization;
using FluentMigrator.Runner.Processors;
using FluentMigrator.Runner.Processors.SqlServer;
using Microsoft.Owin.Hosting;
using NLog;
using FileServiceNS.Api.Service;

namespace FileServiceNS.Api.WinService
{
    public partial class FileServiceService : ServiceBase
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        private IDisposable _apiServer;
        public FileServiceService()
        {
            InitializeComponent();
        }

        public void ConsoleStart()
        {
            _logger.Trace("");
            OnStart(null);
            Thread.Sleep(Timeout.Infinite);
        }

        protected override void OnStart(string[] args)
        {
            _logger.Info("Starting service");
            try
            {
                string thisServiceBaseAddress = ConfigurationManager.AppSettings["ThisServiceBaseAddress"].ToString();

                if (String.IsNullOrWhiteSpace(thisServiceBaseAddress))
                {
                    throw new ArgumentException($"ThisServiceBaseAddress is not set in the app.config");
                }

                _logger.Info($"ThisServiceBaseAddress={thisServiceBaseAddress}");
				_logger.Info($"Service Located at {thisServiceBaseAddress.Replace("*","localhost")}/swagger");
             
                 if (RunMigrations())
                 {
                    this._apiServer = WebApp.Start<Startup>(thisServiceBaseAddress);
                    _logger.Info("Service Started");
                 }
                 else
                 {
                    throw new Exception("Unable to run migrations. The service will now terminate.");
                 }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                this.DisposeServers();
            }
        }

        protected override void OnStop()
        {
            _logger.Info("Stopping service");
            this.DisposeServers();
            _logger.Info("Service stopped");
        }

        private void DisposeServers()
        {
            if (this._apiServer != null)
            {
                this._apiServer.Dispose();
            }
        }

        private bool RunMigrations()
        {
            try
            {
                _logger.Info("Running Migrations");
                bool runMigrationsOnStartup = ConfigurationManager.AppSettings["RunMigrationsOnStartup"].ToString().ToBoolean();
                if(!runMigrationsOnStartup)
                {
                    _logger.Info("Migrations disabled in app.config");
                    return true;
                }

                string migrationAssemblyPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "migrations", "DatabaseMigrations.dll");

                if (!File.Exists(migrationAssemblyPath))
                {
                    _logger.Error("Migration dll not found. Skipping migrations.");
                    return false;
                }

                string connectionString = ConfigurationManager.ConnectionStrings["FileService.Api.WinServiceDBConnection"].ToString();

                Announcer announcer = new TextWriterAnnouncer(s => System.Diagnostics.Debug.WriteLine(s));
                announcer.ShowSql = true;

                System.Reflection.Assembly assembly = Assembly.LoadFile(migrationAssemblyPath);
                IRunnerContext migrationContext = new RunnerContext(announcer);

                var options = new ProcessorOptions
                {
                    PreviewOnly = false,  // set to true to see the SQL
                    Timeout = 60
                };
                var factory = new SqlServer2014ProcessorFactory();
                using (IMigrationProcessor processor = factory.Create(connectionString, announcer, options))
                {
                    var runner = new MigrationRunner(assembly, migrationContext, processor);
                    runner.MigrateUp(true);
                }
                _logger.Info("Migration Successful");
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex,"Error migrating database");
                return false;
            }
        }
    }
}