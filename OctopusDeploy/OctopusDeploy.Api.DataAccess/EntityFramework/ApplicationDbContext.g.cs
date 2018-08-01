using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial class ApplicationDbContext : DbContext
	{
		public Guid UserId { get; private set; }

		public int TenantId { get; private set; }

		public ApplicationDbContext(DbContextOptions options)
			: base(options)
		{
		}

		public void SetUserId(Guid userId)
		{
			if (userId == default(Guid))
			{
				throw new ArgumentException("UserId cannot be a default value");
			}

			this.UserId = userId;
		}

		public void SetTenantId(int tenantId)
		{
			if (tenantId <= 0)
			{
				throw new ArgumentException("TenantId must be greater than 0");
			}

			this.TenantId = tenantId;
		}

		public virtual DbSet<Account> Accounts { get; set; }

		public virtual DbSet<ActionTemplate> ActionTemplates { get; set; }

		public virtual DbSet<ActionTemplateVersion> ActionTemplateVersions { get; set; }

		public virtual DbSet<ApiKey> ApiKeys { get; set; }

		public virtual DbSet<Artifact> Artifacts { get; set; }

		public virtual DbSet<Certificate> Certificates { get; set; }

		public virtual DbSet<Channel> Channels { get; set; }

		public virtual DbSet<CommunityActionTemplate> CommunityActionTemplates { get; set; }

		public virtual DbSet<Configuration> Configurations { get; set; }

		public virtual DbSet<DashboardConfiguration> DashboardConfigurations { get; set; }

		public virtual DbSet<Deployment> Deployments { get; set; }

		public virtual DbSet<DeploymentEnvironment> DeploymentEnvironments { get; set; }

		public virtual DbSet<DeploymentHistory> DeploymentHistories { get; set; }

		public virtual DbSet<DeploymentProcess> DeploymentProcesses { get; set; }

		public virtual DbSet<DeploymentRelatedMachine> DeploymentRelatedMachines { get; set; }

		public virtual DbSet<Event> Events { get; set; }

		public virtual DbSet<EventRelatedDocument> EventRelatedDocuments { get; set; }

		public virtual DbSet<ExtensionConfiguration> ExtensionConfigurations { get; set; }

		public virtual DbSet<Feed> Feeds { get; set; }

		public virtual DbSet<Interruption> Interruptions { get; set; }

		public virtual DbSet<Invitation> Invitations { get; set; }

		public virtual DbSet<KeyAllocation> KeyAllocations { get; set; }

		public virtual DbSet<LibraryVariableSet> LibraryVariableSets { get; set; }

		public virtual DbSet<Lifecycle> Lifecycles { get; set; }

		public virtual DbSet<Machine> Machines { get; set; }

		public virtual DbSet<MachinePolicy> MachinePolicies { get; set; }

		public virtual DbSet<Mutex> Mutexes { get; set; }

		public virtual DbSet<NuGetPackage> NuGetPackages { get; set; }

		public virtual DbSet<OctopusServerNode> OctopusServerNodes { get; set; }

		public virtual DbSet<Project> Projects { get; set; }

		public virtual DbSet<ProjectGroup> ProjectGroups { get; set; }

		public virtual DbSet<ProjectTrigger> ProjectTriggers { get; set; }

		public virtual DbSet<Proxy> Proxies { get; set; }

		public virtual DbSet<Release> Releases { get; set; }

		public virtual DbSet<SchemaVersions> SchemaVersions { get; set; }

		public virtual DbSet<ServerTask> ServerTasks { get; set; }

		public virtual DbSet<Subscription> Subscriptions { get; set; }

		public virtual DbSet<TagSet> TagSets { get; set; }

		public virtual DbSet<Team> Teams { get; set; }

		public virtual DbSet<Tenant> Tenants { get; set; }

		public virtual DbSet<TenantVariable> TenantVariables { get; set; }

		public virtual DbSet<User> Users { get; set; }

		public virtual DbSet<UserRole> UserRoles { get; set; }

		public virtual DbSet<VariableSet> VariableSets { get; set; }

		public virtual DbSet<Worker> Workers { get; set; }

		public virtual DbSet<WorkerPool> WorkerPools { get; set; }

		public virtual DbSet<WorkerTaskLease> WorkerTaskLeases { get; set; }

		/// <summary>
		/// We're overriding SaveChanges because SQLite does not support database computed columns.
		/// RowVersion is a very common type of column and it does not work with SQLite.
		/// To work around this limitation we detect RowVersion columns here and set the value.
		/// On SQL Server the database would set the value.
		/// </summary>
		/// <returns>int</returns>
		public override int SaveChanges()
		{
			var entries = this.ChangeTracker.Entries().Where(e => EntityState.Added.HasFlag(e.State));
			if (entries.Any())
			{
				foreach (var createdEntry in entries)
				{
					var entity = createdEntry.Properties.FirstOrDefault(x => x.Metadata.Name.ToUpper() == "ROWVERSION");
					if (entity != null && entity.Metadata.ClrType == typeof(Guid) && (Guid)entity.CurrentValue != default(Guid))
					{
						entity.CurrentValue = Guid.NewGuid();
					}
				}
			}

			return base.SaveChanges();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			base.OnConfiguring(options);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			var booleanStringConverter = new BoolToStringConverter("N", "Y");
		}
	}

	public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
	{
		public ApplicationDbContext CreateDbContext(string[] args)
		{
			string settingsDirectory = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "OctopusDeploy.Api.Web");

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
    <Hash>c42c6f9c862009b202ecb3e02fdb3daf</Hash>
</Codenesium>*/