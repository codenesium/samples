using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiProxyModelMapper
        {
                ApiProxyResponseModel MapRequestToResponse(
                        string id,
                        ApiProxyRequestModel request);

                ApiProxyRequestModel MapResponseToRequest(
                        ApiProxyResponseModel response);
        }
}

/*<Codenesium>
    <Hash>d5961e258d18c8b4e183c3a7992661ac</Hash>
</Codenesium>*/