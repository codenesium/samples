using Codenesium.DataConversionExtensions;
using System;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractBOTeacherTeacherSkill : AbstractBusinessObject
	{
		public AbstractBOTeacherTeacherSkill()
			: base()
		{
		}

		public virtual void SetProperties(int teacherId,
		                                  int teacherSkillId)
		{
			this.TeacherId = teacherId;
			this.TeacherSkillId = teacherSkillId;
		}

		public int TeacherId { get; private set; }

		public int TeacherSkillId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>da7353aff6f9f11b1b9c5620f8129137</Hash>
</Codenesium>*/