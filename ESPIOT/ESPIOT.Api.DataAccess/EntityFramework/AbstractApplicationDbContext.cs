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

namespace ESPIOTNS.Api.DataAccess
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

		public virtual DbSet<Device> Devices { get; set; }

		public virtual DbSet<DeviceAction> DeviceActions { get; set; }

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
			modelBuilder.Entity<Device>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Device>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<DeviceAction>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<DeviceAction>()
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
			string settingsDirectory = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "ESPIOT.Api.Web");

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
    <Hash>ad3571b697a19ebd7ea18ffd196175e0</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/