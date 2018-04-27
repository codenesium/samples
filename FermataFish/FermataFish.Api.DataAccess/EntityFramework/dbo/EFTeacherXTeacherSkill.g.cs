using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
	[Table("TeacherXTeacherSkill", Schema="dbo")]
	public partial class EFTeacherXTeacherSkill: AbstractEntityFrameworkPOCO
	{
		public EFTeacherXTeacherSkill()
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
		public virtual EFTeacher Teacher { get; set; }

		[ForeignKey("TeacherSkillId")]
		public virtual EFTeacherSkill TeacherSkill { get; set; }
	}
}

/*<Codenesium>
    <Hash>e1b550bf746431c60d4fac6ec6a4ccad</Hash>
</Codenesium>*/