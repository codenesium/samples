using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
namespace PetShippingNS.Api.DataAccess
{
	public partial class ApplicationDbContext: DbContext
	{
		public Guid UserId { get; private set; }

		public int TenantId { get; private set; }

		public ApplicationDbContext(DbContextOptions options)
			: base(options)
		{}

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			base.OnConfiguring(options);
		}

		public void SetUserId(Guid userId)
		{
			if(userId == default (Guid))
			{
				throw new ArgumentException("UserId cannot be a default value");
			}
			this.UserId = userId;
		}

		public void SetTenantId(int tenantId)
		{
			if(tenantId <= 0)
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
	}

	public class ApplicationDbContextFactory: IDesignTimeDbContextFactory<ApplicationDbContext>
	{
		public ApplicationDbContext CreateDbContext(string[] args)
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
    <Hash>8b5338990a0f572a48c73811e1631438</Hash>
</Codenesium>*/