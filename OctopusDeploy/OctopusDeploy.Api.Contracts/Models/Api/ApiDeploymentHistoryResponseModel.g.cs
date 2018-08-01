using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiDeploymentHistoryResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			string deploymentId,
			string channelId,
			string channelName,
			DateTimeOffset? completedTime,
			DateTimeOffset created,
			string deployedBy,
			string deploymentName,
			int? durationSeconds,
			string environmentId,
			string environmentName,
			string projectId,
			string projectName,
			string projectSlug,
			DateTimeOffset queueTime,
			string releaseId,
			string releaseVersion,
			DateTimeOffset? startTime,
			string taskId,
			string taskState,
			string tenantId,
			string tenantName)
		{
			this.DeploymentId = deploymentId;
			this.ChannelId = channelId;
			this.ChannelName = channelName;
			this.CompletedTime = completedTime;
			this.Created = created;
			this.DeployedBy = deployedBy;
			this.DeploymentName = deploymentName;
			this.DurationSeconds = durationSeconds;
			this.EnvironmentId = environmentId;
			this.EnvironmentName = environmentName;
			this.ProjectId = projectId;
			this.ProjectName = projectName;
			this.ProjectSlug = projectSlug;
			this.QueueTime = queueTime;
			this.ReleaseId = releaseId;
			this.ReleaseVersion = releaseVersion;
			this.StartTime = startTime;
			this.TaskId = taskId;
			this.TaskState = taskState;
			this.TenantId = tenantId;
			this.TenantName = tenantName;
		}

		[Required]
		[JsonProperty]
		public string ChannelId { get; private set; }

		[Required]
		[JsonProperty]
		public string ChannelName { get; private set; }

		[Required]
		[JsonProperty]
		public DateTimeOffset? CompletedTime { get; private set; }

		[Required]
		[JsonProperty]
		public DateTimeOffset Created { get; private set; }

		[Required]
		[JsonProperty]
		public string DeployedBy { get; private set; }

		[Required]
		[JsonProperty]
		public string DeploymentId { get; private set; }

		[Required]
		[JsonProperty]
		public string DeploymentName { get; private set; }

		[Required]
		[JsonProperty]
		public int? DurationSeconds { get; private set; }

		[Required]
		[JsonProperty]
		public string EnvironmentId { get; private set; }

		[Required]
		[JsonProperty]
		public string EnvironmentName { get; private set; }

		[Required]
		[JsonProperty]
		public string ProjectId { get; private set; }

		[Required]
		[JsonProperty]
		public string ProjectName { get; private set; }

		[Required]
		[JsonProperty]
		public string ProjectSlug { get; private set; }

		[Required]
		[JsonProperty]
		public DateTimeOffset QueueTime { get; private set; }

		[Required]
		[JsonProperty]
		public string ReleaseId { get; private set; }

		[Required]
		[JsonProperty]
		public string ReleaseVersion { get; private set; }

		[Required]
		[JsonProperty]
		public DateTimeOffset? StartTime { get; private set; }

		[Required]
		[JsonProperty]
		public string TaskId { get; private set; }

		[Required]
		[JsonProperty]
		public string TaskState { get; private set; }

		[Required]
		[JsonProperty]
		public string TenantId { get; private set; }

		[Required]
		[JsonProperty]
		public string TenantName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>08120bd8005ae64675c4eb9f7b6a27e4</Hash>
</Codenesium>*/