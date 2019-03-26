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

namespace StudioResourceManagerNS.Api.DataAccess
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

		public virtual DbSet<Admin> Admins { get; set; }

		public virtual DbSet<Event> Events { get; set; }

		public virtual DbSet<EventStatus> EventStatus { get; set; }

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

		public virtual DbSet<User> Users { get; set; }

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
			modelBuilder.Entity<Admin>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Admin>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Event>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Event>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<EventStatus>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<EventStatus>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

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

			modelBuilder.Entity<Family>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Family>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Rate>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Rate>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Space>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Space>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<SpaceFeature>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<SpaceFeature>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<SpaceSpaceFeature>()
			.HasKey(c => new
			{
				c.SpaceId,
				c.SpaceFeatureId,
			});

			modelBuilder.Entity<Student>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Student>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Studio>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Studio>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Teacher>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Teacher>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<TeacherSkill>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<TeacherSkill>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<TeacherTeacherSkill>()
			.HasKey(c => new
			{
				c.TeacherId,
				c.TeacherSkillId,
			});

			modelBuilder.Entity<User>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<User>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			var booleanStringConverter = new BoolToStringConverter("N", "Y");
			modelBuilder.Entity<Admin>().HasQueryFilter(x => !x.IsDeleted);
			modelBuilder.Entity<Event>().HasQueryFilter(x => !x.IsDeleted);
			modelBuilder.Entity<EventStatus>().HasQueryFilter(x => !x.IsDeleted);
			modelBuilder.Entity<EventStudent>().HasQueryFilter(x => !x.IsDeleted);
			modelBuilder.Entity<EventTeacher>().HasQueryFilter(x => !x.IsDeleted);
			modelBuilder.Entity<Family>().HasQueryFilter(x => !x.IsDeleted);
			modelBuilder.Entity<Rate>().HasQueryFilter(x => !x.IsDeleted);
			modelBuilder.Entity<Space>().HasQueryFilter(x => !x.IsDeleted);
			modelBuilder.Entity<SpaceFeature>().HasQueryFilter(x => !x.IsDeleted);
			modelBuilder.Entity<SpaceSpaceFeature>().HasQueryFilter(x => !x.IsDeleted);
			modelBuilder.Entity<Student>().HasQueryFilter(x => !x.IsDeleted);
			modelBuilder.Entity<Studio>().HasQueryFilter(x => !x.IsDeleted);
			modelBuilder.Entity<Teacher>().HasQueryFilter(x => !x.IsDeleted);
			modelBuilder.Entity<TeacherSkill>().HasQueryFilter(x => !x.IsDeleted);
			modelBuilder.Entity<TeacherTeacherSkill>().HasQueryFilter(x => !x.IsDeleted);
			modelBuilder.Entity<User>().HasQueryFilter(x => !x.IsDeleted);
			base.OnModelCreating(modelBuilder);
		}
	}

	// this is needed to make Entity Framework migrations command line tools work
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

			return new ApplicationDbContext(builder.Options, null);
		}
	}
}

/*<Codenesium>
    <Hash>b9fa5acfcc9b51af1b536296a1c3ca79</Hash>
</Codenesium>*/