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

namespace StudioResourceManagerNS.Api.DataAccess
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

		public virtual DbSet<Admin> Admins { get; set; }

		public virtual DbSet<Event> Events { get; set; }

		public virtual DbSet<EventStatus> EventStatuses { get; set; }

		public virtual DbSet<EventStudent> EventStudents { get; set; }

		public virtual DbSet<EventTeacher> EventTeachers { get; set; }

		public virtual DbSet<Family> Families { get; set; }

		public virtual DbSet<Rate> Rates { get; set; }

		public virtual DbSet<Space> Spaces { get; set; }

		public virtual DbSet<SpaceFeature> SpaceFeatures { get; set; }

		public virtual DbSet<SpaceSpaceFeature> SpaceSpaceFeatures { get; set; }

		public virtual DbSet<Student> Students { get; set; }

		public virtual DbSet<Studio> Studios { get; set; }

		public virtual DbSet<Teacher> Teachers { get; set; }

		public virtual DbSet<TeacherSkill> TeacherSkills { get; set; }

		public virtual DbSet<TeacherTeacherSkill> TeacherTeacherSkills { get; set; }

		public virtual DbSet<Tenant> Tenants { get; set; }

		public virtual DbSet<User> Users { get; set; }

		public virtual DbSet<VEvent> VEvents { get; set; }

		/// <summary>
		/// We're overriding SaveChanges because SQLite does not support database computed columns.
		/// ROWGUID is a very common type of column and it does not work with SQLite.
		/// To work around this limitation we detect ROWGUID columns here and set the value.
		/// On SQL Server the database would set the value.
		/// </summary>
		/// <param name="acceptAllChangesOnSuccess"></param>
		/// <param name="cancellationToken"></param>
		/// <returns>int</returns>
		public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
		{
			var entries = this.ChangeTracker.Entries().Where(e => EntityState.Added.HasFlag(e.State));
			if (entries.Any())
			{
				foreach (var createdEntry in entries)
				{
					var entity = createdEntry.Properties.FirstOrDefault(x => x.Metadata.Name.ToUpper() == "ROWGUID");
					if (entity != null && entity.Metadata.ClrType == typeof(Guid) && (Guid)entity.CurrentValue != default(Guid))
					{
						entity.CurrentValue = Guid.NewGuid();
					}

					var tenantEntity = createdEntry.Properties.FirstOrDefault(x => x.Metadata.Name.ToUpper() == "TENANTID");
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
			modelBuilder.Entity<EventStudent>()
			.HasKey(c => new
			{
				c.EventId,
				c.StudentId,
			});
			modelBuilder.Entity<EventTeacher>()
			.HasKey(c => new
			{
				c.EventId,
				c.TeacherId,
			});
			modelBuilder.Entity<SpaceSpaceFeature>()
			.HasKey(c => new
			{
				c.SpaceId,
				c.SpaceFeatureId,
			});
			modelBuilder.Entity<TeacherTeacherSkill>()
			.HasKey(c => new
			{
				c.TeacherId,
				c.TeacherSkillId,
			});

			var booleanStringConverter = new BoolToStringConverter("N", "Y");
		}
	}

	public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
	{
		public virtual ApplicationDbContext CreateDbContext(string[] args)
		{
			string settingsDirectory = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "StudioResourceManager.Api.Web");

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
    <Hash>94ff0bc437667071838b4625f5c0d274</Hash>
</Codenesium>*/