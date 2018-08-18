using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiSubscriptionResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			string id,
			bool isDisabled,
			string jSON,
			string name,
			string type)
		{
			this.Id = id;
			this.IsDisabled = isDisabled;
			this.JSON = jSON;
			this.Name = name;
			this.Type = type;
		}

		[Required]
		[JsonProperty]
		public string Id { get; private set; }

		[Required]
		[JsonProperty]
		public bool IsDisabled { get; private set; }

		[Required]
		[JsonProperty]
		public string JSON { get; private set; }

		[Required]
		[JsonProperty]
		public string Name { get; private set; }

		[Required]
		[JsonProperty]
		public string Type { get; private set; }
	}
}

/*<Codenesium>
    <Hash>8858f7fc668662d3a8d2ce8789c97be3</Hash>
</Codenesium>*/