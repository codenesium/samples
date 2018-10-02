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

		public virtual void SetProperties(int id,
		                                  int eventId)
		{
			this.EventId = eventId;
			this.Id = id;
		}

		public int EventId { get; private set; }

		public int Id { get; private set; }
	}
}

/*<Codenesium>
    <Hash>26e68698b158c167c7c27e5d3664faf2</Hash>
</Codenesium>*/