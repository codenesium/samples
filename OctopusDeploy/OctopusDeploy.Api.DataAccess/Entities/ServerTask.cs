using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("ServerTask", Schema="dbo")]
        public partial class ServerTask : AbstractEntity
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

                [Column("CompletedTime")]
                public Nullable<DateTimeOffset> CompletedTime { get; private set; }

                [Column("ConcurrencyTag")]
                public string ConcurrencyTag { get; private set; }

                [Column("Description")]
                public string Description { get; private set; }

                [Column("DurationSeconds")]
                public int DurationSeconds { get; private set; }

                [Column("EnvironmentId")]
                public string EnvironmentId { get; private set; }

                [Column("ErrorMessage")]
                public string ErrorMessage { get; private set; }

                [Column("HasPendingInterruptions")]
                public bool HasPendingInterruptions { get; private set; }

                [Column("HasWarningsOrErrors")]
                public bool HasWarningsOrErrors { get; private set; }

                [Key]
                [Column("Id")]
                public string Id { get; private set; }

                [Column("JSON")]
                public string JSON { get; private set; }

                [Column("Name")]
                public string Name { get; private set; }

                [Column("ProjectId")]
                public string ProjectId { get; private set; }

                [Column("QueueTime")]
                public DateTimeOffset QueueTime { get; private set; }

                [Column("ServerNodeId")]
                public string ServerNodeId { get; private set; }

                [Column("StartTime")]
                public Nullable<DateTimeOffset> StartTime { get; private set; }

                [Column("State")]
                public string State { get; private set; }

                [Column("TenantId")]
                public string TenantId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>eb8332304f0d326bf9987a00b2f94ae8</Hash>
</Codenesium>*/