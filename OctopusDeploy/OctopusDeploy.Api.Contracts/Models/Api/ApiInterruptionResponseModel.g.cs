using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiInterruptionResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string id,
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
                        this.Id = id;
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

                public DateTimeOffset Created { get; private set; }

                public string EnvironmentId { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string ProjectId { get; private set; }

                public string RelatedDocumentIds { get; private set; }

                public string ResponsibleTeamIds { get; private set; }

                public string Status { get; private set; }

                public string TaskId { get; private set; }

                public string TenantId { get; private set; }

                public string Title { get; private set; }
        }
}

/*<Codenesium>
    <Hash>25af387f98e973c0c6d895a129b3b6ec</Hash>
</Codenesium>*/