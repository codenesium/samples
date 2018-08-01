using Codenesium.DataConversionExtensions;
using System;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractBOEventRelatedDocument : AbstractBusinessObject
	{
		public AbstractBOEventRelatedDocument()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  string eventId,
		                                  string relatedDocumentId)
		{
			this.EventId = eventId;
			this.Id = id;
			this.RelatedDocumentId = relatedDocumentId;
		}

		public string EventId { get; private set; }

		public int Id { get; private set; }

		public string RelatedDocumentId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>e9e19a97f813ad7242d29b4205503676</Hash>
</Codenesium>*/