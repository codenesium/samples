using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Contracts
{
        public interface IApiTeamModelMapper
        {
                ApiTeamResponseModel MapRequestToResponse(
                        int id,
                        ApiTeamRequestModel request);

                ApiTeamRequestModel MapResponseToRequest(
                        ApiTeamResponseModel response);
        }
}

/*<Codenesium>
    <Hash>56cd4afdefa7ad2b8d2cfb91d9aad445</Hash>
</Codenesium>*/