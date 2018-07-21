using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiMachinePolicyModelMapper
        {
                ApiMachinePolicyResponseModel MapRequestToResponse(
                        string id,
                        ApiMachinePolicyRequestModel request);

                ApiMachinePolicyRequestModel MapResponseToRequest(
                        ApiMachinePolicyResponseModel response);

                JsonPatchDocument<ApiMachinePolicyRequestModel> CreatePatch(ApiMachinePolicyRequestModel model);
        }
}

/*<Codenesium>
    <Hash>e2be0abc92f6909ff428178f3e19035f</Hash>
</Codenesium>*/