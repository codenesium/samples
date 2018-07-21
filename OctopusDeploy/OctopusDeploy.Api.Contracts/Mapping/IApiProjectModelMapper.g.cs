using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiProjectModelMapper
        {
                ApiProjectResponseModel MapRequestToResponse(
                        string id,
                        ApiProjectRequestModel request);

                ApiProjectRequestModel MapResponseToRequest(
                        ApiProjectResponseModel response);

                JsonPatchDocument<ApiProjectRequestModel> CreatePatch(ApiProjectRequestModel model);
        }
}

/*<Codenesium>
    <Hash>7bd881c1dc54f38e89025081646254d5</Hash>
</Codenesium>*/