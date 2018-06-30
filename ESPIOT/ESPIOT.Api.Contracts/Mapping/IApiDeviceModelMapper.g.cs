using System;
using System.Collections.Generic;

namespace ESPIOTNS.Api.Contracts
{
        public interface IApiDeviceModelMapper
        {
                ApiDeviceResponseModel MapRequestToResponse(
                        int id,
                        ApiDeviceRequestModel request);

                ApiDeviceRequestModel MapResponseToRequest(
                        ApiDeviceResponseModel response);
        }
}

/*<Codenesium>
    <Hash>ad7007275e23db39a03288800c209479</Hash>
</Codenesium>*/