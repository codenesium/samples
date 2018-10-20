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
		                                  int teacherId,
		                                  bool isDeleted)
		{
			this.EventId = eventId;
			this.TeacherId = teacherId;
			this.IsDeleted = isDeleted;
		}

		public int EventId { get; private set; }

		public int TeacherId { get; private set; }

		public bool IsDeleted { get; private set; }
	}
}

/*<Codenesium>
    <Hash>5098cc8e73c85f4fb6ebe03ef776ce7f</Hash>
</Codenesium>*/