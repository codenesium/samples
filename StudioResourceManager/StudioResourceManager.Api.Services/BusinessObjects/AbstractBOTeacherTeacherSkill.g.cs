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

		public virtual void SetProperties(int id,
		                                  int teacherId,
		                                  int teacherSkillId)
		{
			this.Id = id;
			this.TeacherId = teacherId;
			this.TeacherSkillId = teacherSkillId;
		}

		public int Id { get; private set; }

		public int TeacherId { get; private set; }

		public int TeacherSkillId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>13a49d2871660566ad833e29eb114fb9</Hash>
</Codenesium>*/