using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiProxyResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			string id,
			string jSON,
			string name)
		{
			this.Id = id;
			this.JSON = jSON;
			this.Name = name;
		}

		[Required]
		[JsonProperty]
		public string Id { get; private set; }

		[Required]
		[JsonProperty]
		public string JSON { get; private set; }

		[Required]
		[JsonProperty]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>64573ea0f32401fd8727897c62241afc</Hash>
</Codenesium>*/