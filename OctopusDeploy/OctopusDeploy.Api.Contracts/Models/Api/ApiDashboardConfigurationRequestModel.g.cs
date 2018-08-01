using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiDashboardConfigurationRequestModel : AbstractApiRequestModel
	{
		public ApiDashboardConfigurationRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string includedEnvironmentIds,
			string includedProjectIds,
			string includedTenantIds,
			string includedTenantTags,
			string jSON)
		{
			this.IncludedEnvironmentIds = includedEnvironmentIds;
			this.IncludedProjectIds = includedProjectIds;
			this.IncludedTenantIds = includedTenantIds;
			this.IncludedTenantTags = includedTenantTags;
			this.JSON = jSON;
		}

		[JsonProperty]
		public string IncludedEnvironmentIds { get; private set; }

		[JsonProperty]
		public string IncludedProjectIds { get; private set; }

		[JsonProperty]
		public string IncludedTenantIds { get; private set; }

		[JsonProperty]
		public string IncludedTenantTags { get; private set; }

		[JsonProperty]
		public string JSON { get; private set; }
	}
}

/*<Codenesium>
    <Hash>0969d9f0e161748d66f4f7019222c205</Hash>
</Codenesium>*/