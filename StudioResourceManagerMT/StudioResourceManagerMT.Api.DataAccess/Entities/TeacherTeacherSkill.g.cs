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
	}
}

/*<Codenesium>
    <Hash>8561ac0d176ddce2e255d3acbd7a0e9e</Hash>
</Codenesium>*/