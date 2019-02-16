using ESPIOTNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services
{
	public abstract class AbstractApiDeviceActionServerModelMapper
	{
		public virtual ApiDeviceActionServerResponseModel MapServerRequestToResponse(
			int id,
			ApiDeviceActionServerRequestModel request)
		{
			var response = new ApiDeviceActionServerResponseModel();
			response.SetProperties(id,
			                       request.Action,
			                       request.DeviceId,
			                       request.Name);
			return response;
		}

		public virtual ApiDeviceActionServerRequestModel MapServerResponseToRequest(
			ApiDeviceActionServerResponseModel response)
		{
			var request = new ApiDeviceActionServerRequestModel();
			request.SetProperties(
				response.Action,
				response.DeviceId,
				response.Name);
			return request;
		}

		public virtual ApiDeviceActionClientRequestModel MapServerResponseToClientRequest(
			ApiDeviceActionServerResponseModel response)
		{
			var request = new ApiDeviceActionClientRequestModel();
			request.SetProperties(
				response.Action,
				response.DeviceId,
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiDeviceActionServerRequestModel> CreatePatch(ApiDeviceActionServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiDeviceActionServerRequestModel>();
			patch.Replace(x => x.Action, model.Action);
			patch.Replace(x => x.DeviceId, model.DeviceId);
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>b7830fc53762d4572b2f55436a93f4f3</Hash>
</Codenesium>*/