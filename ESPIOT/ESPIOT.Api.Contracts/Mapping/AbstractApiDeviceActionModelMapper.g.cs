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
    <Hash>3c241a8c553e6a9ebd76d40bfcb740c0</Hash>
</Codenesium>*/