using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiMachinePolicyModelMapper
        {
                public virtual ApiMachinePolicyResponseModel MapRequestToResponse(
                        string id,
                        ApiMachinePolicyRequestModel request)
                {
                        var response = new ApiMachinePolicyResponseModel();
                        response.SetProperties(id,
                                               request.IsDefault,
                                               request.JSON,
                                               request.Name);
                        return response;
                }

                public virtual ApiMachinePolicyRequestModel MapResponseToRequest(
                        ApiMachinePolicyResponseModel response)
                {
                        var request = new ApiMachinePolicyRequestModel();
                        request.SetProperties(
                                response.IsDefault,
                                response.JSON,
                                response.Name);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>a0e472c3da5fd3d85f9595caf6cf8821</Hash>
</Codenesium>*/