using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StudioResourceManagerNS.Api.DataAccess
{
	[Table("TeacherTeacherSkill", Schema="dbo")]
	public partial class TeacherTeacherSkill : AbstractEntity
	{
		public TeacherTeacherSkill()
		{
		}

		public virtual void SetProperties(
			int id,
			int teacherId,
			int teacherSkillId)
		{
			this.Id = id;
			this.TeacherId = teacherId;
			this.TeacherSkillId = teacherSkillId;
		}

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[Column("teacherId")]
		public virtual int TeacherId { get; private set; }

		[Column("teacherSkillId")]
		public virtual int TeacherSkillId { get; private set; }

		[ForeignKey("TeacherId")]
		public virtual Teacher TeacherIdNavigation { get; private set; }

		public void SetTeacherIdNavigation(Teacher item)
		{
			this.TeacherIdNavigation = item;
		}

		[ForeignKey("TeacherSkillId")]
		public virtual TeacherSkill TeacherSkillIdNavigation { get; private set; }

		public void SetTeacherSkillIdNavigation(TeacherSkill item)
		{
			this.TeacherSkillIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>285c9b124e86853c1a41f782d6080fc3</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/