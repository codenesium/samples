using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Contracts
{
        public abstract class AbstractApiMachineRefTeamModelMapper
        {
                public virtual ApiMachineRefTeamResponseModel MapRequestToResponse(
                        int id,
                        ApiMachineRefTeamRequestModel request)
                {
                        var response = new ApiMachineRefTeamResponseModel();
                        response.SetProperties(id,
                                               request.MachineId,
                                               request.TeamId);
                        return response;
                }

                public virtual ApiMachineRefTeamRequestModel MapResponseToRequest(
                        ApiMachineRefTeamResponseModel response)
                {
                        var request = new ApiMachineRefTeamRequestModel();
                        request.SetProperties(
                                response.MachineId,
                                response.TeamId);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>35d2a7c787a463a861087208c97210ef</Hash>
</Codenesium>*/