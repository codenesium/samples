using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiInterruptionRequestModel : AbstractApiRequestModel
        {
                public ApiInterruptionRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        DateTimeOffset created,
                        string environmentId,
                        string jSON,
                        string projectId,
                        string relatedDocumentIds,
                        string responsibleTeamIds,
                        string status,
                        string taskId,
                        string tenantId,
                        string title)
                {
                        this.Created = created;
                        this.EnvironmentId = environmentId;
                        this.JSON = jSON;
                        this.ProjectId = projectId;
                        this.RelatedDocumentIds = relatedDocumentIds;
                        this.ResponsibleTeamIds = responsibleTeamIds;
                        this.Status = status;
                        this.TaskId = taskId;
                        this.TenantId = tenantId;
                        this.Title = title;
                }

                [JsonProperty]
                public DateTimeOffset Created { get; private set; }

                [JsonProperty]
                public string EnvironmentId { get; private set; }

                [JsonProperty]
                public string JSON { get; private set; }

                [JsonProperty]
                public string ProjectId { get; private set; }

                [JsonProperty]
                public string RelatedDocumentIds { get; private set; }

                [JsonProperty]
                public string ResponsibleTeamIds { get; private set; }

                [JsonProperty]
                public string Status { get; private set; }

                [JsonProperty]
                public string TaskId { get; private set; }

                [JsonProperty]
                public string TenantId { get; private set; }

                [JsonProperty]
                public string Title { get; private set; }
        }
}

/*<Codenesium>
    <Hash>513b289e718d020a2aef8cbd6eedc04f</Hash>
</Codenesium>*/