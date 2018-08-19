using Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ESPIOTNS.Api.DataAccess;

namespace ESPIOTNS.Api.Web
{
    public class TestStartup : Startup
    {
        public TestStartup(IHostingEnvironment env)
        {
             var builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true)
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

            options.UseLoggerFactory(Startup.LoggerFactory);
            options.UseSqlite(connection);

            return options.Options;
        }

        public override void MigrateDatabase(ApplicationDbContext context)
        {
            context.Database.OpenConnection();
            context.Database.EnsureCreated();
            IntegrationTestMigration migrator = new IntegrationTestMigration(context);
            migrator.Migrate();
        }
    }
}