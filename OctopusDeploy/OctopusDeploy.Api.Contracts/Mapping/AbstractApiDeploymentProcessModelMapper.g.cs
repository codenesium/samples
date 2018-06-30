using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiDeploymentProcessModelMapper
        {
                public virtual ApiDeploymentProcessResponseModel MapRequestToResponse(
                        string id,
                        ApiDeploymentProcessRequestModel request)
                {
                        var response = new ApiDeploymentProcessResponseModel();
                        response.SetProperties(id,
                                               request.IsFrozen,
                                               request.JSON,
                                               request.OwnerId,
                                               request.RelatedDocumentIds,
                                               request.Version);
                        return response;
                }

                public virtual ApiDeploymentProcessRequestModel MapResponseToRequest(
                        ApiDeploymentProcessResponseModel response)
                {
                        var request = new ApiDeploymentProcessRequestModel();
                        request.SetProperties(
                                response.IsFrozen,
                                response.JSON,
                                response.OwnerId,
                                response.RelatedDocumentIds,
                                response.Version);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>ee80fda2b848581b85bdef95a077fc9a</Hash>
</Codenesium>*/