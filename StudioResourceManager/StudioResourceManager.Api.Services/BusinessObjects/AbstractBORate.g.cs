using Codenesium.DataConversionExtensions;
using System;

namespace StudioResourceManagerNS.Api.Services
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
		                                  int teacherSkillId,
		                                  bool isDeleted)
		{
			this.AmountPerMinute = amountPerMinute;
			this.Id = id;
			this.TeacherId = teacherId;
			this.TeacherSkillId = teacherSkillId;
			this.IsDeleted = isDeleted;
		}

		public decimal AmountPerMinute { get; private set; }

		public int Id { get; private set; }

		public int TeacherId { get; private set; }

		public int TeacherSkillId { get; private set; }

		public bool IsDeleted { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ce4e76598202fef41f2c36a2d03045a6</Hash>
</Codenesium>*/