using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiServerTaskResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string id,
                        DateTimeOffset? completedTime,
                        string concurrencyTag,
                        string description,
                        int durationSeconds,
                        string environmentId,
                        string errorMessage,
                        bool hasPendingInterruptions,
                        bool hasWarningsOrErrors,
                        string jSON,
                        string name,
                        string projectId,
                        DateTimeOffset queueTime,
                        string serverNodeId,
                        DateTimeOffset? startTime,
                        string state,
                        string tenantId)
                {
                        this.Id = id;
                        this.CompletedTime = completedTime;
                        this.ConcurrencyTag = concurrencyTag;
                        this.Description = description;
                        this.DurationSeconds = durationSeconds;
                        this.EnvironmentId = environmentId;
                        this.ErrorMessage = errorMessage;
                        this.HasPendingInterruptions = hasPendingInterruptions;
                        this.HasWarningsOrErrors = hasWarningsOrErrors;
                        this.JSON = jSON;
                        this.Name = name;
                        this.ProjectId = projectId;
                        this.QueueTime = queueTime;
                        this.ServerNodeId = serverNodeId;
                        this.StartTime = startTime;
                        this.State = state;
                        this.TenantId = tenantId;
                }

                [Required]
                [JsonProperty]
                public DateTimeOffset? CompletedTime { get; private set; }

                [Required]
                [JsonProperty]
                public string ConcurrencyTag { get; private set; }

                [Required]
                [JsonProperty]
                public string Description { get; private set; }

                [Required]
                [JsonProperty]
                public int DurationSeconds { get; private set; }

                [Required]
                [JsonProperty]
                public string EnvironmentId { get; private set; }

                [Required]
                [JsonProperty]
                public string ErrorMessage { get; private set; }

                [Required]
                [JsonProperty]
                public bool HasPendingInterruptions { get; private set; }

                [Required]
                [JsonProperty]
                public bool HasWarningsOrErrors { get; private set; }

                [Required]
                [JsonProperty]
                public string Id { get; private set; }

                [Required]
                [JsonProperty]
                public string JSON { get; private set; }

                [Required]
                [JsonProperty]
                public string Name { get; private set; }

                [Required]
                [JsonProperty]
                public string ProjectId { get; private set; }

                [Required]
                [JsonProperty]
                public DateTimeOffset QueueTime { get; private set; }

                [Required]
                [JsonProperty]
                public string ServerNodeId { get; private set; }

                [Required]
                [JsonProperty]
                public DateTimeOffset? StartTime { get; private set; }

                [Required]
                [JsonProperty]
                public string State { get; private set; }

                [Required]
                [JsonProperty]
                public string TenantId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>e11b35e5bc135e2e080cdb18f35ab321</Hash>
</Codenesium>*/