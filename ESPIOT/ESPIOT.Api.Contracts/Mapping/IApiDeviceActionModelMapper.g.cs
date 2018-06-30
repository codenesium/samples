using System;
using System.Collections.Generic;

namespace ESPIOTNS.Api.Contracts
{
        public interface IApiDeviceActionModelMapper
        {
                ApiDeviceActionResponseModel MapRequestToResponse(
                        int id,
                        ApiDeviceActionRequestModel request);

                ApiDeviceActionRequestModel MapResponseToRequest(
                        ApiDeviceActionResponseModel response);
        }
}

/*<Codenesium>
    <Hash>b411ea871d8159d9f4e3c01d9ffd012f</Hash>
</Codenesium>*/