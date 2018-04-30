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

		public virtual DbSet<EFAirline> Airlines { get; set; }

		public virtual DbSet<EFAirTransport> AirTransports { get; set; }

		public virtual DbSet<EFBreed> Breeds { get; set; }

		public virtual DbSet<EFClient> Clients { get; set; }

		public virtual DbSet<EFClientCommunication> ClientCommunications { get; set; }

		public virtual DbSet<EFCountry> Countries { get; set; }

		public virtual DbSet<EFCountryRequirement> CountryRequirements { get; set; }

		public virtual DbSet<EFDestination> Destinations { get; set; }

		public virtual DbSet<EFEmployee> Employees { get; set; }

		public virtual DbSet<EFHandler> Handlers { get; set; }

		public virtual DbSet<EFHandlerPipelineStep> HandlerPipelineSteps { get; set; }

		public virtual DbSet<EFOtherTransport> OtherTransports { get; set; }

		public virtual DbSet<EFPet> Pets { get; set; }

		public virtual DbSet<EFPipeline> Pipelines { get; set; }

		public virtual DbSet<EFPipelineStatus> PipelineStatus { get; set; }

		public virtual DbSet<EFPipelineStep> PipelineSteps { get; set; }

		public virtual DbSet<EFPipelineStepDestination> PipelineStepDestinations { get; set; }

		public virtual DbSet<EFPipelineStepNote> PipelineStepNotes { get; set; }

		public virtual DbSet<EFPipelineStepStatus> PipelineStepStatus { get; set; }

		public virtual DbSet<EFPipelineStepStepRequirement> PipelineStepStepRequirements { get; set; }

		public virtual DbSet<EFSale> Sales { get; set; }

		public virtual DbSet<EFSpecies> Species { get; set; }
	}

	public class ApplicationDbContextFactory: IDesignTimeDbContextFactory<ApplicationDbContext>
	{
		public ApplicationDbContext CreateDbContext(string[] args)
		{
			string settingsDirectory = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "PetShipping.Api.Service");

			IConfigurationRoot configuration = new ConfigurationBuilder()
			                                   .SetBasePath(settingsDirectory)
			                                   .AddJsonFile("appsettings.json")
			                                   .Build();

			var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

			var connectionString = configuration.GetConnectionString("ApplicationDbContext");

			builder.UseSqlServer(connectionString);

			return new ApplicationDbContext(builder.Options);
		}
	}
}

/*<Codenesium>
    <Hash>30162e8926d93ddfe440e0dd517655a4</Hash>
</Codenesium>*/