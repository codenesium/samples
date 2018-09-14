using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;

namespace PetShippingNS.Api.DataAccess
{
	public abstract class AbstractApplicationDbContext : DbContext
	{
		public Guid UserId { get; private set; }

		public int TenantId { get; private set; }

		public AbstractApplicationDbContext(DbContextOptions options)
			: base(options)
		{
		}

		public virtual void SetUserId(Guid userId)
		{
			if (userId == default(Guid))
			{
				throw new ArgumentException("UserId cannot be a default value");
			}

			this.UserId = userId;
		}

		public virtual void SetTenantId(int tenantId)
		{
			if (tenantId <= 0)
			{
				throw new ArgumentException("TenantId must be greater than 0");
			}

			this.TenantId = tenantId;
		}

		public virtual DbSet<Airline> Airlines { get; set; }

		public virtual DbSet<AirTransport> AirTransports { get; set; }

		public virtual DbSet<Breed> Breeds { get; set; }

		public virtual DbSet<Client> Clients { get; set; }

		public virtual DbSet<ClientCommunication> ClientCommunications { get; set; }

		public virtual DbSet<Country> Countries { get; set; }

		public virtual DbSet<CountryRequirement> CountryRequirements { get; set; }

		public virtual DbSet<Destination> Destinations { get; set; }

		public virtual DbSet<Employee> Employees { get; set; }

		public virtual DbSet<Handler> Handlers { get; set; }

		public virtual DbSet<HandlerPipelineStep> HandlerPipelineSteps { get; set; }

		public virtual DbSet<OtherTransport> OtherTransports { get; set; }

		public virtual DbSet<Pet> Pets { get; set; }

		public virtual DbSet<Pipeline> Pipelines { get; set; }

		public virtual DbSet<PipelineStatus> PipelineStatus { get; set; }

		public virtual DbSet<PipelineStep> PipelineSteps { get; set; }

		public virtual DbSet<PipelineStepDestination> PipelineStepDestinations { get; set; }

		public virtual DbSet<PipelineStepNote> PipelineStepNotes { get; set; }

		public virtual DbSet<PipelineStepStatus> PipelineStepStatus { get; set; }

		public virtual DbSet<PipelineStepStepRequirement> PipelineStepStepRequirements { get; set; }

		public virtual DbSet<Sale> Sales { get; set; }

		public virtual DbSet<Species> Species { get; set; }

		/// <summary>
		/// We're overriding SaveChanges because SQLite does not support database computed columns.
		/// RowVersion is a very common type of column and it does not work with SQLite.
		/// To work around this limitation we detect RowVersion columns here and set the value.
		/// On SQL Server the database would set the value.
		/// </summary>
		/// <returns>int</returns>
		public override int SaveChanges()
		{
			var entries = this.ChangeTracker.Entries().Where(e => EntityState.Added.HasFlag(e.State));
			if (entries.Any())
			{
				foreach (var createdEntry in entries)
				{
					var entity = createdEntry.Properties.FirstOrDefault(x => x.Metadata.Name.ToUpper() == "ROWGUID");
					if (entity != null && entity.Metadata.ClrType == typeof(Guid) && (Guid)entity.CurrentValue != default(Guid))
					{
						entity.CurrentValue = Guid.NewGuid();
					}
				}
			}

			return base.SaveChanges();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			base.OnConfiguring(options);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			var booleanStringConverter = new BoolToStringConverter("N", "Y");
		}
	}

	public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
	{
		public virtual ApplicationDbContext CreateDbContext(string[] args)
		{
			string settingsDirectory = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "PetShipping.Api.Web");

			string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

			IConfigurationRoot configuration = new ConfigurationBuilder()
			                                   .SetBasePath(settingsDirectory)
			                                   .AddJsonFile($"appsettings.{environment}.json")
			                                   .Build();

			var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

			var connectionString = configuration.GetConnectionString("ApplicationDbContext");

			builder.UseSqlServer(connectionString);

			return new ApplicationDbContext(builder.Options);
		}
	}
}

/*<Codenesium>
    <Hash>dcf82558ff091a59ebb85c80d55e4da1</Hash>
</Codenesium>*/