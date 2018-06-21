using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiDeploymentHistoryResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string channelId,
                        string channelName,
                        Nullable<DateTimeOffset> completedTime,
                        DateTimeOffset created,
                        string deployedBy,
                        string deploymentId,
                        string deploymentName,
                        Nullable<int> durationSeconds,
                        string environmentId,
                        string environmentName,
                        string projectId,
                        string projectName,
                        string projectSlug,
                        DateTimeOffset queueTime,
                        string releaseId,
                        string releaseVersion,
                        Nullable<DateTimeOffset> startTime,
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
                        this.DeploymentId = deploymentId;
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

                public string ChannelId { get; private set; }

                public string ChannelName { get; private set; }

                public Nullable<DateTimeOffset> CompletedTime { get; private set; }

                public DateTimeOffset Created { get; private set; }

                public string DeployedBy { get; private set; }

                public string DeploymentId { get; private set; }

                public string DeploymentName { get; private set; }

                public Nullable<int> DurationSeconds { get; private set; }

                public string EnvironmentId { get; private set; }

                public string EnvironmentName { get; private set; }

                public string ProjectId { get; private set; }

                public string ProjectName { get; private set; }

                public string ProjectSlug { get; private set; }

                public DateTimeOffset QueueTime { get; private set; }

                public string ReleaseId { get; private set; }

                public string ReleaseVersion { get; private set; }

                public Nullable<DateTimeOffset> StartTime { get; private set; }

                public string TaskId { get; private set; }

                public string TaskState { get; private set; }

                public string TenantId { get; private set; }

                public string TenantName { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeChannelIdValue { get; set; } = true;

                public bool ShouldSerializeChannelId()
                {
                        return this.ShouldSerializeChannelIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeChannelNameValue { get; set; } = true;

                public bool ShouldSerializeChannelName()
                {
                        return this.ShouldSerializeChannelNameValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeCompletedTimeValue { get; set; } = true;

                public bool ShouldSerializeCompletedTime()
                {
                        return this.ShouldSerializeCompletedTimeValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeCreatedValue { get; set; } = true;

                public bool ShouldSerializeCreated()
                {
                        return this.ShouldSerializeCreatedValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeDeployedByValue { get; set; } = true;

                public bool ShouldSerializeDeployedBy()
                {
                        return this.ShouldSerializeDeployedByValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeDeploymentIdValue { get; set; } = true;

                public bool ShouldSerializeDeploymentId()
                {
                        return this.ShouldSerializeDeploymentIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeDeploymentNameValue { get; set; } = true;

                public bool ShouldSerializeDeploymentName()
                {
                        return this.ShouldSerializeDeploymentNameValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeDurationSecondsValue { get; set; } = true;

                public bool ShouldSerializeDurationSeconds()
                {
                        return this.ShouldSerializeDurationSecondsValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeEnvironmentIdValue { get; set; } = true;

                public bool ShouldSerializeEnvironmentId()
                {
                        return this.ShouldSerializeEnvironmentIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeEnvironmentNameValue { get; set; } = true;

                public bool ShouldSerializeEnvironmentName()
                {
                        return this.ShouldSerializeEnvironmentNameValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeProjectIdValue { get; set; } = true;

                public bool ShouldSerializeProjectId()
                {
                        return this.ShouldSerializeProjectIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeProjectNameValue { get; set; } = true;

                public bool ShouldSerializeProjectName()
                {
                        return this.ShouldSerializeProjectNameValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeProjectSlugValue { get; set; } = true;

                public bool ShouldSerializeProjectSlug()
                {
                        return this.ShouldSerializeProjectSlugValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeQueueTimeValue { get; set; } = true;

                public bool ShouldSerializeQueueTime()
                {
                        return this.ShouldSerializeQueueTimeValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeReleaseIdValue { get; set; } = true;

                public bool ShouldSerializeReleaseId()
                {
                        return this.ShouldSerializeReleaseIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeReleaseVersionValue { get; set; } = true;

                public bool ShouldSerializeReleaseVersion()
                {
                        return this.ShouldSerializeReleaseVersionValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeStartTimeValue { get; set; } = true;

                public bool ShouldSerializeStartTime()
                {
                        return this.ShouldSerializeStartTimeValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeTaskIdValue { get; set; } = true;

                public bool ShouldSerializeTaskId()
                {
                        return this.ShouldSerializeTaskIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeTaskStateValue { get; set; } = true;

                public bool ShouldSerializeTaskState()
                {
                        return this.ShouldSerializeTaskStateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeTenantIdValue { get; set; } = true;

                public bool ShouldSerializeTenantId()
                {
                        return this.ShouldSerializeTenantIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeTenantNameValue { get; set; } = true;

                public bool ShouldSerializeTenantName()
                {
                        return this.ShouldSerializeTenantNameValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeChannelIdValue = false;
                        this.ShouldSerializeChannelNameValue = false;
                        this.ShouldSerializeCompletedTimeValue = false;
                        this.ShouldSerializeCreatedValue = false;
                        this.ShouldSerializeDeployedByValue = false;
                        this.ShouldSerializeDeploymentIdValue = false;
                        this.ShouldSerializeDeploymentNameValue = false;
                        this.ShouldSerializeDurationSecondsValue = false;
                        this.ShouldSerializeEnvironmentIdValue = false;
                        this.ShouldSerializeEnvironmentNameValue = false;
                        this.ShouldSerializeProjectIdValue = false;
                        this.ShouldSerializeProjectNameValue = false;
                        this.ShouldSerializeProjectSlugValue = false;
                        this.ShouldSerializeQueueTimeValue = false;
                        this.ShouldSerializeReleaseIdValue = false;
                        this.ShouldSerializeReleaseVersionValue = false;
                        this.ShouldSerializeStartTimeValue = false;
                        this.ShouldSerializeTaskIdValue = false;
                        this.ShouldSerializeTaskStateValue = false;
                        this.ShouldSerializeTenantIdValue = false;
                        this.ShouldSerializeTenantNameValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>44d2dbe8f4eec35158b20b2b2d680064</Hash>
</Codenesium>*/