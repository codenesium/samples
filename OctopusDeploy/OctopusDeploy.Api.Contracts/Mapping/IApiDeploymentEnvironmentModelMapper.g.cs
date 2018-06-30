using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiDeploymentEnvironmentModelMapper
        {
                ApiDeploymentEnvironmentResponseModel MapRequestToResponse(
                        string id,
                        ApiDeploymentEnvironmentRequestModel request);

                ApiDeploymentEnvironmentRequestModel MapResponseToRequest(
                        ApiDeploymentEnvironmentResponseModel response);
        }
}

/*<Codenesium>
    <Hash>639696923af0135818b3238405a2700f</Hash>
</Codenesium>*/