using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiDeploymentModelMapper
        {
                ApiDeploymentResponseModel MapRequestToResponse(
                        string id,
                        ApiDeploymentRequestModel request);

                ApiDeploymentRequestModel MapResponseToRequest(
                        ApiDeploymentResponseModel response);
        }
}

/*<Codenesium>
    <Hash>34a37b5d0788dc62de147f6a278e86b0</Hash>
</Codenesium>*/