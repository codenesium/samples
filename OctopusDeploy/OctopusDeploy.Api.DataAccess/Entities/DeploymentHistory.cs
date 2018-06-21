using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("DeploymentHistory", Schema="dbo")]
        public partial class DeploymentHistory : AbstractEntity
        {
                public DeploymentHistory()
                {
                }

                public void SetProperties(
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

                [Column("ChannelId")]
                public string ChannelId { get; private set; }

                [Column("ChannelName")]
                public string ChannelName { get; private set; }

                [Column("CompletedTime")]
                public Nullable<DateTimeOffset> CompletedTime { get; private set; }

                [Column("Created")]
                public DateTimeOffset Created { get; private set; }

                [Column("DeployedBy")]
                public string DeployedBy { get; private set; }

                [Key]
                [Column("DeploymentId")]
                public string DeploymentId { get; private set; }

                [Column("DeploymentName")]
                public string DeploymentName { get; private set; }

                [Column("DurationSeconds")]
                public Nullable<int> DurationSeconds { get; private set; }

                [Column("EnvironmentId")]
                public string EnvironmentId { get; private set; }

                [Column("EnvironmentName")]
                public string EnvironmentName { get; private set; }

                [Column("ProjectId")]
                public string ProjectId { get; private set; }

                [Column("ProjectName")]
                public string ProjectName { get; private set; }

                [Column("ProjectSlug")]
                public string ProjectSlug { get; private set; }

                [Column("QueueTime")]
                public DateTimeOffset QueueTime { get; private set; }

                [Column("ReleaseId")]
                public string ReleaseId { get; private set; }

                [Column("ReleaseVersion")]
                public string ReleaseVersion { get; private set; }

                [Column("StartTime")]
                public Nullable<DateTimeOffset> StartTime { get; private set; }

                [Column("TaskId")]
                public string TaskId { get; private set; }

                [Column("TaskState")]
                public string TaskState { get; private set; }

                [Column("TenantId")]
                public string TenantId { get; private set; }

                [Column("TenantName")]
                public string TenantName { get; private set; }
        }
}

/*<Codenesium>
    <Hash>ed00cf79b140d06ee672e9993a5b144d</Hash>
</Codenesium>*/