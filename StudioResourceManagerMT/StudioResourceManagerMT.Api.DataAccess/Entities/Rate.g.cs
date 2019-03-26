using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StudioResourceManagerMTNS.Api.DataAccess
{
	[Table("Rate", Schema="dbo")]
	public partial class Rate : AbstractEntity
	{
		public Rate()
		{
		}

		public virtual void SetProperties(
			int id,
			decimal amountPerMinute,
			int teacherId,
			int teacherSkillId)
		{
			this.Id = id;
			this.AmountPerMinute = amountPerMinute;
			this.TeacherId = teacherId;
			this.TeacherSkillId = teacherSkillId;
		}

		[Column("amountPerMinute")]
		public virtual decimal AmountPerMinute { get; private set; }

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
    <Hash>8b81bd92a8f603733a46ac1f0a1c8d0c</Hash>
</Codenesium>*/