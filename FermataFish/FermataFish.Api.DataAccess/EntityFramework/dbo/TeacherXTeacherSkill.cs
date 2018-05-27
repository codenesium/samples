using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
	[Table("TeacherXTeacherSkill", Schema="dbo")]
	public partial class TeacherXTeacherSkill: AbstractEntityFrameworkDTO
	{
		public TeacherXTeacherSkill()
		{}

		public void SetProperties(
			int id,
			int teacherId,
			int teacherSkillId)
		{
			this.Id = id.ToInt();
			this.TeacherId = teacherId.ToInt();
			this.TeacherSkillId = teacherSkillId.ToInt();
		}

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("teacherId", TypeName="int")]
		public int TeacherId { get; set; }

		[Column("teacherSkillId", TypeName="int")]
		public int TeacherSkillId { get; set; }

		[ForeignKey("TeacherId")]
		public virtual Teacher Teacher { get; set; }

		[ForeignKey("TeacherSkillId")]
		public virtual TeacherSkill TeacherSkill { get; set; }
	}
}

/*<Codenesium>
    <Hash>3efb13ecbd2321acbc19e10c6496cf5d</Hash>
</Codenesium>*/