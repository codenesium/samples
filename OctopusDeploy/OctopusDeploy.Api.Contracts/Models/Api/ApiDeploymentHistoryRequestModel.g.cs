using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiDeploymentHistoryRequestModel : AbstractApiRequestModel
        {
                public ApiDeploymentHistoryRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
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

                [JsonProperty]
                public string ChannelId { get; private set; }

                [JsonProperty]
                public string ChannelName { get; private set; }

                [JsonProperty]
                public DateTimeOffset? CompletedTime { get; private set; }

                [JsonProperty]
                public DateTimeOffset Created { get; private set; }

                [JsonProperty]
                public string DeployedBy { get; private set; }

                [JsonProperty]
                public string DeploymentName { get; private set; }

                [JsonProperty]
                public int? DurationSeconds { get; private set; }

                [JsonProperty]
                public string EnvironmentId { get; private set; }

                [JsonProperty]
                public string EnvironmentName { get; private set; }

                [JsonProperty]
                public string ProjectId { get; private set; }

                [JsonProperty]
                public string ProjectName { get; private set; }

                [JsonProperty]
                public string ProjectSlug { get; private set; }

                [JsonProperty]
                public DateTimeOffset QueueTime { get; private set; }

                [JsonProperty]
                public string ReleaseId { get; private set; }

                [JsonProperty]
                public string ReleaseVersion { get; private set; }

                [JsonProperty]
                public DateTimeOffset? StartTime { get; private set; }

                [JsonProperty]
                public string TaskId { get; private set; }

                [JsonProperty]
                public string TaskState { get; private set; }

                [JsonProperty]
                public string TenantId { get; private set; }

                [JsonProperty]
                public string TenantName { get; private set; }
        }
}

/*<Codenesium>
    <Hash>8b0529548ded5865333da13ae26870f2</Hash>
</Codenesium>*/