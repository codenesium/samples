using Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SecureVideoCRMNS.Api.DataAccess;

namespace SecureVideoCRMNS.Api.Web
{
    public class TestStartup : Startup
    {
		private ILoggerFactory loggerFactory;
        
		public TestStartup(IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
			 this.loggerFactory = loggerFactory;

             var builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile($"appSettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables();
                this.Configuration = builder.Build();
        }

        public override DbContextOptions SetupDatabase(bool enableSensitiveDataLogging)
        {
            SqliteConnectionStringBuilder connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = ":memory:" };
            string connectionString = connectionStringBuilder.ToString();
            SqliteConnection connection = new SqliteConnection(connectionString);
            DbContextOptionsBuilder options = new DbContextOptionsBuilder();
            if (enableSensitiveDataLogging)
            {
                options.EnableSensitiveDataLogging();
            }

            options.UseLoggerFactory(this.loggerFactory);
            options.UseSqlite(connection);

            return options.Options;
        }

        public override void MigrateDatabase(ApplicationDbContext context, ILogger<Startup> logger)
        {
            context.Database.OpenConnection();
            context.Database.EnsureCreated();
            IntegrationTestMigration migrator = new IntegrationTestMigration(context);
            migrator.Migrate();
        }
    }
}