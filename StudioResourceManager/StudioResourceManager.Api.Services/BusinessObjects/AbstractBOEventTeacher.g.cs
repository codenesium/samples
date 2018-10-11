using Codenesium.DataConversionExtensions;
using System;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractBOEventTeacher : AbstractBusinessObject
	{
		public AbstractBOEventTeacher()
			: base()
		{
		}

		public virtual void SetProperties(int eventId,
		                                  int teacherId)
		{
			this.EventId = eventId;
			this.TeacherId = teacherId;
		}

		public int EventId { get; private set; }

		public int TeacherId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>388c6c822287e625c35440d752028403</Hash>
</Codenesium>*/