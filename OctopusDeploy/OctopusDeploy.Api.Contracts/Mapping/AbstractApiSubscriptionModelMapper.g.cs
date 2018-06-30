using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiSubscriptionModelMapper
        {
                public virtual ApiSubscriptionResponseModel MapRequestToResponse(
                        string id,
                        ApiSubscriptionRequestModel request)
                {
                        var response = new ApiSubscriptionResponseModel();
                        response.SetProperties(id,
                                               request.IsDisabled,
                                               request.JSON,
                                               request.Name,
                                               request.Type);
                        return response;
                }

                public virtual ApiSubscriptionRequestModel MapResponseToRequest(
                        ApiSubscriptionResponseModel response)
                {
                        var request = new ApiSubscriptionRequestModel();
                        request.SetProperties(
                                response.IsDisabled,
                                response.JSON,
                                response.Name,
                                response.Type);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>8a4246bbe05fe9b2dcd6ec97865c4038</Hash>
</Codenesium>*/