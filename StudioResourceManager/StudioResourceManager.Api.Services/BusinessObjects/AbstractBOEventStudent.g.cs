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

		public virtual void SetProperties(int eventId,
		                                  int studentId)
		{
			this.EventId = eventId;
			this.StudentId = studentId;
		}

		public int EventId { get; private set; }

		public int StudentId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>978ac90dbac64ef38007613afb4b9d19</Hash>
</Codenesium>*/