using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiServerTaskModelMapper
        {
                ApiServerTaskResponseModel MapRequestToResponse(
                        string id,
                        ApiServerTaskRequestModel request);

                ApiServerTaskRequestModel MapResponseToRequest(
                        ApiServerTaskResponseModel response);
        }
}

/*<Codenesium>
    <Hash>1e0e2705d3b7835cea17f5608c8f36b5</Hash>
</Codenesium>*/