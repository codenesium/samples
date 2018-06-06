using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
	[Table("Rate", Schema="dbo")]
	public partial class Rate:AbstractEntity
	{
		public Rate()
		{}

		public void SetProperties(
			decimal amountPerMinute,
			int id,
			int teacherId,
			int teacherSkillId)
		{
			this.AmountPerMinute = amountPerMinute.ToDecimal();
			this.Id = id.ToInt();
			this.TeacherId = teacherId.ToInt();
			this.TeacherSkillId = teacherSkillId.ToInt();
		}

		[Column("amountPerMinute", TypeName="money")]
		public decimal AmountPerMinute { get; private set; }

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; private set; }

		[Column("teacherId", TypeName="int")]
		public int TeacherId { get; private set; }

		[Column("teacherSkillId", TypeName="int")]
		public int TeacherSkillId { get; private set; }

		[ForeignKey("TeacherId")]
		public virtual Teacher Teacher { get; set; }

		[ForeignKey("TeacherSkillId")]
		public virtual TeacherSkill TeacherSkill { get; set; }
	}
}

/*<Codenesium>
    <Hash>434c1117ac211f27b5229b57b699ad42</Hash>
</Codenesium>*/