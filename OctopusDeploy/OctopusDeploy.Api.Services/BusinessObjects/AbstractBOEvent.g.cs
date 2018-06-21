using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractBOEvent : AbstractBusinessObject
        {
                public AbstractBOEvent()
                        : base()
                {
                }

                public virtual void SetProperties(string id,
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

                public DateTimeOffset Occurred { get; private set; }

                public string ProjectId { get; private set; }

                public string RelatedDocumentIds { get; private set; }

                public string TenantId { get; private set; }

                public string UserId { get; private set; }

                public string Username { get; private set; }
        }
}

/*<Codenesium>
    <Hash>ee5290557e9f12c4a779dbcd980b4bd3</Hash>
</Codenesium>*/