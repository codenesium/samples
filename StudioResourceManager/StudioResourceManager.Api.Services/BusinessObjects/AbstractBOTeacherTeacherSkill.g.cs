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
		                                  int teacherSkillId,
		                                  bool isDeleted)
		{
			this.TeacherId = teacherId;
			this.TeacherSkillId = teacherSkillId;
			this.IsDeleted = isDeleted;
		}

		public int TeacherId { get; private set; }

		public int TeacherSkillId { get; private set; }

		public bool IsDeleted { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c2b46c5975e29ebaf1e19a0f8d0140ff</Hash>
</Codenesium>*/