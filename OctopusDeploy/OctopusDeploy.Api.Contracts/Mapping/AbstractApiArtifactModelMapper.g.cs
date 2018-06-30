using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiArtifactModelMapper
        {
                public virtual ApiArtifactResponseModel MapRequestToResponse(
                        string id,
                        ApiArtifactRequestModel request)
                {
                        var response = new ApiArtifactResponseModel();
                        response.SetProperties(id,
                                               request.Created,
                                               request.EnvironmentId,
                                               request.Filename,
                                               request.JSON,
                                               request.ProjectId,
                                               request.RelatedDocumentIds,
                                               request.TenantId);
                        return response;
                }

                public virtual ApiArtifactRequestModel MapResponseToRequest(
                        ApiArtifactResponseModel response)
                {
                        var request = new ApiArtifactRequestModel();
                        request.SetProperties(
                                response.Created,
                                response.EnvironmentId,
                                response.Filename,
                                response.JSON,
                                response.ProjectId,
                                response.RelatedDocumentIds,
                                response.TenantId);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>81b21c39e7892ddd3f253ac0b806fc2e</Hash>
</Codenesium>*/