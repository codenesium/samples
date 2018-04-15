using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
	[Table("Rate", Schema="dbo")]
	public partial class EFRate
	{
		public EFRate()
		{}

		public void SetProperties(
			int id,
			decimal amountPerMinute,
			int teacherSkillId,
			int teacherId)
		{
			this.Id = id.ToInt();
			this.AmountPerMinute = amountPerMinute.ToDecimal();
			this.TeacherSkillId = teacherSkillId.ToInt();
			this.TeacherId = teacherId.ToInt();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("amountPerMinute", TypeName="money")]
		public decimal AmountPerMinute { get; set; }

		[Column("teacherSkillId", TypeName="int")]
		public int TeacherSkillId { get; set; }

		[Column("teacherId", TypeName="int")]
		public int TeacherId { get; set; }

		[ForeignKey("TeacherSkillId")]
		public virtual EFTeacherSkill TeacherSkill { get; set; }

		[ForeignKey("TeacherId")]
		public virtual EFTeacher Teacher { get; set; }
	}
}

/*<Codenesium>
    <Hash>0c1c3daab8168e51fef04ad330a58170</Hash>
</Codenesium>*/