using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiServerTaskResponseModel: AbstractApiResponseModel
        {
                public virtual void SetProperties(
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

                [JsonIgnore]
                public bool ShouldSerializeCompletedTimeValue { get; set; } = true;

                public bool ShouldSerializeCompletedTime()
                {
                        return this.ShouldSerializeCompletedTimeValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeConcurrencyTagValue { get; set; } = true;

                public bool ShouldSerializeConcurrencyTag()
                {
                        return this.ShouldSerializeConcurrencyTagValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeDescriptionValue { get; set; } = true;

                public bool ShouldSerializeDescription()
                {
                        return this.ShouldSerializeDescriptionValue;
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
                public bool ShouldSerializeErrorMessageValue { get; set; } = true;

                public bool ShouldSerializeErrorMessage()
                {
                        return this.ShouldSerializeErrorMessageValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeHasPendingInterruptionsValue { get; set; } = true;

                public bool ShouldSerializeHasPendingInterruptions()
                {
                        return this.ShouldSerializeHasPendingInterruptionsValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeHasWarningsOrErrorsValue { get; set; } = true;

                public bool ShouldSerializeHasWarningsOrErrors()
                {
                        return this.ShouldSerializeHasWarningsOrErrorsValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeJSONValue { get; set; } = true;

                public bool ShouldSerializeJSON()
                {
                        return this.ShouldSerializeJSONValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeNameValue { get; set; } = true;

                public bool ShouldSerializeName()
                {
                        return this.ShouldSerializeNameValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeProjectIdValue { get; set; } = true;

                public bool ShouldSerializeProjectId()
                {
                        return this.ShouldSerializeProjectIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeQueueTimeValue { get; set; } = true;

                public bool ShouldSerializeQueueTime()
                {
                        return this.ShouldSerializeQueueTimeValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeServerNodeIdValue { get; set; } = true;

                public bool ShouldSerializeServerNodeId()
                {
                        return this.ShouldSerializeServerNodeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeStartTimeValue { get; set; } = true;

                public bool ShouldSerializeStartTime()
                {
                        return this.ShouldSerializeStartTimeValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeStateValue { get; set; } = true;

                public bool ShouldSerializeState()
                {
                        return this.ShouldSerializeStateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeTenantIdValue { get; set; } = true;

                public bool ShouldSerializeTenantId()
                {
                        return this.ShouldSerializeTenantIdValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeCompletedTimeValue = false;
                        this.ShouldSerializeConcurrencyTagValue = false;
                        this.ShouldSerializeDescriptionValue = false;
                        this.ShouldSerializeDurationSecondsValue = false;
                        this.ShouldSerializeEnvironmentIdValue = false;
                        this.ShouldSerializeErrorMessageValue = false;
                        this.ShouldSerializeHasPendingInterruptionsValue = false;
                        this.ShouldSerializeHasWarningsOrErrorsValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeJSONValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializeProjectIdValue = false;
                        this.ShouldSerializeQueueTimeValue = false;
                        this.ShouldSerializeServerNodeIdValue = false;
                        this.ShouldSerializeStartTimeValue = false;
                        this.ShouldSerializeStateValue = false;
                        this.ShouldSerializeTenantIdValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>84dfca76a1b41279cc2953653230d12c</Hash>
</Codenesium>*/