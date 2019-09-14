using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.DataAccess
{
	public abstract class AbstractIntegrationTestMigration
	{
		protected ApplicationDbContext Context { get; private set; }

		public AbstractIntegrationTestMigration(ApplicationDbContext context)
		{
			this.Context = context;
		}

		public virtual async Task Migrate()
		{
			var adminItem1 = new Admin();
			adminItem1.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", 1);
			this.Context.Admins.Add(adminItem1);

			var eventItem1 = new Event();
			eventItem1.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A");
			this.Context.Events.Add(eventItem1);

			var eventStatusItem1 = new EventStatus();
			eventStatusItem1.SetProperties(1, "A");
			this.Context.EventStatus.Add(eventStatusItem1);

			var eventStudentItem1 = new EventStudent();
			eventStudentItem1.SetProperties(1, 1, 1);
			this.Context.EventStudents.Add(eventStudentItem1);

			var eventTeacherItem1 = new EventTeacher();
			eventTeacherItem1.SetProperties(1, 1, 1);
			this.Context.EventTeachers.Add(eventTeacherItem1);

			var familyItem1 = new Family();
			familyItem1.SetProperties(1, "A", "A", "A", "A", "A");
			this.Context.Families.Add(familyItem1);

			var rateItem1 = new Rate();
			rateItem1.SetProperties(1, 1m, 1, 1);
			this.Context.Rates.Add(rateItem1);

			var spaceItem1 = new Space();
			spaceItem1.SetProperties(1, "A", "A");
			this.Context.Spaces.Add(spaceItem1);

			var spaceFeatureItem1 = new SpaceFeature();
			spaceFeatureItem1.SetProperties(1, "A");
			this.Context.SpaceFeatures.Add(spaceFeatureItem1);

			var spaceSpaceFeatureItem1 = new SpaceSpaceFeature();
			spaceSpaceFeatureItem1.SetProperties(1, 1, 1);
			this.Context.SpaceSpaceFeatures.Add(spaceSpaceFeatureItem1);

			var studentItem1 = new Student();
			studentItem1.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", true, 1, "A", true, "A", "A", true, 1);
			this.Context.Students.Add(studentItem1);

			var studioItem1 = new Studio();
			studioItem1.SetProperties(1, "A", "A", "A", "A", "A", "A", "A");
			this.Context.Studios.Add(studioItem1);

			var teacherItem1 = new Teacher();
			teacherItem1.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", 1);
			this.Context.Teachers.Add(teacherItem1);

			var teacherSkillItem1 = new TeacherSkill();
			teacherSkillItem1.SetProperties(1, "A");
			this.Context.TeacherSkills.Add(teacherSkillItem1);

			var teacherTeacherSkillItem1 = new TeacherTeacherSkill();
			teacherTeacherSkillItem1.SetProperties(1, 1, 1);
			this.Context.TeacherTeacherSkills.Add(teacherTeacherSkillItem1);

			var userItem1 = new User();
			userItem1.SetProperties(1, "A", "A");
			this.Context.Users.Add(userItem1);

			await this.Context.SaveChangesAsync();
		}
	}
}

/*<Codenesium>
    <Hash>da2135e96f9cb4a722ee4f30a69cbe95</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/