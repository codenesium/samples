using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Contracts
{
        public abstract class AbstractApiMachineModelMapper
        {
                public virtual ApiMachineResponseModel MapRequestToResponse(
                        int id,
                        ApiMachineRequestModel request)
                {
                        var response = new ApiMachineResponseModel();
                        response.SetProperties(id,
                                               request.Description,
                                               request.JwtKey,
                                               request.LastIpAddress,
                                               request.MachineGuid,
                                               request.Name);
                        return response;
                }

                public virtual ApiMachineRequestModel MapResponseToRequest(
                        ApiMachineResponseModel response)
                {
                        var request = new ApiMachineRequestModel();
                        request.SetProperties(
                                response.Description,
                                response.JwtKey,
                                response.LastIpAddress,
                                response.MachineGuid,
                                response.Name);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>629437f57472efa5488490d4cf99169f</Hash>
</Codenesium>*/