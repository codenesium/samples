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
			int teacherSkillId,
			bool isDeleted)
		{
			this.AmountPerMinute = amountPerMinute;
			this.Id = id;
			this.TeacherId = teacherId;
			this.TeacherSkillId = teacherSkillId;
			this.IsDeleted = isDeleted;
		}

		[Column("amountPerMinute")]
		public decimal AmountPerMinute { get; private set; }

		[Key]
		[Column("id")]
		public int Id { get; private set; }

		[Column("teacherId")]
		public int TeacherId { get; private set; }

		[Column("teacherSkillId")]
		public int TeacherSkillId { get; private set; }

		[Column("isDeleted")]
		public bool IsDeleted { get; private set; }

		[ForeignKey("TeacherId")]
		public virtual Teacher TeacherNavigation { get; private set; }

		[ForeignKey("TeacherSkillId")]
		public virtual TeacherSkill TeacherSkillNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>6623bc1fd6582e2c44035469db4dbe99</Hash>
</Codenesium>*/