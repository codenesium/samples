using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiEventResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string id,
                        long autoId,
                        string category,
                        string environmentId,
                        string jSON,
                        string message,
                        DateTimeOffset occurred,
                        string projectId,
                        string relatedDocumentIds,
                        string tenantId,
                        string userId,
                        string username)
                {
                        this.Id = id;
                        this.AutoId = autoId;
                        this.Category = category;
                        this.EnvironmentId = environmentId;
                        this.JSON = jSON;
                        this.Message = message;
                        this.Occurred = occurred;
                        this.ProjectId = projectId;
                        this.RelatedDocumentIds = relatedDocumentIds;
                        this.TenantId = tenantId;
                        this.UserId = userId;
                        this.Username = username;
                }

                public long AutoId { get; private set; }

                public string Category { get; private set; }

                public string EnvironmentId { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string Message { get; private set; }

                public DateTimeOffset Occurred { get; private set; }

                public string ProjectId { get; private set; }

                public string RelatedDocumentIds { get; private set; }

                public string TenantId { get; private set; }

                public string UserId { get; private set; }

                public string Username { get; private set; }
        }
}

/*<Codenesium>
    <Hash>44c1009ca33de47326e6ac01d305aa4e</Hash>
</Codenesium>*/