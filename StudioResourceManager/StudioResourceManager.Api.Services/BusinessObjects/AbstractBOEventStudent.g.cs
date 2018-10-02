using Codenesium.DataConversionExtensions;
using System;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractBOEventStudent : AbstractBusinessObject
	{
		public AbstractBOEventStudent()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  int eventId,
		                                  int studentId)
		{
			this.EventId = eventId;
			this.Id = id;
			this.StudentId = studentId;
		}

		public int EventId { get; private set; }

		public int Id { get; private set; }

		public int StudentId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>2425fb3f4dd2dd38d91059fee33de918</Hash>
</Codenesium>*/