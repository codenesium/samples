using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.DataAccess
{
	public class IntegrationTestMigration
	{
		private ApplicationDbContext context;

		public IntegrationTestMigration(ApplicationDbContext context)
		{
			this.context = context;
		}

		public async void Migrate()
		{
			var adminItem1 = new Admin();
			adminItem1.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1, "A", "A", 1);
			this.context.Admins.Add(adminItem1);

			var eventItem1 = new Event();
			eventItem1.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A");
			this.context.Events.Add(eventItem1);

			var eventStatusItem1 = new EventStatus();
			eventStatusItem1.SetProperties(1, "A");
			this.context.EventStatuses.Add(eventStatusItem1);

			var eventStudentItem1 = new EventStudent();
			eventStudentItem1.SetProperties(1, 1);
			this.context.EventStudents.Add(eventStudentItem1);

			var eventTeacherItem1 = new EventTeacher();
			eventTeacherItem1.SetProperties(1, 1);
			this.context.EventTeachers.Add(eventTeacherItem1);

			var familyItem1 = new Family();
			familyItem1.SetProperties(1, "A", "A", "A", "A", "A");
			this.context.Families.Add(familyItem1);

			var rateItem1 = new Rate();
			rateItem1.SetProperties(1m, 1, 1, 1);
			this.context.Rates.Add(rateItem1);

			var spaceItem1 = new Space();
			spaceItem1.SetProperties("A", 1, "A");
			this.context.Spaces.Add(spaceItem1);

			var spaceFeatureItem1 = new SpaceFeature();
			spaceFeatureItem1.SetProperties(1, "A");
			this.context.SpaceFeatures.Add(spaceFeatureItem1);

			var spaceSpaceFeatureItem1 = new SpaceSpaceFeature();
			spaceSpaceFeatureItem1.SetProperties(1, 1);
			this.context.SpaceSpaceFeatures.Add(spaceSpaceFeatureItem1);

			var studentItem1 = new Student();
			studentItem1.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", true, 1, "A", 1, true, "A", "A", true, 1);
			this.context.Students.Add(studentItem1);

			var studioItem1 = new Studio();
			studioItem1.SetProperties("A", "A", "A", 1, "A", "A", "A", "A");
			this.context.Studios.Add(studioItem1);

			var teacherItem1 = new Teacher();
			teacherItem1.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1, "A", "A", 1);
			this.context.Teachers.Add(teacherItem1);

			var teacherSkillItem1 = new TeacherSkill();
			teacherSkillItem1.SetProperties(1, "A");
			this.context.TeacherSkills.Add(teacherSkillItem1);

			var teacherTeacherSkillItem1 = new TeacherTeacherSkill();
			teacherTeacherSkillItem1.SetProperties(1, 1);
			this.context.TeacherTeacherSkills.Add(teacherTeacherSkillItem1);

			var tenantItem1 = new Tenant();
			tenantItem1.SetProperties(1, "A");
			this.context.Tenants.Add(tenantItem1);

			var userItem1 = new User();
			userItem1.SetProperties(1, "A", "A");
			this.context.Users.Add(userItem1);

			var vEventItem1 = new VEvent();
			vEventItem1.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"));
			this.context.VEvents.Add(vEventItem1);

			await this.context.SaveChangesAsync();
		}
	}
}

/*<Codenesium>
    <Hash>d1251dfb9d580729fa07f2b0a5c77a16</Hash>
</Codenesium>*/