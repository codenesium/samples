using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
namespace NebulaNS.Api.DataAccess
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

		public virtual DbSet<EFChain> Chains { get; set; }

		public virtual DbSet<EFChainStatus> ChainStatus { get; set; }

		public virtual DbSet<EFClasp> Clasps { get; set; }

		public virtual DbSet<EFLink> Links { get; set; }

		public virtual DbSet<EFLinkLog> LinkLogs { get; set; }

		public virtual DbSet<EFLinkStatus> LinkStatus { get; set; }

		public virtual DbSet<EFMachine> Machines { get; set; }

		public virtual DbSet<EFMachineRefTeam> MachineRefTeams { get; set; }

		public virtual DbSet<EFOrganization> Organizations { get; set; }

		public virtual DbSet<EFTeam> Teams { get; set; }

		public virtual DbSet<EFVersionInfo> VersionInfoes { get; set; }
	}

	public class ApplicationDbContextFactory: IDesignTimeDbContextFactory<ApplicationDbContext>
	{
		public ApplicationDbContext CreateDbContext(string[] args)
		{
			string settingsDirectory = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "Nebula.Api.Service");

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
    <Hash>77229439acd23f39ae710e3327eed4ea</Hash>
</Codenesium>*/