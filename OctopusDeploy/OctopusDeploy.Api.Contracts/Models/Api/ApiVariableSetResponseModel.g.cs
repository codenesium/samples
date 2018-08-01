using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiVariableSetResponseModel : AbstractApiResponseModel
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
    <Hash>7262627bce20940d8d531044d72dca7f</Hash>
</Codenesium>*/