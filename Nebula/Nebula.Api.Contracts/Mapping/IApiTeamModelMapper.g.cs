using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
        public interface IApiTeamModelMapper
        {
                ApiTeamResponseModel MapRequestToResponse(
                        int id,
                        ApiTeamRequestModel request);

                ApiTeamRequestModel MapResponseToRequest(
                        ApiTeamResponseModel response);

                JsonPatchDocument<ApiTeamRequestModel> CreatePatch(ApiTeamRequestModel model);
        }
}

/*<Codenesium>
    <Hash>f59bb9c7cc9d12d4a0fca0d595abc6b8</Hash>
</Codenesium>*/