using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiDeploymentProcessModelMapper
        {
                ApiDeploymentProcessResponseModel MapRequestToResponse(
                        string id,
                        ApiDeploymentProcessRequestModel request);

                ApiDeploymentProcessRequestModel MapResponseToRequest(
                        ApiDeploymentProcessResponseModel response);
        }
}

/*<Codenesium>
    <Hash>191758aef0f9fb486eef8010162170ee</Hash>
</Codenesium>*/