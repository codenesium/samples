using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StudioResourceManagerNS.Api.DataAccess
{
	[Table("Rate", Schema="dbo")]
	public partial class Rate : AbstractEntity
	{
		public Rate()
		{
		}

		public virtual void SetProperties(
			decimal amountPerMinute,
			int id,
			int teacherId,
			int teacherSkillId)
		{
			this.AmountPerMinute = amountPerMinute;
			this.Id = id;
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
		public virtual Teacher TeacherNavigation { get; private set; }

		public void SetTeacherNavigation(Teacher item)
		{
			this.TeacherNavigation = item;
		}

		[ForeignKey("TeacherSkillId")]
		public virtual TeacherSkill TeacherSkillNavigation { get; private set; }

		public void SetTeacherSkillNavigation(TeacherSkill item)
		{
			this.TeacherSkillNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>4a78387b5f04554efe6abbad7e8eccb3</Hash>
</Codenesium>*/