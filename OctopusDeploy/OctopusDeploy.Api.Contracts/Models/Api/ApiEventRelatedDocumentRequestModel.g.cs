using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiEventRelatedDocumentRequestModel : AbstractApiRequestModel
	{
		public ApiEventRelatedDocumentRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string eventId,
			string relatedDocumentId)
		{
			this.EventId = eventId;
			this.RelatedDocumentId = relatedDocumentId;
		}

		[JsonProperty]
		public string EventId { get; private set; }

		[JsonProperty]
		public string RelatedDocumentId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ba56c5e8178066d3f456754b9cb9b1b6</Hash>
</Codenesium>*/