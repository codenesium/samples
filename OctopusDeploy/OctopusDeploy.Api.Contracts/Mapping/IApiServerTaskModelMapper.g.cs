using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiServerTaskModelMapper
        {
                ApiServerTaskResponseModel MapRequestToResponse(
                        string id,
                        ApiServerTaskRequestModel request);

                ApiServerTaskRequestModel MapResponseToRequest(
                        ApiServerTaskResponseModel response);

                JsonPatchDocument<ApiServerTaskRequestModel> CreatePatch(ApiServerTaskRequestModel model);
        }
}

/*<Codenesium>
    <Hash>94dbac1dedf935b9cc4c7be6772d9930</Hash>
</Codenesium>*/