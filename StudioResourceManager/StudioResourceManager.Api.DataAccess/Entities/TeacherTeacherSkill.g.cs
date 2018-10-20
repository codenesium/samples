using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StudioResourceManagerNS.Api.DataAccess
{
	[Table("TeacherTeacherSkill", Schema="dbo")]
	public partial class TeacherTeacherSkill : AbstractEntity
	{
		public TeacherTeacherSkill()
		{
		}

		public virtual void SetProperties(
			int teacherId,
			int teacherSkillId,
			bool isDeleted)
		{
			this.TeacherId = teacherId;
			this.TeacherSkillId = teacherSkillId;
			this.IsDeleted = isDeleted;
		}

		[Key]
		[Column("teacherId")]
		public int TeacherId { get; private set; }

		[Key]
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
    <Hash>069272699ffe790acce305676ed0ae23</Hash>
</Codenesium>*/