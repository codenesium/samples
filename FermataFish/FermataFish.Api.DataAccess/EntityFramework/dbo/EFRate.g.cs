using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
	[Table("Rate", Schema="dbo")]
	public partial class EFRate:AbstractEntityFrameworkPOCO
	{
		public EFRate()
		{}

		public void SetProperties(
			int id,
			decimal amountPerMinute,
			int teacherId,
			int teacherSkillId)
		{
			this.AmountPerMinute = amountPerMinute.ToDecimal();
			this.Id = id.ToInt();
			this.TeacherId = teacherId.ToInt();
			this.TeacherSkillId = teacherSkillId.ToInt();
		}

		[Column("amountPerMinute", TypeName="money")]
		public decimal AmountPerMinute { get; set; }

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
    <Hash>db9511f3e209a95e0f5e27d763d3fa09</Hash>
</Codenesium>*/