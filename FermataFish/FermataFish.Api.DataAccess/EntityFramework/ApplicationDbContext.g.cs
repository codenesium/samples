using System;
using Microsoft.EntityFrameworkCore;
namespace FermataFishNS.Api.DataAccess
{
	public partial class ApplicationDbContext: DbContext
	{
		public Guid UserId { get; private set; }

		public int TenantId { get; private set; }

		public ApplicationDbContext(DbContextOptions options)
			: base(options)
		{}

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
}

/*<Codenesium>
    <Hash>566caac21b65bb98c84afd24923e706a</Hash>
</Codenesium>*/