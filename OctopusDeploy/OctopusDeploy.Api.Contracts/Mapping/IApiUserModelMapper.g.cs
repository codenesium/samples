using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiUserModelMapper
        {
                ApiUserResponseModel MapRequestToResponse(
                        string id,
                        ApiUserRequestModel request);

                ApiUserRequestModel MapResponseToRequest(
                        ApiUserResponseModel response);

                JsonPatchDocument<ApiUserRequestModel> CreatePatch(ApiUserRequestModel model);
        }
}

/*<Codenesium>
    <Hash>b10303d69e3584b67d0c0b6ecdded56e</Hash>
</Codenesium>*/