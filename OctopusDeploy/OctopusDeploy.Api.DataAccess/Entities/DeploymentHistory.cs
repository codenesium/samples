using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("DeploymentHistory", Schema="dbo")]
        public partial class DeploymentHistory: AbstractEntity
        {
                public DeploymentHistory()
                {
                }

                public void SetProperties(
                        string channelId,
                        string channelName,
                        Nullable<DateTime> completedTime,
                        DateTime created,
                        string deployedBy,
                        string deploymentId,
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

                [Column("ChannelId", TypeName="nvarchar(50)")]
                public string ChannelId { get; private set; }

                [Column("ChannelName", TypeName="nvarchar(200)")]
                public string ChannelName { get; private set; }

                [Column("CompletedTime", TypeName="datetimeoffset")]
                public Nullable<DateTime> CompletedTime { get; private set; }

                [Column("Created", TypeName="datetimeoffset")]
                public DateTime Created { get; private set; }

                [Column("DeployedBy", TypeName="nvarchar(200)")]
                public string DeployedBy { get; private set; }

                [Key]
                [Column("DeploymentId", TypeName="nvarchar(50)")]
                public string DeploymentId { get; private set; }

                [Column("DeploymentName", TypeName="nvarchar(200)")]
                public string DeploymentName { get; private set; }

                [Column("DurationSeconds", TypeName="int")]
                public Nullable<int> DurationSeconds { get; private set; }

                [Column("EnvironmentId", TypeName="nvarchar(50)")]
                public string EnvironmentId { get; private set; }

                [Column("EnvironmentName", TypeName="nvarchar(200)")]
                public string EnvironmentName { get; private set; }

                [Column("ProjectId", TypeName="nvarchar(50)")]
                public string ProjectId { get; private set; }

                [Column("ProjectName", TypeName="nvarchar(200)")]
                public string ProjectName { get; private set; }

                [Column("ProjectSlug", TypeName="nvarchar(210)")]
                public string ProjectSlug { get; private set; }

                [Column("QueueTime", TypeName="datetimeoffset")]
                public DateTime QueueTime { get; private set; }

                [Column("ReleaseId", TypeName="nvarchar(150)")]
                public string ReleaseId { get; private set; }

                [Column("ReleaseVersion", TypeName="nvarchar(100)")]
                public string ReleaseVersion { get; private set; }

                [Column("StartTime", TypeName="datetimeoffset")]
                public Nullable<DateTime> StartTime { get; private set; }

                [Column("TaskId", TypeName="nvarchar(50)")]
                public string TaskId { get; private set; }

                [Column("TaskState", TypeName="nvarchar(50)")]
                public string TaskState { get; private set; }

                [Column("TenantId", TypeName="nvarchar(50)")]
                public string TenantId { get; private set; }

                [Column("TenantName", TypeName="nvarchar(200)")]
                public string TenantName { get; private set; }
        }
}

/*<Codenesium>
    <Hash>b0f95ccbd05f7fff961874e12a7d7ae1</Hash>
</Codenesium>*/