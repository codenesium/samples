using Codenesium.DataConversionExtensions;
using System;

namespace FileServiceNS.Api.Services
{
	public abstract class AbstractBOBucket : AbstractBusinessObject
	{
		public AbstractBOBucket()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  Guid externalId,
		                                  string name)
		{
			this.ExternalId = externalId;
			this.Id = id;
			this.Name = name;
		}

		public Guid ExternalId { get; private set; }

		public int Id { get; private set; }

		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>7afe752a8b426860a0fb385db64082dd</Hash>
</Codenesium>*/