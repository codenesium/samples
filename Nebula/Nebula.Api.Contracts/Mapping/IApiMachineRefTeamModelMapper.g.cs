using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Contracts
{
        public interface IApiMachineRefTeamModelMapper
        {
                ApiMachineRefTeamResponseModel MapRequestToResponse(
                        int id,
                        ApiMachineRefTeamRequestModel request);

                ApiMachineRefTeamRequestModel MapResponseToRequest(
                        ApiMachineRefTeamResponseModel response);
        }
}

/*<Codenesium>
    <Hash>786ebebbe720870e4bbe5dde7b580c27</Hash>
</Codenesium>*/