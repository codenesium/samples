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
			int teacherSkillId)
		{
			this.TeacherId = teacherId;
			this.TeacherSkillId = teacherSkillId;
		}

		[Key]
		[Column("teacherId")]
		public virtual int TeacherId { get; private set; }

		[Key]
		[Column("teacherSkillId")]
		public virtual int TeacherSkillId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>8deb25509eb1f0fd4c84198abbe3e7de</Hash>
</Codenesium>*/