using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
namespace FermataFishNS.Api.DataAccess
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

		public virtual DbSet<EFAdmin> Admins { get; set; }

		public virtual DbSet<EFFamily> Families { get; set; }

		public virtual DbSet<EFLesson> Lessons { get; set; }

		public virtual DbSet<EFLessonStatus> LessonStatus { get; set; }

		public virtual DbSet<EFLessonXStudent> LessonXStudents { get; set; }

		public virtual DbSet<EFLessonXTeacher> LessonXTeachers { get; set; }

		public virtual DbSet<EFRate> Rates { get; set; }

		public virtual DbSet<EFSpace> Spaces { get; set; }

		public virtual DbSet<EFSpaceFeature> SpaceFeatures { get; set; }

		public virtual DbSet<EFSpaceXSpaceFeature> SpaceXSpaceFeatures { get; set; }

		public virtual DbSet<EFState> States { get; set; }

		public virtual DbSet<EFStudent> Students { get; set; }

		public virtual DbSet<EFStudentXFamily> StudentXFamilies { get; set; }

		public virtual DbSet<EFStudio> Studios { get; set; }

		public virtual DbSet<EFTeacher> Teachers { get; set; }

		public virtual DbSet<EFTeacherSkill> TeacherSkills { get; set; }

		public virtual DbSet<EFTeacherXTeacherSkill> TeacherXTeacherSkills { get; set; }
	}

	public class ApplicationDbContextFactory: IDesignTimeDbContextFactory<ApplicationDbContext>
	{
		public ApplicationDbContext CreateDbContext(string[] args)
		{
			string settingsDirectory = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "FermataFish.Api.Service");

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
    <Hash>be4bf55e4852a64756ec825684429814</Hash>
</Codenesium>*/