using System;
using System.Collections.Generic;

namespace ESPIOTNS.Api.Contracts
{
        public abstract class AbstractApiDeviceActionModelMapper
        {
                public virtual ApiDeviceActionResponseModel MapRequestToResponse(
                        int id,
                        ApiDeviceActionRequestModel request)
                {
                        var response = new ApiDeviceActionResponseModel();
                        response.SetProperties(id,
                                               request.DeviceId,
                                               request.Name,
                                               request.@Value);
                        return response;
                }

                public virtual ApiDeviceActionRequestModel MapResponseToRequest(
                        ApiDeviceActionResponseModel response)
                {
                        var request = new ApiDeviceActionRequestModel();
                        request.SetProperties(
                                response.DeviceId,
                                response.Name,
                                response.@Value);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>f01bfd263188b34bcbbe62d7227a41df</Hash>
</Codenesium>*/