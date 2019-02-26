using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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
			this.UserId = userId;
		}

		public virtual void SetTenantId(int tenantId)
		{
			this.TenantId = tenantId;
		}

		public virtual DbSet<Airline> Airlines { get; set; }

		public virtual DbSet<AirTransport> AirTransports { get; set; }

		public virtual DbSet<Breed> Breeds { get; set; }

		public virtual DbSet<Country> Countries { get; set; }

		public virtual DbSet<CountryRequirement> CountryRequirements { get; set; }

		public virtual DbSet<Customer> Customers { get; set; }

		public virtual DbSet<CustomerCommunication> CustomerCommunications { get; set; }

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
		/// ROWGUID is a very common type of column and it does not work with SQLite.
		/// To work around this limitation we detect ROWGUID columns here and set the value.
		/// On SQL Server the database would set the value.
		/// </summary>
		/// <param name="acceptAllChangesOnSuccess">Commit all changes on success</param>
		/// <param name="cancellationToken">Token that can be passed to hault execution</param>
		/// <returns>int</returns>
		public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
		{
			var entries = this.ChangeTracker.Entries().Where(e => EntityState.Added.HasFlag(e.State) || EntityState.Modified.HasFlag(e.State));
			if (entries.Any())
			{
				foreach (var entry in entries.Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
				{
					var tenantEntity = entry.Properties.FirstOrDefault(x => x.Metadata.Name.ToUpper() == "TENANTID");
					if (tenantEntity != null)
					{
						tenantEntity.CurrentValue = this.TenantId;
					}
				}
			}

			return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			base.OnConfiguring(options);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Airline>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Airline>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<AirTransport>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<AirTransport>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Breed>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Breed>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Country>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Country>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<CountryRequirement>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<CountryRequirement>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Customer>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<CustomerCommunication>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Destination>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Destination>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Employee>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Employee>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Handler>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Handler>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<HandlerPipelineStep>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<HandlerPipelineStep>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<OtherTransport>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<OtherTransport>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Pet>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Pet>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Pipeline>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Pipeline>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<PipelineStatus>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<PipelineStatus>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<PipelineStep>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<PipelineStep>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<PipelineStepDestination>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<PipelineStepDestination>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<PipelineStepNote>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<PipelineStepNote>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<PipelineStepStatus>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<PipelineStepStatus>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<PipelineStepStepRequirement>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<PipelineStepStepRequirement>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Sale>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Sale>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Species>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Species>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			var booleanStringConverter = new BoolToStringConverter("N", "Y");
		}
	}
}

/*<Codenesium>
    <Hash>abcfedfe668734cfca20f299330903b4</Hash>
</Codenesium>*/