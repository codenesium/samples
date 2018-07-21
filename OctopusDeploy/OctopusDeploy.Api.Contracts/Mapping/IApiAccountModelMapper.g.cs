using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiAccountModelMapper
        {
                ApiAccountResponseModel MapRequestToResponse(
                        string id,
                        ApiAccountRequestModel request);

                ApiAccountRequestModel MapResponseToRequest(
                        ApiAccountResponseModel response);

                JsonPatchDocument<ApiAccountRequestModel> CreatePatch(ApiAccountRequestModel model);
        }
}

/*<Codenesium>
    <Hash>a8a4f6a457d1ef8b9dd6d010807c3d80</Hash>
</Codenesium>*/