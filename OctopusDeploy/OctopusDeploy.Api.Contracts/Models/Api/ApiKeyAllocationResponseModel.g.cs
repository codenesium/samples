using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiKeyAllocationResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			string collectionName,
			int allocated)
		{
			this.CollectionName = collectionName;
			this.Allocated = allocated;
		}

		[Required]
		[JsonProperty]
		public int Allocated { get; private set; }

		[Required]
		[JsonProperty]
		public string CollectionName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>d6283b1974ff5d6227f397c7d3e1a606</Hash>
</Codenesium>*/