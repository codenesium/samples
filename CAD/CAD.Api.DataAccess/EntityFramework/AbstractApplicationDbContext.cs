using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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

namespace CADNS.Api.DataAccess
{
	public abstract class AbstractApplicationDbContext : IdentityDbContext<AuthUser>
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

		public virtual DbSet<Address> Addresses { get; set; }

		public virtual DbSet<Call> Calls { get; set; }

		public virtual DbSet<CallAssignment> CallAssignments { get; set; }

		public virtual DbSet<CallDisposition> CallDispositions { get; set; }

		public virtual DbSet<CallPerson> CallPersons { get; set; }

		public virtual DbSet<CallStatus> CallStatus { get; set; }

		public virtual DbSet<CallType> CallTypes { get; set; }

		public virtual DbSet<Note> Notes { get; set; }

		public virtual DbSet<OffCapability> OffCapabilities { get; set; }

		public virtual DbSet<Officer> Officers { get; set; }

		public virtual DbSet<OfficerCapabilities> OfficerCapabilities { get; set; }

		public virtual DbSet<Person> People { get; set; }

		public virtual DbSet<PersonType> PersonTypes { get; set; }

		public virtual DbSet<Unit> Units { get; set; }

		public virtual DbSet<UnitDisposition> UnitDispositions { get; set; }

		public virtual DbSet<UnitOfficer> UnitOfficers { get; set; }

		public virtual DbSet<VehCapability> VehCapabilities { get; set; }

		public virtual DbSet<Vehicle> Vehicles { get; set; }

		public virtual DbSet<VehicleCapabilities> VehicleCapabilities { get; set; }

		public virtual DbSet<VehicleOfficer> VehicleOfficers { get; set; }

		/// <summary>
		/// We're overriding SaeChanges to set the tenantId and the IsDeleted columns to make the system work wih multi-tenancy and soft deleted.
		/// We work under the assumption that if you have columns named tenantId then you're multi-tenant and IsDeleted mean you want soft deletes
		/// </summary>
		/// <param name="acceptAllChangesOnSuccess">Commit all changes on success</param>
		/// <param name="cancellationToken">Token that can be passed to hault execution</param>
		/// <returns>int</returns>
		public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
		{
			var entries = this.ChangeTracker.Entries().Where(e => EntityState.Added.HasFlag(e.State) || EntityState.Modified.HasFlag(e.State));
			foreach (var entry in entries)
			{
				var tenantEntity = entry.Properties.FirstOrDefault(x => x.Metadata.Name.ToUpper() == "TENANTID");
				if (tenantEntity != null)
				{
					tenantEntity.CurrentValue = this.TenantId;
				}
			}

			var deletedEntries = this.ChangeTracker.Entries().Where(e => EntityState.Deleted.HasFlag(e.State));
			foreach (var entry in deletedEntries)
			{
				var softDeleteEntity = entry.Properties.FirstOrDefault(x => x.Metadata.Name.ToUpper() == "ISDELETED");
				if (softDeleteEntity != null)
				{
					softDeleteEntity.CurrentValue = true;
					entry.State = EntityState.Modified;
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
			modelBuilder.Entity<Address>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Address>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Call>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Call>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<CallAssignment>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<CallAssignment>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<CallDisposition>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<CallDisposition>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<CallPerson>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<CallPerson>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<CallStatus>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<CallStatus>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<CallType>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<CallType>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Note>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Note>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<OffCapability>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<OffCapability>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Officer>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Officer>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<OfficerCapabilities>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<OfficerCapabilities>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Person>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Person>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<PersonType>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<PersonType>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Unit>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Unit>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<UnitDisposition>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<UnitDisposition>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<UnitOfficer>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<UnitOfficer>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<VehCapability>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<VehCapability>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Vehicle>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Vehicle>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<VehicleCapabilities>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<VehicleCapabilities>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<VehicleOfficer>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<VehicleOfficer>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			var booleanStringConverter = new BoolToStringConverter("N", "Y");
			base.OnModelCreating(modelBuilder);
		}
	}

	// this is needed to make Entity Framework migrations command line tools work
	public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
	{
		public virtual ApplicationDbContext CreateDbContext(string[] args)
		{
			string settingsDirectory = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "CAD.Api.Web");

			string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

			IConfigurationRoot configuration = new ConfigurationBuilder()
			                                   .SetBasePath(settingsDirectory)
			                                   .AddJsonFile($"appSettings.{environment}.json")
			                                   .AddEnvironmentVariables()
			                                   .Build();

			var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

			var connectionString = configuration.GetConnectionString("ApplicationDbContext");

			builder.UseSqlServer(connectionString);

			return new ApplicationDbContext(builder.Options, null);
		}
	}
}

/*<Codenesium>
    <Hash>5bc1ac167d97ec4d912078b03ac31a0e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/