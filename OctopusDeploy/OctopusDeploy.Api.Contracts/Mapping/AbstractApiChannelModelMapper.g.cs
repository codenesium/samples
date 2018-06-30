using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiChannelModelMapper
        {
                public virtual ApiChannelResponseModel MapRequestToResponse(
                        string id,
                        ApiChannelRequestModel request)
                {
                        var response = new ApiChannelResponseModel();
                        response.SetProperties(id,
                                               request.DataVersion,
                                               request.JSON,
                                               request.LifecycleId,
                                               request.Name,
                                               request.ProjectId,
                                               request.TenantTags);
                        return response;
                }

                public virtual ApiChannelRequestModel MapResponseToRequest(
                        ApiChannelResponseModel response)
                {
                        var request = new ApiChannelRequestModel();
                        request.SetProperties(
                                response.DataVersion,
                                response.JSON,
                                response.LifecycleId,
                                response.Name,
                                response.ProjectId,
                                response.TenantTags);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>737cd5bb3479cc4b4c45ad3520af0776</Hash>
</Codenesium>*/