using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractBOServerTask : AbstractBusinessObject
        {
                public AbstractBOServerTask()
                        : base()
                {
                }

                public virtual void SetProperties(string id,
                                                  Nullable<DateTimeOffset> completedTime,
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

                public Nullable<DateTimeOffset> CompletedTime { get; private set; }

                public string ConcurrencyTag { get; private set; }

                public string Description { get; private set; }

                public int DurationSeconds { get; private set; }

                public string EnvironmentId { get; private set; }

                public string ErrorMessage { get; private set; }

                public bool HasPendingInterruptions { get; private set; }

                public bool HasWarningsOrErrors { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string Name { get; private set; }

                public string ProjectId { get; private set; }

                public DateTimeOffset QueueTime { get; private set; }

                public string ServerNodeId { get; private set; }

                public Nullable<DateTimeOffset> StartTime { get; private set; }

                public string State { get; private set; }

                public string TenantId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>febe26c64889db46406b85ab6f740fb0</Hash>
</Codenesium>*/