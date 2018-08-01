using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiAccountRequestModel : AbstractApiRequestModel
	{
		public ApiAccountRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string accountType,
			string environmentIds,
			string jSON,
			string name,
			string tenantIds,
			string tenantTags)
		{
			this.AccountType = accountType;
			this.EnvironmentIds = environmentIds;
			this.JSON = jSON;
			this.Name = name;
			this.TenantIds = tenantIds;
			this.TenantTags = tenantTags;
		}

		[JsonProperty]
		public string AccountType { get; private set; }

		[JsonProperty]
		public string EnvironmentIds { get; private set; }

		[JsonProperty]
		public string JSON { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public string TenantIds { get; private set; }

		[JsonProperty]
		public string TenantTags { get; private set; }
	}
}

/*<Codenesium>
    <Hash>fcdcb050cfaee50f9ab5b71da134984e</Hash>
</Codenesium>*/