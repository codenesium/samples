using Codenesium.DataConversionExtensions;
using System;

namespace FermataFishNS.Api.Services
{
	public abstract class AbstractBOTeacherXTeacherSkill : AbstractBusinessObject
	{
		public AbstractBOTeacherXTeacherSkill()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  int teacherId,
		                                  int teacherSkillId,
		                                  int studioId)
		{
			this.Id = id;
			this.TeacherId = teacherId;
			this.TeacherSkillId = teacherSkillId;
			this.StudioId = studioId;
		}

		public int Id { get; private set; }

		public int TeacherId { get; private set; }

		public int TeacherSkillId { get; private set; }

		public int StudioId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>1f2b667d6d066efb6df928c4217782f9</Hash>
</Codenesium>*/