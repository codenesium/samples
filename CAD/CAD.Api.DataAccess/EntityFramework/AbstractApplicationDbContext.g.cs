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

		public virtual DbSet<Address> Addresses { get; set; }

		public virtual DbSet<Call> Calls { get; set; }

		public virtual DbSet<CallAssignment> CallAssignments { get; set; }

		public virtual DbSet<CallDisposition> CallDispositions { get; set; }

		public virtual DbSet<CallPerson> CallPersons { get; set; }

		public virtual DbSet<CallStatu> CallStatus { get; set; }

		public virtual DbSet<CallType> CallTypes { get; set; }

		public virtual DbSet<Note> Notes { get; set; }

		public virtual DbSet<Officer> Officers { get; set; }

		public virtual DbSet<OfficerCapability> OfficerCapabilities { get; set; }

		public virtual DbSet<OfficerRefCapability> OfficerRefCapabilities { get; set; }

		public virtual DbSet<Person> People { get; set; }

		public virtual DbSet<PersonType> PersonTypes { get; set; }

		public virtual DbSet<Unit> Units { get; set; }

		public virtual DbSet<UnitDisposition> UnitDispositions { get; set; }

		public virtual DbSet<UnitOfficer> UnitOfficers { get; set; }

		public virtual DbSet<Vehicle> Vehicles { get; set; }

		public virtual DbSet<VehicleCapability> VehicleCapabilities { get; set; }

		public virtual DbSet<VehicleOfficer> VehicleOfficers { get; set; }

		public virtual DbSet<VehicleRefCapability> VehicleRefCapabilities { get; set; }

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

			modelBuilder.Entity<CallStatu>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<CallStatu>()
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

			modelBuilder.Entity<Officer>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Officer>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<OfficerCapability>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<OfficerCapability>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<OfficerRefCapability>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<OfficerRefCapability>()
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

			modelBuilder.Entity<Vehicle>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Vehicle>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<VehicleCapability>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<VehicleCapability>()
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

			modelBuilder.Entity<VehicleRefCapability>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<VehicleRefCapability>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			var booleanStringConverter = new BoolToStringConverter("N", "Y");
		}
	}
}

/*<Codenesium>
    <Hash>9f1cc187d6495e5d7f837ab879a50be0</Hash>
</Codenesium>*/