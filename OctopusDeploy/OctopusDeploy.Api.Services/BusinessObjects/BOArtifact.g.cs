using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public partial class BOArtifact: AbstractBusinessObject
        {
                public BOArtifact() : base()
                {
                }

                public void SetProperties(string id,
                                          DateTime created,
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

                public DateTime Created { get; private set; }

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
    <Hash>3aa4773bd43c08764918581b4a870fe1</Hash>
</Codenesium>*/