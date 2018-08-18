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
    <Hash>30a6ad2fa58e9fd6a3fcec6aa0756220</Hash>
</Codenesium>*/