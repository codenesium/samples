using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiUserRoleModelMapper
        {
                ApiUserRoleResponseModel MapRequestToResponse(
                        string id,
                        ApiUserRoleRequestModel request);

                ApiUserRoleRequestModel MapResponseToRequest(
                        ApiUserRoleResponseModel response);

                JsonPatchDocument<ApiUserRoleRequestModel> CreatePatch(ApiUserRoleRequestModel model);
        }
}

/*<Codenesium>
    <Hash>0b0aa149550a2766efe92962a53f1389</Hash>
</Codenesium>*/