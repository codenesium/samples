using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("ServerTask", Schema="dbo")]
        public partial class ServerTask: AbstractEntity
        {
                public ServerTask()
                {
                }

                public void SetProperties(
                        Nullable<DateTimeOffset> completedTime,
                        string concurrencyTag,
                        string description,
                        int durationSeconds,
                        string environmentId,
                        string errorMessage,
                        bool hasPendingInterruptions,
                        bool hasWarningsOrErrors,
                        string id,
                        string jSON,
                        string name,
                        string projectId,
                        DateTimeOffset queueTime,
                        string serverNodeId,
                        Nullable<DateTimeOffset> startTime,
                        string state,
                        string tenantId)
                {
                        this.CompletedTime = completedTime;
                        this.ConcurrencyTag = concurrencyTag;
                        this.Description = description;
                        this.DurationSeconds = durationSeconds;
                        this.EnvironmentId = environmentId;
                        this.ErrorMessage = errorMessage;
                        this.HasPendingInterruptions = hasPendingInterruptions;
                        this.HasWarningsOrErrors = hasWarningsOrErrors;
                        this.Id = id;
                        this.JSON = jSON;
                        this.Name = name;
                        this.ProjectId = projectId;
                        this.QueueTime = queueTime;
                        this.ServerNodeId = serverNodeId;
                        this.StartTime = startTime;
                        this.State = state;
                        this.TenantId = tenantId;
                }

                [Column("CompletedTime", TypeName="datetimeoffset")]
                public Nullable<DateTimeOffset> CompletedTime { get; private set; }

                [Column("ConcurrencyTag", TypeName="nvarchar(100)")]
                public string ConcurrencyTag { get; private set; }

                [Column("Description", TypeName="nvarchar(-1)")]
                public string Description { get; private set; }

                [Column("DurationSeconds", TypeName="int")]
                public int DurationSeconds { get; private set; }

                [Column("EnvironmentId", TypeName="nvarchar(50)")]
                public string EnvironmentId { get; private set; }

                [Column("ErrorMessage", TypeName="nvarchar(-1)")]
                public string ErrorMessage { get; private set; }

                [Column("HasPendingInterruptions", TypeName="bit")]
                public bool HasPendingInterruptions { get; private set; }

                [Column("HasWarningsOrErrors", TypeName="bit")]
                public bool HasWarningsOrErrors { get; private set; }

                [Key]
                [Column("Id", TypeName="nvarchar(50)")]
                public string Id { get; private set; }

                [Column("JSON", TypeName="nvarchar(-1)")]
                public string JSON { get; private set; }

                [Column("Name", TypeName="nvarchar(50)")]
                public string Name { get; private set; }

                [Column("ProjectId", TypeName="nvarchar(50)")]
                public string ProjectId { get; private set; }

                [Column("QueueTime", TypeName="datetimeoffset")]
                public DateTimeOffset QueueTime { get; private set; }

                [Column("ServerNodeId", TypeName="nvarchar(250)")]
                public string ServerNodeId { get; private set; }

                [Column("StartTime", TypeName="datetimeoffset")]
                public Nullable<DateTimeOffset> StartTime { get; private set; }

                [Column("State", TypeName="nvarchar(50)")]
                public string State { get; private set; }

                [Column("TenantId", TypeName="nvarchar(50)")]
                public string TenantId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>8e94e272554822f7f979c431eea259fc</Hash>
</Codenesium>*/