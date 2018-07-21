using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiLifecycleModelMapper
        {
                ApiLifecycleResponseModel MapRequestToResponse(
                        string id,
                        ApiLifecycleRequestModel request);

                ApiLifecycleRequestModel MapResponseToRequest(
                        ApiLifecycleResponseModel response);

                JsonPatchDocument<ApiLifecycleRequestModel> CreatePatch(ApiLifecycleRequestModel model);
        }
}

/*<Codenesium>
    <Hash>f984ea7e006b95ca0daa8fc2e1d51c0c</Hash>
</Codenesium>*/