using System;
using System.Collections.Generic;

namespace ESPIOTNS.Api.Contracts
{
        public abstract class AbstractApiDeviceModelMapper
        {
                public virtual ApiDeviceResponseModel MapRequestToResponse(
                        int id,
                        ApiDeviceRequestModel request)
                {
                        var response = new ApiDeviceResponseModel();
                        response.SetProperties(id,
                                               request.Name,
                                               request.PublicId);
                        return response;
                }

                public virtual ApiDeviceRequestModel MapResponseToRequest(
                        ApiDeviceResponseModel response)
                {
                        var request = new ApiDeviceRequestModel();
                        request.SetProperties(
                                response.Name,
                                response.PublicId);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>7a49f94907c6a66d0ac3474acd39ffb7</Hash>
</Codenesium>*/