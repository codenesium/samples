using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StudioResourceManagerMTNS.Api.DataAccess
{
	[Table("TeacherTeacherSkill", Schema="dbo")]
	public partial class TeacherTeacherSkill : AbstractEntity
	{
		public TeacherTeacherSkill()
		{
		}

		public virtual void SetProperties(
			int teacherId,
			int teacherSkillId)
		{
			this.TeacherId = teacherId;
			this.TeacherSkillId = teacherSkillId;
		}

		[Key]
		[Column("teacherId")]
		public virtual int TeacherId { get; private set; }

		[Key]
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
    <Hash>7b222ff004e5336392a06ff11f7c114d</Hash>
</Codenesium>*/