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
    <Hash>84839689f0c015ab637011e8b90f6e9d</Hash>
</Codenesium>*/