using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiTeamModelMapper
        {
                ApiTeamResponseModel MapRequestToResponse(
                        string id,
                        ApiTeamRequestModel request);

                ApiTeamRequestModel MapResponseToRequest(
                        ApiTeamResponseModel response);

                JsonPatchDocument<ApiTeamRequestModel> CreatePatch(ApiTeamRequestModel model);
        }
}

/*<Codenesium>
    <Hash>5b1ba1524e3ecfb3fce3f288d7ad627a</Hash>
</Codenesium>*/