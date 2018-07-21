using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Contracts
{
        public interface IApiDeviceActionModelMapper
        {
                ApiDeviceActionResponseModel MapRequestToResponse(
                        int id,
                        ApiDeviceActionRequestModel request);

                ApiDeviceActionRequestModel MapResponseToRequest(
                        ApiDeviceActionResponseModel response);

                JsonPatchDocument<ApiDeviceActionRequestModel> CreatePatch(ApiDeviceActionRequestModel model);
        }
}

/*<Codenesium>
    <Hash>5d8a46161b862591aaf16464c17464e5</Hash>
</Codenesium>*/