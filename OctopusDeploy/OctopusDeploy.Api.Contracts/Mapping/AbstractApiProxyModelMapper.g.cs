using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiProxyModelMapper
        {
                public virtual ApiProxyResponseModel MapRequestToResponse(
                        string id,
                        ApiProxyRequestModel request)
                {
                        var response = new ApiProxyResponseModel();
                        response.SetProperties(id,
                                               request.JSON,
                                               request.Name);
                        return response;
                }

                public virtual ApiProxyRequestModel MapResponseToRequest(
                        ApiProxyResponseModel response)
                {
                        var request = new ApiProxyRequestModel();
                        request.SetProperties(
                                response.JSON,
                                response.Name);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>de2c2d1c08259271317d6f7e1a3d5f48</Hash>
</Codenesium>*/