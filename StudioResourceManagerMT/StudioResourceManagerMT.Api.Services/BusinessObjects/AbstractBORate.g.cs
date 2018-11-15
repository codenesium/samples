using Codenesium.DataConversionExtensions;
using System;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractBORate : AbstractBusinessObject
	{
		public AbstractBORate()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  decimal amountPerMinute,
		                                  int teacherId,
		                                  int teacherSkillId)
		{
			this.AmountPerMinute = amountPerMinute;
			this.Id = id;
			this.TeacherId = teacherId;
			this.TeacherSkillId = teacherSkillId;
		}

		public decimal AmountPerMinute { get; private set; }

		public int Id { get; private set; }

		public int TeacherId { get; private set; }

		public int TeacherSkillId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>e6bed29cbe7e4b91d852247011e0f41a</Hash>
</Codenesium>*/