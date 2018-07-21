using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiMutexModelMapper
        {
                ApiMutexResponseModel MapRequestToResponse(
                        string id,
                        ApiMutexRequestModel request);

                ApiMutexRequestModel MapResponseToRequest(
                        ApiMutexResponseModel response);

                JsonPatchDocument<ApiMutexRequestModel> CreatePatch(ApiMutexRequestModel model);
        }
}

/*<Codenesium>
    <Hash>a7a1b7773a800962e367288e58ef7380</Hash>
</Codenesium>*/