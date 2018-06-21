using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractBOArtifact : AbstractBusinessObject
        {
                public AbstractBOArtifact()
                        : base()
                {
                }

                public virtual void SetProperties(string id,
                                                  DateTimeOffset created,
                                                  string environmentId,
                                                  string filename,
                                                  string jSON,
                                                  string projectId,
                                                  string relatedDocumentIds,
                                                  string tenantId)
                {
                        this.Created = created;
                        this.EnvironmentId = environmentId;
                        this.Filename = filename;
                        this.Id = id;
                        this.JSON = jSON;
                        this.ProjectId = projectId;
                        this.RelatedDocumentIds = relatedDocumentIds;
                        this.TenantId = tenantId;
                }

                public DateTimeOffset Created { get; private set; }

                public string EnvironmentId { get; private set; }

                public string Filename { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string ProjectId { get; private set; }

                public string RelatedDocumentIds { get; private set; }

                public string TenantId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>2617b6403a2477b2467620fb0ed836f4</Hash>
</Codenesium>*/