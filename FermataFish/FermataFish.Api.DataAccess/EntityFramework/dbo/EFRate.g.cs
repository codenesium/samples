using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
	[Table("Rate", Schema="dbo")]
	public partial class Rate:AbstractEntityFrameworkPOCO
	{
		public Rate()
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
		public virtual Teacher Teacher { get; set; }

		[ForeignKey("TeacherSkillId")]
		public virtual TeacherSkill TeacherSkill { get; set; }
	}
}

/*<Codenesium>
    <Hash>e1c95612eea0c892f53c5a42d0ce63c5</Hash>
</Codenesium>*/