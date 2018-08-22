using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FermataFishNS.Api.DataAccess
{
	public class IntegrationTestMigration
	{
		private ApplicationDbContext context;

		public IntegrationTestMigration(ApplicationDbContext context)
		{
			this.context = context;
		}

		public void Migrate()
		{
			var adminItem1 = new Admin();
			adminItem1.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", 1);
			this.context.Admins.Add(adminItem1);

			var familyItem1 = new Family();
			familyItem1.SetProperties(1, "A", "A", "A", "A", "A", 1);
			this.context.Families.Add(familyItem1);

			var lessonItem1 = new Lesson();
			lessonItem1.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1);
			this.context.Lessons.Add(lessonItem1);

			var lessonStatusItem1 = new LessonStatus();
			lessonStatusItem1.SetProperties(1, "A", 1);
			this.context.LessonStatuses.Add(lessonStatusItem1);

			var lessonXStudentItem1 = new LessonXStudent();
			lessonXStudentItem1.SetProperties(1, 1, 1, 1);
			this.context.LessonXStudents.Add(lessonXStudentItem1);

			var lessonXTeacherItem1 = new LessonXTeacher();
			lessonXTeacherItem1.SetProperties(1, 1, 1);
			this.context.LessonXTeachers.Add(lessonXTeacherItem1);

			var rateItem1 = new Rate();
			rateItem1.SetProperties(1, 1m, 1, 1, 1);
			this.context.Rates.Add(rateItem1);

			var spaceItem1 = new Space();
			spaceItem1.SetProperties(1, "A", "A", 1);
			this.context.Spaces.Add(spaceItem1);

			var spaceFeatureItem1 = new SpaceFeature();
			spaceFeatureItem1.SetProperties(1, "A", 1);
			this.context.SpaceFeatures.Add(spaceFeatureItem1);

			var spaceXSpaceFeatureItem1 = new SpaceXSpaceFeature();
			spaceXSpaceFeatureItem1.SetProperties(1, 1, 1, 1);
			this.context.SpaceXSpaceFeatures.Add(spaceXSpaceFeatureItem1);

			var studentItem1 = new Student();
			studentItem1.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", true, 1, "A", true, "A", "A", true, 1);
			this.context.Students.Add(studentItem1);

			var studentXFamilyItem1 = new StudentXFamily();
			studentXFamilyItem1.SetProperties(1, 1, 1, 1);
			this.context.StudentXFamilies.Add(studentXFamilyItem1);

			var studioItem1 = new Studio();
			studioItem1.SetProperties(1, "A", "A", "A", "A", "A", "A", "A");
			this.context.Studios.Add(studioItem1);

			var teacherItem1 = new Teacher();
			teacherItem1.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", 1);
			this.context.Teachers.Add(teacherItem1);

			var teacherSkillItem1 = new TeacherSkill();
			teacherSkillItem1.SetProperties(1, "A", 1);
			this.context.TeacherSkills.Add(teacherSkillItem1);

			var teacherXTeacherSkillItem1 = new TeacherXTeacherSkill();
			teacherXTeacherSkillItem1.SetProperties(1, 1, 1, 1);
			this.context.TeacherXTeacherSkills.Add(teacherXTeacherSkillItem1);

			this.context.SaveChanges();
		}
	}
}

/*<Codenesium>
    <Hash>5e6415a8cd756c86324aa4760baf86fd</Hash>
</Codenesium>*/