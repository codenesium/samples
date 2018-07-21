using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Contracts
{
        public interface IApiDeviceModelMapper
        {
                ApiDeviceResponseModel MapRequestToResponse(
                        int id,
                        ApiDeviceRequestModel request);

                ApiDeviceRequestModel MapResponseToRequest(
                        ApiDeviceResponseModel response);

                JsonPatchDocument<ApiDeviceRequestModel> CreatePatch(ApiDeviceRequestModel model);
        }
}

/*<Codenesium>
    <Hash>357e1cbb58664ef6668dbb74b63e589e</Hash>
</Codenesium>*/