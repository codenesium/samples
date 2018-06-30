using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiMachinePolicyModelMapper
        {
                ApiMachinePolicyResponseModel MapRequestToResponse(
                        string id,
                        ApiMachinePolicyRequestModel request);

                ApiMachinePolicyRequestModel MapResponseToRequest(
                        ApiMachinePolicyResponseModel response);
        }
}

/*<Codenesium>
    <Hash>9732fbe6eac2d3918c48d7482fc872b4</Hash>
</Codenesium>*/