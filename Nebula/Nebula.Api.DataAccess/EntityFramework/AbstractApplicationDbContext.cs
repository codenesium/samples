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

namespace NebulaNS.Api.DataAccess
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

		public virtual DbSet<Chain> Chains { get; set; }

		public virtual DbSet<ChainStatus> ChainStatus { get; set; }

		public virtual DbSet<Clasp> Clasps { get; set; }

		public virtual DbSet<Link> Links { get; set; }

		public virtual DbSet<LinkLog> LinkLogs { get; set; }

		public virtual DbSet<LinkStatus> LinkStatus { get; set; }

		public virtual DbSet<Machine> Machines { get; set; }

		public virtual DbSet<MachineRefTeam> MachineRefTeams { get; set; }

		public virtual DbSet<Organization> Organizations { get; set; }

		public virtual DbSet<Sysdiagrams> Sysdiagrams { get; set; }

		public virtual DbSet<Team> Teams { get; set; }

		public virtual DbSet<VersionInfo> VersionInfoes { get; set; }

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
				c.Id,
			});

			modelBuilder.Entity<MachineRefTeam>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Organization>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Organization>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Sysdiagrams>()
			.HasKey(c => new
			{
				c.DiagramId,
			});

			modelBuilder.Entity<Sysdiagrams>()
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
			base.OnModelCreating(modelBuilder);
		}
	}

	// this is needed to make Entity Framework migrations command line tools work
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

			return new ApplicationDbContext(builder.Options, null);
		}
	}
}

/*<Codenesium>
    <Hash>b42a7eabc91301725c654141940fc334</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/