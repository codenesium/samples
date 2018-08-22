using Codenesium.DataConversionExtensions;
using System;

namespace FermataFishNS.Api.Services
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
		                                  int studioId)
		{
			this.Id = id;
			this.AmountPerMinute = amountPerMinute;
			this.TeacherId = teacherId;
			this.TeacherSkillId = teacherSkillId;
			this.StudioId = studioId;
		}

		public int Id { get; private set; }

		public decimal AmountPerMinute { get; private set; }

		public int TeacherId { get; private set; }

		public int TeacherSkillId { get; private set; }

		public int StudioId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>19fad0600aa7b9d81fce51fdccf24a36</Hash>
</Codenesium>*/