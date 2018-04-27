using System;
using Microsoft.EntityFrameworkCore;
namespace PetShippingNS.Api.DataAccess
{
	public partial class ApplicationDbContext: DbContext
	{
		public Guid UserId { get; private set; }

		public int TenantId { get; private set; }

		public ApplicationDbContext(DbContextOptions options)
			: base(options)
		{}

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
}

/*<Codenesium>
    <Hash>5bf37c573aa345dd176cbd4a6571558d</Hash>
</Codenesium>*/