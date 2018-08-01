using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiDeploymentResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			string id,
			string channelId,
			DateTimeOffset created,
			string deployedBy,
			string deployedToMachineIds,
			string environmentId,
			string jSON,
			string name,
			string projectGroupId,
			string projectId,
			string releaseId,
			string taskId,
			string tenantId)
		{
			this.Id = id;
			this.ChannelId = channelId;
			this.Created = created;
			this.DeployedBy = deployedBy;
			this.DeployedToMachineIds = deployedToMachineIds;
			this.EnvironmentId = environmentId;
			this.JSON = jSON;
			this.Name = name;
			this.ProjectGroupId = projectGroupId;
			this.ProjectId = projectId;
			this.ReleaseId = releaseId;
			this.TaskId = taskId;
			this.TenantId = tenantId;
		}

		[Required]
		[JsonProperty]
		public string ChannelId { get; private set; }

		[Required]
		[JsonProperty]
		public DateTimeOffset Created { get; private set; }

		[Required]
		[JsonProperty]
		public string DeployedBy { get; private set; }

		[Required]
		[JsonProperty]
		public string DeployedToMachineIds { get; private set; }

		[Required]
		[JsonProperty]
		public string EnvironmentId { get; private set; }

		[Required]
		[JsonProperty]
		public string Id { get; private set; }

		[Required]
		[JsonProperty]
		public string JSON { get; private set; }

		[Required]
		[JsonProperty]
		public string Name { get; private set; }

		[Required]
		[JsonProperty]
		public string ProjectGroupId { get; private set; }

		[Required]
		[JsonProperty]
		public string ProjectId { get; private set; }

		[Required]
		[JsonProperty]
		public string ReleaseId { get; private set; }

		[Required]
		[JsonProperty]
		public string TaskId { get; private set; }

		[Required]
		[JsonProperty]
		public string TenantId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>0a5259b74e143a6e2025f130a6030557</Hash>
</Codenesium>*/