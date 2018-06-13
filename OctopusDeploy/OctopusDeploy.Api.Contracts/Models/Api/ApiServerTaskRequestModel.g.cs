using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiServerTaskRequestModel: AbstractApiRequestModel
        {
                public ApiServerTaskRequestModel() : base()
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
                        this.JSON = jSON;
                        this.Name = name;
                        this.ProjectId = projectId;
                        this.QueueTime = queueTime;
                        this.ServerNodeId = serverNodeId;
                        this.StartTime = startTime;
                        this.State = state;
                        this.TenantId = tenantId;
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

                private string concurrencyTag;

                public string ConcurrencyTag
                {
                        get
                        {
                                return this.concurrencyTag.IsEmptyOrZeroOrNull() ? null : this.concurrencyTag;
                        }

                        set
                        {
                                this.concurrencyTag = value;
                        }
                }

                private string description;

                [Required]
                public string Description
                {
                        get
                        {
                                return this.description;
                        }

                        set
                        {
                                this.description = value;
                        }
                }

                private int durationSeconds;

                [Required]
                public int DurationSeconds
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

                public string EnvironmentId
                {
                        get
                        {
                                return this.environmentId.IsEmptyOrZeroOrNull() ? null : this.environmentId;
                        }

                        set
                        {
                                this.environmentId = value;
                        }
                }

                private string errorMessage;

                public string ErrorMessage
                {
                        get
                        {
                                return this.errorMessage.IsEmptyOrZeroOrNull() ? null : this.errorMessage;
                        }

                        set
                        {
                                this.errorMessage = value;
                        }
                }

                private bool hasPendingInterruptions;

                [Required]
                public bool HasPendingInterruptions
                {
                        get
                        {
                                return this.hasPendingInterruptions;
                        }

                        set
                        {
                                this.hasPendingInterruptions = value;
                        }
                }

                private bool hasWarningsOrErrors;

                [Required]
                public bool HasWarningsOrErrors
                {
                        get
                        {
                                return this.hasWarningsOrErrors;
                        }

                        set
                        {
                                this.hasWarningsOrErrors = value;
                        }
                }

                private string jSON;

                [Required]
                public string JSON
                {
                        get
                        {
                                return this.jSON;
                        }

                        set
                        {
                                this.jSON = value;
                        }
                }

                private string name;

                [Required]
                public string Name
                {
                        get
                        {
                                return this.name;
                        }

                        set
                        {
                                this.name = value;
                        }
                }

                private string projectId;

                public string ProjectId
                {
                        get
                        {
                                return this.projectId.IsEmptyOrZeroOrNull() ? null : this.projectId;
                        }

                        set
                        {
                                this.projectId = value;
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

                private string serverNodeId;

                public string ServerNodeId
                {
                        get
                        {
                                return this.serverNodeId.IsEmptyOrZeroOrNull() ? null : this.serverNodeId;
                        }

                        set
                        {
                                this.serverNodeId = value;
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

                private string state;

                [Required]
                public string State
                {
                        get
                        {
                                return this.state;
                        }

                        set
                        {
                                this.state = value;
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
        }
}

/*<Codenesium>
    <Hash>bfdd5e586ac659cd73a259bd9f5910b6</Hash>
</Codenesium>*/