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

namespace NebulaNS.Api.DataAccess
{
	public abstract class AbstractApplicationDbContext : DbContext
	{
		public Guid UserId { get; private set; }

		public int TenantId { get; private set; } = 1;

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

		public virtual DbSet<Chain> Chains { get; set; }

		public virtual DbSet<ChainStatus> ChainStatuses { get; set; }

		public virtual DbSet<Clasp> Clasps { get; set; }

		public virtual DbSet<Link> Links { get; set; }

		public virtual DbSet<LinkLog> LinkLogs { get; set; }

		public virtual DbSet<LinkStatus> LinkStatuses { get; set; }

		public virtual DbSet<Machine> Machines { get; set; }

		public virtual DbSet<MachineRefTeam> MachineRefTeams { get; set; }

		public virtual DbSet<Organization> Organizations { get; set; }

		public virtual DbSet<Sysdiagram> Sysdiagrams { get; set; }

		public virtual DbSet<Team> Teams { get; set; }

		public virtual DbSet<VersionInfo> VersionInfoes { get; set; }

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
			modelBuilder.Entity<Chain>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Chain>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<ChainStatus>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<ChainStatus>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Clasp>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Clasp>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Link>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Link>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<LinkLog>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<LinkLog>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<LinkStatus>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<LinkStatus>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Machine>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Machine>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<MachineRefTeam>()
			.HasKey(c => new
			{
				c.MachineId,
				c.TeamId,
			});

			modelBuilder.Entity<Organization>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Organization>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Sysdiagram>()
			.HasKey(c => new
			{
				c.DiagramId,
			});

			modelBuilder.Entity<Sysdiagram>()
			.Property("DiagramId")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Team>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Team>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<VersionInfo>()
			.HasKey(c => new
			{
				c.Version,
			});

			var booleanStringConverter = new BoolToStringConverter("N", "Y");
		}
	}

	public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
	{
		public virtual ApplicationDbContext CreateDbContext(string[] args)
		{
			string settingsDirectory = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "Nebula.Api.Web");

			string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

			IConfigurationRoot configuration = new ConfigurationBuilder()
			                                   .SetBasePath(settingsDirectory)
			                                   .AddJsonFile($"appSettings.{environment}.json")
			                                   .AddEnvironmentVariables()
			                                   .Build();

			var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

			var connectionString = configuration.GetConnectionString("ApplicationDbContext");

			builder.UseSqlServer(connectionString);

			return new ApplicationDbContext(builder.Options);
		}
	}
}

/*<Codenesium>
    <Hash>71f9938228a3ec8f76dc86ba39809013</Hash>
</Codenesium>*/