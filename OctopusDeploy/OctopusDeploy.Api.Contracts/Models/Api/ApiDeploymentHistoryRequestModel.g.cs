using Codenesium.DataConversionExtensions;
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

                private string channelId;

                public string ChannelId
                {
                        get
                        {
                                return this.channelId;
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
                                return this.channelName;
                        }

                        set
                        {
                                this.channelName = value;
                        }
                }

                private DateTimeOffset? completedTime;

                public DateTimeOffset? CompletedTime
                {
                        get
                        {
                                return this.completedTime;
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
                                return this.deployedBy;
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

                private int? durationSeconds;

                public int? DurationSeconds
                {
                        get
                        {
                                return this.durationSeconds;
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

                private DateTimeOffset? startTime;

                public DateTimeOffset? StartTime
                {
                        get
                        {
                                return this.startTime;
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
                                return this.tenantId;
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
                                return this.tenantName;
                        }

                        set
                        {
                                this.tenantName = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>d8c796455d785d4cd1975e88f2590b9d</Hash>
</Codenesium>*/