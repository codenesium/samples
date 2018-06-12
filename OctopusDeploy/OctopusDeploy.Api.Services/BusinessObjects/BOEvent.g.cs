using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public partial class BOEvent: AbstractBusinessObject
        {
                public BOEvent() : base()
                {
                }

                public void SetProperties(string id,
                                          long autoId,
                                          string category,
                                          string environmentId,
                                          string jSON,
                                          string message,
                                          DateTime occurred,
                                          string projectId,
                                          string relatedDocumentIds,
                                          string tenantId,
                                          string userId,
                                          string username)
                {
                        this.AutoId = autoId;
                        this.Category = category;
                        this.EnvironmentId = environmentId;
                        this.Id = id;
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

                public DateTime Occurred { get; private set; }

                public string ProjectId { get; private set; }

                public string RelatedDocumentIds { get; private set; }

                public string TenantId { get; private set; }

                public string UserId { get; private set; }

                public string Username { get; private set; }
        }
}

/*<Codenesium>
    <Hash>742d59ad784f471caab17dc4fcd8a249</Hash>
</Codenesium>*/