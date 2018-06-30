using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiDeploymentEnvironmentModelMapper
        {
                public virtual ApiDeploymentEnvironmentResponseModel MapRequestToResponse(
                        string id,
                        ApiDeploymentEnvironmentRequestModel request)
                {
                        var response = new ApiDeploymentEnvironmentResponseModel();
                        response.SetProperties(id,
                                               request.DataVersion,
                                               request.JSON,
                                               request.Name,
                                               request.SortOrder);
                        return response;
                }

                public virtual ApiDeploymentEnvironmentRequestModel MapResponseToRequest(
                        ApiDeploymentEnvironmentResponseModel response)
                {
                        var request = new ApiDeploymentEnvironmentRequestModel();
                        request.SetProperties(
                                response.DataVersion,
                                response.JSON,
                                response.Name,
                                response.SortOrder);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>9c4590e4388056961a1c11eb75d9578f</Hash>
</Codenesium>*/