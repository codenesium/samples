using Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Web
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

        public override ApplicationDbContext SetupDatabase(IServiceCollection services)
        {
            SqliteConnectionStringBuilder connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = ":memory:" };
            string connectionString = connectionStringBuilder.ToString();
            SqliteConnection connection = new SqliteConnection(connectionString);
            DbContextOptionsBuilder options = new DbContextOptionsBuilder();
		    options.UseLoggerFactory(Startup.LoggerFactory);
            options.UseSqlite(connection);
            ApplicationDbContext context = new ApplicationDbContext(options.Options);
			return context;
        }

		public override void MigrateDatabase(ApplicationDbContext context)
        {
			 context.Database.OpenConnection();
			 context.Database.EnsureCreated();
        }
    }
}