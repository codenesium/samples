using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
        public interface IApiMachineRefTeamModelMapper
        {
                ApiMachineRefTeamResponseModel MapRequestToResponse(
                        int id,
                        ApiMachineRefTeamRequestModel request);

                ApiMachineRefTeamRequestModel MapResponseToRequest(
                        ApiMachineRefTeamResponseModel response);

                JsonPatchDocument<ApiMachineRefTeamRequestModel> CreatePatch(ApiMachineRefTeamRequestModel model);
        }
}

/*<Codenesium>
    <Hash>db9d267c8b07eda51478e44530434ba4</Hash>
</Codenesium>*/