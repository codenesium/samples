using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiDeploymentRequestModel : AbstractApiRequestModel
	{
		public ApiDeploymentRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
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

		[JsonProperty]
		public string ChannelId { get; private set; }

		[JsonProperty]
		public DateTimeOffset Created { get; private set; }

		[JsonProperty]
		public string DeployedBy { get; private set; }

		[JsonProperty]
		public string DeployedToMachineIds { get; private set; }

		[JsonProperty]
		public string EnvironmentId { get; private set; }

		[JsonProperty]
		public string JSON { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public string ProjectGroupId { get; private set; }

		[JsonProperty]
		public string ProjectId { get; private set; }

		[JsonProperty]
		public string ReleaseId { get; private set; }

		[JsonProperty]
		public string TaskId { get; private set; }

		[JsonProperty]
		public string TenantId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c855719abc72154144dde2c32a7230f8</Hash>
</Codenesium>*/