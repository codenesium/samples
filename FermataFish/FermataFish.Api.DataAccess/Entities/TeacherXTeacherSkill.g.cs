using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace FermataFishNS.Api.DataAccess
{
	[Table("TeacherXTeacherSkill", Schema="dbo")]
	public partial class TeacherXTeacherSkill : AbstractEntity
	{
		public TeacherXTeacherSkill()
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
		public int Id { get; private set; }

		[Column("teacherId")]
		public int TeacherId { get; private set; }

		[Column("teacherSkillId")]
		public int TeacherSkillId { get; private set; }

		[ForeignKey("TeacherId")]
		public virtual Teacher TeacherNavigation { get; private set; }

		[ForeignKey("TeacherSkillId")]
		public virtual TeacherSkill TeacherSkillNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ccb502db8bd30ed9d0d59ca73832571e</Hash>
</Codenesium>*/