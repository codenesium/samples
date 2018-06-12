using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public partial class BODeploymentHistory: AbstractBusinessObject
        {
                public BODeploymentHistory() : base()
                {
                }

                public void SetProperties(string deploymentId,
                                          string channelId,
                                          string channelName,
                                          Nullable<DateTime> completedTime,
                                          DateTime created,
                                          string deployedBy,
                                          string deploymentName,
                                          Nullable<int> durationSeconds,
                                          string environmentId,
                                          string environmentName,
                                          string projectId,
                                          string projectName,
                                          string projectSlug,
                                          DateTime queueTime,
                                          string releaseId,
                                          string releaseVersion,
                                          Nullable<DateTime> startTime,
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

                public Nullable<DateTime> CompletedTime { get; private set; }

                public DateTime Created { get; private set; }

                public string DeployedBy { get; private set; }

                public string DeploymentId { get; private set; }

                public string DeploymentName { get; private set; }

                public Nullable<int> DurationSeconds { get; private set; }

                public string EnvironmentId { get; private set; }

                public string EnvironmentName { get; private set; }

                public string ProjectId { get; private set; }

                public string ProjectName { get; private set; }

                public string ProjectSlug { get; private set; }

                public DateTime QueueTime { get; private set; }

                public string ReleaseId { get; private set; }

                public string ReleaseVersion { get; private set; }

                public Nullable<DateTime> StartTime { get; private set; }

                public string TaskId { get; private set; }

                public string TaskState { get; private set; }

                public string TenantId { get; private set; }

                public string TenantName { get; private set; }
        }
}

/*<Codenesium>
    <Hash>1086cf29114ac28f4ff1fea03d23dc0f</Hash>
</Codenesium>*/