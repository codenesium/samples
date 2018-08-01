using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiVariableSetRequestModel : AbstractApiRequestModel
	{
		public ApiVariableSetRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			bool isFrozen,
			string jSON,
			string ownerId,
			string relatedDocumentIds,
			int version)
		{
			this.IsFrozen = isFrozen;
			this.JSON = jSON;
			this.OwnerId = ownerId;
			this.RelatedDocumentIds = relatedDocumentIds;
			this.Version = version;
		}

		[JsonProperty]
		public bool IsFrozen { get; private set; }

		[JsonProperty]
		public string JSON { get; private set; }

		[JsonProperty]
		public string OwnerId { get; private set; }

		[JsonProperty]
		public string RelatedDocumentIds { get; private set; }

		[JsonProperty]
		public int Version { get; private set; }
	}
}

/*<Codenesium>
    <Hash>2f1fd9f4604c7c198cb369e7d72f8f37</Hash>
</Codenesium>*/