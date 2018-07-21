using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

                public JsonPatchDocument<ApiDeviceActionRequestModel> CreatePatch(ApiDeviceActionRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiDeviceActionRequestModel>();
                        patch.Replace(x => x.DeviceId, model.DeviceId);
                        patch.Replace(x => x.Name, model.Name);
                        patch.Replace(x => x.@Value, model.@Value);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>9c9b05452fd8126f883da91814110936</Hash>
</Codenesium>*/