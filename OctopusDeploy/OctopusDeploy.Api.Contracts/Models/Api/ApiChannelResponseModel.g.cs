using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiChannelResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			string id,
			byte[] dataVersion,
			string jSON,
			string lifecycleId,
			string name,
			string projectId,
			string tenantTags)
		{
			this.Id = id;
			this.DataVersion = dataVersion;
			this.JSON = jSON;
			this.LifecycleId = lifecycleId;
			this.Name = name;
			this.ProjectId = projectId;
			this.TenantTags = tenantTags;
		}

		[Required]
		[JsonProperty]
		public byte[] DataVersion { get; private set; }

		[Required]
		[JsonProperty]
		public string Id { get; private set; }

		[Required]
		[JsonProperty]
		public string JSON { get; private set; }

		[Required]
		[JsonProperty]
		public string LifecycleId { get; private set; }

		[Required]
		[JsonProperty]
		public string Name { get; private set; }

		[Required]
		[JsonProperty]
		public string ProjectId { get; private set; }

		[Required]
		[JsonProperty]
		public string TenantTags { get; private set; }
	}
}

/*<Codenesium>
    <Hash>261abeac26fd3fec991c64502278d38e</Hash>
</Codenesium>*/