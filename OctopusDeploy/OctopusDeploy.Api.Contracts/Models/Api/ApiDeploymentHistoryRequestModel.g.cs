using Codenesium.DataConversionExtensions.AspNetCore;
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

                public void SetProperties(
                        string channelId,
                        string channelName,
                        Nullable<DateTimeOffset> completedTime,
                        DateTimeOffset created,
                        string deployedBy,
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

                private string channelId;

                public string ChannelId
                {
                        get
                        {
                                return this.channelId.IsEmptyOrZeroOrNull() ? null : this.channelId;
                        }

                        set
                        {
                                this.channelId = value;
                        }
                }

                private string channelName;

                public string ChannelName
                {
                        get
                        {
                                return this.channelName.IsEmptyOrZeroOrNull() ? null : this.channelName;
                        }

                        set
                        {
                                this.channelName = value;
                        }
                }

                private Nullable<DateTimeOffset> completedTime;

                public Nullable<DateTimeOffset> CompletedTime
                {
                        get
                        {
                                return this.completedTime.IsEmptyOrZeroOrNull() ? null : this.completedTime;
                        }

                        set
                        {
                                this.completedTime = value;
                        }
                }

                private DateTimeOffset created;

                [Required]
                public DateTimeOffset Created
                {
                        get
                        {
                                return this.created;
                        }

                        set
                        {
                                this.created = value;
                        }
                }

                private string deployedBy;

                public string DeployedBy
                {
                        get
                        {
                                return this.deployedBy.IsEmptyOrZeroOrNull() ? null : this.deployedBy;
                        }

                        set
                        {
                                this.deployedBy = value;
                        }
                }

                private string deploymentName;

                [Required]
                public string DeploymentName
                {
                        get
                        {
                                return this.deploymentName;
                        }

                        set
                        {
                                this.deploymentName = value;
                        }
                }

                private Nullable<int> durationSeconds;

                public Nullable<int> DurationSeconds
                {
                        get
                        {
                                return this.durationSeconds.IsEmptyOrZeroOrNull() ? null : this.durationSeconds;
                        }

                        set
                        {
                                this.durationSeconds = value;
                        }
                }

                private string environmentId;

                [Required]
                public string EnvironmentId
                {
                        get
                        {
                                return this.environmentId;
                        }

                        set
                        {
                                this.environmentId = value;
                        }
                }

                private string environmentName;

                [Required]
                public string EnvironmentName
                {
                        get
                        {
                                return this.environmentName;
                        }

                        set
                        {
                                this.environmentName = value;
                        }
                }

                private string projectId;

                [Required]
                public string ProjectId
                {
                        get
                        {
                                return this.projectId;
                        }

                        set
                        {
                                this.projectId = value;
                        }
                }

                private string projectName;

                [Required]
                public string ProjectName
                {
                        get
                        {
                                return this.projectName;
                        }

                        set
                        {
                                this.projectName = value;
                        }
                }

                private string projectSlug;

                [Required]
                public string ProjectSlug
                {
                        get
                        {
                                return this.projectSlug;
                        }

                        set
                        {
                                this.projectSlug = value;
                        }
                }

                private DateTimeOffset queueTime;

                [Required]
                public DateTimeOffset QueueTime
                {
                        get
                        {
                                return this.queueTime;
                        }

                        set
                        {
                                this.queueTime = value;
                        }
                }

                private string releaseId;

                [Required]
                public string ReleaseId
                {
                        get
                        {
                                return this.releaseId;
                        }

                        set
                        {
                                this.releaseId = value;
                        }
                }

                private string releaseVersion;

                [Required]
                public string ReleaseVersion
                {
                        get
                        {
                                return this.releaseVersion;
                        }

                        set
                        {
                                this.releaseVersion = value;
                        }
                }

                private Nullable<DateTimeOffset> startTime;

                public Nullable<DateTimeOffset> StartTime
                {
                        get
                        {
                                return this.startTime.IsEmptyOrZeroOrNull() ? null : this.startTime;
                        }

                        set
                        {
                                this.startTime = value;
                        }
                }

                private string taskId;

                [Required]
                public string TaskId
                {
                        get
                        {
                                return this.taskId;
                        }

                        set
                        {
                                this.taskId = value;
                        }
                }

                private string taskState;

                [Required]
                public string TaskState
                {
                        get
                        {
                                return this.taskState;
                        }

                        set
                        {
                                this.taskState = value;
                        }
                }

                private string tenantId;

                public string TenantId
                {
                        get
                        {
                                return this.tenantId.IsEmptyOrZeroOrNull() ? null : this.tenantId;
                        }

                        set
                        {
                                this.tenantId = value;
                        }
                }

                private string tenantName;

                public string TenantName
                {
                        get
                        {
                                return this.tenantName.IsEmptyOrZeroOrNull() ? null : this.tenantName;
                        }

                        set
                        {
                                this.tenantName = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>2888df14bc1ea5a06da4f609599b6062</Hash>
</Codenesium>*/