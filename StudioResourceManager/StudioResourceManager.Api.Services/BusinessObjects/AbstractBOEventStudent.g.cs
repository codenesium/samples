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
		                                  int studentId,
		                                  bool isDeleted)
		{
			this.EventId = eventId;
			this.StudentId = studentId;
			this.IsDeleted = isDeleted;
		}

		public int EventId { get; private set; }

		public int StudentId { get; private set; }

		public bool IsDeleted { get; private set; }
	}
}

/*<Codenesium>
    <Hash>7aed7d6ccf6de0698486e98c55c6462c</Hash>
</Codenesium>*/