using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiUserRoleResponseModel : AbstractApiResponseModel
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
    <Hash>b37c6b6d4665f4ba60c6e76fe6478e62</Hash>
</Codenesium>*/