using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiInterruptionModelMapper
        {
                ApiInterruptionResponseModel MapRequestToResponse(
                        string id,
                        ApiInterruptionRequestModel request);

                ApiInterruptionRequestModel MapResponseToRequest(
                        ApiInterruptionResponseModel response);

                JsonPatchDocument<ApiInterruptionRequestModel> CreatePatch(ApiInterruptionRequestModel model);
        }
}

/*<Codenesium>
    <Hash>790139f6aa29fae1a0725363d9d2d622</Hash>
</Codenesium>*/