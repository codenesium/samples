using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiDeploymentProcessResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			string id,
			bool isFrozen,
			string jSON,
			string ownerId,
			string relatedDocumentIds,
			int version)
		{
			this.Id = id;
			this.IsFrozen = isFrozen;
			this.JSON = jSON;
			this.OwnerId = ownerId;
			this.RelatedDocumentIds = relatedDocumentIds;
			this.Version = version;
		}

		[Required]
		[JsonProperty]
		public string Id { get; private set; }

		[Required]
		[JsonProperty]
		public bool IsFrozen { get; private set; }

		[Required]
		[JsonProperty]
		public string JSON { get; private set; }

		[Required]
		[JsonProperty]
		public string OwnerId { get; private set; }

		[Required]
		[JsonProperty]
		public string RelatedDocumentIds { get; private set; }

		[Required]
		[JsonProperty]
		public int Version { get; private set; }
	}
}

/*<Codenesium>
    <Hash>1ff04dea59fab3c2b92f83f8031f9e65</Hash>
</Codenesium>*/