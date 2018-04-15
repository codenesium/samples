using Microsoft.EntityFrameworkCore;
namespace FermataFishNS.Api.DataAccess
{
	public partial class ApplicationDbContext: DbContext
	{
		public ApplicationDbContext(DbContextOptions options)
			: base(options)
		{}
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
    <Hash>54adb4cc15e183cef916006b0076b588</Hash>
</Codenesium>*/