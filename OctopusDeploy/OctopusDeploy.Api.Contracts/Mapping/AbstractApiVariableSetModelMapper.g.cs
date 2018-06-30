using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiVariableSetModelMapper
        {
                public virtual ApiVariableSetResponseModel MapRequestToResponse(
                        string id,
                        ApiVariableSetRequestModel request)
                {
                        var response = new ApiVariableSetResponseModel();
                        response.SetProperties(id,
                                               request.IsFrozen,
                                               request.JSON,
                                               request.OwnerId,
                                               request.RelatedDocumentIds,
                                               request.Version);
                        return response;
                }

                public virtual ApiVariableSetRequestModel MapResponseToRequest(
                        ApiVariableSetResponseModel response)
                {
                        var request = new ApiVariableSetRequestModel();
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
    <Hash>6b59184d56aca606e47e07261a22b2e2</Hash>
</Codenesium>*/