using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiMutexResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			string id,
			string jSON)
		{
			this.Id = id;
			this.JSON = jSON;
		}

		[Required]
		[JsonProperty]
		public string Id { get; private set; }

		[Required]
		[JsonProperty]
		public string JSON { get; private set; }
	}
}

/*<Codenesium>
    <Hash>abb73da535fb832bbcd23e4874b046a0</Hash>
</Codenesium>*/