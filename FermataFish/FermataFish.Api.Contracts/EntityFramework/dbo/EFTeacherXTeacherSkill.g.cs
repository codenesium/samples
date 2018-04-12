using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.Contracts
{
	[Table("TeacherXTeacherSkill", Schema="dbo")]
	public partial class EFTeacherXTeacherSkill
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
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
    <Hash>86389336dae356d80cfb07aad4023a31</Hash>
</Codenesium>*/