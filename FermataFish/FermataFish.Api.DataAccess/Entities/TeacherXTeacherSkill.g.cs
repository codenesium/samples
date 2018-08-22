using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace FermataFishNS.Api.DataAccess
{
	[Table("TeacherXTeacherSkill", Schema="dbo")]
	public partial class TeacherXTeacherSkill : AbstractEntity
	{
		public TeacherXTeacherSkill()
		{
		}

		public virtual void SetProperties(
			int id,
			int teacherId,
			int teacherSkillId,
			int studioId)
		{
			this.Id = id;
			this.TeacherId = teacherId;
			this.TeacherSkillId = teacherSkillId;
			this.StudioId = studioId;
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int Id { get; private set; }

		[Column("teacherId")]
		public int TeacherId { get; private set; }

		[Column("teacherSkillId")]
		public int TeacherSkillId { get; private set; }

		[Column("studioId")]
		public int StudioId { get; private set; }

		[ForeignKey("TeacherId")]
		public virtual Teacher TeacherNavigation { get; private set; }

		[ForeignKey("TeacherSkillId")]
		public virtual TeacherSkill TeacherSkillNavigation { get; private set; }

		[ForeignKey("StudioId")]
		public virtual Studio StudioNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>5d511493f50b9a37cbe3a60856a874f0</Hash>
</Codenesium>*/